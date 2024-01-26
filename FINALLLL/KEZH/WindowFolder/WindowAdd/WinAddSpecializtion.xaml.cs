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
    /// Логика взаимодействия для WinAddSpecializtion.xaml
    /// </summary>
    public partial class WinAddSpecializtion : Window
    {
        SqlConnection sqlConnection =
       new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        public WinAddSpecializtion()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(TbSpecializtion.Text))
            {
                ClassFolder.ClassMB.MBError("Выберите специальность");
                TbSpecializtion.Focus();
            }
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Specialization(NameSpecialization) " +
                    "values(@NameSpecialization)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("NameSpecialization", TbSpecializtion.Text);
                sqlCommand.ExecuteNonQuery();
                ClassFolder.ClassMB.MBInformation("Специальность добавлена");
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
    }
}
