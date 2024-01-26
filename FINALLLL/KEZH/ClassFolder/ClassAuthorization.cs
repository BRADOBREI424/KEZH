using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KEZH.ClassFolder
{
    class ClassAuthorization
    {
        SqlConnection sqlConnection =
            new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;

        public void Authorization(TextBox TbLogin, PasswordBox PsbPassword, TextBox TbPassword)
        {
            if (string.IsNullOrEmpty(TbLogin.Text))
            {
                ClassMB.MBError("Введите логин");
                TbLogin.Focus();
            }
            else if (string.IsNullOrEmpty(PsbPassword.Password)&&string.IsNullOrEmpty(TbPassword.Text))
            {
                ClassMB.MBError("Введите пароль");
                TbLogin.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Select * from dbo.[User] " +
                        $"Where [Login]='{TbLogin.Text}'", sqlConnection);
                    dataReader = sqlCommand.ExecuteReader();
                    dataReader.Read();
                    if (dataReader[1].ToString() != TbLogin.Text)
                    {
                        ClassMB.MBError("Неверный логин");
                    }
                    else if (dataReader[2].ToString() != PsbPassword.Password && dataReader[2].ToString() != TbPassword.Text)
                    {
                        ClassMB.MBError("Неверный пароль");
                        
                    }                   
                    else
                    {
                        TableFolder.ClassUser.Login = TbLogin.Text;
                        if (string.IsNullOrEmpty(PsbPassword.Password))
                        {
                            TableFolder.ClassUser.Password = TbPassword.Text;
                        }
                        else
                        {
                            TableFolder.ClassUser.Password = PsbPassword.Password;
                        }

                        TableFolder.ClassUser.IdUser = Int32.Parse(dataReader[0].ToString());
                        TableFolder.ClassUser.IdRole = Int32.Parse(dataReader[5].ToString());
                        TableFolder.ClassUser.IdGroup = Int32.Parse(dataReader[3].ToString());

                        switch (TableFolder.ClassUser.IdRole)
                        {
                            case 2:
                                WindowFolder.WinSystemAdmin winSystemAdmin =
                                    new WindowFolder.WinSystemAdmin();
                                winSystemAdmin.Show();
                                //Application.Current.MainWindow.Hide();
                                break;
                            case 1:
                                WindowFolder.WinClassroomTeacher winClassroomTeacher =
                                    new WindowFolder.WinClassroomTeacher();
                                winClassroomTeacher.Show();                                
                                Application.Current.MainWindow.Hide();
                                break;
                            case 3:
                                WindowFolder.WinSocialPedagog.WinSocialPedagog winSocialPedagog =
                                    new WindowFolder.WinSocialPedagog.WinSocialPedagog();
                                winSocialPedagog.Show();
                                Application.Current.MainWindow.Hide();
                                break;
                        }

                    }
                }
                catch (Exception ex)
                {
                    ClassMB.MBError(ex);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
