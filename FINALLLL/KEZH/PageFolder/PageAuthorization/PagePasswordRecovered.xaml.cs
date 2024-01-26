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
    /// Логика взаимодействия для PagePasswordRecovered.xaml
    /// </summary>
    public partial class PagePasswordRecovered : Page
    {
        public PagePasswordRecovered()
        {
            InitializeComponent();
        }

        private void BtnToEnter_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PageFolder/PageAuthorization/PageAuthorization.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
