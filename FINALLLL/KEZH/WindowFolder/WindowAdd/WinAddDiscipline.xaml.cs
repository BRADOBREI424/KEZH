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
    /// Логика взаимодействия для WinAddDiscipline.xaml
    /// </summary>
    public partial class WinAddDiscipline : Window
    {
        SqlConnection sqlConnection =
      new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        ClassFolder.ClassCB classCB;
        public WinAddDiscipline()
        {
            InitializeComponent();
            classCB = new ClassFolder.ClassCB();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            classCB.LoadSemestr(CbSemestr);
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(CbSemestr.SelectedItem==null)
                {
                    ClassFolder.ClassMB.MBError("Выберите семестр");
                }
                else if(string.IsNullOrEmpty(TbCypher.Text))
                {
                    ClassFolder.ClassMB.MBError("Укажите шифр");
                }
                else if(string.IsNullOrEmpty(TbDiscipline.Text))
                {
                    ClassFolder.ClassMB.MBError("Укажите дисциплину");
                }
                else
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Insert into dbo.Discipline(Cypher, NameDiscipline, IdGroup, IdSemestr) " +
                        "values(@Cypher, @NameDiscipline, @IdGroup, @IdSemestr)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Cypher", TbCypher.Text);
                    sqlCommand.Parameters.AddWithValue("NameDiscipline", TbDiscipline.Text);
                    sqlCommand.Parameters.AddWithValue("IdGroup", ClassFolder.TableFolder.ClassUser.IdGroup);
                    sqlCommand.Parameters.AddWithValue("IdSemestr", Int32.Parse(CbSemestr.SelectedValue.ToString()));
                    sqlCommand.ExecuteNonQuery();
                    ClassFolder.ClassMB.MBInformation("Дисциплина добавлена");
                    this.Close();
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
