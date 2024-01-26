using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для WinSingIn.xaml
    /// </summary>
    public partial class WinSingIn : Window
    {
        public WinSingIn()
        {
            InitializeComponent();
            ClassFolder.ClassMB.frameAuth=FAutnhorization;
        }

        private void FAutnhorization_Loaded(object sender, RoutedEventArgs e)
        {
            FAutnhorization.NavigationService.Navigate(new Uri("PageFolder/PageAuthorization/PageAuthorization.xaml", UriKind.RelativeOrAbsolute));
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

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {
            WinInfo.WinInfo winInfo = new WinInfo.WinInfo();
            winInfo.ShowDialog();
        }
    }
}
