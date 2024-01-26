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

namespace KEZH.PageFolder.PageTimeTable
{
    /// <summary>
    /// Логика взаимодействия для PageEdit.xaml
    /// </summary>
    public partial class PageEdit : Page
    {
        SqlConnection sqlConnection =
          new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        ClassFolder.ClassCB classCB;
        ClassFolder.ClassEdit classEdit;
        ClassFolder.ClassRead classRead;
        

        public PageEdit()
        {
            InitializeComponent();
            classCB = new ClassFolder.ClassCB();
            classEdit = new ClassFolder.ClassEdit();
            classRead = new ClassFolder.ClassRead();


            //if (ClassFolder.TableFolder.ClassCounter.PastCounter != ClassFolder.TableFolder.ClassCounter.Counter)
            //{
            //    Edit();
            //}
        }

        private void btOtmena_Click(object sender, RoutedEventArgs e)
        {
            CbGroup.SelectedItem = null;
            CbDiscipline.SelectedItem = null;
        }

        private void btEdit_Click(object sender, RoutedEventArgs e)
        {
            
            if(CbGroup.SelectedItem == null && CbDiscipline.SelectedItem == null)
            {
                if(ClassFolder.TableFolder.ClassSemestr.IdSemestr == 1)
                {
                    ClassFolder.TableFolder.ClassDiscipline.IdDiscipline = 5;
                }
                else if(ClassFolder.TableFolder.ClassSemestr.IdSemestr == 2)
                {
                    ClassFolder.TableFolder.ClassDiscipline.IdDiscipline = 6;
                }

                try
                {
                    
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Update dbo.TimeTable " +
                        $"Set IdGroup ='11', " +
                        $"IdDisciplineT ='{ClassFolder.TableFolder.ClassDiscipline.IdDiscipline}' " +
                        $"Where IdTimeTable = '{ClassFolder.TableFolder.ClassTimeTable.IdTimeTable}'",
                       sqlConnection);

                    sqlCommand.ExecuteNonQuery();                   


                    ClassFolder.ClassMB.frame.Navigate(new PageAttendance.PageTimeTable());
                    ClassFolder.ClassMB.MBInformation("Данные успешно " +
                        "отредактированы!");
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
            else if (CbDiscipline.SelectedItem == null)
            {
                ClassFolder.ClassMB.MBError("Выберите дисциплину");
            }
            else if (CbGroup.SelectedItem == null)
            {
                ClassFolder.ClassMB.MBError("Выберите группу");
                CbGroup.Focus();
            }
            else
            {
                if (ClassFolder.TableFolder.ClassSemestr.IdSemestr == 1)
                {
                    classRead.ReadDisciplineT1(CbDiscipline);
                }
                else if (ClassFolder.TableFolder.ClassSemestr.IdSemestr == 2)
                {
                    classRead.ReadDisciplineT2(CbDiscipline);
                }

                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Update dbo.TimeTable " +
                        $"Set IdGroup ='{Int32.Parse(CbGroup.SelectedValue.ToString())}', " +
                        $"IdDisciplineT ='{ClassFolder.TableFolder.ClassDiscipline.IdDiscipline}' " +
                        $"Where IdTimeTable = '{ClassFolder.TableFolder.ClassTimeTable.IdTimeTable}'",
                       sqlConnection);

                    sqlCommand.ExecuteNonQuery();


                    ClassFolder.ClassMB.frame.Navigate(new PageAttendance.PageTimeTable());
                    ClassFolder.ClassMB.MBInformation("Данные успешно " +
                        "отредактированы!");
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
        }
        public void Edit()
        {
            
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            classCB.LoadDisciplineInEditForTimeTable(CbDiscipline);
            classCB.LoadGroup(CbGroup);



            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Select * From dbo.ViewTimeTable " +
                    $"Where IdTimeTable = '{ClassFolder.TableFolder.ClassTimeTable.IdTimeTable}'", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();

                CbGroup.Text = dataReader[6].ToString();
                sqlConnection.Close();


                classRead.DisciplineForTimeTableToEdit(ClassFolder.TableFolder.ClassDiscipline.IdDiscipline);
                CbDiscipline.Text = ClassFolder.TableFolder.ClassDiscipline.NameDiscipline;


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
        private void BtnAddDiscipline_Click(object sender, RoutedEventArgs e)
        {
            WindowFolder.WindowAdd.WinAddDisciplineToTimeTable winAddDisciplineToTimeTable =
                new WindowFolder.WindowAdd.WinAddDisciplineToTimeTable();
            winAddDisciplineToTimeTable.ShowDialog();
            CbDiscipline.Items.Clear();
            classCB.LoadDisciplineInEditForTimeTable(CbDiscipline);
        }
    }
}
