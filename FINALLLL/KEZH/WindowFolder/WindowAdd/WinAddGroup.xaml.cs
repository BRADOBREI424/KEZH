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

namespace KEZH.WindowFolder.WindowAdd
{
    /// <summary>
    /// Логика взаимодействия для WinAddGroup.xaml
    /// </summary>
    public partial class WinAddGroup : Window
    {
        SqlConnection sqlConnection =
      new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        ClassFolder.ClassCB classCB;
        public WinAddGroup()
        {
            InitializeComponent();
            classCB = new ClassFolder.ClassCB();
        }

        private void BtnAddSpecilization_Click(object sender, RoutedEventArgs e)
        {
            WinAddSpecializtion winAddSpecializtion = new WinAddSpecializtion();
            winAddSpecializtion.ShowDialog();
            CbSpecializtion.SelectedIndex = -1;
            classCB.LoadSpecialization(CbSpecializtion);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbGroup.Text))
            {
                ClassFolder.ClassMB.MBError("Введите группу.");
                TbGroup.Focus();
            }
            else if (CbSpecializtion.SelectedItem == null)
            {
                ClassFolder.ClassMB.MBError("Выберите специальность.");
                CbSpecializtion.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Insert into dbo.[Group](NameGroup, IdSpecialization) " +
                        "values(@NameGroup, @IdSpecialization)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("NameGroup", TbGroup.Text);
                    sqlCommand.Parameters.AddWithValue("IdSpecialization", Int32.Parse(CbSpecializtion.SelectedValue.ToString()));
                    sqlCommand.ExecuteNonQuery();
                    ClassFolder.ClassMB.MBInformation("Группа добавлена");
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
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        private void btnClose_MouseEnter(object sender, MouseEventArgs e)
        {
            btnClose.Visibility = Visibility.Hidden;
            btnCloseV2.Visibility = Visibility.Visible;
        }



        private void btnCloseV2_MouseLeave(object sender, MouseEventArgs e)
        {
            btnClose.Visibility = Visibility.Visible;
            btnCloseV2.Visibility = Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            classCB.LoadSpecialization(CbSpecializtion);
        }
    }
}
