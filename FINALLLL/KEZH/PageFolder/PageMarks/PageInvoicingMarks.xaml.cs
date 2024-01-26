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

namespace KEZH.PageFolder.PageMarks
{
    /// <summary>
    /// Логика взаимодействия для PageInvoicingMarks.xaml
    /// </summary>
    public partial class PageInvoicingMarks : Page
    {
        SqlConnection sqlConnection =
      new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        ClassFolder.ClassCB classCB;
        ClassFolder.ClassDG classDG;
        ClassFolder.ClassRead classRead;
        public PageInvoicingMarks()
        {
            InitializeComponent();
            classDG = new ClassFolder.ClassDG(DgInvoicingMarks);
            classCB = new ClassFolder.ClassCB();
            classRead = new ClassFolder.ClassRead();
        }

       

        private void BtnInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassStudent.IdStudent =
               Int32.Parse(classDG.SelectId());


                if (CbSemestr.SelectedItem == null)
                {
                    ClassFolder.ClassMB.MBError("Укажите семестр");
                }
                else if (CbDiscipline.SelectedItem == null)
                {
                    ClassFolder.ClassMB.MBError("Выберите дисциплину");
                }
                else if (CbMark.SelectedItem == null)
                {
                    ClassFolder.ClassMB.MBError("Укажите оценку");
                }
                else
                {                                      
                        try
                        {
                        if (CbSemestr.SelectedValue.ToString() == "1")
                        {
                            classRead.ReadDiscipline1(CbDiscipline);
                        }
                        else if (CbSemestr.SelectedValue.ToString() == "2")
                        {
                            classRead.ReadDiscipline2(CbDiscipline);
                        }
                        else if (CbSemestr.SelectedValue.ToString() == "3")
                        {
                            classRead.ReadDiscipline3(CbDiscipline);
                        }
                        else if (CbSemestr.SelectedValue.ToString() == "4")
                        {
                            classRead.ReadDiscipline4(CbDiscipline);
                        }
                        else if (CbSemestr.SelectedValue.ToString() == "5")
                        {
                            classRead.ReadDiscipline5(CbDiscipline);
                        }
                        else if (CbSemestr.SelectedValue.ToString() == "6")
                        {
                            classRead.ReadDiscipline6(CbDiscipline);
                        }
                        else if (CbSemestr.SelectedValue.ToString() == "7")
                        {
                            classRead.ReadDiscipline7(CbDiscipline);
                        }
                        else if (CbSemestr.SelectedValue.ToString() == "8")
                        {
                            classRead.ReadDiscipline8(CbDiscipline);
                        }

                        sqlConnection.Open();
                            sqlCommand = new SqlCommand("Insert into dbo.FinalMark(" +
                                "IdStudent, IdDiscipline, IdMark, IdSemestr, IdGroup) " +
                                "values(@IdStudent, @IdDiscipline, @IdMark, @IdSemestr, @IdGroup)", sqlConnection);
                            sqlCommand.Parameters.AddWithValue("IdStudent", ClassFolder.TableFolder.ClassStudent.IdStudent);
                            sqlCommand.Parameters.AddWithValue("IdDiscipline", ClassFolder.TableFolder.ClassDiscipline.IdDiscipline);
                            sqlCommand.Parameters.AddWithValue("IdMark", Int32.Parse(CbMark.SelectedValue.ToString()));
                            sqlCommand.Parameters.AddWithValue("IdSemestr", Int32.Parse(CbSemestr.SelectedValue.ToString()));
                            sqlCommand.Parameters.AddWithValue("IdGroup", ClassFolder.TableFolder.ClassUser.IdGroup);
                            sqlCommand.ExecuteNonQuery();                            
                            ClassFolder.ClassMB.MBInformation("Оценка выставлена");
                            CbMark.SelectedIndex = -1;
                        }
                        catch
                        {

                        }
                        finally
                        {
                            sqlConnection.Close();
                        }
                    
                }
            }
            catch
            {
                ClassFolder.ClassMB.MBError("Выберите студента");
            }                                                            
        }

        private void BtnAddDiscipline_Click(object sender, RoutedEventArgs e)
        {
            WindowFolder.WindowAdd.WinAddDiscipline winAddDiscipline =
                new WindowFolder.WindowAdd.WinAddDiscipline();
            winAddDiscipline.ShowDialog();
            CbDiscipline.Items.Clear();
            if(CbSemestr.SelectedItem==null)
            {
                classCB.LoadDiscipline(CbDiscipline);
            }
            else
            {
                classCB.LoadDisciplineChange(CbDiscipline, CbSemestr);
            }
        }

        private void CbSemestr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CbDiscipline.Items.Clear();
            classCB.LoadDisciplineChange(CbDiscipline, CbSemestr);            
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            classDG.LoadDB("Select * from dbo.ViewStudentDG " +
               $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and " +
               $"NameStatus='Активен' and " +              
               $"FIO like '{TbSearch.Text}%'");
        }

        private void Page_Loaded_1(object sender, RoutedEventArgs e)
        {
            classCB.LoadSemestr(CbSemestr);
            classCB.LoadDiscipline(CbDiscipline);
            classCB.LoadMarks(CbMark);
            classDG.LoadDB("Select * from dbo.ViewStudentDG " +
                $"where NameStatus='Активен' and IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}'");        
        }
    }
}
