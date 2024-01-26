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

namespace KEZH.PageFolder.PageEditComboBox
{
    /// <summary>
    /// Логика взаимодействия для EditComboBox.xaml
    /// </summary>
    public partial class EditComboBox : Page
    {
        SqlConnection sqlConnection =
      new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        ClassFolder.ClassDG classDGCity;
        ClassFolder.ClassDG classDGAuthority;
        ClassFolder.ClassDG classDGPlaceOfBorn;
        ClassFolder.ClassDG classDGStreet;
        ClassFolder.ClassDG classDGDiscipline;
        ClassFolder.ClassDG classDGDisciplineToTimeTable;
        ClassFolder.ClassCB classCB;
        ClassFolder.ClassEdit classEdit;
        ClassFolder.ClassRead classRead;
        public EditComboBox()
        {
            InitializeComponent();
            classDGAuthority = new ClassFolder.ClassDG(dgPassword);
            classDGCity = new ClassFolder.ClassDG(dgCity);
            classDGDiscipline = new ClassFolder.ClassDG(dgDiscipline);
            classDGDisciplineToTimeTable = new ClassFolder.ClassDG(dgDisciplineTimeTable);
            classDGPlaceOfBorn = new ClassFolder.ClassDG(dgBirth);
            classDGStreet = new ClassFolder.ClassDG(dgStreet);
            classCB = new ClassFolder.ClassCB();
            classEdit = new ClassFolder.ClassEdit();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            classDGAuthority.LoadDB("Select * from dbo.IssuedByWhom");
            classDGCity.LoadDB("Select * from dbo.City where IdCity!=3");
            classDGDiscipline.LoadDB("Select * from dbo.Discipline order by IdSemestr asc");
            classDGDisciplineToTimeTable.LoadDB("Select * from dbo.DiscipplineToTimeTable where IdDisciplineT!=5 and IdDisciplineT!=6 order by IdSemestr asc");
            classDGPlaceOfBorn.LoadDB("Select * from dbo.PlaceOfBorn");
            classDGStreet.LoadDB("Select * from dbo.Street where IdStreet!=3");
            classCB.LoadSemestr(cbSemestr);
            classCB.LoadSemestrToTimeTable(cbSemestrTimeTable);
        }

        private void dgCity_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassCity.IdCity = Int32.Parse(classDGCity.SelectId());
                btEdit.IsEnabled = true;
                btOtmena.IsEnabled = true;
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand($"Select * from dbo.City " +
                        $"where IdCity='{ClassFolder.TableFolder.ClassCity.IdCity}'", sqlConnection);
                    dataReader = sqlCommand.ExecuteReader();
                    dataReader.Read();

                    TBCity.Text = dataReader[1].ToString();

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
            catch 
            {
                ClassFolder.ClassMB.MBError("Выберите строку");
            }

           
        }

        private void dgPassword_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassPassport.IdIssuedByWhom = Int32.Parse(classDGAuthority.SelectId());
                BtEdit2.IsEnabled = true;
                BtOtmena2.IsEnabled = true;
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand($"Select * from dbo.IssuedByWhom " +
                        $"where IdAuthority='{ClassFolder.TableFolder.ClassPassport.IdIssuedByWhom}'", sqlConnection);
                    dataReader = sqlCommand.ExecuteReader();
                    dataReader.Read();

