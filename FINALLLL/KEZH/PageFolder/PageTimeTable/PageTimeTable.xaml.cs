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

namespace KEZH.PageFolder.PageAttendance
{
    /// <summary>
    /// Логика взаимодействия для PageTimeTable.xaml
    /// </summary>
    public partial class PageTimeTable : Page
    {
        SqlConnection sqlConnection =
           new SqlConnection(App.ConnectionString());
        ClassFolder.ClassDG classDGSem1;
        ClassFolder.ClassDG classDGSem2;
        ClassFolder.ClassDG classDGSem3;
        ClassFolder.ClassDG classDGSem4;
        ClassFolder.ClassDG classDGSem5;
        ClassFolder.ClassDG classDGSem6;
        ClassFolder.ClassDG classDGSem7;
        ClassFolder.ClassDG classDGSem8;
        ClassFolder.ClassDG classDGSem9;
        ClassFolder.ClassDG classDGSem10;
        ClassFolder.ClassRead classRead;
        SqlCommand sqlCommand;


        public PageTimeTable()
        {
            InitializeComponent();
            classDGSem1 = new ClassFolder.ClassDG(dgDayWeed);
            classDGSem2 = new ClassFolder.ClassDG(dgDayWeed1);
            classDGSem3 = new ClassFolder.ClassDG(dgDayWeed2);
            classDGSem4 = new ClassFolder.ClassDG(dgDayWeed3);
            classDGSem5 = new ClassFolder.ClassDG(dgDayWeed4);
            classDGSem6 = new ClassFolder.ClassDG(dgDayWeed5);
            classDGSem7 = new ClassFolder.ClassDG(dgDayWeed6);
            classDGSem8 = new ClassFolder.ClassDG(dgDayWeed7);
            classDGSem9 = new ClassFolder.ClassDG(dgDayWeed8);
            classDGSem10 = new ClassFolder.ClassDG(dgDayWeed9);
            classRead = new ClassFolder.ClassRead();
            ClassFolder.ClassMB.frameTimeTable = frmTimeTable;
        }

        

        public void dgDayWeed_Loaded(object sender, RoutedEventArgs e)
        {
            classDGSem1.LoadDB("Select * from dbo.ViewTimeTable " +
              $"where NumberSemester='1' " +
              $"and DayWeek='Понедельник' and " +
              $"IdUser='{ClassFolder.TableFolder.ClassUser.IdUser}' " +
              $"Order by Number asc ");
        }

        private void dgDayWeed1_Loaded(object sender, RoutedEventArgs e)
        {
            classDGSem2.LoadDB("Select * from dbo.ViewTimeTable " +
              $"where NumberSemester='1' " +
              $"and DayWeek='Вторник' and " +
              $"IdUser='{ClassFolder.TableFolder.ClassUser.IdUser}' " +
              $"Order by Number asc ");
        }

        private void dgDayWeed2_Loaded(object sender, RoutedEventArgs e)
        {
            classDGSem3.LoadDB("Select * from dbo.ViewTimeTable " +
              $"where NumberSemester='1' " +
              $"and DayWeek='Среда' and " +
              $"IdUser='{ClassFolder.TableFolder.ClassUser.IdUser}' " +
              $"Order by Number asc");
        }

        private void dgDayWeed3_Loaded(object sender, RoutedEventArgs e)
        {
            classDGSem4.LoadDB("Select * from dbo.ViewTimeTable " +
              $"where NumberSemester='1' " +
              $"and DayWeek='Четверг' and " +
              $"IdUser='{ClassFolder.TableFolder.ClassUser.IdUser}' " +
              $"Order by Number asc");
        }

        private void dgDayWeed4_Loaded(object sender, RoutedEventArgs e)
        {
            classDGSem5.LoadDB("Select * from dbo.ViewTimeTable " +
              $"where NumberSemester='1' " +
              $"and DayWeek='Пятница' and " +
              $"IdUser='{ClassFolder.TableFolder.ClassUser.IdUser}' " +
              $"Order by Number asc");
        }

