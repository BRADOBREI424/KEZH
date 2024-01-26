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
using System.Windows.Shapes;

namespace KEZH.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для WinSystemAdmin.xaml
    /// </summary>
    public partial class WinSystemAdmin : Window
    {
        SqlConnection sqlConnection =
      new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        ClassFolder.ClassCB classCB;
        ClassFolder.ClassDG classDG;
        ClassFolder.ClassEdit classEdit;
        public WinSystemAdmin()
        {
            InitializeComponent();
            classDG = new ClassFolder.ClassDG(DgTeacher);
            classCB = new ClassFolder.ClassCB();
            classEdit = new ClassFolder.ClassEdit();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnHide_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void ToolBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void btnClose_MouseEnter(object sender, MouseEventArgs e)
        {
            btnClose.Visibility = Visibility.Hidden;
            btnCloseV2.Visibility = Visibility.Visible;
        }

        private void btnHide_MouseEnter(object sender, MouseEventArgs e)
        {
            btnHide.Visibility = Visibility.Hidden;
            btnHideV2.Visibility = Visibility.Visible;
        }

        private void btnCloseV2_MouseLeave(object sender, MouseEventArgs e)
        {
            btnClose.Visibility = Visibility.Visible;
            btnCloseV2.Visibility = Visibility.Hidden;
        }

        private void btnHideV2_MouseLeave(object sender, MouseEventArgs e)
        {
            btnHide.Visibility = Visibility.Visible;
            btnHideV2.Visibility = Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            classCB.LoadGroup(CbNameGroup);
            classDG.LoadDB("Select * From dbo.ViewTeacher");            
        }

        private void DgTeacher_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassUser.IdUser = Int32.Parse(classDG.SelectId());
                BtnAdd.IsEnabled = false;
                BtnSave.IsEnabled = true;

                try
                {
                    TbLogin.IsEnabled = false;
                    PsbPassword.IsEnabled = false;
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Select * From dbo.ViewTeacher " +
                        $"Where IdUser = '{ClassFolder.TableFolder.ClassUser.IdUser}'", sqlConnection);
                    dataReader = sqlCommand.ExecuteReader();
                    dataReader.Read();

                    TbLastName.Text = dataReader[1].ToString();
                    TbFirstName.Text = dataReader[2].ToString();
                    TbMiddleName.Text = dataReader[3].ToString();
                    TbEmail.Text = dataReader[4].ToString();
                    TbLogin.Text = dataReader[5].ToString();

                    PsbPassword.Password = dataReader[6].ToString();
                    CbNameGroup.Text = dataReader[7].ToString();
                    TbUserName.Text = dataReader[8].ToString();
                    TbNumberPhone.Text = dataReader[14].ToString();


                    ClassFolder.TableFolder.ClassUser.IdUser = Int32.Parse(dataReader[0].ToString());
                    ClassFolder.TableFolder.ClassUser.IdGroup = Int32.Parse(dataReader[13].ToString());
                    ClassFolder.TableFolder.ClassSpecialization.IdSpecialization = dataReader[12].ToString();
                    ClassFolder.TableFolder.ClassTeacher.IdTeacher = Int32.Parse(dataReader[11].ToString());
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
                ClassFolder.ClassMB.MBError("Выберите строку!");
            }
        }
        

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ClassFolder.TableFolder.ClassUser.IdUser < 1)
            {
                ClassFolder.ClassMB.MBError("Выберите преподователя");
            }
            else
            {
                //ClassFolder.TableFolder.ClassRole.IdRole = CbNameRole.SelectedValue.ToString();
                //classEdit.Edit("Update dbo.[Group] " +
                //   $"Set  NameGroup='{CbNameGroup.SelectedValue.ToString()}' " +
                //   $"Where IdGroup = '{ClassFolder.TableFolder.ClassUser.IdGroup }'");

                classEdit.Edit("Update dbo.[User] " +
                   $"Set Login='{TbLogin.Text}', " +
                   $"Password='{PsbPassword.Password}'," +
                   $"IdGroup='{Int32.Parse(CbNameGroup.SelectedValue.ToString())}', " +
                   $"Email ='{TbEmail.Text}', " +
                   $"UserName='{TbUserName.Text}'" +
                   $"Where IdUser = '{ClassFolder.TableFolder.ClassUser.IdUser}'");

                classEdit.Edit("Update dbo.Teacher " +
                   $"Set LastNameTeacher='{TbFirstName.Text}', " +  
                   $"FirstNameTeacher='{TbLastName.Text}', " +
                   $"MiddleNameTeacher ='{TbMiddleName.Text}', " +
                   $"NumberPhone ='{TbNumberPhone.Text}' " +
                   $"Where IdTeacher = '{ClassFolder.TableFolder.ClassTeacher.IdTeacher}'");            

                ClassFolder.ClassMB.MBInformation("Данные отредактированы");


                //Отчистка строк
                TbLastName.Clear();
                TbFirstName.Clear();
                TbMiddleName.Clear();
                TbEmail.Clear();
                TbLogin.Clear();
                PsbPassword.Clear();
                CbNameGroup.SelectedIndex = -1;
                TbUserName.Clear();
                TbNumberPhone.Clear();
                
                
                
      

                TbLogin.IsEnabled = true;
                PsbPassword.IsEnabled = true;
                BtnAdd.IsEnabled = true;
                BtnSave.IsEnabled = false;
                classDG.LoadDB("Select * From dbo.ViewTeacher");

                ClassFolder.TableFolder.ClassTeacher.IdTeacher = 0;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbLastName.Text))
            {
                ClassFolder.ClassMB.MBError("Введите фамилию");
                TbLastName.Focus();
            }
            else if (string.IsNullOrEmpty(TbFirstName.Text))
            {
                ClassFolder.ClassMB.MBError("Введите имя");
                TbFirstName.Focus();
            }
            else if (string.IsNullOrEmpty(TbEmail.Text))
            {
                ClassFolder.ClassMB.MBError("Введите почту");
                TbEmail.Focus();
            }
            else if (string.IsNullOrEmpty(TbLogin.Text))
            {
                ClassFolder.ClassMB.MBError("Введите логин");
                TbLogin.Focus();
            }
            else if (string.IsNullOrEmpty(PsbPassword.Password))
            {
                ClassFolder.ClassMB.MBError("Введите пароль");
                PsbPassword.Focus();
            }
            else if (CbNameGroup.SelectedItem == null)
            {
                ClassFolder.ClassMB.MBError("Введите группу");
                CbNameGroup.Focus();
            }
            else if (string.IsNullOrEmpty(TbUserName.Text))
            {
                ClassFolder.ClassMB.MBError("Введите имя пользователя");
                TbUserName.Focus();
            }        
            else if (string.IsNullOrEmpty(TbNumberPhone.Text))
            {
                ClassFolder.ClassMB.MBError("Введите номер телефона");
                TbNumberPhone.Focus();
            }
            else
            {              
                int teacher = 0;               
                try
                {

                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Insert into dbo.Teacher " +
                        "(LastNameTeacher, FirstNameTeacher, MiddleNameTeacher, NumberPhone) " +
                        "Values (@LastNameTeacher, @FirstNameTeacher, @MiddleNameTeacher, @NumberPhone) ", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("LastNameTeacher", TbLastName.Text);
                    sqlCommand.Parameters.AddWithValue("FirstNameTeacher", TbFirstName.Text);
                    sqlCommand.Parameters.AddWithValue("MiddleNameTeacher", TbMiddleName.Text);
                    sqlCommand.Parameters.AddWithValue("NumberPhone", TbNumberPhone.Text);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ClassFolder.ClassMB.MBError(ex);
                }
                finally
                {
                    sqlConnection.Close();
                }

                //чтение преподавателя
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Select IdTeacher from dbo.Teacher " +
                        $"where [LastNameTeacher]='{TbLastName.Text}' ", sqlConnection);
                    dataReader = sqlCommand.ExecuteReader();
                    dataReader.Read();
                    teacher = Int32.Parse(dataReader[0].ToString());
                }
                catch (Exception ex)
                {
                    ClassFolder.ClassMB.MBError(ex);
                }
                finally
                {
                    sqlConnection.Close();
                }

                //добавление пользователя
                try
                {

                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Insert into dbo.[User] " +
                        "(IdGroup, Login, Password, Email, IdRole, UserName, IdTeacher) " +
                        "Values (@IdGroup, @Login, @Password, @Email, @IdRole, @UserName, @IdTeacher) ", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Login", TbLogin.Text);
                    sqlCommand.Parameters.AddWithValue("Password", PsbPassword.Password);
                    sqlCommand.Parameters.AddWithValue("Email", TbEmail.Text);
                    sqlCommand.Parameters.AddWithValue("IdRole", 1);
                    sqlCommand.Parameters.AddWithValue("UserName", TbUserName.Text);
                    sqlCommand.Parameters.AddWithValue("IdGroup", Int32.Parse(CbNameGroup.SelectedValue.ToString()));
                    sqlCommand.Parameters.AddWithValue("IdTeacher", teacher);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ClassFolder.ClassMB.MBError(ex);
                }
                finally
                {
                    sqlConnection.Close();
                }

                ClassFolder.ClassMB.MBInformation("Пользователь успешно добавлен");


                classDG.LoadDB("Select * From dbo.ViewTeacher");
                
            }
        }

        private void btnAddGroup_Click(object sender, RoutedEventArgs e)
        {
           
            WindowAdd.WinAddGroup winAddGroup = new WindowAdd.WinAddGroup();
            winAddGroup.ShowDialog();
          CbNameGroup.SelectedIndex = -1;
                
                classCB.LoadGroup(CbNameGroup);           
           
            
        }

       
     
    }
}
