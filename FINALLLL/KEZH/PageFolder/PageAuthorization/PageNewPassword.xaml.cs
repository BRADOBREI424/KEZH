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
    /// Логика взаимодействия для PageNewPassword.xaml
    /// </summary>
    public partial class PageNewPassword : Page
    {
        SqlConnection sqlConnection =
           new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;       
        public PageNewPassword()
        {
            InitializeComponent();
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(TbNewPassword.Text)&&string.IsNullOrEmpty(TbRepeatPassword.Text))
            {
                ClassFolder.ClassMB.MBError("Введите пароль");
                TbNewPassword.Focus();
            }
            else if(string.IsNullOrEmpty(TbNewPassword.Text))
            {
                ClassFolder.ClassMB.MBError("Введите новый пароль");
                TbNewPassword.Focus();
            }
            else if(string.IsNullOrEmpty(TbRepeatPassword.Text))
            {
                ClassFolder.ClassMB.MBError("Повторите пароль");
                TbRepeatPassword.Focus();
            }
            else if(TbNewPassword.Text!=TbRepeatPassword.Text)
            {
                ClassFolder.ClassMB.MBError("Пароли  не совпадают");
                TbRepeatPassword.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Update dbo.[User] " +
                        $"set Password='{TbNewPassword.Text}' " +
                        $"where IdUser='{ClassFolder.TableFolder.ClassUser.IdUser}'", sqlConnection);
                    sqlCommand.ExecuteNonQuery();                    
                    NavigationService.Navigate(new Uri("/PageFolder/PageAuthorization/PagePasswordRecovered.xaml", UriKind.RelativeOrAbsolute));
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