        private void dgDayWeed5_Loaded(object sender, RoutedEventArgs e)
        {
            classDGSem6.LoadDB("Select * from dbo.ViewTimeTable " +
              $"where NumberSemester='2' " +
              $"and DayWeek='Понедельник' and " +
              $"IdUser='{ClassFolder.TableFolder.ClassUser.IdUser}' " +
              $"Order by Number asc");
        }

        private void dgDayWeed6_Loaded(object sender, RoutedEventArgs e)
        {
            classDGSem7.LoadDB("Select * from dbo.ViewTimeTable " +
              $"where NumberSemester='2' " +
              $"and DayWeek='Вторник' and " +
              $"IdUser='{ClassFolder.TableFolder.ClassUser.IdUser}' " +
              $"Order by Number asc");
        }

        private void dgDayWeed7_Loaded(object sender, RoutedEventArgs e)
        {
            classDGSem8.LoadDB("Select * from dbo.ViewTimeTable " +
              $"where NumberSemester='2' " +
              $"and DayWeek='Среда' and " +
              $"IdUser='{ClassFolder.TableFolder.ClassUser.IdUser}' " +
              $"Order by Number asc");
        }

        private void dgDayWeed8_Loaded(object sender, RoutedEventArgs e)
        {
            classDGSem9.LoadDB("Select * from dbo.ViewTimeTable " +
              $"where NumberSemester='2' " +
              $"and DayWeek='Четверг' and " +
              $"IdUser='{ClassFolder.TableFolder.ClassUser.IdUser}' " +
              $"Order by Number asc");
        }

