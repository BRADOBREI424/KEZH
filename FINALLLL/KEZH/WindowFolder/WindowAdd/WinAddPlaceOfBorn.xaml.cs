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
    /// Логика взаимодействия для WinAddPlaceOfBorn.xaml
    /// </summary>
    public partial class WinAddPlaceOfBorn : Window
    {
        SqlConnection sqlConnection =
        new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        public WinAddPlaceOfBorn()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbPlaceOFBorn.Text))
            {
                ClassFolder.ClassMB.MBError("Введите место рождения.");
                TbPlaceOFBorn.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Insert into dbo.PlaceOfBorn(NamePlaceOfBorn) values(@NamePlaceOfBorn)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("NamePlaceOfBorn", TbPlaceOFBorn.Text);
                    sqlCommand.ExecuteNonQuery();
                    ClassFolder.ClassMB.MBInformation("Добавлено место рождения");
                }
                catch (Exception ex)
                {
                    ClassFolder.ClassMB.MBError(ex);
                }
                finally
                {
                    sqlConnection.Close();
                    this.Close();
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
    }
}