                    TBPassword.Text = dataReader[1].ToString();

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
            catch
            {
                ClassFolder.ClassMB.MBError("Выберите строку");
            }
        }

        private void dgBirth_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassPassport.IdPlaceOfBorn = Int32.Parse(classDGPlaceOfBorn.SelectId());
                BtEdit3.IsEnabled = true;
                BtOtmena3.IsEnabled = true;
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand($"Select * from dbo.PlaceOfBorn " +
                        $"where IdPlaceOfBorn='{ClassFolder.TableFolder.ClassPassport.IdPlaceOfBorn}'", sqlConnection);
                    dataReader = sqlCommand.ExecuteReader();
                    dataReader.Read();

                    TBBirth.Text = dataReader[1].ToString();

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
            catch
            {
                ClassFolder.ClassMB.MBError("Выберите строку");
            }
        }

        private void dgStreet_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassStreet.IdStreet = Int32.Parse(classDGStreet.SelectId());
                BtEdit4.IsEnabled = true;
                BtOtmena4.IsEnabled = true;
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand($"Select * from dbo.Street " +
                        $"where IdStreet='{ClassFolder.TableFolder.ClassStreet.IdStreet}'", sqlConnection);
                    dataReader = sqlCommand.ExecuteReader();
                    dataReader.Read();

                    TBStreet.Text = dataReader[1].ToString();

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
            catch
            {
                ClassFolder.ClassMB.MBError("Выберите строку");
            }
        }

        private void dgDiscipline_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            try
            {
                ClassFolder.TableFolder.ClassDiscipline.IdDiscipline = Int32.Parse(classDGDiscipline.SelectId());
                BtEdit5.IsEnabled = true;
                BtOtmena5.IsEnabled = true;
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand($"Select * from dbo.Discipline " +
                        $"where IdDiscipline='{ClassFolder.TableFolder.ClassDiscipline.IdDiscipline}'", sqlConnection);
                    dataReader = sqlCommand.ExecuteReader();
                    dataReader.Read();

                    cbSemestr.Text = dataReader[4].ToString();
                    TBCypher.Text = dataReader[1].ToString();
                    TBNameDiscipline.Text = dataReader[2].ToString();

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
            catch
            {
                ClassFolder.ClassMB.MBError("Выберите строку");
            }
        }

        private void dgDisciplineTimeTable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassDiscipline.IdDisciplineToTimeTable = Int32.Parse(classDGDisciplineToTimeTable.SelectId());
                
                BtEdit6.IsEnabled = true;
                BtOtmena6.IsEnabled = true;
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand($"Select * from dbo.DiscipplineToTimeTable " +
                        $"where IdDisciplineT='{ClassFolder.TableFolder.ClassDiscipline.IdDisciplineToTimeTable}'", sqlConnection);
                    dataReader = sqlCommand.ExecuteReader();
                    dataReader.Read();

                    cbSemestrTimeTable.Text = dataReader[4].ToString();
                    TBCypherTimetable.Text = dataReader[1].ToString();
                    TBNameDisciplineTimeTable.Text = dataReader[2].ToString();

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
            catch
            {
                ClassFolder.ClassMB.MBError("Выберите строку");
            }
        }

        private void TbSearch1_TextChanged(object sender, TextChangedEventArgs e)
        {            
            classDGCity.LoadDB($"Select * from dbo.City where IdCity!=3 and NameCity like '%{TbSearch1.Text}%'");
        }

        private void TBSearch2_TextChanged(object sender, TextChangedEventArgs e)
        {
            classDGAuthority.LoadDB($"Select * from dbo.IssuedByWhom " +
                $"where NameAuthority like '%{TBSearch2.Text}%'");
        }

        private void tbSearch3_TextChanged(object sender, TextChangedEventArgs e)
        {
            classDGPlaceOfBorn.LoadDB($"Select * from dbo.PlaceOfBorn where NamePlaceOfBorn like '%{tbSearch3.Text}%'");
        }

        private void tbSearch4_TextChanged(object sender, TextChangedEventArgs e)
        {
            classDGStreet.LoadDB($"Select * from dbo.Street where IdStreet!=3 and NameStreet like '%{tbSearch4.Text}%'");
        }

        private void tbSearch5_TextChanged(object sender, TextChangedEventArgs e)
        {
            classDGDiscipline.LoadDB($"Select * from dbo.Discipline where NameDiscipline like '%{tbSearch5.Text}%' order by IdSemestr asc");
        }

        private void tbSearch6_TextChanged(object sender, TextChangedEventArgs e)
        {
            classDGDisciplineToTimeTable.LoadDB($"Select * from dbo.DiscipplineToTimeTable where IdDisciplineT!=5 and IdDisciplineT!=6 and NameDiscipline like '%{tbSearch6.Text}%' order by IdSemestr asc");
        }

        private void btOtmena_Click(object sender, RoutedEventArgs e)
        {
            TBBirth.Text = null;
            TBCity.Text = null;
            TBCypher.Text = null;
            TBCypherTimetable.Text = null;
            TBNameDiscipline.Text = null;
            TBNameDisciplineTimeTable.Text = null;
            TBPassword.Text = null;
            TBStreet.Text = null;
            cbSemestr.SelectedIndex = -1;
            cbSemestrTimeTable.SelectedIndex = -1;
        }

        private void btEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                classEdit.Edit($"Update dbo.City " +
                        $"set NameCity='{TBCity.Text}' " +
                        $"where IdCity='{ClassFolder.TableFolder.ClassCity.IdCity}'");
                ClassFolder.ClassMB.MBInformation("Данные успешно отредактированы");
                classDGCity.LoadDB("Select * from dbo.City where IdCity!=3");

            }
            catch
            {
             
            }
        }

        private void BtEdit2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                classEdit.Edit($"Update dbo.IssuedByWhom " +
                            $"set NameAuthority='{TBPassword.Text}' " +
                            $"where IdAuthority='{ClassFolder.TableFolder.ClassPassport.IdIssuedByWhom}'");
                ClassFolder.ClassMB.MBInformation("Данные успешно отредактированы");
                classDGAuthority.LoadDB("Select * from dbo.IssuedByWhom");
            }
            catch
            {

            }
        }

        private void BtEdit3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                classEdit.Edit($"Update dbo.PlaceOfBorn " +
                           $"set NamePlaceOfBorn='{TBBirth.Text}' " +
                           $"where IdPlaceOfBorn='{ClassFolder.TableFolder.ClassPassport.IdPlaceOfBorn}'");
                ClassFolder.ClassMB.MBInformation("Данные успешно отредактированы");
                classDGPlaceOfBorn.LoadDB("Select * from dbo.PlaceOfBorn");
            }
            catch
            {

            }
        }

        private void BtEdit4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                classEdit.Edit($"Update dbo.Street " +
                           $"set NameStreet='{TBStreet.Text}' " +
                           $"where IdStreet='{ClassFolder.TableFolder.ClassStreet.IdStreet}'");
                ClassFolder.ClassMB.MBInformation("Данные успешно отредактированы");
                classDGStreet.LoadDB("Select * from dbo.Street where IdStreet!=3");
            }
            catch
            {

            }
        }

        private void BtEdit5_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TBCypher.Text) && string.IsNullOrEmpty(TBNameDiscipline.Text) && cbSemestr.SelectedItem == null)
                {
                    ClassFolder.ClassMB.MBError("Воспользуйтесть удалением");
                }
                else
                {
                    
                        classEdit.Edit($"Update dbo.Discipline " +
                                  $"set Cypher='{TBCypher.Text}', " +
                                  $"NameDiscipline='{TBNameDiscipline.Text}', " +
                                  $"IdSemestr='{Int32.Parse(cbSemestr.SelectedValue.ToString())}'" +
                                  $"where IdDiscipline='{ClassFolder.TableFolder.ClassDiscipline.IdDiscipline}'");
                    

                    ClassFolder.ClassMB.MBInformation("Данные успешно отредактированы");
                    classDGDiscipline.LoadDB("Select * from dbo.Discipline order by IdSemestr asc");
                }
            }
            catch
            {

            }
        }

        private void BtEdit6_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TBCypherTimetable.Text) && string.IsNullOrEmpty(TBNameDisciplineTimeTable.Text) && cbSemestr.SelectedItem == null)
                {
                    ClassFolder.ClassMB.MBError("Воспользуйтесть удалением");
                }
                else
                {


                    classEdit.Edit($"Update dbo.DiscipplineToTimeTable " +
                                  $"set Cypher='{TBCypherTimetable.Text}', " +
                                  $"NameDiscipline='{TBNameDisciplineTimeTable.Text}', " +
                                  $"IdSemestr='{Int32.Parse(cbSemestrTimeTable.SelectedValue.ToString())}'" +
                                  $"where IdDisciplineT='{ClassFolder.TableFolder.ClassDiscipline.IdDisciplineToTimeTable}'");

                    ClassFolder.ClassMB.MBInformation("Данные успешно отредактированы");
                    classDGDisciplineToTimeTable.LoadDB("Select * from dbo.DiscipplineToTimeTable where IdDisciplineT!=5 and IdDisciplineT!=6 order by IdSemestr asc");
                }
            }
            catch(Exception ex)
            {
                ClassFolder.ClassMB.MBError(ex);
            }
        }

        private void DelCity_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить город?",
                                    "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    ClassFolder.TableFolder.ClassCity.IdCity = Int32.Parse(classDGCity.SelectId());
                    try
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand($"Delete City " +
                            $"where IdCity='{ClassFolder.TableFolder.ClassCity.IdCity}'", sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        ClassFolder.ClassMB.MBInformation("Строка удалена");
                        classDGCity.LoadDB("Select * from dbo.City where IdCity!=3");
                    }
                    catch
                    {
                        ClassFolder.ClassMB.MBError("Город используется!");
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
            catch
            {
                ClassFolder.ClassMB.MBError("Выберите строку!");
            }
            
        }

        private void Delauthority_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить орган выдавший паспорт?",
                                    "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    ClassFolder.TableFolder.ClassPassport.IdIssuedByWhom = Int32.Parse(classDGAuthority.SelectId());
                    try
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand($"Delete IssuedByWhom " +
                            $"where IdAuthority='{ClassFolder.TableFolder.ClassPassport.IdIssuedByWhom}'", sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        ClassFolder.ClassMB.MBInformation("Строка удалена");
                        classDGAuthority.LoadDB("Select * from dbo.IssuedByWhom");
                    }
                    catch
                    {
                        ClassFolder.ClassMB.MBError("Орган выдавший паспорт используется!");
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
            catch
            {
                ClassFolder.ClassMB.MBError("Выберите строку!");
            }
        }

        private void DelPalceOfBorn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить место рождения?",
                                    "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    ClassFolder.TableFolder.ClassPassport.IdPlaceOfBorn = Int32.Parse(classDGPlaceOfBorn.SelectId());
                    try
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand($"Delete PlaceOfBorn " +
                            $"where IdPlaceOfBorn='{ClassFolder.TableFolder.ClassPassport.IdPlaceOfBorn}'", sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        ClassFolder.ClassMB.MBInformation("Строка удалена");
                        classDGPlaceOfBorn.LoadDB("Select * from dbo.PlaceOfBorn");
                    }
                    catch
                    {
                        ClassFolder.ClassMB.MBError("Место рождения используется!");
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
            catch
            {
                ClassFolder.ClassMB.MBError("Выберите строку!");
            }
        }

        private void DelStreet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить улицу?",
                                    "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    ClassFolder.TableFolder.ClassStreet.IdStreet = Int32.Parse(classDGStreet.SelectId());
                    try
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand($"Delete Street " +
                            $"where IdStreet='{ClassFolder.TableFolder.ClassStreet.IdStreet}'", sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        ClassFolder.ClassMB.MBInformation("Строка удалена");
                        classDGStreet.LoadDB("Select * from dbo.Street where IdStreet!=3");
                    }
                    catch
                    {
                        ClassFolder.ClassMB.MBError("Улица используется!");
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
            catch
            {
                ClassFolder.ClassMB.MBError("Выберите строку!");
            }
        }

        private void DelDiscipline_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить дисциплину?",
                                    "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    ClassFolder.TableFolder.ClassDiscipline.IdDiscipline = Int32.Parse(classDGDiscipline.SelectId());
                    try
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand($"Delete Discipline " +
                            $"where IdDiscipline='{ClassFolder.TableFolder.ClassDiscipline.IdDiscipline}'", sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        ClassFolder.ClassMB.MBInformation("Строка удалена");
                        classDGDiscipline.LoadDB("Select * from dbo.Discipline order by IdSemestr asc");
                    }
                    catch
                    {
                        ClassFolder.ClassMB.MBError("Дисциплина используется!");
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
            catch
            {
                ClassFolder.ClassMB.MBError("Выберите строку!");
            }
        }

        private void DelDisciplineFoTimeTable_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить дисциплину?",
                                    "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    ClassFolder.TableFolder.ClassDiscipline.IdDisciplineToTimeTable = Int32.Parse(classDGDisciplineToTimeTable.SelectId());
                    try
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand($"Delete DiscipplineToTimeTable " +
                            $"where IdDisciplineT='{ClassFolder.TableFolder.ClassDiscipline.IdDisciplineToTimeTable}'", sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        ClassFolder.ClassMB.MBInformation("Строка удалена");
                        classDGDisciplineToTimeTable.LoadDB("Select * from dbo.DiscipplineToTimeTable where IdDisciplineT!=5 and IdDisciplineT!=6 order by IdSemestr asc");
                    }
                    catch
                    {
                        ClassFolder.ClassMB.MBError("Дисциплина используется!");
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
            catch
            {
                ClassFolder.ClassMB.MBError("Выберите строку!");
            }
        }
    }
}
