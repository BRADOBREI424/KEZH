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

namespace KEZH.PageFolder.PageStudent
{
    /// <summary>
    /// Логика взаимодействия для PageStudent.xaml
    /// </summary>
    public partial class PageStudent : System.Windows.Controls.Page
    {
        SqlConnection sqlConnection =
      new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        ClassFolder.ClassDG classDG;
        ClassFolder.ClassDG classDG1;
        ClassFolder.ClassEdit classEdit;
        ClassFolder.ClassRead classRead;
        public PageStudent()
        {
            InitializeComponent();
            classDG = new ClassFolder.ClassDG(dgListStudent);
            classDG1 = new ClassFolder.ClassDG(dgFullListStudent);
            classEdit = new ClassFolder.ClassEdit();
            classRead = new ClassFolder.ClassRead();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {           
            classDG.LoadDB("Select * from dbo.ViewStudentDG " +
                $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and NameStatus='Активен'");
            classDG1.LoadDB("Select * from dbo.ViewStudent " +
             $"where (IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and NameStatus='Активен')");
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Select NameGroup from dbo.[Group] " +
                    $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}'", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                LblLoadNameGroup.Content = dataReader[0].ToString();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbSearch.Text))
            {
                classDG.LoadDB("Select * from dbo.ViewStudentDG " +
                $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and NameStatus='Активен'");
            }
            else
            {
                classDG.LoadDB("Select * from dbo.ViewStudentDG " +
                $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' " +
                "and NameStatus='Активен' and " +
                $"FIO like '%{TbSearch.Text}%'");
            }
        }

        private void dgListStudent_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //sqlConnection.Open();
            //FolderClass.FolderTable.ClassStudent.Idstudent = Int32.Parse(classDG.SelectId());
            //sqlCommand = new SqlCommand("Select IdMom, IdDad, IdPassport, IdAddress, IdGroup from dbo.Student " +
            //    $"where IdStudent=" +
            //    $"'{FolderClass.FolderTable.ClassStudent.Idstudent}'",
            //    sqlConnection);
            //dataReader = sqlCommand.ExecuteReader();
            //dataReader.Read();
            //try
            //{
            //    FolderClass.FolderTable.ClassParents.IdMom = Int32.Parse(dataReader[0].ToString());
            //    FolderClass.FolderTable.ClassParents.IdDad = Int32.Parse(dataReader[1].ToString());
            //    FolderClass.FolderTable.ClassPassport.IdPassport = Int32.Parse(dataReader[2].ToString());
            //    FolderClass.FolderTable.ClassAddress.IdAddress = Int32.Parse(dataReader[3].ToString());
            //    FolderClass.FolderTable.ClassGroup.IdGroup = Int32.Parse(dataReader[4].ToString());
            //}
            //catch (Exception ex)
            //{
            //    FolderClass.ClassMB.MBError(ex);
            //}

            //sqlConnection.Close();

            //sqlConnection.Open();
            //sqlCommand = new SqlCommand("Select IdRegistration from dbo.Passport " +
            //    $"where IdPassport='{FolderClass.FolderTable.ClassPassport.IdPassport}'", sqlConnection);
            //dataReader = sqlCommand.ExecuteReader();
            //dataReader.Read();
            //try
            //{
            //    FolderClass.FolderTable.ClassRegistrtion.IdReg = Int32.Parse(dataReader[0].ToString());
            //}
            //catch (Exception ex)
            //{
            //    FolderClass.ClassMB.MBError(ex);
            //}

            //sqlConnection.Close();

            //if (FolderClass.FolderTable.ClassStudent.Idstudent < 1)
            //{
            //    FolderClass.ClassMB.MBError("Выберите строку");
            //}
            //else
            //{
            //    NavigationService.Navigate(new Uri("/FolderView/ViewFullStudentInfo.xaml", UriKind.RelativeOrAbsolute));
            //}
            if (dgListStudent.SelectedItem == null)
            {
                ClassFolder.ClassMB.MBError("Выберете строчку");
            }
            else
            {
                ClassFolder.TableFolder.ClassStudent.IdStudent = Int32.Parse(classDG.SelectId());
                classRead.ReadIdImage(ClassFolder.TableFolder.ClassStudent.IdStudent);
                classDG.LoadDB("Select * from dbo.ViewStudentDG " +
                $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and NameStatus='Активен'");
                //ClassFolder.ClassMB.MBInformation($"{ ClassFolder.TableFolder.ClassStudent.IdStudent}");

                try
                {
                    NavigationService.Navigate(new Uri("/PageFolder/PageStudent/PageEditStudent.xaml", UriKind.RelativeOrAbsolute));

                }
                catch (Exception ex)
                {
                    ClassFolder.ClassMB.MBError(ex);
                }
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
        

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PageFolder/PageStudent/PageAddStudent.xaml", UriKind.RelativeOrAbsolute));
        }

        private void MenuItem_Click_Marks(object sender, RoutedEventArgs e)
        {
            
            try
            {                
                    ClassFolder.TableFolder.ClassStudent.IdStudent = Int32.Parse(classDG.SelectId());
                    NavigationService.Navigate(new Uri("/PageFolder/PageMarks/PageMarksLists.xaml", UriKind.RelativeOrAbsolute));
            }
            catch 
            {
                ClassFolder.ClassMB.MBError("Выберите студента");
            }
           
           
        }

        private void MenuItem_Click_Order(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassStudent.IdStudent = Int32.Parse(classDG.SelectId());
                WindowFolder.WinChooseOrder winChooseOrder =
               new WindowFolder.WinChooseOrder();
                winChooseOrder.ShowDialog();
                classDG.LoadDB("Select * from dbo.ViewStudentDG " +
                $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and NameStatus='Активен'");

            }
            catch
            {
                ClassFolder.ClassMB.MBError("Выберите студента");
            }
           
        }

        private void MenuItem_Click_Attendance(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassStudent.IdStudent = Int32.Parse(classDG.SelectId());
                NavigationService.Navigate(new Uri("/PageFolder/PageAttendance/PageListAttendance.xaml", UriKind.RelativeOrAbsolute));
                
            }
            catch
            {
                ClassFolder.ClassMB.MBError("Выберите студента");
            }
        }
    }
    }

  
