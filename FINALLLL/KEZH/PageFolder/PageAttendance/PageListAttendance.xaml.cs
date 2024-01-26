using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;

namespace KEZH.PageFolder.PageAttendance
{
    /// <summary>
    /// Логика взаимодействия для PageListAttendance.xaml
    /// </summary>
    public partial class PageListAttendance : Page
    {

        SqlConnection sqlConnection =
           new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        ClassFolder.ClassDG classDG;
        ClassFolder.ClassCB ClassCB;


        public PageListAttendance()
        {
            InitializeComponent();
            classDG = new ClassFolder.ClassDG(dgStudentToAttendance);
            ClassCB = new ClassFolder.ClassCB();
        }

        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

            for (int j = 0; j < dgStudentToAttendance.Columns.Count; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = dgStudentToAttendance.Columns[j].Header;
            }
            for (int i = 0; i < dgStudentToAttendance.Columns.Count; i++)
            {
                for (int j = 0; j < dgStudentToAttendance.Items.Count; j++)
                {
                    TextBlock b = dgStudentToAttendance.Columns[i].GetCellContent(dgStudentToAttendance.Items[j]) as TextBlock;
                    Excel.Range myRange = (Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }

            sheet1.Columns.AutoFit();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            if (ClassFolder.TableFolder.ClassStudent.IdStudent <= 0)
            {
               
                classDG.LoadDB("Select * from dbo.ViewAttendanceExport " +
                  $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' " +
                  $"and NameStatus = 'Активен'");
            }
            else
            {
                classDG.LoadDB("Select * from dbo.ViewAttendanceExport " +
                  $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and " +
                  $"IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}'");
            }
        }

        private void btnSaveAttendance_Click(object sender, RoutedEventArgs e)
        {
            if (DpDate1.SelectedDate.ToString() == "")
            {
                ClassFolder.ClassMB.MBError("Выберите период с");
            }
            else if (DpDate2.SelectedDate.ToString() == "")
            {
                ClassFolder.ClassMB.MBError("Выберите период по");
            }
            else
            {
                if (ClassFolder.TableFolder.ClassStudent.IdStudent <= 0)
                {

                    classDG.LoadDB("Select * from dbo.ViewAttendanceExport " +
                      $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' " +
                      $"and NameStatus = 'Активен' " +
                      $"and DateAttendance Between '{DpDate1}' and '{DpDate2}' " +
                      $"order by DateAttendance asc");
                }
                else
                {
                    classDG.LoadDB("Select * from dbo.ViewAttendanceExport " +
                      $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and " +
                      $"IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}' " +
                      $"and DateAttendance Between '{DpDate1}' and '{DpDate2}' " +
                      $"order by DateAttendance asc");
                }             
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (ClassFolder.TableFolder.ClassStudent.IdStudent <= 0)
            {

                classDG.LoadDB("Select * from dbo.ViewAttendanceExport " +
                  $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' " +
                  $"and NameStatus = 'Активен'");
            }
            else
            {
                classDG.LoadDB("Select * from dbo.ViewAttendanceExport " +
                  $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and " +
                  $"IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}'");
            }
            DpDate1.Text = "";
            DpDate2.Text = "";
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {           
            if (ClassFolder.TableFolder.ClassStudent.IdStudent <= 0)
            {

                classDG.LoadDB("Select * from dbo.ViewAttendanceExport " +
                  $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}'" +
                  $"and NameStatus = 'Активен' and FIO like '%{TbSearch.Text}%' " +
                  $"order by DateAttendance asc");
            }
            else
            {
                classDG.LoadDB("Select * from dbo.ViewAttendanceExport " +
                  $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and " +
                  $"IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}' and FIO like '%{TbSearch.Text}%' " +
                  $"order by DateAttendance asc");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