        private void dgDayWeed9_Loaded(object sender, RoutedEventArgs e)
        {
            classDGSem10.LoadDB("Select * from dbo.ViewTimeTable " +
              $"where NumberSemester='2' " +
              $"and DayWeek='Пятница' and " +
              $"IdUser='{ClassFolder.TableFolder.ClassUser.IdUser}' " +
              $"Order by Number asc");
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassTimeTable.IdTimeTable = Int32.Parse(classDGSem1.SelectId());

                try
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить пару?",
                                     "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand($"Delete TimeTable " +
                            $"where IdTimeTable='{ClassFolder.TableFolder.ClassTimeTable.IdTimeTable}'", sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        ClassFolder.ClassMB.MBInformation("Пара удалена");
                        classDGSem1.LoadDB("Select * from dbo.ViewTimeTable " +
             $"where NumberSemester='1' " +
             $"and DayWeek='Понедельник' and " +
             $"IdUser='{ClassFolder.TableFolder.ClassUser.IdUser}' " +
             $"Order by Number asc ");
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

        private void BtnDelete2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassTimeTable.IdTimeTable = Int32.Parse(classDGSem2.SelectId());

                try
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить пару?",
                                     "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand($"Delete TimeTable " +
                            $"where IdTimeTable='{ClassFolder.TableFolder.ClassTimeTable.IdTimeTable}'", sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        ClassFolder.ClassMB.MBInformation("Пара удалена");
                        classDGSem2.LoadDB("Select * from dbo.ViewTimeTable " +
              $"where NumberSemester='1' " +
              $"and DayWeek='Вторник' and " +
              $"IdUser='{ClassFolder.TableFolder.ClassUser.IdUser}' " +
              $"Order by Number asc ");
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

        private void BtnDelete3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassTimeTable.IdTimeTable = Int32.Parse(classDGSem3.SelectId());

                try
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить пару?",
                                     "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand($"Delete TimeTable " +
                            $"where IdTimeTable='{ClassFolder.TableFolder.ClassTimeTable.IdTimeTable}'", sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        ClassFolder.ClassMB.MBInformation("Пара удалена");
                        classDGSem3.LoadDB("Select * from dbo.ViewTimeTable " +
              $"where NumberSemester='1' " +
              $"and DayWeek='Среда' and " +
              $"IdUser='{ClassFolder.TableFolder.ClassUser.IdUser}' " +
              $"Order by Number asc");
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

        private void BtnDelete4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassTimeTable.IdTimeTable = Int32.Parse(classDGSem4.SelectId());

                try
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить пару?",
                                     "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand($"Delete TimeTable " +
                            $"where IdTimeTable='{ClassFolder.TableFolder.ClassTimeTable.IdTimeTable}'", sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        ClassFolder.ClassMB.MBInformation("Пара удалена");
                        classDGSem4.LoadDB("Select * from dbo.ViewTimeTable " +
               $"where NumberSemester='1' " +
               $"and DayWeek='Четверг' and " +
               $"IdUser='{ClassFolder.TableFolder.ClassUser.IdUser}' " +
               $"Order by Number asc");
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

        private void BtnDelete5_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassTimeTable.IdTimeTable = Int32.Parse(classDGSem5.SelectId());

                try
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить пару?",
                                     "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand($"Delete TimeTable " +
                            $"where IdTimeTable='{ClassFolder.TableFolder.ClassTimeTable.IdTimeTable}'", sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        ClassFolder.ClassMB.MBInformation("Пара удалена");
                        classDGSem5.LoadDB("Select * from dbo.ViewTimeTable " +
             $"where NumberSemester='1' " +
             $"and DayWeek='Пятница' and " +
             $"IdUser='{ClassFolder.TableFolder.ClassUser.IdUser}' " +
             $"Order by Number asc");
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

        private void BtnDelete6_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassTimeTable.IdTimeTable = Int32.Parse(classDGSem6.SelectId());

                try
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить пару?",
                                     "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand($"Delete TimeTable " +
                            $"where IdTimeTable='{ClassFolder.TableFolder.ClassTimeTable.IdTimeTable}'", sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        ClassFolder.ClassMB.MBInformation("Пара удалена");
                        classDGSem6.LoadDB("Select * from dbo.ViewTimeTable " +
              $"where NumberSemester='2' " +
              $"and DayWeek='Понедельник' and " +
              $"IdUser='{ClassFolder.TableFolder.ClassUser.IdUser}' " +
              $"Order by Number asc");
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

        private void BtnDelete7_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassTimeTable.IdTimeTable = Int32.Parse(classDGSem7.SelectId());

                try
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить пару?",
                                     "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand($"Delete TimeTable " +
                            $"where IdTimeTable='{ClassFolder.TableFolder.ClassTimeTable.IdTimeTable}'", sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        ClassFolder.ClassMB.MBInformation("Пара удалена");
                        classDGSem7.LoadDB("Select * from dbo.ViewTimeTable " +
              $"where NumberSemester='2' " +
              $"and DayWeek='Вторник' and " +
              $"IdUser='{ClassFolder.TableFolder.ClassUser.IdUser}' " +
              $"Order by Number asc");
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

        private void BtnDelete8_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassTimeTable.IdTimeTable = Int32.Parse(classDGSem8.SelectId());

                try
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить пару?",
                                     "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand($"Delete TimeTable " +
                            $"where IdTimeTable='{ClassFolder.TableFolder.ClassTimeTable.IdTimeTable}'", sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        ClassFolder.ClassMB.MBInformation("Пара удалена");
                        classDGSem8.LoadDB("Select * from dbo.ViewTimeTable " +
             $"where NumberSemester='2' " +
             $"and DayWeek='Среда' and " +
             $"IdUser='{ClassFolder.TableFolder.ClassUser.IdUser}' " +
             $"Order by Number asc");
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

        private void BtnDelete9_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassTimeTable.IdTimeTable = Int32.Parse(classDGSem9.SelectId());

                try
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить пару?",
                                     "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand($"Delete TimeTable " +
                            $"where IdTimeTable='{ClassFolder.TableFolder.ClassTimeTable.IdTimeTable}'", sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        ClassFolder.ClassMB.MBInformation("Пара удалена");
                        classDGSem9.LoadDB("Select * from dbo.ViewTimeTable " +
              $"where NumberSemester='2' " +
              $"and DayWeek='Четверг' and " +
              $"IdUser='{ClassFolder.TableFolder.ClassUser.IdUser}' " +
              $"Order by Number asc");
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

        private void BtnDelete10_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassTimeTable.IdTimeTable = Int32.Parse(classDGSem10.SelectId());

                try
                {
                    MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить пару?",
                                     "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand($"Delete TimeTable " +
                            $"where IdTimeTable='{ClassFolder.TableFolder.ClassTimeTable.IdTimeTable}'", sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        ClassFolder.ClassMB.MBInformation("Пара удалена");
                        classDGSem10.LoadDB("Select * from dbo.ViewTimeTable " +
              $"where NumberSemester='2' " +
              $"and DayWeek='Пятница' and " +
              $"IdUser='{ClassFolder.TableFolder.ClassUser.IdUser}' " +
              $"Order by Number asc");
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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            frmTimeTable.NavigationService.Navigate(new Uri("PageFolder/PageTimeTable/PageAdd.xaml", UriKind.Relative));
        }       

        private void dgDayWeed_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassTimeTable.IdTimeTable = Int32.Parse(classDGSem1.SelectId());
                classRead.RedDisciplineTimeTable(ClassFolder.TableFolder.ClassTimeTable.IdTimeTable);
                

                try
                {

                    frmTimeTable.NavigationService.RemoveBackEntry();
                    frmTimeTable.NavigationService.Navigate(new PageFolder.PageTimeTable.PageEdit());

                }
                catch (Exception ex)
                {
                    ClassFolder.ClassMB.MBError(ex);
                }
            }
            catch
            {
                ClassFolder.ClassMB.MBError("Выберите строку");
            }
        }



