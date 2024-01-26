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
    /// Логика взаимодействия для PageAdd.xaml
    /// </summary>
    public partial class PageAdd : Page
    {

        SqlConnection sqlConnection =
           new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        ClassFolder.ClassCB classCB;
        ClassFolder.ClassRead classRead;


        public PageAdd()
        {
            InitializeComponent();

            classCB = new ClassFolder.ClassCB();
            classRead = new ClassFolder.ClassRead();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CbNumber.SelectedItem == null)
            {
                ClassFolder.ClassMB.MBError("Выберите номер пары");
            }
            else if (CbSemestr.SelectedItem == null)
            {
                ClassFolder.ClassMB.MBError("Выберите семестр");
            }
            else if (CbDayWeek.SelectedItem == null)
            {
                ClassFolder.ClassMB.MBError("Выберите день недели");
            }
            else if(CbGroup.SelectedItem==null&&CbDiscipline.SelectedItem!=null)
            {
                ClassFolder.ClassMB.MBError("Выберите группу");
            }
            else if(CbGroup.SelectedItem!=null&&CbDiscipline.SelectedItem==null)
            {
                ClassFolder.ClassMB.MBError("Выберите дисциплину");
            }
            else if (CbGroup.SelectedItem == null && CbDiscipline.SelectedItem == null && CbSemestr.SelectedValue.ToString()=="1")
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Insert into dbo.TimeTable" +
                        "(IdNumber, IdDisciplineT, IdDayWeek, IdUser) " +
                        "values(@IdNumber, @IdDisciplineT, @IdDayWeek, @IdUser)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("IdNumber", Int32.Parse(CbNumber.SelectedValue.ToString()));                    
                    sqlCommand.Parameters.AddWithValue("IdDayWeek", Int32.Parse(CbDayWeek.SelectedValue.ToString()));                    
                    sqlCommand.Parameters.AddWithValue("IdUser", ClassFolder.TableFolder.ClassUser.IdUser);
                    sqlCommand.Parameters.AddWithValue("IdDisciplineT", 5);
                    sqlCommand.ExecuteNonQuery();                    
                    ClassFolder.ClassMB.MBInformation("Расписание обновлено");
                    ClassFolder.ClassMB.frame.Navigate(new PageAttendance.PageTimeTable());
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
            else if (CbGroup.SelectedItem == null && CbDiscipline.SelectedItem == null && CbSemestr.SelectedValue.ToString() == "2")
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Insert into dbo.TimeTable" +
                        "(IdNumber, IdDisciplineT, IdDayWeek, IdUser) " +
                        "values(@IdNumber, @IdDisciplineT, @IdDayWeek, @IdUser)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("IdNumber", Int32.Parse(CbNumber.SelectedValue.ToString()));
                    sqlCommand.Parameters.AddWithValue("IdDayWeek", Int32.Parse(CbDayWeek.SelectedValue.ToString()));
                    sqlCommand.Parameters.AddWithValue("IdUser", ClassFolder.TableFolder.ClassUser.IdUser);
                    sqlCommand.Parameters.AddWithValue("IdDisciplineT", 6);
                    sqlCommand.ExecuteNonQuery();
                    ClassFolder.ClassMB.MBInformation("Расписание обновлено");
                    ClassFolder.ClassMB.frame.Navigate(new PageAttendance.PageTimeTable());
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
            else
            {
                try
                {
                    if(CbSemestr.SelectedValue.ToString()=="1")
                    {
                        classRead.ReadDisciplineT1(CbDiscipline);
                    }
                    else if(CbSemestr.SelectedValue.ToString()=="2")
                    {
                        classRead.ReadDisciplineT2(CbDiscipline);
                    }
                    
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Insert into dbo.TimeTable" +
                        "(IdNumber, IdGroup, IdDisciplineT, IdDayWeek, IdUser) " +
                        "values(@IdNumber, @IdGroup, @IdDisciplineT, @IdDayWeek, @IdUser)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("IdNumber", Int32.Parse(CbNumber.SelectedValue.ToString()));
                    sqlCommand.Parameters.AddWithValue("IdGroup", Int32.Parse(CbGroup.SelectedValue.ToString()));
                    sqlCommand.Parameters.AddWithValue("IdDisciplineT", ClassFolder.TableFolder.ClassDiscipline.IdDiscipline);
                    sqlCommand.Parameters.AddWithValue("IdDayWeek", Int32.Parse(CbDayWeek.SelectedValue.ToString()));                    
                    sqlCommand.Parameters.AddWithValue("IdUser", ClassFolder.TableFolder.ClassUser.IdUser);
                    sqlCommand.ExecuteNonQuery();
                    ClassFolder.ClassMB.MBInformation("Расписание обновлено");
                    ClassFolder.ClassMB.frame.Navigate(new PageAttendance.PageTimeTable());
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                classCB.LoadDisciplineForTimeTable(CbDiscipline);
                classCB.LoadSemestrToTimeTable(CbSemestr);
                classCB.LoadDayWeek(CbDayWeek);
                classCB.LoadGroup(CbGroup);
                classCB.LoadNumber(CbNumber);
            }
            catch 
            {
                
            }
            
        }

        private void btOtmena_Click(object sender, RoutedEventArgs e)
        {
            CbDayWeek.SelectedIndex = -1;
            CbDiscipline.SelectedIndex = -1;
            CbGroup.SelectedIndex = -1;
            CbNumber.SelectedIndex = -1;
            CbSemestr.SelectedIndex = -1;

                        
            classCB.LoadSemestrToTimeTable(CbSemestr);
            classCB.LoadDayWeek(CbDayWeek);
            classCB.LoadGroup(CbGroup);
            classCB.LoadNumber(CbNumber);

        }

        private void BtnAddDiscipline_Click(object sender, RoutedEventArgs e)
        {
            WindowFolder.WindowAdd.WinAddDisciplineToTimeTable winAddDisciplineToTimeTable =
                new WindowFolder.WindowAdd.WinAddDisciplineToTimeTable();
            winAddDisciplineToTimeTable.ShowDialog();
            CbDiscipline.Items.Clear();
            if (CbSemestr.SelectedItem == null)
            {
                classCB.LoadDisciplineForTimeTable(CbDiscipline);
            }
            else
            {
                classCB.LoadDisciplineChangeForTimeTable(CbDiscipline, CbSemestr);
            }
        }

        private void CbSemestr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CbDiscipline.Items.Clear();            
           classCB.LoadDisciplineChangeForTimeTable(CbDiscipline, CbSemestr);
           
            
        }
    }
}
