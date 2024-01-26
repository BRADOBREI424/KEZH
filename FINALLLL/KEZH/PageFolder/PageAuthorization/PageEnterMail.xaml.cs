using System;
using System.Collections.Generic;
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
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;

namespace KEZH.PageFolder.PageAuthorization
{
    /// <summary>
    /// Логика взаимодействия для PageEnterMail.xaml
    /// </summary>
    public partial class PageEnterMail : Page
    {
        SqlConnection sqlConnection =
           new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        public PageEnterMail()
        {
            InitializeComponent();
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbEmail.Text))
            {
                ClassFolder.ClassMB.MBError("Введите почту");
                TbEmail.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("select Email, UserName from dbo.[User] " +
                        $"where IdUser='{ClassFolder.TableFolder.ClassUser.IdUser}'", sqlConnection);
                    dataReader = sqlCommand.ExecuteReader();
                    dataReader.Read();
                    string Mail = dataReader[0].ToString();
                    ClassFolder.TableFolder.ClassUser.UserName = dataReader[1].ToString();
                    sqlConnection.Close();
                    if (Mail != TbEmail.Text)
                    {
                        ClassFolder.ClassMB.MBError("Вы ввели не верную почту");
                    }
                    else
                    {
                        Random ranCode = new Random();

                        int EmailCode = ranCode.Next(100000, 999999);

                        ClassFolder.TableFolder.ClassUser.SecretCode = EmailCode;

                        try
                        {
                            sqlConnection.Open();
                            sqlCommand = new SqlCommand("Update dbo.[User] " +
                                $"set SecretCode='{EmailCode}' " +
                                $"where IdUser='{ClassFolder.TableFolder.ClassUser.IdUser}'", sqlConnection);
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

                        // отправитель - устанавливаем адрес и отображаемое в письме имя
                        MailAddress from = new MailAddress("KEZH.suport@gmail.com", "Техническая поддержка ЭЖК");
                        // кому отправляем
                        MailAddress to = new MailAddress($"{TbEmail.Text}");
                        // создаем объект сообщения
                        MailMessage m = new MailMessage(from, to);
                        // тема письма
                        m.Subject = "Востановление пароля";
                        // текст письма
                        m.Body = $"<h4>Здравствуйте {ClassFolder.TableFolder.ClassUser.UserName}, </h4>" +
                            $"Поступил запрос на смену пароля!<br>" +
                            $"Если вы не делали этот запрос, пожалуйста проигнорируйте это письмо.<br>" +
                            $"В ином случае, введите данный код для востановления пароля:<br>" +
                            $"<h1>{EmailCode}</h1>";
                        // письмо представляет код html
                        m.IsBodyHtml = true;
                        // адрес smtp-сервера и порт, с которого будем отправлять письмо
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                        // логин и пароль
                        smtp.Credentials = new NetworkCredential("KEZH.suport@gmail.com", "c5r-3J4-4Ea-wKK");
                        smtp.EnableSsl = true;
                        smtp.Send(m);

                        NavigationService.Navigate(new Uri("/PageFolder/PageAuthorization/PageReciveCode.xaml", UriKind.RelativeOrAbsolute));
                    }
                }
                catch (Exception ex)
                {
                    ClassFolder.ClassMB.MBError(ex);
                }               
            }





        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnToEnter_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PageFolder/PageAuthorization/PageAuthorization.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
