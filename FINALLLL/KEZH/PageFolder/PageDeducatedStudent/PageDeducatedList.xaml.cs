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

namespace KEZH.PageFolder.PageDeducatedStudent
{
    /// <summary>
    /// Логика взаимодействия для PageDeducatedList.xaml
    /// </summary>
    public partial class PageDeducatedList : Page
    {
        SqlConnection sqlConnection =
     new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        ClassFolder.ClassDG classDGAcadem;
        ClassFolder.ClassDG classDGTransfer;
        ClassFolder.ClassDG classDGDeduct;
        ClassFolder.ClassDG classDGRelease;
        ClassFolder.ClassEdit classEdit;
        public PageDeducatedList()
        {
            InitializeComponent();
            classDGAcadem = new ClassFolder.ClassDG(DgDeducatedStudentAcadem);
            classDGTransfer = new ClassFolder.ClassDG(DgDeducatedStudentTransfer);
            classDGDeduct = new ClassFolder.ClassDG(DgDeducatedStudentDeduct);
            classDGRelease = new ClassFolder.ClassDG(DgDeducatedStudentRelease);
            classEdit = new ClassFolder.ClassEdit();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            classDGAcadem.LoadDB("Select * from dbo.ViewStudentDG " +
                $"where NameStatus='Академичиский отпуск' and " +
                $"IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}'");
            classDGTransfer.LoadDB("Select * from dbo.ViewStudentDG " +
                $"where NameStatus='Перевод' and " +
                $"IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}'");
            classDGDeduct.LoadDB("Select * from dbo.ViewStudentDG " +
             $"where NameStatus='Отчисление' and " +
             $"IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}'");
            classDGRelease.LoadDB("Select * from dbo.ViewStudentDG " +
            $"where NameStatus='Выпуск' and " +
            $"IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}'");
        }

        private void TbSearchAcadem_TextChanged(object sender, TextChangedEventArgs e)
        {
            classDGAcadem.LoadDB("Select * from dbo.ViewStudentDG " +
                $"where NameStatus='Академичиский отпуск' and " +
                $"IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and " +
                $"FIO like '%{TbSearchAcadem.Text}%'");
        }

        private void TbSearchTransfer_TextChanged(object sender, TextChangedEventArgs e)
        {
            classDGTransfer.LoadDB("Select * from dbo.ViewStudentDG " +
               $"where NameStatus='Перевод' and " +
               $"IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and " +
               $"FIO like '%{TbSearchTransfer.Text}%'");
        }

        private void TbSearchDeduct_TextChanged(object sender, TextChangedEventArgs e)
        {
            classDGDeduct.LoadDB("Select * from dbo.ViewStudentDG " +
             $"where NameStatus='Отчисление' and " +
             $"IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and " +
             $"FIO like '%{TbSearchDeduct.Text}%'");
        }

        private void TbSearchRelease_TextChanged(object sender, TextChangedEventArgs e)
        {
            classDGRelease.LoadDB("Select * from dbo.ViewStudentDG " +
           $"where NameStatus='Выпуск' and " +
           $"IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and  " +
           $"FIO like '%{TbSearchRelease.Text}%'");
        }

        private void MiRecoverAcadem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassStudent.IdStudent = Int32.Parse(classDGAcadem.SelectId());
                classEdit.Edit("Update dbo.Student " +
                    "set IdStatus='1' " +
                    $"where IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}'");
                classDGAcadem.LoadDB("Select * from dbo.ViewStudentDG " +
               $"where NameStatus='Академичиский отпуск' and " +
               $"IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}'");
            }
            catch 
            {
                ClassFolder.ClassMB.MBError("Выберите студента");
            }           
        }

        private void MiRecoverTransfer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassStudent.IdStudent = Int32.Parse(classDGTransfer.SelectId());
                classEdit.Edit("Update dbo.Student " +
                   "set IdStatus='1' " +
                   $"where IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}'");
                classDGTransfer.LoadDB("Select * from dbo.ViewStudentDG " +
                $"where NameStatus='Перевод' and " +
                $"IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}'");
            }
            catch
            {
                ClassFolder.ClassMB.MBError("Выберите студента");
            }          
        }

        private void MiRecoverDeduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassStudent.IdStudent = Int32.Parse(classDGDeduct.SelectId());
                classEdit.Edit("Update dbo.Student " +
                    "set IdStatus='1' " +
                    $"where IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}'");
                classDGDeduct.LoadDB("Select * from dbo.ViewStudentDG " +
              $"where NameStatus='Отчисление' and " +
              $"IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}'");
            }
            catch
            {
                ClassFolder.ClassMB.MBError("Выберите студента");
            }           
        }

        private void MiRecoverRelease_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassStudent.IdStudent = Int32.Parse(classDGRelease.SelectId());
                classEdit.Edit("Update dbo.Student " +
                    "set IdStatus='1' " +
                    $"where IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}'");
                classDGRelease.LoadDB("Select * from dbo.ViewStudentDG " +
            $"where NameStatus='Выпуск' and " +
            $"IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}'");
            }
            catch
            {
                ClassFolder.ClassMB.MBError("Выберите студента");
            }         
        }
    }
}
