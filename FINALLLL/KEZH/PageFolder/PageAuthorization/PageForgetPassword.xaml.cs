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

namespace KEZH.PageFolder.PageAuthorization
{
    /// <summary>
    /// Логика взаимодействия для PageForgetPassword.xaml
    /// </summary>
    public partial class PageForgetPassword : Page
    {
        SqlConnection sqlConnection =
            new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        public PageForgetPassword()
        {
            InitializeComponent();
        }

        private void BtnToEnter_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PageFolder/PageAuthorization/PageAuthorization.xaml", UriKind.RelativeOrAbsolute));
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbLogin.Text))
            {
                ClassFolder.ClassMB.MBError("Введите логин");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Select * from dbo.[User] " +
                        $"where [Login]='{TbLogin.Text}'",
                        sqlConnection);
                    dataReader = sqlCommand.ExecuteReader();
                    dataReader.Read();

                    if (dataReader[1].ToString() != TbLogin.Text)
                    {
                        ClassFolder.ClassMB.MBError("Логина не существует");
                        TbLogin.Focus();
                    }
                    else
                    {
                        NavigationService.Navigate(new Uri("/PageFolder/PageAuthorization/PageEnterMail.xaml", UriKind.RelativeOrAbsolute));
                        ClassFolder.TableFolder.ClassUser.IdUser = Int32.Parse(dataReader[0].ToString());
                    }
                }
                catch
                {
                    ClassFolder.ClassMB.MBError("Логина не существует");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
           
        }
    }
}