        private void dgDayWeed1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassTimeTable.IdTimeTable = Int32.Parse(classDGSem2.SelectId());
                classRead.RedDisciplineTimeTable(ClassFolder.TableFolder.ClassTimeTable.IdTimeTable);
                
                try
                {
                    frmTimeTable.NavigationService.RemoveBackEntry();
                    frmTimeTable.NavigationService.Navigate(new PageFolder.PageTimeTable.PageEdit());
                }
                catch (Exception ex)
                {
                    ClassFolder.ClassMB.MBError(ex);
                }
            }
            catch
            {
                ClassFolder.ClassMB.MBError("Выберите строку");
            }
        }

        private void dgDayWeed2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassTimeTable.IdTimeTable = Int32.Parse(classDGSem3.SelectId());
                classRead.RedDisciplineTimeTable(ClassFolder.TableFolder.ClassTimeTable.IdTimeTable);
                
                try
                {
                    frmTimeTable.NavigationService.RemoveBackEntry();
                    frmTimeTable.NavigationService.Navigate(new PageFolder.PageTimeTable.PageEdit());
                    
                }
                catch (Exception ex)
                {
                    ClassFolder.ClassMB.MBError(ex);
                }
            }
            catch
            {
                ClassFolder.ClassMB.MBError("Выберите строку");
            }
        }

        private void dgDayWeed3_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassTimeTable.IdTimeTable = Int32.Parse(classDGSem4.SelectId());
                classRead.RedDisciplineTimeTable(ClassFolder.TableFolder.ClassTimeTable.IdTimeTable);
                
                try
                {
                    frmTimeTable.NavigationService.RemoveBackEntry();
                    frmTimeTable.NavigationService.Navigate(new PageFolder.PageTimeTable.PageEdit());
                    
                }
                catch (Exception ex)
                {
                    ClassFolder.ClassMB.MBError(ex);
                }
            }
            catch 
            {
                ClassFolder.ClassMB.MBError("Выберите строку");
            }
        }

        private void dgDayWeed4_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassTimeTable.IdTimeTable = Int32.Parse(classDGSem5.SelectId());
                classRead.RedDisciplineTimeTable(ClassFolder.TableFolder.ClassTimeTable.IdTimeTable);
               
                try
                {
                    frmTimeTable.NavigationService.RemoveBackEntry();
                    frmTimeTable.NavigationService.Navigate(new PageFolder.PageTimeTable.PageEdit());
                    
                }
                catch (Exception ex)
                {
                    ClassFolder.ClassMB.MBError(ex);
                }
            }
            catch 
            {
                ClassFolder.ClassMB.MBError("Выберите строку");
            }
        }

        private void dgDayWeed5_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassTimeTable.IdTimeTable = Int32.Parse(classDGSem6.SelectId());
                classRead.RedDisciplineTimeTable(ClassFolder.TableFolder.ClassTimeTable.IdTimeTable);
               
                try
                {
                    frmTimeTable.NavigationService.RemoveBackEntry();
                    frmTimeTable.NavigationService.Navigate(new PageFolder.PageTimeTable.PageEdit());
                    
                }
                catch (Exception ex)
                {
                    ClassFolder.ClassMB.MBError(ex);
                }
            }
            catch 
            {
                ClassFolder.ClassMB.MBError("Выберите строку");
            }
        }

        private void dgDayWeed6_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassTimeTable.IdTimeTable = Int32.Parse(classDGSem7.SelectId());
                classRead.RedDisciplineTimeTable(ClassFolder.TableFolder.ClassTimeTable.IdTimeTable);
               
                try
                {
                    frmTimeTable.NavigationService.RemoveBackEntry();
                    frmTimeTable.NavigationService.Navigate(new PageFolder.PageTimeTable.PageEdit());
                   
                }
                catch (Exception ex)
                {
                    ClassFolder.ClassMB.MBError(ex);
                }
            }
            catch 
            {
                ClassFolder.ClassMB.MBError("Выберите строку");
            }
        }

        private void dgDayWeed7_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassTimeTable.IdTimeTable = Int32.Parse(classDGSem8.SelectId());
                classRead.RedDisciplineTimeTable(ClassFolder.TableFolder.ClassTimeTable.IdTimeTable);
               
                try
                {
                    frmTimeTable.NavigationService.RemoveBackEntry();
                    frmTimeTable.NavigationService.Navigate(new PageFolder.PageTimeTable.PageEdit());
                    
                }
                catch (Exception ex)
                {
                    ClassFolder.ClassMB.MBError(ex);
                }
            }
            catch 
            {
                ClassFolder.ClassMB.MBError("Выберите строку");
            }
        }

        private void dgDayWeed8_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassTimeTable.IdTimeTable = Int32.Parse(classDGSem9.SelectId());
                classRead.RedDisciplineTimeTable(ClassFolder.TableFolder.ClassTimeTable.IdTimeTable);
                
                try
                {
                    frmTimeTable.NavigationService.RemoveBackEntry();
                    frmTimeTable.NavigationService.Navigate(new PageFolder.PageTimeTable.PageEdit());
                   
                }
                catch (Exception ex)
                {
                    ClassFolder.ClassMB.MBError(ex);
                }
            }
            catch
            {
                ClassFolder.ClassMB.MBError("Выберите строку");
            }
        }

        private void dgDayWeed9_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassTimeTable.IdTimeTable = Int32.Parse(classDGSem10.SelectId());
                classRead.RedDisciplineTimeTable(ClassFolder.TableFolder.ClassTimeTable.IdTimeTable);
                
                try
                {
                    frmTimeTable.NavigationService.RemoveBackEntry();
                    frmTimeTable.NavigationService.Navigate(new PageFolder.PageTimeTable.PageEdit());
                    
                }
                catch (Exception ex)
                {
                    ClassFolder.ClassMB.MBError(ex);
                }
            }
            catch 
            {
                ClassFolder.ClassMB.MBError("Выберите строку");
            }
        }

       
       

        //private void Page_TargetUpdated(object sender, DataTransferEventArgs e)
        //{
        //    if (ClassFolder.TableFolder.ClassCounter.PastCounter != ClassFolder.TableFolder.ClassCounter.Counter)
        //    {
        //        classDGSem1.LoadDB("Select * from dbo.ViewTimeTable " +
        //            $"where NumberSemester='1' " +
        //            $"and DayWeek='Понедельник'");
        //    }
        //    else
        //    {

        //    }
        //}

        private void frmTimeTable_NavigationStopped(object sender, NavigationEventArgs e)
        {
            classDGSem1.LoadDB("Select * from dbo.ViewTimeTable " +
                   $"where NumberSemester='1' " +
                   $"and DayWeek='Понедельник'");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        
    }
}
