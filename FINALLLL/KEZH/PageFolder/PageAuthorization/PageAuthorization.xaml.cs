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

namespace KEZH.PageFolder.PageAuthorization
{
    /// <summary>
    /// Логика взаимодействия для PageAuthorization.xaml
    /// </summary>
    public partial class PageAuthorization : Page
    {
        public PageAuthorization()
        {
            InitializeComponent();
            
        }

        private void BtnForgetPasswordr_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("PageFolder/PageAuthorization/PageForgetPassword.xaml", UriKind.RelativeOrAbsolute));
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            ClassFolder.ClassAuthorization classAuthorization =
                new ClassFolder.ClassAuthorization();
            classAuthorization.Authorization(TbLogin, PsbPassword, TbPassword);            
        }

        private void BtnShowPasswordBox_Click(object sender, RoutedEventArgs e)
        {
            PsbPassword.Visibility = Visibility.Visible;
            BtnShowTextBox.Visibility = Visibility.Visible;
            TbPassword.Visibility = Visibility.Hidden;
            BtnShowPasswordBox.Visibility = Visibility.Hidden;
            PsbPassword.Password = TbPassword.Text;
        }

        private void BtnShowTextBox_Click(object sender, RoutedEventArgs e)
        {
            TbPassword.Visibility = Visibility.Visible;
            BtnShowPasswordBox.Visibility = Visibility.Visible;
            PsbPassword.Visibility = Visibility.Hidden;
            BtnShowTextBox.Visibility = Visibility.Hidden;
            TbPassword.Text = PsbPassword.Password;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {                      
            TbLogin.Text = null;
            TbPassword.Text = null;
            PsbPassword.Password = null;
        }
    }
}
