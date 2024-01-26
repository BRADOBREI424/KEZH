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
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace KEZH.PageFolder.PageSocialPedagog.PageListStudent
{
    /// <summary>
    /// Логика взаимодействия для PageStidentList.xaml
    /// </summary>
    public partial class PageStidentList : System.Windows.Controls.Page
    {

        SqlConnection sqlConnection =
      new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        ClassFolder.ClassDG classDG;
        ClassFolder.ClassDG classDGExport;
        ClassFolder.ClassCB classCB;



        public PageStidentList()
        {
            InitializeComponent();
            classDG = new ClassFolder.ClassDG(dgListStudentTeacher);
            classDGExport = new ClassFolder.ClassDG(dgFullListStudent);
            classCB = new ClassFolder.ClassCB();
        }

        private void ListAttendance_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                ClassFolder.TableFolder.ClassStudent.IdStudent = Int32.Parse(classDG.SelectId());                
                NavigationService.Navigate(new Uri("/PageFolder/PageSocialPedagog/PageAttendance/PageAttendanceList.xaml", UriKind.RelativeOrAbsolute));
            }
            catch 
            {
                ClassFolder.ClassMB.MBError("Выберете строчку");
            }
                 
        }

        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

            for (int j = 0; j < dgFullListStudent.Columns.Count; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = dgFullListStudent.Columns[j].Header;
            }
            for (int i = 0; i < dgFullListStudent.Columns.Count; i++)
            {
                for (int j = 0; j < dgFullListStudent.Items.Count; j++)
                {
                    TextBlock b = dgFullListStudent.Columns[i].GetCellContent(dgFullListStudent.Items[j]) as TextBlock;
                    Excel.Range myRange = (Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }

            sheet1.Columns.AutoFit();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            classDGExport.LoadDB("Select * from dbo.ViewStudent " +
             $"where NameStatus='Активен'");
            classDG.LoadDB("Select * from ViewStudentTeacher " +
                "where NameStatus='Активен'");
            classCB.LoadGroup(CbGroup);
            classCB.LoadFamily(CbFamily);
            classCB.LoadFamilyStatus(CbFamilyStatus);
            
        }
        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            
                classDG.LoadDB("Select * from dbo.ViewStudentTeacher " +
                $"where NameStatus='Активен' and " +
                $"FIO like '%{TbSearch.Text}%'");
            
        }

        private void ClearComboBox()
        {
            if (CbFamilyStatus.SelectedIndex != -1)
            {
                if (CbFamilyStatus.SelectedIndex == -1)
                { }
                else
                {
                    classDG.LoadDB($"Select * from ViewStudentTeacher " +
                       $"where NameStatus='Активен' and IdFamilyStatus='{CbFamilyStatus.SelectedValue.ToString()}'");                   
                }
                if (CbGroup.SelectedIndex != -1 || CbFamily.SelectedIndex != -1)
                {
                    CbFamily.SelectedIndex = -1;
                    CbGroup.SelectedIndex = -1;
                }
                else
                { }

            }
            else if (CbFamily.SelectedIndex != -1)
            {
                if (CbFamily.SelectedIndex == -1)
                { }
                else
                {
                    classDG.LoadDB($"Select * from ViewStudentTeacher " +
                       $"where NameStatus='Активен' and IdFamily='{CbFamily.SelectedValue.ToString()}'");        
                }
                if (CbGroup.SelectedIndex != -1 || CbFamilyStatus.SelectedIndex != -1)
                {
                    CbFamilyStatus.SelectedIndex = -1;
                    CbGroup.SelectedIndex = -1;
                }
                else
                { }

            }
            else if (CbGroup.SelectedIndex != -1)
            {
                if (CbGroup.SelectedIndex == -1)
                { }
                else
                {
                    classDG.LoadDB($"Select * from ViewStudentTeacher " +
                       $"where NameStatus='Активен' and IdGroup='{CbGroup.SelectedValue.ToString()}'");
                    
                }
                if (CbFamily.SelectedIndex != -1 || CbFamilyStatus.SelectedIndex != -1)
                {
                    CbFamily.SelectedIndex = -1;
                    CbFamilyStatus.SelectedIndex = -1;
                }
                else
                { }

                
               
            }
        }

        private void Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            // ClearComboBox();
            
        }

        private void CbFamilyStatus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CbFamily.SelectedIndex = -1;
            CbFamilyStatus.SelectedIndex = -1;
        }

        private void CbFamilyStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbFamilyStatus.SelectedIndex == -1)
            { }
            else
            {
                CbFamily.SelectedIndex = -1;
                CbGroup.SelectedIndex = -1;
                //CbFamilyStatus.SelectedIndex = -1;
                classDG.LoadDB($"Select * from ViewStudentTeacher " +
                   $"where NameStatus='Активен' and IdFamilyStatus='{CbFamilyStatus.SelectedValue.ToString()}'");
            }
        }

        private void CbFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbFamily.SelectedIndex == -1)
            { }
            else
            {
                //CbFamily.SelectedIndex = -1;
                CbGroup.SelectedIndex = -1;
                CbFamilyStatus.SelectedIndex = -1;
                classDG.LoadDB($"Select * from ViewStudentTeacher " +
                       $"where NameStatus='Активен' and IdFamily='{CbFamily.SelectedValue.ToString()}'");
            }
        }

        private void CbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbGroup.SelectedIndex == -1)
            { }
            else
            {
                CbFamily.SelectedIndex = -1;
               // CbGroup.SelectedIndex = -1;
                CbFamilyStatus.SelectedIndex = -1;
                classDG.LoadDB($"Select * from ViewStudentTeacher " +
                   $"where NameStatus='Активен' and IdGroup='{CbGroup.SelectedValue.ToString()}'");

            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
           
                classDG.LoadDB("Select * from ViewStudentTeacher " +
                "where NameStatus='Активен'");
           
            CbFamily.Text = "";
            CbFamilyStatus.Text = "";
            CbGroup.Text = "";
        }
    }
}
