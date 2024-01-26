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
using System.Windows.Shapes;

namespace KEZH.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для WinClassroomTeacher.xaml
    /// </summary>
    public partial class WinClassroomTeacher : Window
    {
        public WinClassroomTeacher()
        {
            InitializeComponent();
            ClassFolder.ClassMB.frame = FrmMain;
            
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnHide_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void ToolBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            TbMenu.Visibility = Visibility.Visible;
            imLogo.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            TbMenu.Visibility = Visibility.Collapsed;
            imLogo.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ItemMark_Selected(object sender, RoutedEventArgs e)
        {
            FrmMain.NavigationService.RemoveBackEntry();
            FrmMain.Navigate(new PageFolder.PageMarks.PageInvoicingMarks());
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

        private void ItemStudent_Selected(object sender, RoutedEventArgs e)
        {
            FrmMain.NavigationService.RemoveBackEntry();
            FrmMain.Navigate(new PageFolder.PageStudent.PageStudent());
        }

        private void ItemListtDellStudent_Selected(object sender, RoutedEventArgs e)
        {
            FrmMain.NavigationService.RemoveBackEntry();
            FrmMain.Navigate(new PageFolder.PageDeducatedStudent.PageDeducatedList());
        }

        private void ItemExit_Selected(object sender, RoutedEventArgs e)
        {
            ClassFolder.ClassMB.MessageQuestionExit();
        }

        private void ItemAttendance_Selected(object sender, RoutedEventArgs e)
        {
            FrmMain.NavigationService.RemoveBackEntry();
            FrmMain.Navigate(new PageFolder.PageAttendance.PageAttendance());
        }

        private void ItemTimeTable_Selected(object sender, RoutedEventArgs e)
        {
            FrmMain.NavigationService.RemoveBackEntry();
            FrmMain.Navigate(new PageFolder.PageAttendance.PageTimeTable());
        }

        private void ItemSetting_Selected(object sender, RoutedEventArgs e)
        {
            WinInfo.WinInfo winInfo = new WinInfo.WinInfo();
            winInfo.ShowDialog();
        }



        private void btnNormalize_MouseEnter(object sender, MouseEventArgs e)
        {

            btnNormalize.Visibility = Visibility.Hidden;
            btnNormalizeV2.Visibility = Visibility.Visible;

        }

        private void btnNormalizeV2_MouseLeave(object sender, MouseEventArgs e)
        {

            if(ClassFolder.TableFolder.ClassCounter.PastCounter==ClassFolder.TableFolder.ClassCounter.Counter)
            {
                btnNormalize.Visibility = Visibility.Visible;
                btnNormalizeV2.Visibility = Visibility.Hidden;
            }
            else
            {
                btnNormalize.Visibility = Visibility.Hidden;
                btnNormalizeV2.Visibility = Visibility.Hidden;
                ClassFolder.TableFolder.ClassCounter.PastCounter += 1;
            }
            
            
                    
        }

        private void btnMaximize_MouseEnter(object sender, MouseEventArgs e)
        {
            btnMaximize.Visibility = Visibility.Hidden;
            btnMaximizeV2.Visibility = Visibility.Visible;
        }

        private void btnMaximizeV2_MouseLeave(object sender, MouseEventArgs e)
        {
            if(ClassFolder.TableFolder.ClassCounter.PastCounter2==ClassFolder.TableFolder.ClassCounter.Counter2)
            {
                btnMaximize.Visibility = Visibility.Visible;
                btnMaximizeV2.Visibility = Visibility.Hidden;
            }
            else
            {
                btnMaximize.Visibility = Visibility.Hidden;
                btnMaximizeV2.Visibility = Visibility.Hidden;
                ClassFolder.TableFolder.ClassCounter.PastCounter2 += 1;
            }
            
        }

        private void btnNormalizeV2_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Normal;
            btnNormalize.Visibility = Visibility.Hidden;
            btnNormalizeV2.Visibility = Visibility.Hidden;
            btnMaximize.Visibility = Visibility.Visible;
            btnMaximizeV2.Visibility = Visibility.Hidden;
            ClassFolder.TableFolder.ClassCounter.Counter += 1;
        }

        private void btnMaximizeV2_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
            btnNormalizeV2.Visibility = Visibility.Hidden;
            btnMaximize.Visibility = Visibility.Hidden;
            btnMaximizeV2.Visibility = Visibility.Hidden;
            btnNormalize.Visibility = Visibility.Visible;
            ClassFolder.TableFolder.ClassCounter.Counter2 += 1;
        }

        private void ItemReLogin_Selected(object sender, RoutedEventArgs e)
        {
         MessageBoxResult result=   MessageBox.Show("Вы действительно хотите выйти из аккаунта?", 
             "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ClassFolder.ClassMB.frameAuth.Refresh();
                Application.Current.MainWindow.Show();
                this.Close();
            }            
        }

        private void ItemComboBoxEdit_Selected(object sender, RoutedEventArgs e)
        {
            FrmMain.NavigationService.RemoveBackEntry();
            FrmMain.Navigate(new PageFolder.PageEditComboBox.EditComboBox());
        }
    }
}
