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

namespace KEZH.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для WinChooseOrder.xaml
    /// </summary>
    public partial class WinChooseOrder : Window
    {
        SqlConnection sqlConnection =
      new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        ClassFolder.ClassCB classCB;
        ClassFolder.ClassEdit classEdit;
        public WinChooseOrder()
        {
            InitializeComponent();
            classCB = new ClassFolder.ClassCB();
            classEdit = new ClassFolder.ClassEdit();
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
            classCB.LoadOrder(CbOrder);
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {                
                if(DpDateOrder.SelectedDate.ToString() == "")
                {
                    ClassFolder.ClassMB.MBError("Выберите дату");
                }
                else
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Insert into dbo.OrderTo(OrderTo, DateOrder, Comment) " +
                        "values(@OrderTo, @DateOrder, @Comment)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("OrderTo", TbOrder.Text);
                    sqlCommand.Parameters.AddWithValue("DateOrder", DpDateOrder.SelectedDate.ToString());
                    sqlCommand.Parameters.AddWithValue("Comment", TbComment.Text);
                    sqlCommand.ExecuteNonQuery();                                       
                }
                
            }
               
            catch 
            {
                
            }
            finally
            {
                sqlConnection.Close();
            }


            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Select IdOrderTo from dbo.OrderTo " +
                    $"where OrderTo='{TbOrder.Text}' and " +
                    $"DateOrder='{DpDateOrder.Text}'", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();

                ClassFolder.TableFolder.ClassOrder.IdOrder = Int32.Parse(dataReader[0].ToString());
                

            }
            catch 
            {
                
            }
            finally
            {
                sqlConnection.Close();
            }

            try
            {

                if(ClassFolder.TableFolder.ClassOrder.IdOrder<1)
                {

                }
                else if(CbOrder.SelectedItem == null)
                {
                    ClassFolder.ClassMB.MBError("Выберите тип");
                }
                else
                {
                    classEdit.Edit("update dbo.Student " +
                   $"set IdStatus='{Int32.Parse(CbOrder.SelectedValue.ToString())}', " +
                   $"IdOrderTo='{ClassFolder.TableFolder.ClassOrder.IdOrder}' " +
                   $"where IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}'");
                    ClassFolder.ClassMB.MBInformation("Приказ добавлен");
                    this.Close();
                }
               
            }
            catch 
            {
               
            }
        }
    }
}
