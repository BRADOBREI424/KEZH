using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
using Excel = Microsoft.Office.Interop.Excel;


namespace KEZH.PageFolder.PageMarks
{
    /// <summary>
    /// Логика взаимодействия для PageMarksLists.xaml
    /// </summary>
    public partial class PageMarksLists : Page
    {
        SqlConnection sqlConnection =
      new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        ClassFolder.ClassCB classCB;
        ClassFolder.ClassDG classDGSem1;
        ClassFolder.ClassDG classDGSem2;
        ClassFolder.ClassDG classDGSem3;
        ClassFolder.ClassDG classDGSem4;
        ClassFolder.ClassDG classDGSem5;
        ClassFolder.ClassDG classDGSem6;
        ClassFolder.ClassDG classDGSem7;
        ClassFolder.ClassDG classDGSem8;
        ClassFolder.ClassRead classRead;
        public PageMarksLists()
        {
            InitializeComponent();
            classDGSem1 = new ClassFolder.ClassDG(DgSemestr1Marks);
            classDGSem2 = new ClassFolder.ClassDG(DgSemestr2Marks);
            classDGSem3 = new ClassFolder.ClassDG(DgSemestr3Marks);
            classDGSem4 = new ClassFolder.ClassDG(DgSemestr4Marks);
            classDGSem5 = new ClassFolder.ClassDG(DgSemestr5Marks);
            classDGSem6 = new ClassFolder.ClassDG(DgSemestr6Marks);
            classDGSem7 = new ClassFolder.ClassDG(DgSemestr7Marks);
            classDGSem8 = new ClassFolder.ClassDG(DgSemestr8Marks);
            classRead = new ClassFolder.ClassRead();
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Select IdMark from dbo.FinalMark " +
                    $"where IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}'", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                ClassFolder.TableFolder.ClassMark.IdMark = Int32.Parse(dataReader[0].ToString());               
            }
            catch
            {
                
            }
            finally
            {
                sqlConnection.Close();
            }
            if (ClassFolder.TableFolder.ClassMark.IdMark < 1)
            {
                NavigationService.GoBack();
                ClassFolder.ClassMB.MBError("У студента нет оценок");
            }
            else
            {



                classDGSem1.LoadDB("Select * from dbo.ViewFinalMark " +
                    $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and " +
                    $"IdSemestr='1' and NameStatus='Активен' and " +
                    $"IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}'");
                classDGSem2.LoadDB("Select * from dbo.ViewFinalMark " +
                    $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and " +
                    $"IdSemestr='2' and NameStatus='Активен' and " +
                    $"IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}'");
                classDGSem3.LoadDB("Select * from dbo.ViewFinalMark " +
                    $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and " +
                    $"IdSemestr='3' and NameStatus='Активен' and " +
                    $"IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}'");
                classDGSem4.LoadDB("Select * from dbo.ViewFinalMark " +
                    $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and " +
                    $"IdSemestr='4' and NameStatus='Активен' and " +
                    $"IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}'");
                classDGSem5.LoadDB("Select * from dbo.ViewFinalMark " +
                    $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and " +
                    $"IdSemestr='5' and NameStatus='Активен' and " +
                    $"IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}'");
                classDGSem6.LoadDB("Select * from dbo.ViewFinalMark " +
                    $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and " +
                    $"IdSemestr='6' and NameStatus='Активен' and " +
                    $"IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}'");
                classDGSem7.LoadDB("Select * from dbo.ViewFinalMark " +
                    $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and " +
                    $"IdSemestr='7' and NameStatus='Активен' and " +
                    $"IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}'");
                classDGSem8.LoadDB("Select * from dbo.ViewFinalMark " +
                    $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and " +
                    $"IdSemestr='8' and NameStatus='Активен' and " +
                    $"IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}'");



                classRead.ReadStudentToFinalMark(LblFIO, LblGroup);
                classRead.ReadMiddleMarkSem1(LblMiddleMarkValue1);
                classRead.ReadMiddleMarkSem2(LblMiddleMarkValue2);
                classRead.ReadMiddleMarkSem3(LblMiddleMarkValue3);
                classRead.ReadMiddleMarkSem4(LblMiddleMarkValue4);
                classRead.ReadMiddleMarkSem5(LblMiddleMarkValue5);
                classRead.ReadMiddleMarkSem6(LblMiddleMarkValue6);
                classRead.ReadMiddleMarkSem7(LblMiddleMarkValue7);
                classRead.ReadMiddleMarkSem8(LblMiddleMarkValue8);
                GetImageBinaryFromDb();
            }

        }
        private void GetImageBinaryFromDb()
        {
            
            
                sqlConnection.Open();
                sqlCommand = new SqlCommand($"SELECT [Photo] FROM dbo.Image WHERE IdImage = {ClassFolder.TableFolder.ClassImage.IdImage}", sqlConnection);

                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    byte[] imageBytes = (byte[])dataReader[0];
                    MemoryStream ms = new MemoryStream();
                    ms.Write(imageBytes, 0, imageBytes.Length);
                    ms.Seek(0, SeekOrigin.Begin);
                    BitmapImage bmp = new BitmapImage();
                    bmp.BeginInit();
                    bmp.StreamSource = ms;
                    bmp.EndInit();
                    ImgPhoto.Source = bmp;
                }
                sqlConnection.Close();
            
        }

        private void BtnExport1_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

            for (int j = 0; j < DgSemestr1Marks.Columns.Count; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = DgSemestr1Marks.Columns[j].Header;
            }
            for (int i = 0; i < DgSemestr1Marks.Columns.Count; i++)
            {
                for (int j = 0; j < DgSemestr1Marks.Items.Count; j++)
                {
                    TextBlock b = DgSemestr1Marks.Columns[i].GetCellContent(DgSemestr1Marks.Items[j]) as TextBlock;
                    Excel.Range myRange = (Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }

            sheet1.Columns.AutoFit();
        }

        private void BtnExport2_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

            for (int j = 0; j < DgSemestr2Marks.Columns.Count; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = DgSemestr2Marks.Columns[j].Header;
            }
            for (int i = 0; i < DgSemestr2Marks.Columns.Count; i++)
            {
                for (int j = 0; j < DgSemestr2Marks.Items.Count; j++)
                {
                    TextBlock b = DgSemestr2Marks.Columns[i].GetCellContent(DgSemestr2Marks.Items[j]) as TextBlock;
                    Excel.Range myRange = (Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }

            sheet1.Columns.AutoFit();
        }

        private void BtnExport3_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

            for (int j = 0; j < DgSemestr3Marks.Columns.Count; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = DgSemestr3Marks.Columns[j].Header;
            }
            for (int i = 0; i < DgSemestr3Marks.Columns.Count; i++)
            {
                for (int j = 0; j < DgSemestr3Marks.Items.Count; j++)
                {
                    TextBlock b = DgSemestr3Marks.Columns[i].GetCellContent(DgSemestr3Marks.Items[j]) as TextBlock;
                    Excel.Range myRange = (Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }

            sheet1.Columns.AutoFit();
        }

        private void BtnExport4_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

            for (int j = 0; j < DgSemestr4Marks.Columns.Count; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = DgSemestr4Marks.Columns[j].Header;
            }
            for (int i = 0; i < DgSemestr4Marks.Columns.Count; i++)
            {
                for (int j = 0; j < DgSemestr4Marks.Items.Count; j++)
                {
                    TextBlock b = DgSemestr4Marks.Columns[i].GetCellContent(DgSemestr4Marks.Items[j]) as TextBlock;
                    Excel.Range myRange = (Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }

            sheet1.Columns.AutoFit();
        }

        private void BtnExport5_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

            for (int j = 0; j < DgSemestr5Marks.Columns.Count; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = DgSemestr5Marks.Columns[j].Header;
            }
            for (int i = 0; i < DgSemestr5Marks.Columns.Count; i++)
            {
                for (int j = 0; j < DgSemestr5Marks.Items.Count; j++)
                {
                    TextBlock b = DgSemestr5Marks.Columns[i].GetCellContent(DgSemestr5Marks.Items[j]) as TextBlock;
                    Excel.Range myRange = (Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }

            sheet1.Columns.AutoFit();
        }

        private void BtnExport6_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

            for (int j = 0; j < DgSemestr6Marks.Columns.Count; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = DgSemestr6Marks.Columns[j].Header;
            }
            for (int i = 0; i < DgSemestr6Marks.Columns.Count; i++)
            {
                for (int j = 0; j < DgSemestr6Marks.Items.Count; j++)
                {
                    TextBlock b = DgSemestr6Marks.Columns[i].GetCellContent(DgSemestr6Marks.Items[j]) as TextBlock;
                    Excel.Range myRange = (Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }

            sheet1.Columns.AutoFit();
        }

        private void BtnExport7_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

            for (int j = 0; j < DgSemestr7Marks.Columns.Count; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = DgSemestr7Marks.Columns[j].Header;
            }
            for (int i = 0; i < DgSemestr7Marks.Columns.Count; i++)
            {
                for (int j = 0; j < DgSemestr7Marks.Items.Count; j++)
                {
                    TextBlock b = DgSemestr7Marks.Columns[i].GetCellContent(DgSemestr7Marks.Items[j]) as TextBlock;
                    Excel.Range myRange = (Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }

            sheet1.Columns.AutoFit();
        }

        private void BtnExport8_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

            for (int j = 0; j < DgSemestr8Marks.Columns.Count; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = DgSemestr8Marks.Columns[j].Header;
            }
            for (int i = 0; i < DgSemestr8Marks.Columns.Count; i++)
            {
                for (int j = 0; j < DgSemestr8Marks.Items.Count; j++)
                {
                    TextBlock b = DgSemestr8Marks.Columns[i].GetCellContent(DgSemestr8Marks.Items[j]) as TextBlock;
                    Excel.Range myRange = (Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }

            sheet1.Columns.AutoFit();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ClassFolder.TableFolder.ClassStudent.IdStudent = -1;
            ClassFolder.TableFolder.ClassMark.IdMark = 0;
            NavigationService.GoBack();
        }      

        private void MenuItemDelMark1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassMark.IdMarkInList = Int32.Parse(classDGSem1.SelectId());

                try
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить оценку?",
                                     "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand($"Delete FinalMark " +
                            $"where IdFinalMark='{ClassFolder.TableFolder.ClassMark.IdMarkInList}'", sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        ClassFolder.ClassMB.MBInformation("Оценка удалена");
                        classDGSem1.LoadDB("Select * from dbo.ViewFinalMark " +
                      $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and " +
                      $"IdSemestr='1' and NameStatus='Активен' and " +
                      $"IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}'");
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
            catch (Exception)
            {
                ClassFolder.ClassMB.MBError("Выберите строку");
            }
        }       

        private void MenuItemDelMark2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassMark.IdMarkInList = Int32.Parse(classDGSem2.SelectId());

                try
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить оценку?",
                                     "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand($"Delete FinalMark " +
                            $"where IdFinalMark='{ClassFolder.TableFolder.ClassMark.IdMarkInList}'", sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        ClassFolder.ClassMB.MBInformation("Оценка удалена");
                        classDGSem1.LoadDB("Select * from dbo.ViewFinalMark " +
                      $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and " +
                      $"IdSemestr='2' and NameStatus='Активен' and " +
                      $"IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}'");
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
            catch (Exception)
            {
                ClassFolder.ClassMB.MBError("Выберите строку");
            }
        }

        private void MenuItemDelMark3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassMark.IdMarkInList = Int32.Parse(classDGSem3.SelectId());

                try
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить оценку?",
                                     "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand($"Delete FinalMark " +
                            $"where IdFinalMark='{ClassFolder.TableFolder.ClassMark.IdMarkInList}'", sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        ClassFolder.ClassMB.MBInformation("Оценка удалена");
                        classDGSem1.LoadDB("Select * from dbo.ViewFinalMark " +
                      $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and " +
                      $"IdSemestr='3' and NameStatus='Активен' and " +
                      $"IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}'");
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
            catch (Exception)
            {
                ClassFolder.ClassMB.MBError("Выберите строку");
            }
        }

        private void MenuItemDelMark4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassMark.IdMarkInList = Int32.Parse(classDGSem4.SelectId());

                try
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить оценку?",
                                     "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand($"Delete FinalMark " +
                            $"where IdFinalMark='{ClassFolder.TableFolder.ClassMark.IdMarkInList}'", sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        ClassFolder.ClassMB.MBInformation("Оценка удалена");
                        classDGSem1.LoadDB("Select * from dbo.ViewFinalMark " +
                      $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and " +
                      $"IdSemestr='4' and NameStatus='Активен' and " +
                      $"IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}'");
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
            catch (Exception)
            {
                ClassFolder.ClassMB.MBError("Выберите строку");
            }
        }

        private void MenuItemDelMark5_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassMark.IdMarkInList = Int32.Parse(classDGSem5.SelectId());

                try
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить оценку?",
                                     "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand($"Delete FinalMark " +
                            $"where IdFinalMark='{ClassFolder.TableFolder.ClassMark.IdMarkInList}'", sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        ClassFolder.ClassMB.MBInformation("Оценка удалена");
                        classDGSem1.LoadDB("Select * from dbo.ViewFinalMark " +
                      $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and " +
                      $"IdSemestr='5' and NameStatus='Активен' and " +
                      $"IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}'");
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
            catch (Exception)
            {
                ClassFolder.ClassMB.MBError("Выберите строку");
            }
        }

        private void MenuItemDelMark6_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassMark.IdMarkInList = Int32.Parse(classDGSem6.SelectId());

                try
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить оценку?",
                                     "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand($"Delete FinalMark " +
                            $"where IdFinalMark='{ClassFolder.TableFolder.ClassMark.IdMarkInList}'", sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        ClassFolder.ClassMB.MBInformation("Оценка удалена");
                        classDGSem1.LoadDB("Select * from dbo.ViewFinalMark " +
                      $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and " +
                      $"IdSemestr='6' and NameStatus='Активен' and " +
                      $"IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}'");
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
            catch (Exception)
            {
                ClassFolder.ClassMB.MBError("Выберите строку");
            }
        }

        private void MenuItemDelMark7_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassMark.IdMarkInList = Int32.Parse(classDGSem7.SelectId());

                try
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить оценку?",
                                     "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand($"Delete FinalMark " +
                            $"where IdFinalMark='{ClassFolder.TableFolder.ClassMark.IdMarkInList}'", sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        ClassFolder.ClassMB.MBInformation("Оценка удалена");
                        classDGSem1.LoadDB("Select * from dbo.ViewFinalMark " +
                      $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and " +
                      $"IdSemestr='7' and NameStatus='Активен' and " +
                      $"IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}'");
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
            catch (Exception)
            {
                ClassFolder.ClassMB.MBError("Выберите строку");
            }
        }

        private void MenuItemDelMark8_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassMark.IdMarkInList = Int32.Parse(classDGSem8.SelectId());

                try
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить оценку?",
                                     "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand($"Delete FinalMark " +
                            $"where IdFinalMark='{ClassFolder.TableFolder.ClassMark.IdMarkInList}'", sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        ClassFolder.ClassMB.MBInformation("Оценка удалена");
                        classDGSem1.LoadDB("Select * from dbo.ViewFinalMark " +
                      $"where IdGroup='{ClassFolder.TableFolder.ClassUser.IdGroup}' and " +
                      $"IdSemestr='8' and NameStatus='Активен' and " +
                      $"IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}'");
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
            catch (Exception)
            {
                ClassFolder.ClassMB.MBError("Выберите строку");
            }
        }
    }
}
