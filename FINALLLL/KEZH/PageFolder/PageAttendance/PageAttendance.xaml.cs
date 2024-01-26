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

namespace KEZH.PageFolder.PageAttendance
{
    /// <summary>
    /// Логика взаимодействия для PageAttendance.xaml
    /// </summary>
    public partial class PageAttendance : Page
    {
        SqlConnection sqlConnection =
           new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        ClassFolder.ClassDG classDG;
        ClassFolder.ClassCB classCB;

        public PageAttendance()

        {
            InitializeComponent();
            classDG = new ClassFolder.ClassDG(dgAttendance);
            classCB = new ClassFolder.ClassCB();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            classCB.LoadAttendance(CbAttendance);
            classDG.LoadDB("Select * from dbo.ViewStudent " +
                $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}'" +
                $"and NameStatus = 'Активен'");
        }

        private void btnSaveAttendance_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassStudent.IdStudent = Int32.Parse(classDG.SelectId());
                try
                {
                    if (DpDate.SelectedDate == null)
                    {
                        ClassFolder.ClassMB.MBError("Выберите дату");
                    }
                    else if (CbAttendance.SelectedItem == null)
                    {
                        ClassFolder.ClassMB.MBError("Укажите посещение");
                    }
                    else
                    {
                        //ClassFolder.ClassMB.MBInformation($"{ClassFolder.TableFolder.ClassStudent.IdStudent}");
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand("Insert into dbo.Attendance" +
                            "(DateAttendance, IdStatusAttendance, IdStudent, Comment) " +
                            "values(@DateAttendance, @IdStatusAttendance, @IdStudent, @Comment)", sqlConnection);
                        sqlCommand.Parameters.AddWithValue("DateAttendance", DpDate.SelectedDate.GetValueOrDefault());
                        sqlCommand.Parameters.AddWithValue("IdStatusAttendance", CbAttendance.SelectedValue.ToString());
                        sqlCommand.Parameters.AddWithValue("IdStudent", ClassFolder.TableFolder.ClassStudent.IdStudent);
                        sqlCommand.Parameters.AddWithValue("Comment", TbComment.Text);
                        sqlCommand.ExecuteNonQuery();
                        ClassFolder.ClassMB.MBInformation("Посещаемость студента отмечена");
                        CbAttendance.SelectedIndex = -1;
                        TbComment.Text = null;
                    }
                    
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
            catch
            {
                ClassFolder.ClassMB.MBError("Выберите студента");
            }
            





        }
                

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (string.IsNullOrEmpty(TbSearch.Text))
            //{
            //    classDG.LoadDB("Select * from dbo.ViewAttendance " +
            //        $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' " +
            //        $"and NameStatus='Активен'");
            //}
            //else
            //{
            //    classDG.LoadDB("Select * from dbo.ViewAttendance " +
            //        $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' " +
            //        $"and NameStatus='Активен' and " +
            //        $"LastName like '{TbSearch.Text}%'");
            //}
            classDG.LoadDB("Select * from dbo.ViewStudentDG " +
               $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' " +
               "and NameStatus='Активен' and " +
               $"FIO like '%{TbSearch.Text}%'");
        }

        private void btnListAttendance_Click(object sender, RoutedEventArgs e)
        {
            ClassFolder.TableFolder.ClassStudent.IdStudent = 0;
            NavigationService.Navigate(new Uri("/PageFolder/PageAttendance/PageListAttendance.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
