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
    /// Логика взаимодействия для PageReciveCode.xaml
    /// </summary>
    public partial class PageReciveCode : Page
    {
        SqlConnection sqlConnection =
           new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        public PageReciveCode()
        {
            InitializeComponent();
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(TbCode.Text))
            {
                ClassFolder.ClassMB.MBError("Введите код");
                TbCode.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Select SecretCode from dbo.[User] " +
                        $"where IdUser='{ClassFolder.TableFolder.ClassUser.IdUser}'", sqlConnection);
                    dataReader = sqlCommand.ExecuteReader();
                    dataReader.Read();
                    ClassFolder.TableFolder.ClassUser.SecretCode =Int32.Parse(dataReader[0].ToString());

                    if (ClassFolder.TableFolder.ClassUser.SecretCode == Int32.Parse(TbCode.Text))
                    {
                        NavigationService.Navigate(new Uri("/PageFolder/PageAuthorization/PageNewPassword.xaml", UriKind.RelativeOrAbsolute));
                    }
                    else
                    {
                        ClassFolder.ClassMB.MBError("Вы ввели не верный код");
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
