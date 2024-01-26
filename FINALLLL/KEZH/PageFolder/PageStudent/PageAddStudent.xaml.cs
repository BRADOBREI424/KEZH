using Microsoft.Win32;
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

namespace KEZH.PageFolder.PageStudent
{
    /// <summary>
    /// Логика взаимодействия для PageAddStudent.xaml
    /// </summary>
    public partial class PageAddStudent : Page
    {
        SqlConnection sqlConnection =
       new SqlConnection(App.ConnectionString());
        string s = App.ConnectionString();
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        ClassFolder.ClassCB classCB;
        ClassFolder.ClassRead classRead;
        ClassFolder.ClassAdd classAdd;
        public PageAddStudent()
        {
            InitializeComponent();
            classCB = new ClassFolder.ClassCB();
            classRead = new ClassFolder.ClassRead();
            classAdd = new ClassFolder.ClassAdd();
        }

        private void btnPlaceImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFolder.TableFolder.ClassImage images = new ClassFolder.TableFolder.ClassImage();

                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.ShowDialog();

                openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

                openFileDialog1.DefaultExt = ".jpeg";

                TbImage.Text = openFileDialog1.FileName;

                ImageSource imageSource = new BitmapImage(new Uri(TbImage.Text));

                ImageAdd.Source = imageSource;
            }
            catch
            {

            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbLastName.Text))
            {
                ClassFolder.ClassMB.MBError("Введите фамилию");
                TbLastName.Focus();
            }
            else if (string.IsNullOrEmpty(TbFirstName.Text))
            {
                ClassFolder.ClassMB.MBError("Введите имя");
                TbFirstName.Focus();
            }
            else if (CbGender.SelectedItem == null)
            {
                ClassFolder.ClassMB.MBError("Выберите пол");
                CbGender.Focus();
            }
            else if (DpDateOfBorn.SelectedDate.ToString() == "")
            {
                ClassFolder.ClassMB.MBError("Выберите дату рождения");
                DpDateOfBorn.Focus();
            }
            else if (string.IsNullOrEmpty(TbNumberPhone.Text))
            {
                ClassFolder.ClassMB.MBError("Введите номер телефона");
                TbNumberPhone.Focus();
            }
            else if (CbFamily.SelectedItem == null)
            {
                ClassFolder.ClassMB.MBError("Выберите семью");
                CbFamily.Focus();
            }
            else if (CbFamilyStatus.SelectedItem == null)
            {
                ClassFolder.ClassMB.MBError("Выберите семейный статус");
                CbFamilyStatus.Focus();
            }
            else if (string.IsNullOrEmpty(TbEmail.Text))
            {
                ClassFolder.ClassMB.MBError("Введите электронную почту");
                TbEmail.Focus();
            }
            else if(string.IsNullOrEmpty(TbOrder.Text))
            {
                ClassFolder.ClassMB.MBError("Введите номер приказа");
                TbOrder.Focus();
            }
            else if (DpDateOfOrder.SelectedDate.ToString() == "")
            {
                ClassFolder.ClassMB.MBError("Выберите дату приказа");
                DpDateOfOrder.Focus();
            }
            else if (string.IsNullOrEmpty(TbSeries.Text))
            {
                ClassFolder.ClassMB.MBError("Введите серию паспорта");
                TbSeries.Focus();
            }
            else if (string.IsNullOrEmpty(TbNumber.Text))
            {
                ClassFolder.ClassMB.MBError("Введите номер паспорта");
                TbNumber.Focus();
            }
            else if (CbIsuedByWhom.SelectedItem == null)
            {
                ClassFolder.ClassMB.MBError("Выберите кем выдан паспорт");
                CbIsuedByWhom.Focus();
            }
            else if (DpDateOfIsue.SelectedDate.ToString() == "")
            {
                ClassFolder.ClassMB.MBError("Выберите дату выдачи паспорта");
                DpDateOfIsue.Focus();
            }
            else if (string.IsNullOrEmpty(TbCode.Text))
            {
                ClassFolder.ClassMB.MBError("Введите код подразделения");
                TbCode.Focus();
            }
            else if (CbPlaceOfBorn.SelectedItem == null)
            {
                ClassFolder.ClassMB.MBError("Выберите место рождения");
                CbPlaceOfBorn.Focus();
            }
            else if (string.IsNullOrEmpty(TbHospital.Text))
            {
                ClassFolder.ClassMB.MBError("Введите медицинский полис");
                TbHospital.Focus();
            }
            else if (string.IsNullOrEmpty(TbINN.Text))
            {
                ClassFolder.ClassMB.MBError("Введите ИНН");
                TbINN.Focus();
            }
            else if (string.IsNullOrEmpty(TbSNILS.Text))
            {
                ClassFolder.ClassMB.MBError("Введите СНИЛС");
                TbSNILS.Focus();
            }
            else if (CbRegCity.SelectedItem == null)
            {
                ClassFolder.ClassMB.MBError("Выберите город по прописке");
                CbRegCity.Focus();
            }
            else if (CbRegStreet.SelectedItem == null)
            {
                ClassFolder.ClassMB.MBError("Выберите улицу по прописке");
                CbRegStreet.Focus();
            }
            else if (string.IsNullOrEmpty(TbRegPostcode.Text))
            {
                ClassFolder.ClassMB.MBError("Введите почтовый индекс по прописке");
                TbRegPostcode.Focus();
            }
            else if (string.IsNullOrEmpty(TbRegHouse.Text))
            {
                ClassFolder.ClassMB.MBError("Введите дом по прописке");
                TbRegHouse.Focus();
            }
            else if (string.IsNullOrEmpty(TbRegEnclosure.Text))
            {
                ClassFolder.ClassMB.MBError("Введите корпус по прописке");
                TbRegEnclosure.Focus();
            }
            else if (string.IsNullOrEmpty(TbRegAppartment.Text))
            {
                ClassFolder.ClassMB.MBError("Введите квартиру по прописке");
                TbRegAppartment.Focus();
            }
            else if (CbRealCity.SelectedItem == null)
            {
                ClassFolder.ClassMB.MBError("Выберите город по месту жительства");
                CbRealCity.Focus();
            }
            else if (CbRealStreet.SelectedItem == null)
            {
                ClassFolder.ClassMB.MBError("Выберите улицу по месту жительства");
                CbRealStreet.Focus();
            }
            else if (string.IsNullOrEmpty(TbRealPostcode.Text))
            {
                ClassFolder.ClassMB.MBError("Введите почтовый индекс по месту жительства");
                TbRealPostcode.Focus();
            }
            else if (string.IsNullOrEmpty(TbRealHouse.Text))
            {
                ClassFolder.ClassMB.MBError("Введите дом по месту жительства");
                TbRealHouse.Focus();
            }
            else if (string.IsNullOrEmpty(TbRealEnclosure.Text))
            {
                ClassFolder.ClassMB.MBError("Введите корпус по месту жительства");
                TbRealEnclosure.Focus();
            }
            else if (string.IsNullOrEmpty(TbRealAppartment.Text))
            {
                ClassFolder.ClassMB.MBError("Введите квартиру по месту жительства");
                TbRealAppartment.Focus();
            }
            else if (string.IsNullOrEmpty(TbImage.Text))
            {
                ClassFolder.ClassMB.MBError("Выберите фото студента");
                TbImage.Focus();
            }

            else if (string.IsNullOrEmpty(CbVremCity.Text) && string.IsNullOrEmpty(CbVremStreet.Text) && string.IsNullOrEmpty(TbVremPostcode.Text)
                && string.IsNullOrEmpty(TbVremHouse.Text) && string.IsNullOrEmpty(TbVremEnclosure.Text) && string.IsNullOrEmpty(TbVremAppartment.Text)
               && ChbNoMom.IsChecked == true && ChbNoPap.IsChecked == true && ChbNoMomGuard.IsChecked == true)
            {
                //+++
                AddAllNullAddDadGuard();
                ClassFolder.ClassMB.frame.Refresh();

            }
            else if (string.IsNullOrEmpty(CbVremCity.Text) && string.IsNullOrEmpty(CbVremStreet.Text) && string.IsNullOrEmpty(TbVremPostcode.Text)
                && string.IsNullOrEmpty(TbVremHouse.Text) && string.IsNullOrEmpty(TbVremEnclosure.Text) && string.IsNullOrEmpty(TbVremAppartment.Text)
               && ChbNoMom.IsChecked == true && ChbNoPap.IsChecked == true && ChbNoPapGuard.IsChecked == true)
            {
                //+++
                AddAllNullAddMomGuard();
                ClassFolder.ClassMB.frame.Refresh();
            }
            else if (string.IsNullOrEmpty(CbVremCity.Text) && string.IsNullOrEmpty(CbVremStreet.Text) && string.IsNullOrEmpty(TbVremPostcode.Text)
                && string.IsNullOrEmpty(TbVremHouse.Text) && string.IsNullOrEmpty(TbVremEnclosure.Text) && string.IsNullOrEmpty(TbVremAppartment.Text)
               && ChbNoMom.IsChecked == true && ChbNoPap.IsChecked == true)
            {
                //+++
                AddAllNullMomGuardDadGuard();
                ClassFolder.ClassMB.frame.Refresh();
            }
            else if (string.IsNullOrEmpty(CbVremCity.Text) && string.IsNullOrEmpty(CbVremStreet.Text) && string.IsNullOrEmpty(TbVremPostcode.Text)
                && string.IsNullOrEmpty(TbVremHouse.Text) && string.IsNullOrEmpty(TbVremEnclosure.Text) && string.IsNullOrEmpty(TbVremAppartment.Text)
               && ChbNoMomGuard.IsChecked == true && ChbNoPap.IsChecked == true && ChbNoPapGuard.IsChecked == true)
            {
                //+++
                AddAllNullAddMom();
                ClassFolder.ClassMB.frame.Refresh();
            }
            else if (string.IsNullOrEmpty(CbVremCity.Text) && string.IsNullOrEmpty(CbVremStreet.Text) && string.IsNullOrEmpty(TbVremPostcode.Text)
                && string.IsNullOrEmpty(TbVremHouse.Text) && string.IsNullOrEmpty(TbVremEnclosure.Text) && string.IsNullOrEmpty(TbVremAppartment.Text)
               && ChbNoMomGuard.IsChecked == true && ChbNoMom.IsChecked == true && ChbNoPapGuard.IsChecked == true)
            {
                //+++
                AddAllNullAddDad();
                ClassFolder.ClassMB.frame.Refresh();
            }
            else if (string.IsNullOrEmpty(CbVremCity.Text) && string.IsNullOrEmpty(CbVremStreet.Text) && string.IsNullOrEmpty(TbVremPostcode.Text)
                && string.IsNullOrEmpty(TbVremHouse.Text) && string.IsNullOrEmpty(TbVremEnclosure.Text) && string.IsNullOrEmpty(TbVremAppartment.Text)
               && ChbNoMomGuard.IsChecked == true && ChbNoPapGuard.IsChecked == true)
            {
                //+++
                AddAllNullMomDad();
                ClassFolder.ClassMB.frame.Refresh();
            }
            else if (string.IsNullOrEmpty(CbVremCity.Text) && string.IsNullOrEmpty(CbVremStreet.Text) && string.IsNullOrEmpty(TbVremPostcode.Text)
               && string.IsNullOrEmpty(TbVremHouse.Text) && string.IsNullOrEmpty(TbVremEnclosure.Text) && string.IsNullOrEmpty(TbVremAppartment.Text)
              && ChbNoPap.IsChecked == true && ChbNoMomGuard.IsChecked == true)
            {
                //+++
                AddAllNullMomDadGuard();
                ClassFolder.ClassMB.frame.Refresh();
            }
            else if (string.IsNullOrEmpty(CbVremCity.Text) && string.IsNullOrEmpty(CbVremStreet.Text) && string.IsNullOrEmpty(TbVremPostcode.Text)
               && string.IsNullOrEmpty(TbVremHouse.Text) && string.IsNullOrEmpty(TbVremEnclosure.Text) && string.IsNullOrEmpty(TbVremAppartment.Text)
              && ChbNoMom.IsChecked == true && ChbNoPapGuard.IsChecked == true)
            {
                //+++
                AddAllNullMomGuardDad();
                ClassFolder.ClassMB.frame.Refresh();
            }
            else if (ChbNoMom.IsChecked == true && ChbNoPap.IsChecked == true && ChbNoMomGuard.IsChecked == true)
            {
                //+++
                AddDadGuard();
                ClassFolder.ClassMB.frame.Refresh();
            }
            else if (ChbNoMom.IsChecked == true && ChbNoPap.IsChecked == true && ChbNoPapGuard.IsChecked == true)
            {
                //+++
                AddMomGuard();
                ClassFolder.ClassMB.frame.Refresh();
            }
            else if (ChbNoMom.IsChecked == true && ChbNoPap.IsChecked == true)
            {
                //+++
                MomGuardDadGuard();
                ClassFolder.ClassMB.frame.Refresh();
            }
            else if (ChbNoMomGuard.IsChecked == true && ChbNoPap.IsChecked == true && ChbNoPapGuard.IsChecked == true)
            {
                //+++
                AddMom();
                ClassFolder.ClassMB.frame.Refresh();
            }
            else if (ChbNoMomGuard.IsChecked == true && ChbNoMom.IsChecked == true && ChbNoPapGuard.IsChecked == true)
            {
                //+++
                AddDad();
                ClassFolder.ClassMB.frame.Refresh();
            }
            else if (ChbNoMomGuard.IsChecked == true && ChbNoPapGuard.IsChecked == true)
            {
                //+++
                MomDad();
                ClassFolder.ClassMB.frame.Refresh();
            }
            else if (ChbNoPap.IsChecked == true && ChbNoMomGuard.IsChecked == true)
            {
                //+++
                MomDadGuard();
                ClassFolder.ClassMB.frame.Refresh();
            }
            else if (ChbNoMom.IsChecked == true && ChbNoPapGuard.IsChecked == true)
            {
                //+++
                MomGuardDad();
                ClassFolder.ClassMB.frame.Refresh();
            }
            //TbCode.Text = null;
            //TbDadFirstName.Text = null;
            //TbDadFirstNameGuard.Text = null;
            //TbDadLastName.Text = null;
            //TbDadLastNameGuard.Text = null;
            //TbDadMiddleName.Text = null;
            //TbDadMiddleNameGuard.Text = null;
            //TbDadNumberPhone.Text = null;
            //TbDadNumberPhoneGuard.Text = null;
            //TbEmail.Text = null;
            //TbFirstName.Text = null;
            //TbHospital.Text = null;
            //TbImage.Text = null;
            //TbINN.Text = null;
            //TbLastName.Text = null;
            //TbMiddleName.Text = null;
            //TbMomFirstName.Text = null;
            //TbMomFirstNameGuard.Text = null;
            //TbMomLastName.Text = null;
            //TbMomLastNameGuard.Text = null;
            //TbMomMiddleName.Text = null;
            //TbMomMiddleNameGuard.Text = null;
            //TbMomNumberPhone.Text = null;
            //TbMomNumberPhoneGuard.Text = null;
            //TbNumber.Text = null;
            //TbNumberPhone.Text = null;
            //TbRealAppartment.Text = null;
            //TbRealEnclosure.Text = null;
            //TbRealHouse.Text = null;
            //TbRealPostcode.Text = null;
            //TbRegAppartment.Text = null;
            //TbRegEnclosure.Text = null;
            //TbRegHouse.Text = null;
            //TbRegPostcode.Text = null;
            //TbSeries.Text = null;
            //TbSNILS.Text = null;
            //TbVremAppartment.Text = null;
            //TbVremEnclosure.Text = null;
            //TbVremHouse.Text = null;
            //TbVremPostcode.Text = null;
            //CbFamily.SelectedIndex = -1;
            //CbFamilyStatus.SelectedIndex = -1;
            //CbGender.SelectedIndex = -1;
            //CbIsuedByWhom.SelectedIndex = -1;
            //CbPlaceOfBorn.SelectedIndex = -1;
            //CbRealCity.SelectedIndex = -1;
            //CbRealStreet.SelectedIndex = -1;
            //CbRegCity.SelectedIndex = -1;
            //CbRegStreet.SelectedIndex = -1;
            //CbVremCity.SelectedIndex = -1;
            //CbVremStreet.SelectedIndex = -1;
            //DpDateOfBorn.SelectedDate = null;
            //DpDateOfIsue.SelectedDate = null;

            

            //{
            //    try
            //    {
            //        sqlConnection.Open();
            //        sqlCommand = new SqlCommand("Insert into dbo.Registration(" +
            //            "PostcodeReg, IdCity, IdStreet, HouseReg, EnclosureReg, AppartmentReg) " +
            //            "Values(" +
            //            "@PostcodeReg, @IdCity, @IdStreet, @HouseReg, @EnclosureReg, @AppartmentReg)",
            //            sqlConnection);
            //        sqlCommand.Parameters.AddWithValue("PostcodeReg", Int32.Parse(TbRegPostcode.Text));
            //        sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRegCity.SelectedValue.ToString()));
            //        sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRegStreet.SelectedValue.ToString()));
            //        sqlCommand.Parameters.AddWithValue("HouseReg", TbRegHouse.Text);
            //        sqlCommand.Parameters.AddWithValue("EnclosureReg", TbRegEnclosure.Text);
            //        sqlCommand.Parameters.AddWithValue("AppartmentReg", Int32.Parse(TbRegAppartment.Text));
            //        sqlCommand.ExecuteNonQuery();
            //    }
            //     catch (Exception ex)
            //    {
            //        ClassFolder.ClassMB.MBError(ex);
            //    }
            //    finally
            //    {
            //        sqlConnection.Close();
            //    }
            //    classRead.ReadRegistration(CbRegCity, CbRegStreet, TbRegPostcode, TbRegHouse, TbRegEnclosure, TbRegAppartment);
            //    try
            //    {
            //        sqlConnection.Open();
            //        sqlCommand = new SqlCommand("Insert into dbo.Passport(" +
            //            "LastName, FirstName, MiddleName, Series, Number, IdIssuedByWhom, " +
            //            "DateOfIssue, CodeDivision, IdGender, DateOfBorn, IdPlaceOfBorn, FamilyPosition, " +
            //            "IdRegistration) " +
            //            "Values(" +
            //            "@LastName, @FirstName, @MiddleName, @Series, @Number, @IdIssuedByWhom, " +
            //            "@DateOfIssue, @CodeDivision, @IdGender, @DateOfBorn, @IdPlaceOfBorn, @FamilyPosition, " +
            //            "@IdRegistration)", sqlConnection);
            //        sqlCommand.Parameters.AddWithValue("LastName", TbLastName.Text);
            //        sqlCommand.Parameters.AddWithValue("FirstName", TbFirstName.Text);
            //        sqlCommand.Parameters.AddWithValue("MiddleName", TbMiddleName.Text);
            //        sqlCommand.Parameters.AddWithValue("Series", Int32.Parse(TbSeries.Text));
            //        sqlCommand.Parameters.AddWithValue("Number", Int32.Parse(TbNumber.Text));
            //        sqlCommand.Parameters.AddWithValue("IdIssuedByWhom", Int32.Parse(CbIsuedByWhom.SelectedValue.ToString()));
            //        sqlCommand.Parameters.AddWithValue("DateOfIssue", DpDateOfIsue.SelectedDate.GetValueOrDefault());
            //        sqlCommand.Parameters.AddWithValue("CodeDivision", TbCode.Text);
            //        sqlCommand.Parameters.AddWithValue("IdGender", Int32.Parse(CbGender.SelectedValue.ToString()));
            //        sqlCommand.Parameters.AddWithValue("DateOfBorn", DpDateOfBorn.SelectedDate.GetValueOrDefault());
            //        sqlCommand.Parameters.AddWithValue("IdPlaceOfBorn", Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString()));
            //        sqlCommand.Parameters.AddWithValue("FamilyPosition", Convert.ToBoolean(ChbFamilyPosition.IsChecked));
            //        sqlCommand.Parameters.AddWithValue("IdRegistration", ClassFolder.TableFolder.ClassRegistration.IdReg);
            //        sqlCommand.ExecuteNonQuery();
            //    }
            //    catch (Exception ex)
            //    {
            //        ClassFolder.ClassMB.MBError(ex);
            //    }
            //    finally
            //    {
            //        sqlConnection.Close();
            //    }
            //    classRead.ReadPassport(TbLastName, TbFirstName, TbMiddleName, TbSeries, TbNumber, CbIsuedByWhom,
            //        DpDateOfIsue, TbCode, CbGender, DpDateOfBorn, CbPlaceOfBorn);
            //    try
            //    {
            //        sqlConnection.Open();
            //        sqlCommand = new SqlCommand("Insert into dbo.Address(" +
            //            "Postcode, IdCity, IdStreet, House, Enclosure, Appartment) " +
            //            "Values(" +
            //            "@Postcode, @IdCity, @IdStreet, @House, @Enclosure, @Appartment)", sqlConnection);
            //        sqlCommand.Parameters.AddWithValue("Postcode", TbRealPostcode.Text);
            //        sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRealCity.SelectedValue.ToString()));
            //        sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRealStreet.SelectedValue.ToString()));
            //        sqlCommand.Parameters.AddWithValue("House", TbRealHouse.Text);
            //        sqlCommand.Parameters.AddWithValue("Enclosure", TbRealEnclosure.Text);
            //        sqlCommand.Parameters.AddWithValue("Appartment", Int32.Parse(TbRealAppartment.Text));
            //        sqlCommand.ExecuteNonQuery();
            //    }
            //    catch (Exception ex)
            //    {
            //        ClassFolder.ClassMB.MBError(ex);
            //    }
            //    finally
            //    {
            //        sqlConnection.Close();
            //    }
            //    classRead.ReadAddress(CbRealCity, CbRealStreet, TbRealPostcode, TbRealHouse, TbRealEnclosure, TbRealAppartment);





            //        try
            //        {
            //            sqlConnection.Open();
            //            sqlCommand = new SqlCommand("Insert into dbo.TemporaryRegistration " +
            //                "(PostcodeTemp, IdCity, IdStreet, HouseTemp, EnclosureTemp, AppartmentTemp) " +
            //                "Values(@PostcodeTemp, @IdCity, @IdStreet, @HouseTemp, @EnclosureTemp, @AppartmentTemp)",
            //                sqlConnection);
            //            sqlCommand.Parameters.AddWithValue("PostcodeTemp", Int32.Parse(TbVremPostcode.Text));
            //            sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbVremCity.SelectedValue.ToString()));
            //            sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbVremStreet.SelectedValue.ToString()));
            //            sqlCommand.Parameters.AddWithValue("HouseTemp", TbVremHouse.Text);
            //            sqlCommand.Parameters.AddWithValue("EnclosureTemp", TbVremEnclosure.Text);
            //            sqlCommand.Parameters.AddWithValue("AppartmentTemp", Int32.Parse(TbVremAppartment.Text));
            //            sqlCommand.ExecuteNonQuery();

            //        }
            //        catch (Exception ex)
            //        {
            //            ClassFolder.ClassMB.MBError(ex);
            //        }
            //        finally
            //        {
            //            sqlConnection.Close();
            //        }

            //    classRead.VremRegistration(CbVremCity, CbVremStreet, TbVremPostcode, TbVremHouse, TbVremEnclosure, TbVremAppartment);

            //    try
            //    {
            //        sqlConnection.Open();
            //        sqlCommand = new SqlCommand("Insert into dbo.Dad(LastNameDad, FirstNameDad, " +
            //            "MiddleNameDad, NumberPhoneDad) " +
            //            "values(@LastNameDad, @FirstNameDad, @MiddleNameDad, @NumberPhoneDad)", sqlConnection);
            //        sqlCommand.Parameters.AddWithValue("LastNameDad", TbDadLastName.Text);
            //        sqlCommand.Parameters.AddWithValue("FirstNameDad", TbDadFirstName.Text);
            //        sqlCommand.Parameters.AddWithValue("MiddleNameDad", TbDadMiddleName.Text);
            //        sqlCommand.Parameters.AddWithValue("NumberPhoneDad", TbDadNumberPhone.Text);
            //        sqlCommand.ExecuteNonQuery();
            //    }
            //    catch (Exception ex)
            //    {
            //        ClassFolder.ClassMB.MBError(ex);
            //    }
            //    finally
            //    {
            //        sqlConnection.Close();
            //    }
            //    classRead.ReadDad(TbDadLastName, TbDadFirstName, TbDadMiddleName, TbDadNumberPhone);
            //    try
            //    {
            //        sqlConnection.Open();
            //        sqlCommand = new SqlCommand("Insert into dbo.Mom(LastNameMom, FirstNameMom, " +
            //            "MiddleNameMom, NumberPhoneMom) " +
            //            "values(@LastNameMom, @FirstNameMom, @MiddleNameMom, @NumberPhoneMom)", sqlConnection);
            //        sqlCommand.Parameters.AddWithValue("LastNameMom", TbMomLastName.Text);
            //        sqlCommand.Parameters.AddWithValue("FirstNameMom", TbMomFirstName.Text);
            //        sqlCommand.Parameters.AddWithValue("MiddleNameMom", TbMomMiddleName.Text);
            //        sqlCommand.Parameters.AddWithValue("NumberPhoneMom", TbMomNumberPhone.Text);
            //        sqlCommand.ExecuteNonQuery();
            //    }
            //    catch (Exception ex)
            //    {
            //        ClassFolder.ClassMB.MBError(ex);
            //    }
            //    finally
            //    {
            //        sqlConnection.Close();
            //    }
            //    classRead.ReadMom(TbMomLastName, TbMomFirstName, TbMomMiddleName, TbMomNumberPhone);
            //    try
            //    {
            //        sqlConnection.Open();
            //        sqlCommand = new SqlCommand("Insert into dbo.GuardianDad(LastNameGuardianDad, " +
            //            "FirstNameGuardianDad, MiddleNameGuardianDad, NumberPhoneGuardianDad) " +
            //            "values(@LastNameGuardianDad, @FirstNameGuardianDad, " +
            //            "@MiddleNameGuardianDad, @NumberPhoneGuardianDad)", sqlConnection);
            //        sqlCommand.Parameters.AddWithValue("LastNameGuardianDad", TbDadLastNameGuard.Text);
            //        sqlCommand.Parameters.AddWithValue("FirstNameGuardianDad", TbDadFirstNameGuard.Text);
            //        sqlCommand.Parameters.AddWithValue("MiddleNameGuardianDad", TbDadMiddleNameGuard.Text);
            //        sqlCommand.Parameters.AddWithValue("NumberPhoneGuardianDad", TbDadNumberPhoneGuard.Text);
            //        sqlCommand.ExecuteNonQuery();
            //    }
            //    catch (Exception ex)
            //    {
            //        ClassFolder.ClassMB.MBError(ex);
            //    }
            //    finally
            //    {
            //        sqlConnection.Close();
            //    }
            //    classRead.ReadGuardianDad(TbDadLastNameGuard, TbDadFirstNameGuard, TbDadMiddleNameGuard, TbDadNumberPhoneGuard);
            //    try
            //    {
            //        sqlConnection.Open();
            //        sqlCommand = new SqlCommand("Insert into dbo.GuardianMom(LastNameGuardianMom, FirstNameGuardianMom, " +
            //            "MiddleNameGuardianMom, NumberPhoneGuardianMom) " +
            //            "values(@LastNameGuardianMom, @FirstNameGuardianMom, " +
            //            "@MiddleNameGuardianMom, @NumberPhoneGuardianMom)", sqlConnection);
            //        sqlCommand.Parameters.AddWithValue("LastNameGuardianMom", TbMomLastNameGuard.Text);
            //        sqlCommand.Parameters.AddWithValue("FirstNameGuardianMom", TbMomFirstNameGuard.Text);
            //        sqlCommand.Parameters.AddWithValue("MiddleNameGuardianMom", TbMomMiddleNameGuard.Text);
            //        sqlCommand.Parameters.AddWithValue("NumberPhoneGuardianMom", TbMomNumberPhoneGuard.Text);
            //        sqlCommand.ExecuteNonQuery();
            //    }
            //    catch (Exception ex)
            //    {
            //        ClassFolder.ClassMB.MBError(ex);
            //    }
            //    finally
            //    {
            //        sqlConnection.Close();
            //    }
            //    classRead.ReadGuardianMom(TbMomLastNameGuard, TbMomFirstNameGuard, TbMomMiddleNameGuard, TbMomNumberPhoneGuard);
            //    try
            //    {
            //        string iFile = TbImage.Text;
            //       // конвертация изображения в байты
            //        byte[] imageData = null;
            //        FileInfo fInfo = new FileInfo(iFile);
            //        long numBytes = fInfo.Length;
            //        FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
            //        BinaryReader br = new BinaryReader(fStream);
            //        imageData = br.ReadBytes((int)numBytes);
            //      //  получение расширения файла изображения не забыв удалить точку перед расширением
            //        string iImageExtension = (System.IO.Path.GetExtension(iFile)).Replace(".", "").ToLower();

            //        using (SqlConnection sql = new SqlConnection(s))
            //        {
            //            sqlConnection.Open();
            //            sqlCommand = new SqlCommand("declare @idImages int; " +
            //                "set @idImages =(select max(IdImage) from [Image]) + 1; " +
            //                "insert into dbo.[Image] (idImage, Title, Photo) values " +
            //                $"(@idImages, @Title, @Photo)", sqlConnection);
            //            sqlCommand.Parameters.AddWithValue("Title", iImageExtension);
            //            sqlCommand.Parameters.AddWithValue("Photo", imageData);
            //            sqlCommand.ExecuteNonQuery();
            //            sqlConnection.Close();
            //        }
            //        ReadImage();

            //        sqlConnection.Open();
            //        sqlCommand = new SqlCommand("Insert into dbo.Student(" +
            //            "IdPassport, IdGroup, SNILS, INN, IdAddress, IdFamily, IdFamilyStatus, NumberPhone, " +
            //            "Email, IdMom, IdDad, HospitalPolice, IdImage, IdTemporaryRegistration, IdStatus, " +
            //            "IdMomGuradian, IdDadGuardina) " +
            //            "values(@IdPassport, @IdGroup, @SNILS, @INN, " +
            //            "@IdAddress, @IdFamily, @IdFamilyStatus, @NumberPhone, " +
            //            "@Email, @IdMom, @IdDad, @HospitalPolice, @IdImage, @IdTemporaryRegistration, @IdStatus, " +
            //            "@IdMomGuradian, @IdDadGuardina)", sqlConnection);
            //        sqlCommand.Parameters.AddWithValue("IdPassport", ClassFolder.TableFolder.ClassPassport.IdPassport);
            //        sqlCommand.Parameters.AddWithValue("IdGroup", ClassFolder.TableFolder.ClassUser.IdGroup);
            //        sqlCommand.Parameters.AddWithValue("SNILS", TbSNILS.Text);
            //        sqlCommand.Parameters.AddWithValue("INN", TbINN.Text);
            //        sqlCommand.Parameters.AddWithValue("IdAddress", ClassFolder.TableFolder.ClassAddress.IdAddress);
            //        sqlCommand.Parameters.AddWithValue("IdFamily", Int32.Parse(CbFamily.SelectedValue.ToString()));
            //        sqlCommand.Parameters.AddWithValue("IdFamilyStatus", Int32.Parse(CbFamilyStatus.SelectedValue.ToString()));
            //        sqlCommand.Parameters.AddWithValue("NumberPhone", TbNumberPhone.Text);
            //        sqlCommand.Parameters.AddWithValue("Email", TbEmail.Text);
            //        sqlCommand.Parameters.AddWithValue("IdMom", ClassFolder.TableFolder.ClassParents.IdMom);
            //        sqlCommand.Parameters.AddWithValue("IdDad", ClassFolder.TableFolder.ClassParents.IdDad);
            //        sqlCommand.Parameters.AddWithValue("HospitalPolice", TbHospital.Text);
            //        sqlCommand.Parameters.AddWithValue("IdStatus", 1);
            //        sqlCommand.Parameters.AddWithValue("IdMomGuradian", ClassFolder.TableFolder.ClassParentGuard.IdMomGuradian);
            //        sqlCommand.Parameters.AddWithValue("IdDadGuardina", ClassFolder.TableFolder.ClassParentGuard.IdDadGuradian);
            //        sqlCommand.Parameters.AddWithValue("IdImage", ClassFolder.TableFolder.ClassImage.IdImage);

            //        sqlCommand.Parameters.AddWithValue("IdTemporaryRegistration", ClassFolder.TableFolder.ClassVremAddress.IdVremReg);
            //        sqlCommand.ExecuteNonQuery();
            //    }
            //    catch (Exception ex)
            //    {
            //        ClassFolder.ClassMB.MBError(ex);
            //    }
            //    finally
            //    {
            //        sqlConnection.Close();
            //    }
            //    classRead.ReadStudent(TbSNILS, TbINN, TbNumberPhone, TbEmail);
            //    //LoadBDImage(TbImage.Text);
            //    ClassFolder.ClassMB.MBInformation("Студент добавлен");
            //}
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            classCB.LoadGender(CbGender);
            classCB.LoadPlaceOfBorn(CbPlaceOfBorn);
            classCB.LoadFamilyStatus(CbFamilyStatus);
            classCB.LoadCity(CbRegCity);
            classCB.LoadCity(CbRealCity);
            classCB.LoadStreet(CbRegStreet);
            classCB.LoadStreet(CbRealStreet);
            classCB.LoadAuthority(CbIsuedByWhom);
            classCB.LoadCity(CbVremCity);
            classCB.LoadStreet(CbVremStreet);
            classCB.LoadFamily(CbFamily);
        }

        public void ReadImage()
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("declare @idImage int; " +
                    "set @idImage = (select max(IdImage) from dbo.[Image]);" +
                "select IdImage from dbo.Image where IdImage=@idImage", sqlConnection);
                dataReader = this.sqlCommand.ExecuteReader();
                dataReader.Read();
                ClassFolder.TableFolder.ClassImage.IdImage = Int32.Parse(dataReader[0].ToString());
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

        //отец опекун, нет врем адреса
        public void AddAllNullAddDadGuard()
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Registration(" +
                    "PostcodeReg, IdCity, IdStreet, HouseReg, EnclosureReg, AppartmentReg) " +
                    "Values(" +
                    "@PostcodeReg, @IdCity, @IdStreet, @HouseReg, @EnclosureReg, @AppartmentReg)",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("PostcodeReg", Int32.Parse(TbRegPostcode.Text));
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRegCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRegStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("HouseReg", TbRegHouse.Text);
                sqlCommand.Parameters.AddWithValue("EnclosureReg", TbRegEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("AppartmentReg", Int32.Parse(TbRegAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadRegistration(CbRegCity, CbRegStreet, TbRegPostcode, TbRegHouse, TbRegEnclosure, TbRegAppartment);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Passport(" +
                    "LastName, FirstName, MiddleName, Series, Number, IdIssuedByWhom, " +
                    "DateOfIssue, CodeDivision, IdGender, DateOfBorn, IdPlaceOfBorn, FamilyPosition, " +
                    "IdRegistration) " +
                    "Values(" +
                    "@LastName, @FirstName, @MiddleName, @Series, @Number, @IdIssuedByWhom, " +
                    "@DateOfIssue, @CodeDivision, @IdGender, @DateOfBorn, @IdPlaceOfBorn, @FamilyPosition, " +
                    "@IdRegistration)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastName", TbLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstName", TbFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleName", TbMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("Series", Int32.Parse(TbSeries.Text));
                sqlCommand.Parameters.AddWithValue("Number", Int32.Parse(TbNumber.Text));
                sqlCommand.Parameters.AddWithValue("IdIssuedByWhom", Int32.Parse(CbIsuedByWhom.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfIssue", DpDateOfIsue.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("CodeDivision", TbCode.Text);
                sqlCommand.Parameters.AddWithValue("IdGender", Int32.Parse(CbGender.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfBorn", DpDateOfBorn.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("IdPlaceOfBorn", Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("FamilyPosition", ChbFamilyPosition.IsChecked);
                sqlCommand.Parameters.AddWithValue("IdRegistration", ClassFolder.TableFolder.ClassRegistration.IdReg);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadPassport(TbLastName, TbFirstName, TbMiddleName, TbSeries, TbNumber, CbIsuedByWhom,
                DpDateOfIsue, TbCode, CbGender, DpDateOfBorn, CbPlaceOfBorn);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Address(" +
                    "Postcode, IdCity, IdStreet, House, Enclosure, Appartment) " +
                    "Values(" +
                    "@Postcode, @IdCity, @IdStreet, @House, @Enclosure, @Appartment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("Postcode", TbRealPostcode.Text);
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRealCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRealStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("House", TbRealHouse.Text);
                sqlCommand.Parameters.AddWithValue("Enclosure", TbRealEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("Appartment", Int32.Parse(TbRealAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadAddress(CbRealCity, CbRealStreet, TbRealPostcode, TbRealHouse, TbRealEnclosure, TbRealAppartment);



            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.GuardianDad(LastNameGuardianDad, " +
                    "FirstNameGuardianDad, MiddleNameGuardianDad, NumberPhoneGuardianDad) " +
                    "values(@LastNameGuardianDad, @FirstNameGuardianDad, " +
                    "@MiddleNameGuardianDad, @NumberPhoneGuardianDad)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameGuardianDad", TbDadLastNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("FirstNameGuardianDad", TbDadFirstNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("MiddleNameGuardianDad", TbDadMiddleNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("NumberPhoneGuardianDad", TbDadNumberPhoneGuard.Text);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadGuardianDad(TbDadLastNameGuard, TbDadFirstNameGuard, TbDadMiddleNameGuard, TbDadNumberPhoneGuard);
            classAdd.AddNullDad();
            classRead.ReadNullDad();
            classAdd.AddNullMom();
            classRead.ReadNullMom();
            classAdd.AddNullMomGuard();
            classRead.ReadNullMomGuard();
            classAdd.AddNullTempReg();
            classRead.ReadNullTempReg();
            try
            {
                string iFile = TbImage.Text;
                // конвертация изображения в байты
                byte[] imageData = null;
                FileInfo fInfo = new FileInfo(iFile);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                imageData = br.ReadBytes((int)numBytes);
                //  получение расширения файла изображения не забыв удалить точку перед расширением
                string iImageExtension = (System.IO.Path.GetExtension(iFile)).Replace(".", "").ToLower();

                using (SqlConnection sql = new SqlConnection(s))
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("declare @idImages int; " +
                        "set @idImages =(select max(IdImage) from [Image]) + 1; " +
                        "insert into dbo.[Image] (idImage, Title, Photo) values " +
                        $"(@idImages, @Title, @Photo)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Title", iImageExtension);
                    sqlCommand.Parameters.AddWithValue("Photo", imageData);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                ReadImage();

                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Student(" +
                    "IdPassport, IdGroup, SNILS, INN, IdAddress, IdFamily, IdFamilyStatus, NumberPhone, " +
                    "Email, IdMom, IdDad, HospitalPolice, IdImage, IdTemporaryRegistration, IdStatus, " +
                    "IdMomGuradian, IdDadGuardina, NumberOrder, DateOrder, Comment) " +
                    "values(@IdPassport, @IdGroup, @SNILS, @INN, " +
                    "@IdAddress, @IdFamily, @IdFamilyStatus, @NumberPhone, " +
                    "@Email, @IdMom, @IdDad, @HospitalPolice, @IdImage, @IdTemporaryRegistration, @IdStatus, " +
                    "@IdMomGuradian, @IdDadGuardina, @NumberOrder, @DateOrder, @Comment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("IdPassport", ClassFolder.TableFolder.ClassPassport.IdPassport);
                sqlCommand.Parameters.AddWithValue("IdGroup", ClassFolder.TableFolder.ClassUser.IdGroup);
                sqlCommand.Parameters.AddWithValue("SNILS", TbSNILS.Text);
                sqlCommand.Parameters.AddWithValue("INN", TbINN.Text);
                sqlCommand.Parameters.AddWithValue("IdAddress", ClassFolder.TableFolder.ClassAddress.IdAddress);
                sqlCommand.Parameters.AddWithValue("IdFamily", Int32.Parse(CbFamily.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdFamilyStatus", Int32.Parse(CbFamilyStatus.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("NumberPhone", TbNumberPhone.Text);
                sqlCommand.Parameters.AddWithValue("Email", TbEmail.Text);
                sqlCommand.Parameters.AddWithValue("IdMom", ClassFolder.TableFolder.ClassParents.IdMom);
                sqlCommand.Parameters.AddWithValue("IdDad", ClassFolder.TableFolder.ClassParents.IdDad);
                sqlCommand.Parameters.AddWithValue("HospitalPolice", TbHospital.Text);
                sqlCommand.Parameters.AddWithValue("IdStatus", 1);
                sqlCommand.Parameters.AddWithValue("IdMomGuradian", ClassFolder.TableFolder.ClassParentGuard.IdMomGuradian);
                sqlCommand.Parameters.AddWithValue("IdDadGuardina", ClassFolder.TableFolder.ClassParentGuard.IdDadGuradian);
                sqlCommand.Parameters.AddWithValue("IdImage", ClassFolder.TableFolder.ClassImage.IdImage);
                sqlCommand.Parameters.AddWithValue("IdTemporaryRegistration", ClassFolder.TableFolder.ClassVremAddress.IdVremReg);
                sqlCommand.Parameters.AddWithValue("NumberOrder", TbOrder.Text);
                sqlCommand.Parameters.AddWithValue("DateOrder", DpDateOfOrder.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("Comment", TbComment.Text);
                sqlCommand.ExecuteNonQuery();
                ClassFolder.ClassMB.MBInformation("Студент добавлен");
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadStudent(TbSNILS, TbINN, TbNumberPhone, TbEmail);
            //LoadBDImage(TbImage.Text);
            
        }



















        //мама опекун, нет врем адреса
        public void AddAllNullAddMomGuard()
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Registration(" +
                    "PostcodeReg, IdCity, IdStreet, HouseReg, EnclosureReg, AppartmentReg) " +
                    "Values(" +
                    "@PostcodeReg, @IdCity, @IdStreet, @HouseReg, @EnclosureReg, @AppartmentReg)",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("PostcodeReg", Int32.Parse(TbRegPostcode.Text));
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRegCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRegStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("HouseReg", TbRegHouse.Text);
                sqlCommand.Parameters.AddWithValue("EnclosureReg", TbRegEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("AppartmentReg", Int32.Parse(TbRegAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadRegistration(CbRegCity, CbRegStreet, TbRegPostcode, TbRegHouse, TbRegEnclosure, TbRegAppartment);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Passport(" +
                    "LastName, FirstName, MiddleName, Series, Number, IdIssuedByWhom, " +
                    "DateOfIssue, CodeDivision, IdGender, DateOfBorn, IdPlaceOfBorn, FamilyPosition, " +
                    "IdRegistration) " +
                    "Values(" +
                    "@LastName, @FirstName, @MiddleName, @Series, @Number, @IdIssuedByWhom, " +
                    "@DateOfIssue, @CodeDivision, @IdGender, @DateOfBorn, @IdPlaceOfBorn, @FamilyPosition, " +
                    "@IdRegistration)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastName", TbLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstName", TbFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleName", TbMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("Series", Int32.Parse(TbSeries.Text));
                sqlCommand.Parameters.AddWithValue("Number", Int32.Parse(TbNumber.Text));
                sqlCommand.Parameters.AddWithValue("IdIssuedByWhom", Int32.Parse(CbIsuedByWhom.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfIssue", DpDateOfIsue.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("CodeDivision", TbCode.Text);
                sqlCommand.Parameters.AddWithValue("IdGender", Int32.Parse(CbGender.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfBorn", DpDateOfBorn.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("IdPlaceOfBorn", Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("FamilyPosition", ChbFamilyPosition.IsChecked);
                sqlCommand.Parameters.AddWithValue("IdRegistration", ClassFolder.TableFolder.ClassRegistration.IdReg);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadPassport(TbLastName, TbFirstName, TbMiddleName, TbSeries, TbNumber, CbIsuedByWhom,
                DpDateOfIsue, TbCode, CbGender, DpDateOfBorn, CbPlaceOfBorn);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Address(" +
                    "Postcode, IdCity, IdStreet, House, Enclosure, Appartment) " +
                    "Values(" +
                    "@Postcode, @IdCity, @IdStreet, @House, @Enclosure, @Appartment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("Postcode", TbRealPostcode.Text);
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRealCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRealStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("House", TbRealHouse.Text);
                sqlCommand.Parameters.AddWithValue("Enclosure", TbRealEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("Appartment", Int32.Parse(TbRealAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadAddress(CbRealCity, CbRealStreet, TbRealPostcode, TbRealHouse, TbRealEnclosure, TbRealAppartment);


            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.GuardianMom(LastNameGuardianMom, FirstNameGuardianMom, " +
                    "MiddleNameGuardianMom, NumberPhoneGuardianMom) " +
                    "values(@LastNameGuardianMom, @FirstNameGuardianMom, " +
                    "@MiddleNameGuardianMom, @NumberPhoneGuardianMom)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameGuardianMom", TbMomLastNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("FirstNameGuardianMom", TbMomFirstNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("MiddleNameGuardianMom", TbMomMiddleNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("NumberPhoneGuardianMom", TbMomNumberPhoneGuard.Text);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadGuardianMom(TbMomLastNameGuard, TbMomFirstNameGuard, TbMomMiddleNameGuard, TbMomNumberPhoneGuard);
            classAdd.AddNullDad();
            classRead.ReadNullDad();
            classAdd.AddNullMom();
            classRead.ReadNullMom();
            classAdd.AddNullDadGuard();
            classRead.ReadNullDadGuard();
            classAdd.AddNullTempReg();
            classRead.ReadNullTempReg();
            try
            {
                string iFile = TbImage.Text;
                // конвертация изображения в байты
                byte[] imageData = null;
                FileInfo fInfo = new FileInfo(iFile);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                imageData = br.ReadBytes((int)numBytes);
                //  получение расширения файла изображения не забыв удалить точку перед расширением
                string iImageExtension = (System.IO.Path.GetExtension(iFile)).Replace(".", "").ToLower();

                using (SqlConnection sql = new SqlConnection(s))
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("declare @idImages int; " +
                        "set @idImages =(select max(IdImage) from [Image]) + 1; " +
                        "insert into dbo.[Image] (idImage, Title, Photo) values " +
                        $"(@idImages, @Title, @Photo)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Title", iImageExtension);
                    sqlCommand.Parameters.AddWithValue("Photo", imageData);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                ReadImage();

                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Student(" +
                    "IdPassport, IdGroup, SNILS, INN, IdAddress, IdFamily, IdFamilyStatus, NumberPhone, " +
                    "Email, IdMom, IdDad, HospitalPolice, IdImage, IdTemporaryRegistration, IdStatus, " +
                    "IdMomGuradian, IdDadGuardina, NumberOrder, DateOrder, Comment) " +
                    "values(@IdPassport, @IdGroup, @SNILS, @INN, " +
                    "@IdAddress, @IdFamily, @IdFamilyStatus, @NumberPhone, " +
                    "@Email, @IdMom, @IdDad, @HospitalPolice, @IdImage, @IdTemporaryRegistration, @IdStatus, " +
                    "@IdMomGuradian, @IdDadGuardina, @NumberOrder, @DateOrder, @Comment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("IdPassport", ClassFolder.TableFolder.ClassPassport.IdPassport);
                sqlCommand.Parameters.AddWithValue("IdGroup", ClassFolder.TableFolder.ClassUser.IdGroup);
                sqlCommand.Parameters.AddWithValue("SNILS", TbSNILS.Text);
                sqlCommand.Parameters.AddWithValue("INN", TbINN.Text);
                sqlCommand.Parameters.AddWithValue("IdAddress", ClassFolder.TableFolder.ClassAddress.IdAddress);
                sqlCommand.Parameters.AddWithValue("IdFamily", Int32.Parse(CbFamily.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdFamilyStatus", Int32.Parse(CbFamilyStatus.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("NumberPhone", TbNumberPhone.Text);
                sqlCommand.Parameters.AddWithValue("Email", TbEmail.Text);
                sqlCommand.Parameters.AddWithValue("IdMom", ClassFolder.TableFolder.ClassParents.IdMom);
                sqlCommand.Parameters.AddWithValue("IdDad", ClassFolder.TableFolder.ClassParents.IdDad);
                sqlCommand.Parameters.AddWithValue("HospitalPolice", TbHospital.Text);
                sqlCommand.Parameters.AddWithValue("IdStatus", 1);
                sqlCommand.Parameters.AddWithValue("IdMomGuradian", ClassFolder.TableFolder.ClassParentGuard.IdMomGuradian);
                sqlCommand.Parameters.AddWithValue("IdDadGuardina", ClassFolder.TableFolder.ClassParentGuard.IdDadGuradian);
                sqlCommand.Parameters.AddWithValue("IdImage", ClassFolder.TableFolder.ClassImage.IdImage);
                sqlCommand.Parameters.AddWithValue("NumberOrder", TbOrder.Text);
                sqlCommand.Parameters.AddWithValue("DateOrder", DpDateOfOrder.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("IdTemporaryRegistration", ClassFolder.TableFolder.ClassVremAddress.IdVremReg);
                sqlCommand.Parameters.AddWithValue("Comment", TbComment.Text);
                sqlCommand.ExecuteNonQuery();
                ClassFolder.ClassMB.MBInformation("Студент добавлен");
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadStudent(TbSNILS, TbINN, TbNumberPhone, TbEmail);
            //LoadBDImage(TbImage.Text);
            
        }









        //опекун отец и мать, нет врем адреса
        public void AddAllNullMomGuardDadGuard()
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Registration(" +
                    "PostcodeReg, IdCity, IdStreet, HouseReg, EnclosureReg, AppartmentReg) " +
                    "Values(" +
                    "@PostcodeReg, @IdCity, @IdStreet, @HouseReg, @EnclosureReg, @AppartmentReg)",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("PostcodeReg", Int32.Parse(TbRegPostcode.Text));
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRegCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRegStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("HouseReg", TbRegHouse.Text);
                sqlCommand.Parameters.AddWithValue("EnclosureReg", TbRegEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("AppartmentReg", Int32.Parse(TbRegAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadRegistration(CbRegCity, CbRegStreet, TbRegPostcode, TbRegHouse, TbRegEnclosure, TbRegAppartment);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Passport(" +
                    "LastName, FirstName, MiddleName, Series, Number, IdIssuedByWhom, " +
                    "DateOfIssue, CodeDivision, IdGender, DateOfBorn, IdPlaceOfBorn, FamilyPosition, " +
                    "IdRegistration) " +
                    "Values(" +
                    "@LastName, @FirstName, @MiddleName, @Series, @Number, @IdIssuedByWhom, " +
                    "@DateOfIssue, @CodeDivision, @IdGender, @DateOfBorn, @IdPlaceOfBorn, @FamilyPosition, " +
                    "@IdRegistration)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastName", TbLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstName", TbFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleName", TbMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("Series", Int32.Parse(TbSeries.Text));
                sqlCommand.Parameters.AddWithValue("Number", Int32.Parse(TbNumber.Text));
                sqlCommand.Parameters.AddWithValue("IdIssuedByWhom", Int32.Parse(CbIsuedByWhom.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfIssue", DpDateOfIsue.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("CodeDivision", TbCode.Text);
                sqlCommand.Parameters.AddWithValue("IdGender", Int32.Parse(CbGender.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfBorn", DpDateOfBorn.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("IdPlaceOfBorn", Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("FamilyPosition", ChbFamilyPosition.IsChecked);
                sqlCommand.Parameters.AddWithValue("IdRegistration", ClassFolder.TableFolder.ClassRegistration.IdReg);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadPassport(TbLastName, TbFirstName, TbMiddleName, TbSeries, TbNumber, CbIsuedByWhom,
                DpDateOfIsue, TbCode, CbGender, DpDateOfBorn, CbPlaceOfBorn);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Address(" +
                    "Postcode, IdCity, IdStreet, House, Enclosure, Appartment) " +
                    "Values(" +
                    "@Postcode, @IdCity, @IdStreet, @House, @Enclosure, @Appartment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("Postcode", TbRealPostcode.Text);
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRealCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRealStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("House", TbRealHouse.Text);
                sqlCommand.Parameters.AddWithValue("Enclosure", TbRealEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("Appartment", Int32.Parse(TbRealAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadAddress(CbRealCity, CbRealStreet, TbRealPostcode, TbRealHouse, TbRealEnclosure, TbRealAppartment);


            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.GuardianMom(LastNameGuardianMom, FirstNameGuardianMom, " +
                    "MiddleNameGuardianMom, NumberPhoneGuardianMom) " +
                    "values(@LastNameGuardianMom, @FirstNameGuardianMom, " +
                    "@MiddleNameGuardianMom, @NumberPhoneGuardianMom)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameGuardianMom", TbMomLastNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("FirstNameGuardianMom", TbMomFirstNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("MiddleNameGuardianMom", TbMomMiddleNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("NumberPhoneGuardianMom", TbMomNumberPhoneGuard.Text);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadGuardianMom(TbMomLastNameGuard, TbMomFirstNameGuard, TbMomMiddleNameGuard, TbMomNumberPhoneGuard);


            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.GuardianDad(LastNameGuardianDad, " +
                    "FirstNameGuardianDad, MiddleNameGuardianDad, NumberPhoneGuardianDad) " +
                    "values(@LastNameGuardianDad, @FirstNameGuardianDad, " +
                    "@MiddleNameGuardianDad, @NumberPhoneGuardianDad)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameGuardianDad", TbDadLastNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("FirstNameGuardianDad", TbDadFirstNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("MiddleNameGuardianDad", TbDadMiddleNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("NumberPhoneGuardianDad", TbDadNumberPhoneGuard.Text);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadGuardianDad(TbDadLastNameGuard, TbDadFirstNameGuard, TbDadMiddleNameGuard, TbDadNumberPhoneGuard);

            classAdd.AddNullMom();
            classRead.ReadNullMom();
            classAdd.AddNullDad();
            classRead.ReadNullDad();
            classAdd.AddNullTempReg();
            classRead.ReadNullTempReg();
            try
            {
                string iFile = TbImage.Text;
                // конвертация изображения в байты
                byte[] imageData = null;
                FileInfo fInfo = new FileInfo(iFile);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                imageData = br.ReadBytes((int)numBytes);
                //  получение расширения файла изображения не забыв удалить точку перед расширением
                string iImageExtension = (System.IO.Path.GetExtension(iFile)).Replace(".", "").ToLower();

                using (SqlConnection sql = new SqlConnection(s))
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("declare @idImages int; " +
                        "set @idImages =(select max(IdImage) from [Image]) + 1; " +
                        "insert into dbo.[Image] (idImage, Title, Photo) values " +
                        $"(@idImages, @Title, @Photo)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Title", iImageExtension);
                    sqlCommand.Parameters.AddWithValue("Photo", imageData);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                ReadImage();

                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Student(" +
                    "IdPassport, IdGroup, SNILS, INN, IdAddress, IdFamily, IdFamilyStatus, NumberPhone, " +
                    "Email, IdMom, IdDad, HospitalPolice, IdImage, IdTemporaryRegistration, IdStatus, " +
                    "IdMomGuradian, IdDadGuardina, NumberOrder, DateOrder, Comment) " +
                    "values(@IdPassport, @IdGroup, @SNILS, @INN, " +
                    "@IdAddress, @IdFamily, @IdFamilyStatus, @NumberPhone, " +
                    "@Email, @IdMom, @IdDad, @HospitalPolice, @IdImage, @IdTemporaryRegistration, @IdStatus, " +
                    "@IdMomGuradian, @IdDadGuardina, @NumberOrder, @DateOrder, @Comment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("IdPassport", ClassFolder.TableFolder.ClassPassport.IdPassport);
                sqlCommand.Parameters.AddWithValue("IdGroup", ClassFolder.TableFolder.ClassUser.IdGroup);
                sqlCommand.Parameters.AddWithValue("SNILS", TbSNILS.Text);
                sqlCommand.Parameters.AddWithValue("INN", TbINN.Text);
                sqlCommand.Parameters.AddWithValue("IdAddress", ClassFolder.TableFolder.ClassAddress.IdAddress);
                sqlCommand.Parameters.AddWithValue("IdFamily", Int32.Parse(CbFamily.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdFamilyStatus", Int32.Parse(CbFamilyStatus.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("NumberPhone", TbNumberPhone.Text);
                sqlCommand.Parameters.AddWithValue("Email", TbEmail.Text);
                sqlCommand.Parameters.AddWithValue("IdMom", ClassFolder.TableFolder.ClassParents.IdMom);
                sqlCommand.Parameters.AddWithValue("IdDad", ClassFolder.TableFolder.ClassParents.IdDad);
                sqlCommand.Parameters.AddWithValue("HospitalPolice", TbHospital.Text);
                sqlCommand.Parameters.AddWithValue("IdStatus", 1);
                sqlCommand.Parameters.AddWithValue("IdMomGuradian", ClassFolder.TableFolder.ClassParentGuard.IdMomGuradian);
                sqlCommand.Parameters.AddWithValue("IdDadGuardina", ClassFolder.TableFolder.ClassParentGuard.IdDadGuradian);
                sqlCommand.Parameters.AddWithValue("IdImage", ClassFolder.TableFolder.ClassImage.IdImage);
                sqlCommand.Parameters.AddWithValue("IdTemporaryRegistration", ClassFolder.TableFolder.ClassVremAddress.IdVremReg);
                sqlCommand.Parameters.AddWithValue("NumberOrder", TbOrder.Text);
                sqlCommand.Parameters.AddWithValue("DateOrder", DpDateOfOrder.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("Comment", TbComment.Text);
                sqlCommand.ExecuteNonQuery();
                ClassFolder.ClassMB.MBInformation("Студент добавлен");
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadStudent(TbSNILS, TbINN, TbNumberPhone, TbEmail);
            //LoadBDImage(TbImage.Text);
            
        }








        //мама , нет врем адреса
        public void AddAllNullAddMom()
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Registration(" +
                    "PostcodeReg, IdCity, IdStreet, HouseReg, EnclosureReg, AppartmentReg) " +
                    "Values(" +
                    "@PostcodeReg, @IdCity, @IdStreet, @HouseReg, @EnclosureReg, @AppartmentReg)",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("PostcodeReg", Int32.Parse(TbRegPostcode.Text));
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRegCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRegStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("HouseReg", TbRegHouse.Text);
                sqlCommand.Parameters.AddWithValue("EnclosureReg", TbRegEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("AppartmentReg", Int32.Parse(TbRegAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadRegistration(CbRegCity, CbRegStreet, TbRegPostcode, TbRegHouse, TbRegEnclosure, TbRegAppartment);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Passport(" +
                    "LastName, FirstName, MiddleName, Series, Number, IdIssuedByWhom, " +
                    "DateOfIssue, CodeDivision, IdGender, DateOfBorn, IdPlaceOfBorn, FamilyPosition, " +
                    "IdRegistration) " +
                    "Values(" +
                    "@LastName, @FirstName, @MiddleName, @Series, @Number, @IdIssuedByWhom, " +
                    "@DateOfIssue, @CodeDivision, @IdGender, @DateOfBorn, @IdPlaceOfBorn, @FamilyPosition, " +
                    "@IdRegistration)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastName", TbLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstName", TbFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleName", TbMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("Series", Int32.Parse(TbSeries.Text));
                sqlCommand.Parameters.AddWithValue("Number", Int32.Parse(TbNumber.Text));
                sqlCommand.Parameters.AddWithValue("IdIssuedByWhom", Int32.Parse(CbIsuedByWhom.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfIssue", DpDateOfIsue.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("CodeDivision", TbCode.Text);
                sqlCommand.Parameters.AddWithValue("IdGender", Int32.Parse(CbGender.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfBorn", DpDateOfBorn.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("IdPlaceOfBorn", Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("FamilyPosition", ChbFamilyPosition.IsChecked);
                sqlCommand.Parameters.AddWithValue("IdRegistration", ClassFolder.TableFolder.ClassRegistration.IdReg);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadPassport(TbLastName, TbFirstName, TbMiddleName, TbSeries, TbNumber, CbIsuedByWhom,
                DpDateOfIsue, TbCode, CbGender, DpDateOfBorn, CbPlaceOfBorn);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Address(" +
                    "Postcode, IdCity, IdStreet, House, Enclosure, Appartment) " +
                    "Values(" +
                    "@Postcode, @IdCity, @IdStreet, @House, @Enclosure, @Appartment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("Postcode", TbRealPostcode.Text);
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRealCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRealStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("House", TbRealHouse.Text);
                sqlCommand.Parameters.AddWithValue("Enclosure", TbRealEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("Appartment", Int32.Parse(TbRealAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadAddress(CbRealCity, CbRealStreet, TbRealPostcode, TbRealHouse, TbRealEnclosure, TbRealAppartment);


            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Mom(LastNameMom, FirstNameMom, " +
                    "MiddleNameMom, NumberPhoneMom) " +
                    "values(@LastNameMom, @FirstNameMom, @MiddleNameMom, @NumberPhoneMom)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameMom", TbMomLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstNameMom", TbMomFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleNameMom", TbMomMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("NumberPhoneMom", TbMomNumberPhone.Text);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadMom(TbMomLastName, TbMomFirstName, TbMomMiddleName, TbMomNumberPhone);
            classAdd.AddNullDad();
            classRead.ReadNullDad();
            classAdd.AddNullDadGuard();
            classRead.ReadNullDadGuard();
            classAdd.AddNullMomGuard();
            classRead.ReadNullMomGuard();
            classAdd.AddNullTempReg();
            classRead.ReadNullTempReg();
            try
            {
                string iFile = TbImage.Text;
                // конвертация изображения в байты
                byte[] imageData = null;
                FileInfo fInfo = new FileInfo(iFile);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                imageData = br.ReadBytes((int)numBytes);
                //  получение расширения файла изображения не забыв удалить точку перед расширением
                string iImageExtension = (System.IO.Path.GetExtension(iFile)).Replace(".", "").ToLower();

                using (SqlConnection sql = new SqlConnection(s))
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("declare @idImages int; " +
                        "set @idImages =(select max(IdImage) from [Image]) + 1; " +
                        "insert into dbo.[Image] (idImage, Title, Photo) values " +
                        $"(@idImages, @Title, @Photo)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Title", iImageExtension);
                    sqlCommand.Parameters.AddWithValue("Photo", imageData);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                ReadImage();

                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Student(" +
                    "IdPassport, IdGroup, SNILS, INN, IdAddress, IdFamily, IdFamilyStatus, NumberPhone, " +
                    "Email, IdMom, IdDad, HospitalPolice, IdImage, IdTemporaryRegistration, IdStatus, " +
                    "IdMomGuradian, IdDadGuardina, NumberOrder, DateOrder, Comment) " +
                    "values(@IdPassport, @IdGroup, @SNILS, @INN, " +
                    "@IdAddress, @IdFamily, @IdFamilyStatus, @NumberPhone, " +
                    "@Email, @IdMom, @IdDad, @HospitalPolice, @IdImage, @IdTemporaryRegistration, @IdStatus, " +
                    "@IdMomGuradian, @IdDadGuardina, @NumberOrder, @DateOrder, @Comment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("IdPassport", ClassFolder.TableFolder.ClassPassport.IdPassport);
                sqlCommand.Parameters.AddWithValue("IdGroup", ClassFolder.TableFolder.ClassUser.IdGroup);
                sqlCommand.Parameters.AddWithValue("SNILS", TbSNILS.Text);
                sqlCommand.Parameters.AddWithValue("INN", TbINN.Text);
                sqlCommand.Parameters.AddWithValue("IdAddress", ClassFolder.TableFolder.ClassAddress.IdAddress);
                sqlCommand.Parameters.AddWithValue("IdFamily", Int32.Parse(CbFamily.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdFamilyStatus", Int32.Parse(CbFamilyStatus.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("NumberPhone", TbNumberPhone.Text);
                sqlCommand.Parameters.AddWithValue("Email", TbEmail.Text);
                sqlCommand.Parameters.AddWithValue("IdMom", ClassFolder.TableFolder.ClassParents.IdMom);
                sqlCommand.Parameters.AddWithValue("IdDad", ClassFolder.TableFolder.ClassParents.IdDad);
                sqlCommand.Parameters.AddWithValue("HospitalPolice", TbHospital.Text);
                sqlCommand.Parameters.AddWithValue("IdStatus", 1);
                sqlCommand.Parameters.AddWithValue("IdMomGuradian", ClassFolder.TableFolder.ClassParentGuard.IdMomGuradian);
                sqlCommand.Parameters.AddWithValue("IdDadGuardina", ClassFolder.TableFolder.ClassParentGuard.IdDadGuradian);
                sqlCommand.Parameters.AddWithValue("IdImage", ClassFolder.TableFolder.ClassImage.IdImage);
                sqlCommand.Parameters.AddWithValue("IdTemporaryRegistration", ClassFolder.TableFolder.ClassVremAddress.IdVremReg);
                sqlCommand.Parameters.AddWithValue("NumberOrder", TbOrder.Text);
                sqlCommand.Parameters.AddWithValue("DateOrder", DpDateOfOrder.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("Comment", TbComment.Text);
                sqlCommand.ExecuteNonQuery();ClassFolder.ClassMB.MBInformation("Студент добавлен");
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadStudent(TbSNILS, TbINN, TbNumberPhone, TbEmail);
            //LoadBDImage(TbImage.Text);
            
        }










        //отец, нет врем адреса
        public void AddAllNullAddDad()
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Registration(" +
                    "PostcodeReg, IdCity, IdStreet, HouseReg, EnclosureReg, AppartmentReg) " +
                    "Values(" +
                    "@PostcodeReg, @IdCity, @IdStreet, @HouseReg, @EnclosureReg, @AppartmentReg)",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("PostcodeReg", Int32.Parse(TbRegPostcode.Text));
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRegCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRegStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("HouseReg", TbRegHouse.Text);
                sqlCommand.Parameters.AddWithValue("EnclosureReg", TbRegEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("AppartmentReg", Int32.Parse(TbRegAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadRegistration(CbRegCity, CbRegStreet, TbRegPostcode, TbRegHouse, TbRegEnclosure, TbRegAppartment);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Passport(" +
                    "LastName, FirstName, MiddleName, Series, Number, IdIssuedByWhom, " +
                    "DateOfIssue, CodeDivision, IdGender, DateOfBorn, IdPlaceOfBorn, FamilyPosition, " +
                    "IdRegistration) " +
                    "Values(" +
                    "@LastName, @FirstName, @MiddleName, @Series, @Number, @IdIssuedByWhom, " +
                    "@DateOfIssue, @CodeDivision, @IdGender, @DateOfBorn, @IdPlaceOfBorn, @FamilyPosition, " +
                    "@IdRegistration)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastName", TbLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstName", TbFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleName", TbMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("Series", Int32.Parse(TbSeries.Text));
                sqlCommand.Parameters.AddWithValue("Number", Int32.Parse(TbNumber.Text));
                sqlCommand.Parameters.AddWithValue("IdIssuedByWhom", Int32.Parse(CbIsuedByWhom.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfIssue", DpDateOfIsue.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("CodeDivision", TbCode.Text);
                sqlCommand.Parameters.AddWithValue("IdGender", Int32.Parse(CbGender.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfBorn", DpDateOfBorn.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("IdPlaceOfBorn", Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("FamilyPosition", ChbFamilyPosition.IsChecked);
                sqlCommand.Parameters.AddWithValue("IdRegistration", ClassFolder.TableFolder.ClassRegistration.IdReg);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadPassport(TbLastName, TbFirstName, TbMiddleName, TbSeries, TbNumber, CbIsuedByWhom,
                DpDateOfIsue, TbCode, CbGender, DpDateOfBorn, CbPlaceOfBorn);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Address(" +
                    "Postcode, IdCity, IdStreet, House, Enclosure, Appartment) " +
                    "Values(" +
                    "@Postcode, @IdCity, @IdStreet, @House, @Enclosure, @Appartment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("Postcode", TbRealPostcode.Text);
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRealCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRealStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("House", TbRealHouse.Text);
                sqlCommand.Parameters.AddWithValue("Enclosure", TbRealEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("Appartment", Int32.Parse(TbRealAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadAddress(CbRealCity, CbRealStreet, TbRealPostcode, TbRealHouse, TbRealEnclosure, TbRealAppartment);



            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Dad(LastNameDad, FirstNameDad, " +
                    "MiddleNameDad, NumberPhoneDad) " +
                    "values(@LastNameDad, @FirstNameDad, @MiddleNameDad, @NumberPhoneDad)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameDad", TbDadLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstNameDad", TbDadFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleNameDad", TbDadMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("NumberPhoneDad", TbDadNumberPhone.Text);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadDad(TbDadLastName, TbDadFirstName, TbDadMiddleName, TbDadNumberPhone);
            classAdd.AddNullMom();
            classRead.ReadNullMom();
            classAdd.AddNullDadGuard();
            classRead.ReadNullDadGuard();
            classAdd.AddNullMomGuard();
            classRead.ReadNullMomGuard();
            classAdd.AddNullTempReg();
            classRead.ReadNullTempReg();
            try
            {
                string iFile = TbImage.Text;
                // конвертация изображения в байты
                byte[] imageData = null;
                FileInfo fInfo = new FileInfo(iFile);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                imageData = br.ReadBytes((int)numBytes);
                //  получение расширения файла изображения не забыв удалить точку перед расширением
                string iImageExtension = (System.IO.Path.GetExtension(iFile)).Replace(".", "").ToLower();

                using (SqlConnection sql = new SqlConnection(s))
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("declare @idImages int; " +
                        "set @idImages =(select max(IdImage) from [Image]) + 1; " +
                        "insert into dbo.[Image] (idImage, Title, Photo) values " +
                        $"(@idImages, @Title, @Photo)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Title", iImageExtension);
                    sqlCommand.Parameters.AddWithValue("Photo", imageData);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                ReadImage();

                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Student(" +
                    "IdPassport, IdGroup, SNILS, INN, IdAddress, IdFamily, IdFamilyStatus, NumberPhone, " +
                    "Email, IdMom, IdDad, HospitalPolice, IdImage, IdTemporaryRegistration, IdStatus, " +
                    "IdMomGuradian, IdDadGuardina, NumberOrder, DateOrder, Comment) " +
                    "values(@IdPassport, @IdGroup, @SNILS, @INN, " +
                    "@IdAddress, @IdFamily, @IdFamilyStatus, @NumberPhone, " +
                    "@Email, @IdMom, @IdDad, @HospitalPolice, @IdImage, @IdTemporaryRegistration, @IdStatus, " +
                    "@IdMomGuradian, @IdDadGuardina, @NumberOrder, @DateOrder, @Comment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("IdPassport", ClassFolder.TableFolder.ClassPassport.IdPassport);
                sqlCommand.Parameters.AddWithValue("IdGroup", ClassFolder.TableFolder.ClassUser.IdGroup);
                sqlCommand.Parameters.AddWithValue("SNILS", TbSNILS.Text);
                sqlCommand.Parameters.AddWithValue("INN", TbINN.Text);
                sqlCommand.Parameters.AddWithValue("IdAddress", ClassFolder.TableFolder.ClassAddress.IdAddress);
                sqlCommand.Parameters.AddWithValue("IdFamily", Int32.Parse(CbFamily.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdFamilyStatus", Int32.Parse(CbFamilyStatus.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("NumberPhone", TbNumberPhone.Text);
                sqlCommand.Parameters.AddWithValue("Email", TbEmail.Text);
                sqlCommand.Parameters.AddWithValue("IdMom", ClassFolder.TableFolder.ClassParents.IdMom);
                sqlCommand.Parameters.AddWithValue("IdDad", ClassFolder.TableFolder.ClassParents.IdDad);
                sqlCommand.Parameters.AddWithValue("HospitalPolice", TbHospital.Text);
                sqlCommand.Parameters.AddWithValue("IdStatus", 1);
                sqlCommand.Parameters.AddWithValue("IdMomGuradian", ClassFolder.TableFolder.ClassParentGuard.IdMomGuradian);
                sqlCommand.Parameters.AddWithValue("IdDadGuardina", ClassFolder.TableFolder.ClassParentGuard.IdDadGuradian);
                sqlCommand.Parameters.AddWithValue("IdImage", ClassFolder.TableFolder.ClassImage.IdImage);
                sqlCommand.Parameters.AddWithValue("IdTemporaryRegistration", ClassFolder.TableFolder.ClassVremAddress.IdVremReg);
                sqlCommand.Parameters.AddWithValue("NumberOrder", TbOrder.Text);
                sqlCommand.Parameters.AddWithValue("DateOrder", DpDateOfOrder.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("Comment", TbComment.Text);
                sqlCommand.ExecuteNonQuery();
                ClassFolder.ClassMB.MBInformation("Студент добавлен");

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadStudent(TbSNILS, TbINN, TbNumberPhone, TbEmail);
            //LoadBDImage(TbImage.Text);
            
        }








        //отец и мать, нет врем адреса
        public void AddAllNullMomDad()
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Registration(" +
                    "PostcodeReg, IdCity, IdStreet, HouseReg, EnclosureReg, AppartmentReg) " +
                    "Values(" +
                    "@PostcodeReg, @IdCity, @IdStreet, @HouseReg, @EnclosureReg, @AppartmentReg)",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("PostcodeReg", Int32.Parse(TbRegPostcode.Text));
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRegCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRegStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("HouseReg", TbRegHouse.Text);
                sqlCommand.Parameters.AddWithValue("EnclosureReg", TbRegEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("AppartmentReg", Int32.Parse(TbRegAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadRegistration(CbRegCity, CbRegStreet, TbRegPostcode, TbRegHouse, TbRegEnclosure, TbRegAppartment);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Passport(" +
                    "LastName, FirstName, MiddleName, Series, Number, IdIssuedByWhom, " +
                    "DateOfIssue, CodeDivision, IdGender, DateOfBorn, IdPlaceOfBorn, FamilyPosition, " +
                    "IdRegistration) " +
                    "Values(" +
                    "@LastName, @FirstName, @MiddleName, @Series, @Number, @IdIssuedByWhom, " +
                    "@DateOfIssue, @CodeDivision, @IdGender, @DateOfBorn, @IdPlaceOfBorn, @FamilyPosition, " +
                    "@IdRegistration)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastName", TbLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstName", TbFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleName", TbMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("Series", Int32.Parse(TbSeries.Text));
                sqlCommand.Parameters.AddWithValue("Number", Int32.Parse(TbNumber.Text));
                sqlCommand.Parameters.AddWithValue("IdIssuedByWhom", Int32.Parse(CbIsuedByWhom.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfIssue", DpDateOfIsue.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("CodeDivision", TbCode.Text);
                sqlCommand.Parameters.AddWithValue("IdGender", Int32.Parse(CbGender.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfBorn", DpDateOfBorn.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("IdPlaceOfBorn", Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("FamilyPosition", ChbFamilyPosition.IsChecked);
                sqlCommand.Parameters.AddWithValue("IdRegistration", ClassFolder.TableFolder.ClassRegistration.IdReg);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadPassport(TbLastName, TbFirstName, TbMiddleName, TbSeries, TbNumber, CbIsuedByWhom,
                DpDateOfIsue, TbCode, CbGender, DpDateOfBorn, CbPlaceOfBorn);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Address(" +
                    "Postcode, IdCity, IdStreet, House, Enclosure, Appartment) " +
                    "Values(" +
                    "@Postcode, @IdCity, @IdStreet, @House, @Enclosure, @Appartment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("Postcode", TbRealPostcode.Text);
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRealCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRealStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("House", TbRealHouse.Text);
                sqlCommand.Parameters.AddWithValue("Enclosure", TbRealEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("Appartment", Int32.Parse(TbRealAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadAddress(CbRealCity, CbRealStreet, TbRealPostcode, TbRealHouse, TbRealEnclosure, TbRealAppartment);


            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Dad(LastNameDad, FirstNameDad, " +
                    "MiddleNameDad, NumberPhoneDad) " +
                    "values(@LastNameDad, @FirstNameDad, @MiddleNameDad, @NumberPhoneDad)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameDad", TbDadLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstNameDad", TbDadFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleNameDad", TbDadMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("NumberPhoneDad", TbDadNumberPhone.Text);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadDad(TbDadLastName, TbDadFirstName, TbDadMiddleName, TbDadNumberPhone);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Mom(LastNameMom, FirstNameMom, " +
                    "MiddleNameMom, NumberPhoneMom) " +
                    "values(@LastNameMom, @FirstNameMom, @MiddleNameMom, @NumberPhoneMom)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameMom", TbMomLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstNameMom", TbMomFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleNameMom", TbMomMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("NumberPhoneMom", TbMomNumberPhone.Text);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadMom(TbMomLastName, TbMomFirstName, TbMomMiddleName, TbMomNumberPhone);

            classAdd.AddNullDadGuard();
            classRead.ReadNullDadGuard();
            classAdd.AddNullMomGuard();
            classRead.ReadNullMomGuard();
            classAdd.AddNullTempReg();
            classRead.ReadNullTempReg();
            try
            {
                string iFile = TbImage.Text;
                // конвертация изображения в байты
                byte[] imageData = null;
                FileInfo fInfo = new FileInfo(iFile);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                imageData = br.ReadBytes((int)numBytes);
                //  получение расширения файла изображения не забыв удалить точку перед расширением
                string iImageExtension = (System.IO.Path.GetExtension(iFile)).Replace(".", "").ToLower();

                using (SqlConnection sql = new SqlConnection(s))
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("declare @idImages int; " +
                        "set @idImages =(select max(IdImage) from [Image]) + 1; " +
                        "insert into dbo.[Image] (idImage, Title, Photo) values " +
                        $"(@idImages, @Title, @Photo)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Title", iImageExtension);
                    sqlCommand.Parameters.AddWithValue("Photo", imageData);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                ReadImage();

                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Student(" +
                    "IdPassport, IdGroup, SNILS, INN, IdAddress, IdFamily, IdFamilyStatus, NumberPhone, " +
                    "Email, IdMom, IdDad, HospitalPolice, IdImage, IdTemporaryRegistration, IdStatus, " +
                    "IdMomGuradian, IdDadGuardina, NumberOrder, DateOrder, Comment) " +
                    "values(@IdPassport, @IdGroup, @SNILS, @INN, " +
                    "@IdAddress, @IdFamily, @IdFamilyStatus, @NumberPhone, " +
                    "@Email, @IdMom, @IdDad, @HospitalPolice, @IdImage, @IdTemporaryRegistration, @IdStatus, " +
                    "@IdMomGuradian, @IdDadGuardina, @NumberOrder, @DateOrder, @Comment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("IdPassport", ClassFolder.TableFolder.ClassPassport.IdPassport);
                sqlCommand.Parameters.AddWithValue("IdGroup", ClassFolder.TableFolder.ClassUser.IdGroup);
                sqlCommand.Parameters.AddWithValue("SNILS", TbSNILS.Text);
                sqlCommand.Parameters.AddWithValue("INN", TbINN.Text);
                sqlCommand.Parameters.AddWithValue("IdAddress", ClassFolder.TableFolder.ClassAddress.IdAddress);
                sqlCommand.Parameters.AddWithValue("IdFamily", Int32.Parse(CbFamily.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdFamilyStatus", Int32.Parse(CbFamilyStatus.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("NumberPhone", TbNumberPhone.Text);
                sqlCommand.Parameters.AddWithValue("Email", TbEmail.Text);
                sqlCommand.Parameters.AddWithValue("IdMom", ClassFolder.TableFolder.ClassParents.IdMom);
                sqlCommand.Parameters.AddWithValue("IdDad", ClassFolder.TableFolder.ClassParents.IdDad);
                sqlCommand.Parameters.AddWithValue("HospitalPolice", TbHospital.Text);
                sqlCommand.Parameters.AddWithValue("IdStatus", 1);
                sqlCommand.Parameters.AddWithValue("IdMomGuradian", ClassFolder.TableFolder.ClassParentGuard.IdMomGuradian);
                sqlCommand.Parameters.AddWithValue("IdDadGuardina", ClassFolder.TableFolder.ClassParentGuard.IdDadGuradian);
                sqlCommand.Parameters.AddWithValue("IdImage", ClassFolder.TableFolder.ClassImage.IdImage);
                sqlCommand.Parameters.AddWithValue("IdTemporaryRegistration", ClassFolder.TableFolder.ClassVremAddress.IdVremReg);
                sqlCommand.Parameters.AddWithValue("NumberOrder", TbOrder.Text);
                sqlCommand.Parameters.AddWithValue("DateOrder", DpDateOfOrder.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("Comment", TbComment.Text);
                sqlCommand.ExecuteNonQuery();
                ClassFolder.ClassMB.MBInformation("Студент добавлен");
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadStudent(TbSNILS, TbINN, TbNumberPhone, TbEmail);
            //LoadBDImage(TbImage.Text);
           
        }









        //мама и (отец опекун), нет врем адреса
        public void AddAllNullMomDadGuard()
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Registration(" +
                    "PostcodeReg, IdCity, IdStreet, HouseReg, EnclosureReg, AppartmentReg) " +
                    "Values(" +
                    "@PostcodeReg, @IdCity, @IdStreet, @HouseReg, @EnclosureReg, @AppartmentReg)",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("PostcodeReg", Int32.Parse(TbRegPostcode.Text));
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRegCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRegStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("HouseReg", TbRegHouse.Text);
                sqlCommand.Parameters.AddWithValue("EnclosureReg", TbRegEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("AppartmentReg", Int32.Parse(TbRegAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadRegistration(CbRegCity, CbRegStreet, TbRegPostcode, TbRegHouse, TbRegEnclosure, TbRegAppartment);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Passport(" +
                    "LastName, FirstName, MiddleName, Series, Number, IdIssuedByWhom, " +
                    "DateOfIssue, CodeDivision, IdGender, DateOfBorn, IdPlaceOfBorn, FamilyPosition, " +
                    "IdRegistration) " +
                    "Values(" +
                    "@LastName, @FirstName, @MiddleName, @Series, @Number, @IdIssuedByWhom, " +
                    "@DateOfIssue, @CodeDivision, @IdGender, @DateOfBorn, @IdPlaceOfBorn, @FamilyPosition, " +
                    "@IdRegistration)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastName", TbLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstName", TbFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleName", TbMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("Series", Int32.Parse(TbSeries.Text));
                sqlCommand.Parameters.AddWithValue("Number", Int32.Parse(TbNumber.Text));
                sqlCommand.Parameters.AddWithValue("IdIssuedByWhom", Int32.Parse(CbIsuedByWhom.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfIssue", DpDateOfIsue.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("CodeDivision", TbCode.Text);
                sqlCommand.Parameters.AddWithValue("IdGender", Int32.Parse(CbGender.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfBorn", DpDateOfBorn.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("IdPlaceOfBorn", Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("FamilyPosition", ChbFamilyPosition.IsChecked);
                sqlCommand.Parameters.AddWithValue("IdRegistration", ClassFolder.TableFolder.ClassRegistration.IdReg);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadPassport(TbLastName, TbFirstName, TbMiddleName, TbSeries, TbNumber, CbIsuedByWhom,
                DpDateOfIsue, TbCode, CbGender, DpDateOfBorn, CbPlaceOfBorn);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Address(" +
                    "Postcode, IdCity, IdStreet, House, Enclosure, Appartment) " +
                    "Values(" +
                    "@Postcode, @IdCity, @IdStreet, @House, @Enclosure, @Appartment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("Postcode", TbRealPostcode.Text);
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRealCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRealStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("House", TbRealHouse.Text);
                sqlCommand.Parameters.AddWithValue("Enclosure", TbRealEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("Appartment", Int32.Parse(TbRealAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadAddress(CbRealCity, CbRealStreet, TbRealPostcode, TbRealHouse, TbRealEnclosure, TbRealAppartment);


            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Mom(LastNameMom, FirstNameMom, " +
                    "MiddleNameMom, NumberPhoneMom) " +
                    "values(@LastNameMom, @FirstNameMom, @MiddleNameMom, @NumberPhoneMom)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameMom", TbMomLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstNameMom", TbMomFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleNameMom", TbMomMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("NumberPhoneMom", TbMomNumberPhone.Text);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadMom(TbMomLastName, TbMomFirstName, TbMomMiddleName, TbMomNumberPhone);


            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.GuardianDad(LastNameGuardianDad, " +
                    "FirstNameGuardianDad, MiddleNameGuardianDad, NumberPhoneGuardianDad) " +
                    "values(@LastNameGuardianDad, @FirstNameGuardianDad, " +
                    "@MiddleNameGuardianDad, @NumberPhoneGuardianDad)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameGuardianDad", TbDadLastNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("FirstNameGuardianDad", TbDadFirstNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("MiddleNameGuardianDad", TbDadMiddleNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("NumberPhoneGuardianDad", TbDadNumberPhoneGuard.Text);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
           ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadGuardianDad(TbDadLastNameGuard, TbDadFirstNameGuard, TbDadMiddleNameGuard, TbDadNumberPhoneGuard);
            classAdd.AddNullDad();
            classRead.ReadNullDad();
            classAdd.AddNullMomGuard();
            classRead.ReadNullMomGuard();
            classAdd.AddNullTempReg();
            classRead.ReadNullTempReg();

            try
            {
                string iFile = TbImage.Text;
                // конвертация изображения в байты
                byte[] imageData = null;
                FileInfo fInfo = new FileInfo(iFile);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                imageData = br.ReadBytes((int)numBytes);
                //  получение расширения файла изображения не забыв удалить точку перед расширением
                string iImageExtension = (System.IO.Path.GetExtension(iFile)).Replace(".", "").ToLower();

                using (SqlConnection sql = new SqlConnection(s))
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("declare @idImages int; " +
                        "set @idImages =(select max(IdImage) from [Image]) + 1; " +
                        "insert into dbo.[Image] (idImage, Title, Photo) values " +
                        $"(@idImages, @Title, @Photo)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Title", iImageExtension);
                    sqlCommand.Parameters.AddWithValue("Photo", imageData);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                ReadImage();

                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Student(" +
                    "IdPassport, IdGroup, SNILS, INN, IdAddress, IdFamily, IdFamilyStatus, NumberPhone, " +
                    "Email, IdMom, IdDad, HospitalPolice, IdImage, IdTemporaryRegistration, IdStatus, " +
                    "IdMomGuradian, IdDadGuardina, NumberOrder, DateOrder, Comment) " +
                    "values(@IdPassport, @IdGroup, @SNILS, @INN, " +
                    "@IdAddress, @IdFamily, @IdFamilyStatus, @NumberPhone, " +
                    "@Email, @IdMom, @IdDad, @HospitalPolice, @IdImage, @IdTemporaryRegistration, @IdStatus, " +
                    "@IdMomGuradian, @IdDadGuardina, @NumberOrder, @DateOrder, @Comment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("IdPassport", ClassFolder.TableFolder.ClassPassport.IdPassport);
                sqlCommand.Parameters.AddWithValue("IdGroup", ClassFolder.TableFolder.ClassUser.IdGroup);
                sqlCommand.Parameters.AddWithValue("SNILS", TbSNILS.Text);
                sqlCommand.Parameters.AddWithValue("INN", TbINN.Text);
                sqlCommand.Parameters.AddWithValue("IdAddress", ClassFolder.TableFolder.ClassAddress.IdAddress);
                sqlCommand.Parameters.AddWithValue("IdFamily", Int32.Parse(CbFamily.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdFamilyStatus", Int32.Parse(CbFamilyStatus.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("NumberPhone", TbNumberPhone.Text);
                sqlCommand.Parameters.AddWithValue("Email", TbEmail.Text);
                sqlCommand.Parameters.AddWithValue("IdMom", ClassFolder.TableFolder.ClassParents.IdMom);
                sqlCommand.Parameters.AddWithValue("IdDad", ClassFolder.TableFolder.ClassParents.IdDad);
                sqlCommand.Parameters.AddWithValue("HospitalPolice", TbHospital.Text);
                sqlCommand.Parameters.AddWithValue("IdStatus", 1);
                sqlCommand.Parameters.AddWithValue("IdMomGuradian", ClassFolder.TableFolder.ClassParentGuard.IdMomGuradian);
                sqlCommand.Parameters.AddWithValue("IdDadGuardina", ClassFolder.TableFolder.ClassParentGuard.IdDadGuradian);
                sqlCommand.Parameters.AddWithValue("IdImage", ClassFolder.TableFolder.ClassImage.IdImage);
                sqlCommand.Parameters.AddWithValue("IdTemporaryRegistration", ClassFolder.TableFolder.ClassVremAddress.IdVremReg);
                sqlCommand.Parameters.AddWithValue("NumberOrder", TbOrder.Text);
                sqlCommand.Parameters.AddWithValue("DateOrder", DpDateOfOrder.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("Comment", TbComment.Text);
                sqlCommand.ExecuteNonQuery();
                ClassFolder.ClassMB.MBInformation("Студент добавлен");
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadStudent(TbSNILS, TbINN, TbNumberPhone, TbEmail);
            //LoadBDImage(TbImage.Text);
            
        }











        //отец и (мать опекун), нет врем адреса
        public void AddAllNullMomGuardDad()
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Registration(" +
                    "PostcodeReg, IdCity, IdStreet, HouseReg, EnclosureReg, AppartmentReg) " +
                    "Values(" +
                    "@PostcodeReg, @IdCity, @IdStreet, @HouseReg, @EnclosureReg, @AppartmentReg)",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("PostcodeReg", Int32.Parse(TbRegPostcode.Text));
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRegCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRegStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("HouseReg", TbRegHouse.Text);
                sqlCommand.Parameters.AddWithValue("EnclosureReg", TbRegEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("AppartmentReg", Int32.Parse(TbRegAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadRegistration(CbRegCity, CbRegStreet, TbRegPostcode, TbRegHouse, TbRegEnclosure, TbRegAppartment);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Passport(" +
                    "LastName, FirstName, MiddleName, Series, Number, IdIssuedByWhom, " +
                    "DateOfIssue, CodeDivision, IdGender, DateOfBorn, IdPlaceOfBorn, FamilyPosition, " +
                    "IdRegistration) " +
                    "Values(" +
                    "@LastName, @FirstName, @MiddleName, @Series, @Number, @IdIssuedByWhom, " +
                    "@DateOfIssue, @CodeDivision, @IdGender, @DateOfBorn, @IdPlaceOfBorn, @FamilyPosition, " +
                    "@IdRegistration)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastName", TbLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstName", TbFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleName", TbMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("Series", Int32.Parse(TbSeries.Text));
                sqlCommand.Parameters.AddWithValue("Number", Int32.Parse(TbNumber.Text));
                sqlCommand.Parameters.AddWithValue("IdIssuedByWhom", Int32.Parse(CbIsuedByWhom.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfIssue", DpDateOfIsue.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("CodeDivision", TbCode.Text);
                sqlCommand.Parameters.AddWithValue("IdGender", Int32.Parse(CbGender.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfBorn", DpDateOfBorn.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("IdPlaceOfBorn", Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("FamilyPosition", ChbFamilyPosition.IsChecked);
                sqlCommand.Parameters.AddWithValue("IdRegistration", ClassFolder.TableFolder.ClassRegistration.IdReg);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadPassport(TbLastName, TbFirstName, TbMiddleName, TbSeries, TbNumber, CbIsuedByWhom,
                DpDateOfIsue, TbCode, CbGender, DpDateOfBorn, CbPlaceOfBorn);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Address(" +
                    "Postcode, IdCity, IdStreet, House, Enclosure, Appartment) " +
                    "Values(" +
                    "@Postcode, @IdCity, @IdStreet, @House, @Enclosure, @Appartment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("Postcode", TbRealPostcode.Text);
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRealCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRealStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("House", TbRealHouse.Text);
                sqlCommand.Parameters.AddWithValue("Enclosure", TbRealEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("Appartment", Int32.Parse(TbRealAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadAddress(CbRealCity, CbRealStreet, TbRealPostcode, TbRealHouse, TbRealEnclosure, TbRealAppartment);


            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.GuardianMom(LastNameGuardianMom, FirstNameGuardianMom, " +
                    "MiddleNameGuardianMom, NumberPhoneGuardianMom) " +
                    "values(@LastNameGuardianMom, @FirstNameGuardianMom, " +
                    "@MiddleNameGuardianMom, @NumberPhoneGuardianMom)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameGuardianMom", TbMomLastNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("FirstNameGuardianMom", TbMomFirstNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("MiddleNameGuardianMom", TbMomMiddleNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("NumberPhoneGuardianMom", TbMomNumberPhoneGuard.Text);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadGuardianMom(TbMomLastNameGuard, TbMomFirstNameGuard, TbMomMiddleNameGuard, TbMomNumberPhoneGuard);

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Dad(LastNameDad, FirstNameDad, " +
                    "MiddleNameDad, NumberPhoneDad) " +
                    "values(@LastNameDad, @FirstNameDad, @MiddleNameDad, @NumberPhoneDad)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameDad", TbDadLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstNameDad", TbDadFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleNameDad", TbDadMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("NumberPhoneDad", TbDadNumberPhone.Text);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadDad(TbDadLastName, TbDadFirstName, TbDadMiddleName, TbDadNumberPhone);
            classAdd.AddNullMom();
            classRead.ReadNullMom();
            classAdd.AddNullDadGuard();
            classRead.ReadNullDadGuard();
            classAdd.AddNullTempReg();
            classRead.ReadNullTempReg();

            try
            {
                string iFile = TbImage.Text;
                // конвертация изображения в байты
                byte[] imageData = null;
                FileInfo fInfo = new FileInfo(iFile);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                imageData = br.ReadBytes((int)numBytes);
                //  получение расширения файла изображения не забыв удалить точку перед расширением
                string iImageExtension = (System.IO.Path.GetExtension(iFile)).Replace(".", "").ToLower();

                using (SqlConnection sql = new SqlConnection(s))
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("declare @idImages int; " +
                        "set @idImages =(select max(IdImage) from [Image]) + 1; " +
                        "insert into dbo.[Image] (idImage, Title, Photo) values " +
                        $"(@idImages, @Title, @Photo)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Title", iImageExtension);
                    sqlCommand.Parameters.AddWithValue("Photo", imageData);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                ReadImage();

                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Student(" +
                    "IdPassport, IdGroup, SNILS, INN, IdAddress, IdFamily, IdFamilyStatus, NumberPhone, " +
                    "Email, IdMom, IdDad, HospitalPolice, IdImage, IdTemporaryRegistration, IdStatus, " +
                    "IdMomGuradian, IdDadGuardina, NumberOrder, DateOrder, Comment) " +
                    "values(@IdPassport, @IdGroup, @SNILS, @INN, " +
                    "@IdAddress, @IdFamily, @IdFamilyStatus, @NumberPhone, " +
                    "@Email, @IdMom, @IdDad, @HospitalPolice, @IdImage, @IdTemporaryRegistration, @IdStatus, " +
                    "@IdMomGuradian, @IdDadGuardina, @NumberOrder, @DateOrder, @Comment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("IdPassport", ClassFolder.TableFolder.ClassPassport.IdPassport);
                sqlCommand.Parameters.AddWithValue("IdGroup", ClassFolder.TableFolder.ClassUser.IdGroup);
                sqlCommand.Parameters.AddWithValue("SNILS", TbSNILS.Text);
                sqlCommand.Parameters.AddWithValue("INN", TbINN.Text);
                sqlCommand.Parameters.AddWithValue("IdAddress", ClassFolder.TableFolder.ClassAddress.IdAddress);
                sqlCommand.Parameters.AddWithValue("IdFamily", Int32.Parse(CbFamily.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdFamilyStatus", Int32.Parse(CbFamilyStatus.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("NumberPhone", TbNumberPhone.Text);
                sqlCommand.Parameters.AddWithValue("Email", TbEmail.Text);
                sqlCommand.Parameters.AddWithValue("IdMom", ClassFolder.TableFolder.ClassParents.IdMom);
                sqlCommand.Parameters.AddWithValue("IdDad", ClassFolder.TableFolder.ClassParents.IdDad);
                sqlCommand.Parameters.AddWithValue("HospitalPolice", TbHospital.Text);
                sqlCommand.Parameters.AddWithValue("IdStatus", 1);
                sqlCommand.Parameters.AddWithValue("IdMomGuradian", ClassFolder.TableFolder.ClassParentGuard.IdMomGuradian);
                sqlCommand.Parameters.AddWithValue("IdDadGuardina", ClassFolder.TableFolder.ClassParentGuard.IdDadGuradian);
                sqlCommand.Parameters.AddWithValue("IdImage", ClassFolder.TableFolder.ClassImage.IdImage);
                sqlCommand.Parameters.AddWithValue("IdTemporaryRegistration", ClassFolder.TableFolder.ClassVremAddress.IdVremReg);
                sqlCommand.Parameters.AddWithValue("NumberOrder", TbOrder.Text);
                sqlCommand.Parameters.AddWithValue("DateOrder", DpDateOfOrder.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("Comment", TbComment.Text);
                sqlCommand.ExecuteNonQuery();
                ClassFolder.ClassMB.MBInformation("Студент добавлен");
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadStudent(TbSNILS, TbINN, TbNumberPhone, TbEmail);
            //LoadBDImage(TbImage.Text);
            
        }










































        //отец опекун
        public void AddDadGuard()
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Registration(" +
                    "PostcodeReg, IdCity, IdStreet, HouseReg, EnclosureReg, AppartmentReg) " +
                    "Values(" +
                    "@PostcodeReg, @IdCity, @IdStreet, @HouseReg, @EnclosureReg, @AppartmentReg)",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("PostcodeReg", Int32.Parse(TbRegPostcode.Text));
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRegCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRegStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("HouseReg", TbRegHouse.Text);
                sqlCommand.Parameters.AddWithValue("EnclosureReg", TbRegEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("AppartmentReg", Int32.Parse(TbRegAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadRegistration(CbRegCity, CbRegStreet, TbRegPostcode, TbRegHouse, TbRegEnclosure, TbRegAppartment);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Passport(" +
                    "LastName, FirstName, MiddleName, Series, Number, IdIssuedByWhom, " +
                    "DateOfIssue, CodeDivision, IdGender, DateOfBorn, IdPlaceOfBorn, FamilyPosition, " +
                    "IdRegistration) " +
                    "Values(" +
                    "@LastName, @FirstName, @MiddleName, @Series, @Number, @IdIssuedByWhom, " +
                    "@DateOfIssue, @CodeDivision, @IdGender, @DateOfBorn, @IdPlaceOfBorn, @FamilyPosition, " +
                    "@IdRegistration)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastName", TbLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstName", TbFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleName", TbMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("Series", Int32.Parse(TbSeries.Text));
                sqlCommand.Parameters.AddWithValue("Number", Int32.Parse(TbNumber.Text));
                sqlCommand.Parameters.AddWithValue("IdIssuedByWhom", Int32.Parse(CbIsuedByWhom.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfIssue", DpDateOfIsue.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("CodeDivision", TbCode.Text);
                sqlCommand.Parameters.AddWithValue("IdGender", Int32.Parse(CbGender.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfBorn", DpDateOfBorn.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("IdPlaceOfBorn", Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("FamilyPosition", ChbFamilyPosition.IsChecked);
                sqlCommand.Parameters.AddWithValue("IdRegistration", ClassFolder.TableFolder.ClassRegistration.IdReg);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadPassport(TbLastName, TbFirstName, TbMiddleName, TbSeries, TbNumber, CbIsuedByWhom,
                DpDateOfIsue, TbCode, CbGender, DpDateOfBorn, CbPlaceOfBorn);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Address(" +
                    "Postcode, IdCity, IdStreet, House, Enclosure, Appartment) " +
                    "Values(" +
                    "@Postcode, @IdCity, @IdStreet, @House, @Enclosure, @Appartment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("Postcode", TbRealPostcode.Text);
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRealCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRealStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("House", TbRealHouse.Text);
                sqlCommand.Parameters.AddWithValue("Enclosure", TbRealEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("Appartment", Int32.Parse(TbRealAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadAddress(CbRealCity, CbRealStreet, TbRealPostcode, TbRealHouse, TbRealEnclosure, TbRealAppartment);

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.TemporaryRegistration " +
                    "(PostcodeTemp, IdCity, IdStreet, HouseTemp, EnclosureTemp, AppartmentTemp) " +
                    "Values(@PostcodeTemp, @IdCity, @IdStreet, @HouseTemp, @EnclosureTemp, @AppartmentTemp)",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("PostcodeTemp", TbVremPostcode.Text);
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbVremCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbVremStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("HouseTemp", TbVremHouse.Text);
                sqlCommand.Parameters.AddWithValue("EnclosureTemp", TbVremEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("AppartmentTemp", TbVremAppartment.Text);
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }

            classRead.VremRegistration(CbVremCity, CbVremStreet, TbVremPostcode, TbVremHouse, TbVremEnclosure, TbVremAppartment);


            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.GuardianDad(LastNameGuardianDad, " +
                    "FirstNameGuardianDad, MiddleNameGuardianDad, NumberPhoneGuardianDad) " +
                    "values(@LastNameGuardianDad, @FirstNameGuardianDad, " +
                    "@MiddleNameGuardianDad, @NumberPhoneGuardianDad)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameGuardianDad", TbDadLastNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("FirstNameGuardianDad", TbDadFirstNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("MiddleNameGuardianDad", TbDadMiddleNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("NumberPhoneGuardianDad", TbDadNumberPhoneGuard.Text);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadGuardianDad(TbDadLastNameGuard, TbDadFirstNameGuard, TbDadMiddleNameGuard, TbDadNumberPhoneGuard);
            classAdd.AddNullDad();
            classRead.ReadNullDad();
            classAdd.AddNullMom();
            classRead.ReadNullMom();
            classAdd.AddNullMomGuard();
            classRead.ReadNullMomGuard();
            try
            {
                string iFile = TbImage.Text;
                // конвертация изображения в байты
                byte[] imageData = null;
                FileInfo fInfo = new FileInfo(iFile);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                imageData = br.ReadBytes((int)numBytes);
                //  получение расширения файла изображения не забыв удалить точку перед расширением
                string iImageExtension = (System.IO.Path.GetExtension(iFile)).Replace(".", "").ToLower();

                using (SqlConnection sql = new SqlConnection(s))
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("declare @idImages int; " +
                        "set @idImages =(select max(IdImage) from [Image]) + 1; " +
                        "insert into dbo.[Image] (idImage, Title, Photo) values " +
                        $"(@idImages, @Title, @Photo)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Title", iImageExtension);
                    sqlCommand.Parameters.AddWithValue("Photo", imageData);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                ReadImage();

                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Student(" +
                    "IdPassport, IdGroup, SNILS, INN, IdAddress, IdFamily, IdFamilyStatus, NumberPhone, " +
                    "Email, IdMom, IdDad, HospitalPolice, IdImage, IdTemporaryRegistration, IdStatus, " +
                    "IdMomGuradian, IdDadGuardina, NumberOrder, DateOrder, Comment) " +
                    "values(@IdPassport, @IdGroup, @SNILS, @INN, " +
                    "@IdAddress, @IdFamily, @IdFamilyStatus, @NumberPhone, " +
                    "@Email, @IdMom, @IdDad, @HospitalPolice, @IdImage, @IdTemporaryRegistration, @IdStatus, " +
                    "@IdMomGuradian, @IdDadGuardina, @NumberOrder, @DateOrder, @Comment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("IdPassport", ClassFolder.TableFolder.ClassPassport.IdPassport);
                sqlCommand.Parameters.AddWithValue("IdGroup", ClassFolder.TableFolder.ClassUser.IdGroup);
                sqlCommand.Parameters.AddWithValue("SNILS", TbSNILS.Text);
                sqlCommand.Parameters.AddWithValue("INN", TbINN.Text);
                sqlCommand.Parameters.AddWithValue("IdAddress", ClassFolder.TableFolder.ClassAddress.IdAddress);
                sqlCommand.Parameters.AddWithValue("IdFamily", Int32.Parse(CbFamily.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdFamilyStatus", Int32.Parse(CbFamilyStatus.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("NumberPhone", TbNumberPhone.Text);
                sqlCommand.Parameters.AddWithValue("Email", TbEmail.Text);
                sqlCommand.Parameters.AddWithValue("IdMom", ClassFolder.TableFolder.ClassParents.IdMom);
                sqlCommand.Parameters.AddWithValue("IdDad", ClassFolder.TableFolder.ClassParents.IdDad);
                sqlCommand.Parameters.AddWithValue("HospitalPolice", TbHospital.Text);
                sqlCommand.Parameters.AddWithValue("IdStatus", 1);
                sqlCommand.Parameters.AddWithValue("IdMomGuradian", ClassFolder.TableFolder.ClassParentGuard.IdMomGuradian);
                sqlCommand.Parameters.AddWithValue("IdDadGuardina", ClassFolder.TableFolder.ClassParentGuard.IdDadGuradian);
                sqlCommand.Parameters.AddWithValue("IdImage", ClassFolder.TableFolder.ClassImage.IdImage);
                sqlCommand.Parameters.AddWithValue("IdTemporaryRegistration", ClassFolder.TableFolder.ClassVremAddress.IdVremReg);
                sqlCommand.Parameters.AddWithValue("NumberOrder", TbOrder.Text);
                sqlCommand.Parameters.AddWithValue("DateOrder", DpDateOfOrder.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("Comment", TbComment.Text);
                sqlCommand.ExecuteNonQuery();
                ClassFolder.ClassMB.MBInformation("Студент добавлен");
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadStudent(TbSNILS, TbINN, TbNumberPhone, TbEmail);
            //LoadBDImage(TbImage.Text);
            
        }



















        //мама опекун
        public void AddMomGuard()
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Registration(" +
                    "PostcodeReg, IdCity, IdStreet, HouseReg, EnclosureReg, AppartmentReg) " +
                    "Values(" +
                    "@PostcodeReg, @IdCity, @IdStreet, @HouseReg, @EnclosureReg, @AppartmentReg)",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("PostcodeReg", Int32.Parse(TbRegPostcode.Text));
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRegCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRegStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("HouseReg", TbRegHouse.Text);
                sqlCommand.Parameters.AddWithValue("EnclosureReg", TbRegEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("AppartmentReg", Int32.Parse(TbRegAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadRegistration(CbRegCity, CbRegStreet, TbRegPostcode, TbRegHouse, TbRegEnclosure, TbRegAppartment);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Passport(" +
                    "LastName, FirstName, MiddleName, Series, Number, IdIssuedByWhom, " +
                    "DateOfIssue, CodeDivision, IdGender, DateOfBorn, IdPlaceOfBorn, FamilyPosition, " +
                    "IdRegistration) " +
                    "Values(" +
                    "@LastName, @FirstName, @MiddleName, @Series, @Number, @IdIssuedByWhom, " +
                    "@DateOfIssue, @CodeDivision, @IdGender, @DateOfBorn, @IdPlaceOfBorn, @FamilyPosition, " +
                    "@IdRegistration)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastName", TbLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstName", TbFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleName", TbMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("Series", Int32.Parse(TbSeries.Text));
                sqlCommand.Parameters.AddWithValue("Number", Int32.Parse(TbNumber.Text));
                sqlCommand.Parameters.AddWithValue("IdIssuedByWhom", Int32.Parse(CbIsuedByWhom.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfIssue", DpDateOfIsue.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("CodeDivision", TbCode.Text);
                sqlCommand.Parameters.AddWithValue("IdGender", Int32.Parse(CbGender.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfBorn", DpDateOfBorn.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("IdPlaceOfBorn", Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("FamilyPosition", ChbFamilyPosition.IsChecked);
                sqlCommand.Parameters.AddWithValue("IdRegistration", ClassFolder.TableFolder.ClassRegistration.IdReg);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadPassport(TbLastName, TbFirstName, TbMiddleName, TbSeries, TbNumber, CbIsuedByWhom,
                DpDateOfIsue, TbCode, CbGender, DpDateOfBorn, CbPlaceOfBorn);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Address(" +
                    "Postcode, IdCity, IdStreet, House, Enclosure, Appartment) " +
                    "Values(" +
                    "@Postcode, @IdCity, @IdStreet, @House, @Enclosure, @Appartment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("Postcode", TbRealPostcode.Text);
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRealCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRealStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("House", TbRealHouse.Text);
                sqlCommand.Parameters.AddWithValue("Enclosure", TbRealEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("Appartment", Int32.Parse(TbRealAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadAddress(CbRealCity, CbRealStreet, TbRealPostcode, TbRealHouse, TbRealEnclosure, TbRealAppartment);


            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.GuardianMom(LastNameGuardianMom, FirstNameGuardianMom, " +
                    "MiddleNameGuardianMom, NumberPhoneGuardianMom) " +
                    "values(@LastNameGuardianMom, @FirstNameGuardianMom, " +
                    "@MiddleNameGuardianMom, @NumberPhoneGuardianMom)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameGuardianMom", TbMomLastNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("FirstNameGuardianMom", TbMomFirstNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("MiddleNameGuardianMom", TbMomMiddleNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("NumberPhoneGuardianMom", TbMomNumberPhoneGuard.Text);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadGuardianMom(TbMomLastNameGuard, TbMomFirstNameGuard, TbMomMiddleNameGuard, TbMomNumberPhoneGuard);

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.TemporaryRegistration " +
                    "(PostcodeTemp, IdCity, IdStreet, HouseTemp, EnclosureTemp, AppartmentTemp) " +
                    "Values(@PostcodeTemp, @IdCity, @IdStreet, @HouseTemp, @EnclosureTemp, @AppartmentTemp)",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("PostcodeTemp", TbVremPostcode.Text);
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbVremCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbVremStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("HouseTemp", TbVremHouse.Text);
                sqlCommand.Parameters.AddWithValue("EnclosureTemp", TbVremEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("AppartmentTemp", TbVremAppartment.Text);
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }

            classRead.VremRegistration(CbVremCity, CbVremStreet, TbVremPostcode, TbVremHouse, TbVremEnclosure, TbVremAppartment);

            classAdd.AddNullDad();
            classRead.ReadNullDad();
            classAdd.AddNullMom();
            classRead.ReadNullMom();
            classAdd.AddNullDadGuard();
            classRead.ReadNullDadGuard();
            try
            {
                string iFile = TbImage.Text;
                // конвертация изображения в байты
                byte[] imageData = null;
                FileInfo fInfo = new FileInfo(iFile);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                imageData = br.ReadBytes((int)numBytes);
                //  получение расширения файла изображения не забыв удалить точку перед расширением
                string iImageExtension = (System.IO.Path.GetExtension(iFile)).Replace(".", "").ToLower();

                using (SqlConnection sql = new SqlConnection(s))
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("declare @idImages int; " +
                        "set @idImages =(select max(IdImage) from [Image]) + 1; " +
                        "insert into dbo.[Image] (idImage, Title, Photo) values " +
                        $"(@idImages, @Title, @Photo)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Title", iImageExtension);
                    sqlCommand.Parameters.AddWithValue("Photo", imageData);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                ReadImage();

                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Student(" +
                    "IdPassport, IdGroup, SNILS, INN, IdAddress, IdFamily, IdFamilyStatus, NumberPhone, " +
                    "Email, IdMom, IdDad, HospitalPolice, IdImage, IdTemporaryRegistration, IdStatus, " +
                    "IdMomGuradian, IdDadGuardina, NumberOrder, DateOrder, Comment) " +
                    "values(@IdPassport, @IdGroup, @SNILS, @INN, " +
                    "@IdAddress, @IdFamily, @IdFamilyStatus, @NumberPhone, " +
                    "@Email, @IdMom, @IdDad, @HospitalPolice, @IdImage, @IdTemporaryRegistration, @IdStatus, " +
                    "@IdMomGuradian, @IdDadGuardina, @NumberOrder, @DateOrder, @Comment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("IdPassport", ClassFolder.TableFolder.ClassPassport.IdPassport);
                sqlCommand.Parameters.AddWithValue("IdGroup", ClassFolder.TableFolder.ClassUser.IdGroup);
                sqlCommand.Parameters.AddWithValue("SNILS", TbSNILS.Text);
                sqlCommand.Parameters.AddWithValue("INN", TbINN.Text);
                sqlCommand.Parameters.AddWithValue("IdAddress", ClassFolder.TableFolder.ClassAddress.IdAddress);
                sqlCommand.Parameters.AddWithValue("IdFamily", Int32.Parse(CbFamily.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdFamilyStatus", Int32.Parse(CbFamilyStatus.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("NumberPhone", TbNumberPhone.Text);
                sqlCommand.Parameters.AddWithValue("Email", TbEmail.Text);
                sqlCommand.Parameters.AddWithValue("IdMom", ClassFolder.TableFolder.ClassParents.IdMom);
                sqlCommand.Parameters.AddWithValue("IdDad", ClassFolder.TableFolder.ClassParents.IdDad);
                sqlCommand.Parameters.AddWithValue("HospitalPolice", TbHospital.Text);
                sqlCommand.Parameters.AddWithValue("IdStatus", 1);
                sqlCommand.Parameters.AddWithValue("IdMomGuradian", ClassFolder.TableFolder.ClassParentGuard.IdMomGuradian);
                sqlCommand.Parameters.AddWithValue("IdDadGuardina", ClassFolder.TableFolder.ClassParentGuard.IdDadGuradian);
                sqlCommand.Parameters.AddWithValue("IdImage", ClassFolder.TableFolder.ClassImage.IdImage);
                sqlCommand.Parameters.AddWithValue("IdTemporaryRegistration", ClassFolder.TableFolder.ClassVremAddress.IdVremReg);
                sqlCommand.Parameters.AddWithValue("NumberOrder", TbOrder.Text);
                sqlCommand.Parameters.AddWithValue("DateOrder", DpDateOfOrder.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("Comment", TbComment.Text);
                sqlCommand.ExecuteNonQuery();
                ClassFolder.ClassMB.MBInformation("Студент добавлен");
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadStudent(TbSNILS, TbINN, TbNumberPhone, TbEmail);
            //LoadBDImage(TbImage.Text);
            
        }









        //опекун отец и мать
        public void MomGuardDadGuard()
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Registration(" +
                    "PostcodeReg, IdCity, IdStreet, HouseReg, EnclosureReg, AppartmentReg) " +
                    "Values(" +
                    "@PostcodeReg, @IdCity, @IdStreet, @HouseReg, @EnclosureReg, @AppartmentReg)",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("PostcodeReg", Int32.Parse(TbRegPostcode.Text));
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRegCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRegStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("HouseReg", TbRegHouse.Text);
                sqlCommand.Parameters.AddWithValue("EnclosureReg", TbRegEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("AppartmentReg", Int32.Parse(TbRegAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadRegistration(CbRegCity, CbRegStreet, TbRegPostcode, TbRegHouse, TbRegEnclosure, TbRegAppartment);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Passport(" +
                    "LastName, FirstName, MiddleName, Series, Number, IdIssuedByWhom, " +
                    "DateOfIssue, CodeDivision, IdGender, DateOfBorn, IdPlaceOfBorn, FamilyPosition, " +
                    "IdRegistration) " +
                    "Values(" +
                    "@LastName, @FirstName, @MiddleName, @Series, @Number, @IdIssuedByWhom, " +
                    "@DateOfIssue, @CodeDivision, @IdGender, @DateOfBorn, @IdPlaceOfBorn, @FamilyPosition, " +
                    "@IdRegistration)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastName", TbLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstName", TbFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleName", TbMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("Series", Int32.Parse(TbSeries.Text));
                sqlCommand.Parameters.AddWithValue("Number", Int32.Parse(TbNumber.Text));
                sqlCommand.Parameters.AddWithValue("IdIssuedByWhom", Int32.Parse(CbIsuedByWhom.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfIssue", DpDateOfIsue.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("CodeDivision", TbCode.Text);
                sqlCommand.Parameters.AddWithValue("IdGender", Int32.Parse(CbGender.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfBorn", DpDateOfBorn.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("IdPlaceOfBorn", Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("FamilyPosition", ChbFamilyPosition.IsChecked);
                sqlCommand.Parameters.AddWithValue("IdRegistration", ClassFolder.TableFolder.ClassRegistration.IdReg);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadPassport(TbLastName, TbFirstName, TbMiddleName, TbSeries, TbNumber, CbIsuedByWhom,
                DpDateOfIsue, TbCode, CbGender, DpDateOfBorn, CbPlaceOfBorn);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Address(" +
                    "Postcode, IdCity, IdStreet, House, Enclosure, Appartment) " +
                    "Values(" +
                    "@Postcode, @IdCity, @IdStreet, @House, @Enclosure, @Appartment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("Postcode", TbRealPostcode.Text);
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRealCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRealStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("House", TbRealHouse.Text);
                sqlCommand.Parameters.AddWithValue("Enclosure", TbRealEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("Appartment", Int32.Parse(TbRealAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadAddress(CbRealCity, CbRealStreet, TbRealPostcode, TbRealHouse, TbRealEnclosure, TbRealAppartment);


            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.GuardianMom(LastNameGuardianMom, FirstNameGuardianMom, " +
                    "MiddleNameGuardianMom, NumberPhoneGuardianMom) " +
                    "values(@LastNameGuardianMom, @FirstNameGuardianMom, " +
                    "@MiddleNameGuardianMom, @NumberPhoneGuardianMom)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameGuardianMom", TbMomLastNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("FirstNameGuardianMom", TbMomFirstNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("MiddleNameGuardianMom", TbMomMiddleNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("NumberPhoneGuardianMom", TbMomNumberPhoneGuard.Text);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadGuardianMom(TbMomLastNameGuard, TbMomFirstNameGuard, TbMomMiddleNameGuard, TbMomNumberPhoneGuard);


            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.GuardianDad(LastNameGuardianDad, " +
                    "FirstNameGuardianDad, MiddleNameGuardianDad, NumberPhoneGuardianDad) " +
                    "values(@LastNameGuardianDad, @FirstNameGuardianDad, " +
                    "@MiddleNameGuardianDad, @NumberPhoneGuardianDad)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameGuardianDad", TbDadLastNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("FirstNameGuardianDad", TbDadFirstNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("MiddleNameGuardianDad", TbDadMiddleNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("NumberPhoneGuardianDad", TbDadNumberPhoneGuard.Text);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadGuardianDad(TbDadLastNameGuard, TbDadFirstNameGuard, TbDadMiddleNameGuard, TbDadNumberPhoneGuard);

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.TemporaryRegistration " +
                    "(PostcodeTemp, IdCity, IdStreet, HouseTemp, EnclosureTemp, AppartmentTemp) " +
                    "Values(@PostcodeTemp, @IdCity, @IdStreet, @HouseTemp, @EnclosureTemp, @AppartmentTemp)",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("PostcodeTemp", TbVremPostcode.Text);
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbVremCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbVremStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("HouseTemp", TbVremHouse.Text);
                sqlCommand.Parameters.AddWithValue("EnclosureTemp", TbVremEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("AppartmentTemp", TbVremAppartment.Text);
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }

            classRead.VremRegistration(CbVremCity, CbVremStreet, TbVremPostcode, TbVremHouse, TbVremEnclosure, TbVremAppartment);
            classAdd.AddNullDad();
            classRead.ReadNullDad();
            classAdd.AddNullMom();
            classRead.ReadNullMom();

            try
            {
                string iFile = TbImage.Text;
                // конвертация изображения в байты
                byte[] imageData = null;
                FileInfo fInfo = new FileInfo(iFile);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                imageData = br.ReadBytes((int)numBytes);
                //  получение расширения файла изображения не забыв удалить точку перед расширением
                string iImageExtension = (System.IO.Path.GetExtension(iFile)).Replace(".", "").ToLower();

                using (SqlConnection sql = new SqlConnection(s))
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("declare @idImages int; " +
                        "set @idImages =(select max(IdImage) from [Image]) + 1; " +
                        "insert into dbo.[Image] (idImage, Title, Photo) values " +
                        $"(@idImages, @Title, @Photo)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Title", iImageExtension);
                    sqlCommand.Parameters.AddWithValue("Photo", imageData);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                ReadImage();

                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Student(" +
                    "IdPassport, IdGroup, SNILS, INN, IdAddress, IdFamily, IdFamilyStatus, NumberPhone, " +
                    "Email, IdMom, IdDad, HospitalPolice, IdImage, IdTemporaryRegistration, IdStatus, " +
                    "IdMomGuradian, IdDadGuardina, NumberOrder, DateOrder, Comment) " +
                    "values(@IdPassport, @IdGroup, @SNILS, @INN, " +
                    "@IdAddress, @IdFamily, @IdFamilyStatus, @NumberPhone, " +
                    "@Email, @IdMom, @IdDad, @HospitalPolice, @IdImage, @IdTemporaryRegistration, @IdStatus, " +
                    "@IdMomGuradian, @IdDadGuardina, @NumberOrder, @DateOrder, @Comment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("IdPassport", ClassFolder.TableFolder.ClassPassport.IdPassport);
                sqlCommand.Parameters.AddWithValue("IdGroup", ClassFolder.TableFolder.ClassUser.IdGroup);
                sqlCommand.Parameters.AddWithValue("SNILS", TbSNILS.Text);
                sqlCommand.Parameters.AddWithValue("INN", TbINN.Text);
                sqlCommand.Parameters.AddWithValue("IdAddress", ClassFolder.TableFolder.ClassAddress.IdAddress);
                sqlCommand.Parameters.AddWithValue("IdFamily", Int32.Parse(CbFamily.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdFamilyStatus", Int32.Parse(CbFamilyStatus.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("NumberPhone", TbNumberPhone.Text);
                sqlCommand.Parameters.AddWithValue("Email", TbEmail.Text);
                sqlCommand.Parameters.AddWithValue("IdMom", ClassFolder.TableFolder.ClassParents.IdMom);
                sqlCommand.Parameters.AddWithValue("IdDad", ClassFolder.TableFolder.ClassParents.IdDad);
                sqlCommand.Parameters.AddWithValue("HospitalPolice", TbHospital.Text);
                sqlCommand.Parameters.AddWithValue("IdStatus", 1);
                sqlCommand.Parameters.AddWithValue("IdMomGuradian", ClassFolder.TableFolder.ClassParentGuard.IdMomGuradian);
                sqlCommand.Parameters.AddWithValue("IdDadGuardina", ClassFolder.TableFolder.ClassParentGuard.IdDadGuradian);
                sqlCommand.Parameters.AddWithValue("IdImage", ClassFolder.TableFolder.ClassImage.IdImage);
                sqlCommand.Parameters.AddWithValue("IdTemporaryRegistration", ClassFolder.TableFolder.ClassVremAddress.IdVremReg);
                sqlCommand.Parameters.AddWithValue("NumberOrder", TbOrder.Text);
                sqlCommand.Parameters.AddWithValue("DateOrder", DpDateOfOrder.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("Comment", TbComment.Text);
                sqlCommand.ExecuteNonQuery(); 
                ClassFolder.ClassMB.MBInformation("Студент добавлен");
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadStudent(TbSNILS, TbINN, TbNumberPhone, TbEmail);
            //LoadBDImage(TbImage.Text);
          
        }








        //мама
        public void AddMom()
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Registration(" +
                    "PostcodeReg, IdCity, IdStreet, HouseReg, EnclosureReg, AppartmentReg) " +
                    "Values(" +
                    "@PostcodeReg, @IdCity, @IdStreet, @HouseReg, @EnclosureReg, @AppartmentReg)",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("PostcodeReg", Int32.Parse(TbRegPostcode.Text));
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRegCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRegStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("HouseReg", TbRegHouse.Text);
                sqlCommand.Parameters.AddWithValue("EnclosureReg", TbRegEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("AppartmentReg", Int32.Parse(TbRegAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadRegistration(CbRegCity, CbRegStreet, TbRegPostcode, TbRegHouse, TbRegEnclosure, TbRegAppartment);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Passport(" +
                    "LastName, FirstName, MiddleName, Series, Number, IdIssuedByWhom, " +
                    "DateOfIssue, CodeDivision, IdGender, DateOfBorn, IdPlaceOfBorn, FamilyPosition, " +
                    "IdRegistration) " +
                    "Values(" +
                    "@LastName, @FirstName, @MiddleName, @Series, @Number, @IdIssuedByWhom, " +
                    "@DateOfIssue, @CodeDivision, @IdGender, @DateOfBorn, @IdPlaceOfBorn, @FamilyPosition, " +
                    "@IdRegistration)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastName", TbLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstName", TbFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleName", TbMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("Series", Int32.Parse(TbSeries.Text));
                sqlCommand.Parameters.AddWithValue("Number", Int32.Parse(TbNumber.Text));
                sqlCommand.Parameters.AddWithValue("IdIssuedByWhom", Int32.Parse(CbIsuedByWhom.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfIssue", DpDateOfIsue.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("CodeDivision", TbCode.Text);
                sqlCommand.Parameters.AddWithValue("IdGender", Int32.Parse(CbGender.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfBorn", DpDateOfBorn.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("IdPlaceOfBorn", Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("FamilyPosition", ChbFamilyPosition.IsChecked);
                sqlCommand.Parameters.AddWithValue("IdRegistration", ClassFolder.TableFolder.ClassRegistration.IdReg);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadPassport(TbLastName, TbFirstName, TbMiddleName, TbSeries, TbNumber, CbIsuedByWhom,
                DpDateOfIsue, TbCode, CbGender, DpDateOfBorn, CbPlaceOfBorn);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Address(" +
                    "Postcode, IdCity, IdStreet, House, Enclosure, Appartment) " +
                    "Values(" +
                    "@Postcode, @IdCity, @IdStreet, @House, @Enclosure, @Appartment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("Postcode", TbRealPostcode.Text);
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRealCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRealStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("House", TbRealHouse.Text);
                sqlCommand.Parameters.AddWithValue("Enclosure", TbRealEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("Appartment", Int32.Parse(TbRealAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadAddress(CbRealCity, CbRealStreet, TbRealPostcode, TbRealHouse, TbRealEnclosure, TbRealAppartment);


            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Mom(LastNameMom, FirstNameMom, " +
                    "MiddleNameMom, NumberPhoneMom) " +
                    "values(@LastNameMom, @FirstNameMom, @MiddleNameMom, @NumberPhoneMom)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameMom", TbMomLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstNameMom", TbMomFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleNameMom", TbMomMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("NumberPhoneMom", TbMomNumberPhone.Text);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadMom(TbMomLastName, TbMomFirstName, TbMomMiddleName, TbMomNumberPhone);


            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.TemporaryRegistration " +
                    "(PostcodeTemp, IdCity, IdStreet, HouseTemp, EnclosureTemp, AppartmentTemp) " +
                    "Values(@PostcodeTemp, @IdCity, @IdStreet, @HouseTemp, @EnclosureTemp, @AppartmentTemp)",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("PostcodeTemp", TbVremPostcode.Text);
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbVremCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbVremStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("HouseTemp", TbVremHouse.Text);
                sqlCommand.Parameters.AddWithValue("EnclosureTemp", TbVremEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("AppartmentTemp", TbVremAppartment.Text);
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }

            classRead.VremRegistration(CbVremCity, CbVremStreet, TbVremPostcode, TbVremHouse, TbVremEnclosure, TbVremAppartment);
            classAdd.AddNullDad();
            classRead.ReadNullDad();
            classAdd.AddNullDadGuard();
            classRead.ReadNullDadGuard();
            classAdd.AddNullMomGuard();
            classRead.ReadNullMomGuard();

            try
            {
                string iFile = TbImage.Text;
                // конвертация изображения в байты
                byte[] imageData = null;
                FileInfo fInfo = new FileInfo(iFile);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                imageData = br.ReadBytes((int)numBytes);
                //  получение расширения файла изображения не забыв удалить точку перед расширением
                string iImageExtension = (System.IO.Path.GetExtension(iFile)).Replace(".", "").ToLower();

                using (SqlConnection sql = new SqlConnection(s))
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("declare @idImages int; " +
                        "set @idImages =(select max(IdImage) from [Image]) + 1; " +
                        "insert into dbo.[Image] (idImage, Title, Photo) values " +
                        $"(@idImages, @Title, @Photo)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Title", iImageExtension);
                    sqlCommand.Parameters.AddWithValue("Photo", imageData);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                ReadImage();

                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Student(" +
                    "IdPassport, IdGroup, SNILS, INN, IdAddress, IdFamily, IdFamilyStatus, NumberPhone, " +
                    "Email, IdMom, IdDad, HospitalPolice, IdImage, IdTemporaryRegistration, IdStatus, " +
                    "IdMomGuradian, IdDadGuardina, NumberOrder, DateOrder, Comment) " +
                    "values(@IdPassport, @IdGroup, @SNILS, @INN, " +
                    "@IdAddress, @IdFamily, @IdFamilyStatus, @NumberPhone, " +
                    "@Email, @IdMom, @IdDad, @HospitalPolice, @IdImage, @IdTemporaryRegistration, @IdStatus, " +
                    "@IdMomGuradian, @IdDadGuardina, @NumberOrder, @DateOrder, @Comment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("IdPassport", ClassFolder.TableFolder.ClassPassport.IdPassport);
                sqlCommand.Parameters.AddWithValue("IdGroup", ClassFolder.TableFolder.ClassUser.IdGroup);
                sqlCommand.Parameters.AddWithValue("SNILS", TbSNILS.Text);
                sqlCommand.Parameters.AddWithValue("INN", TbINN.Text);
                sqlCommand.Parameters.AddWithValue("IdAddress", ClassFolder.TableFolder.ClassAddress.IdAddress);
                sqlCommand.Parameters.AddWithValue("IdFamily", Int32.Parse(CbFamily.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdFamilyStatus", Int32.Parse(CbFamilyStatus.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("NumberPhone", TbNumberPhone.Text);
                sqlCommand.Parameters.AddWithValue("Email", TbEmail.Text);
                sqlCommand.Parameters.AddWithValue("IdMom", ClassFolder.TableFolder.ClassParents.IdMom);
                sqlCommand.Parameters.AddWithValue("IdDad", ClassFolder.TableFolder.ClassParents.IdDad);
                sqlCommand.Parameters.AddWithValue("HospitalPolice", TbHospital.Text);
                sqlCommand.Parameters.AddWithValue("IdStatus", 1);
                sqlCommand.Parameters.AddWithValue("IdMomGuradian", ClassFolder.TableFolder.ClassParentGuard.IdMomGuradian);
                sqlCommand.Parameters.AddWithValue("IdDadGuardina", ClassFolder.TableFolder.ClassParentGuard.IdDadGuradian);
                sqlCommand.Parameters.AddWithValue("IdImage", ClassFolder.TableFolder.ClassImage.IdImage);
                sqlCommand.Parameters.AddWithValue("IdTemporaryRegistration", ClassFolder.TableFolder.ClassVremAddress.IdVremReg);
                sqlCommand.Parameters.AddWithValue("NumberOrder", TbOrder.Text);
                sqlCommand.Parameters.AddWithValue("DateOrder", DpDateOfOrder.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("Comment", TbComment.Text);
                sqlCommand.ExecuteNonQuery();
                ClassFolder.ClassMB.MBInformation("Студент добавлен");
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadStudent(TbSNILS, TbINN, TbNumberPhone, TbEmail);
            //LoadBDImage(TbImage.Text);
            
        }










        //отец
        public void AddDad()
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Registration(" +
                    "PostcodeReg, IdCity, IdStreet, HouseReg, EnclosureReg, AppartmentReg) " +
                    "Values(" +
                    "@PostcodeReg, @IdCity, @IdStreet, @HouseReg, @EnclosureReg, @AppartmentReg)",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("PostcodeReg", Int32.Parse(TbRegPostcode.Text));
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRegCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRegStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("HouseReg", TbRegHouse.Text);
                sqlCommand.Parameters.AddWithValue("EnclosureReg", TbRegEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("AppartmentReg", Int32.Parse(TbRegAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadRegistration(CbRegCity, CbRegStreet, TbRegPostcode, TbRegHouse, TbRegEnclosure, TbRegAppartment);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Passport(" +
                    "LastName, FirstName, MiddleName, Series, Number, IdIssuedByWhom, " +
                    "DateOfIssue, CodeDivision, IdGender, DateOfBorn, IdPlaceOfBorn, FamilyPosition, " +
                    "IdRegistration) " +
                    "Values(" +
                    "@LastName, @FirstName, @MiddleName, @Series, @Number, @IdIssuedByWhom, " +
                    "@DateOfIssue, @CodeDivision, @IdGender, @DateOfBorn, @IdPlaceOfBorn, @FamilyPosition, " +
                    "@IdRegistration)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastName", TbLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstName", TbFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleName", TbMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("Series", Int32.Parse(TbSeries.Text));
                sqlCommand.Parameters.AddWithValue("Number", Int32.Parse(TbNumber.Text));
                sqlCommand.Parameters.AddWithValue("IdIssuedByWhom", Int32.Parse(CbIsuedByWhom.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfIssue", DpDateOfIsue.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("CodeDivision", TbCode.Text);
                sqlCommand.Parameters.AddWithValue("IdGender", Int32.Parse(CbGender.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfBorn", DpDateOfBorn.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("IdPlaceOfBorn", Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("FamilyPosition", ChbFamilyPosition.IsChecked);
                sqlCommand.Parameters.AddWithValue("IdRegistration", ClassFolder.TableFolder.ClassRegistration.IdReg);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadPassport(TbLastName, TbFirstName, TbMiddleName, TbSeries, TbNumber, CbIsuedByWhom,
                DpDateOfIsue, TbCode, CbGender, DpDateOfBorn, CbPlaceOfBorn);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Address(" +
                    "Postcode, IdCity, IdStreet, House, Enclosure, Appartment) " +
                    "Values(" +
                    "@Postcode, @IdCity, @IdStreet, @House, @Enclosure, @Appartment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("Postcode", TbRealPostcode.Text);
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRealCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRealStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("House", TbRealHouse.Text);
                sqlCommand.Parameters.AddWithValue("Enclosure", TbRealEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("Appartment", Int32.Parse(TbRealAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadAddress(CbRealCity, CbRealStreet, TbRealPostcode, TbRealHouse, TbRealEnclosure, TbRealAppartment);



            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Dad(LastNameDad, FirstNameDad, " +
                    "MiddleNameDad, NumberPhoneDad) " +
                    "values(@LastNameDad, @FirstNameDad, @MiddleNameDad, @NumberPhoneDad)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameDad", TbDadLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstNameDad", TbDadFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleNameDad", TbDadMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("NumberPhoneDad", TbDadNumberPhone.Text);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadDad(TbDadLastName, TbDadFirstName, TbDadMiddleName, TbDadNumberPhone);



            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.TemporaryRegistration " +
                    "(PostcodeTemp, IdCity, IdStreet, HouseTemp, EnclosureTemp, AppartmentTemp) " +
                    "Values(@PostcodeTemp, @IdCity, @IdStreet, @HouseTemp, @EnclosureTemp, @AppartmentTemp)",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("PostcodeTemp", TbVremPostcode.Text);
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbVremCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbVremStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("HouseTemp", TbVremHouse.Text);
                sqlCommand.Parameters.AddWithValue("EnclosureTemp", TbVremEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("AppartmentTemp", TbVremAppartment.Text);
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }

            classRead.VremRegistration(CbVremCity, CbVremStreet, TbVremPostcode, TbVremHouse, TbVremEnclosure, TbVremAppartment);

            classAdd.AddNullMom();
            classRead.ReadNullMom();
            classAdd.AddNullDadGuard();
            classRead.ReadNullDadGuard();
            classAdd.AddNullMomGuard();
            classRead.ReadNullMomGuard();

            try
            {
                string iFile = TbImage.Text;
                // конвертация изображения в байты
                byte[] imageData = null;
                FileInfo fInfo = new FileInfo(iFile);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                imageData = br.ReadBytes((int)numBytes);
                //  получение расширения файла изображения не забыв удалить точку перед расширением
                string iImageExtension = (System.IO.Path.GetExtension(iFile)).Replace(".", "").ToLower();

                using (SqlConnection sql = new SqlConnection(s))
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("declare @idImages int; " +
                        "set @idImages =(select max(IdImage) from [Image]) + 1; " +
                        "insert into dbo.[Image] (idImage, Title, Photo) values " +
                        $"(@idImages, @Title, @Photo)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Title", iImageExtension);
                    sqlCommand.Parameters.AddWithValue("Photo", imageData);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                ReadImage();

                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Student(" +
                    "IdPassport, IdGroup, SNILS, INN, IdAddress, IdFamily, IdFamilyStatus, NumberPhone, " +
                    "Email, IdMom, IdDad, HospitalPolice, IdImage, IdTemporaryRegistration, IdStatus, " +
                    "IdMomGuradian, IdDadGuardina, NumberOrder, DateOrder, Comment) " +
                    "values(@IdPassport, @IdGroup, @SNILS, @INN, " +
                    "@IdAddress, @IdFamily, @IdFamilyStatus, @NumberPhone, " +
                    "@Email, @IdMom, @IdDad, @HospitalPolice, @IdImage, @IdTemporaryRegistration, @IdStatus, " +
                    "@IdMomGuradian, @IdDadGuardina, @NumberOrder, @DateOrder, @Comment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("IdPassport", ClassFolder.TableFolder.ClassPassport.IdPassport);
                sqlCommand.Parameters.AddWithValue("IdGroup", ClassFolder.TableFolder.ClassUser.IdGroup);
                sqlCommand.Parameters.AddWithValue("SNILS", TbSNILS.Text);
                sqlCommand.Parameters.AddWithValue("INN", TbINN.Text);
                sqlCommand.Parameters.AddWithValue("IdAddress", ClassFolder.TableFolder.ClassAddress.IdAddress);
                sqlCommand.Parameters.AddWithValue("IdFamily", Int32.Parse(CbFamily.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdFamilyStatus", Int32.Parse(CbFamilyStatus.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("NumberPhone", TbNumberPhone.Text);
                sqlCommand.Parameters.AddWithValue("Email", TbEmail.Text);
                sqlCommand.Parameters.AddWithValue("IdMom", ClassFolder.TableFolder.ClassParents.IdMom);
                sqlCommand.Parameters.AddWithValue("IdDad", ClassFolder.TableFolder.ClassParents.IdDad);
                sqlCommand.Parameters.AddWithValue("HospitalPolice", TbHospital.Text);
                sqlCommand.Parameters.AddWithValue("IdStatus", 1);
                sqlCommand.Parameters.AddWithValue("IdMomGuradian", ClassFolder.TableFolder.ClassParentGuard.IdMomGuradian);
                sqlCommand.Parameters.AddWithValue("IdDadGuardina", ClassFolder.TableFolder.ClassParentGuard.IdDadGuradian);
                sqlCommand.Parameters.AddWithValue("IdImage", ClassFolder.TableFolder.ClassImage.IdImage);
                sqlCommand.Parameters.AddWithValue("IdTemporaryRegistration", ClassFolder.TableFolder.ClassVremAddress.IdVremReg);
                sqlCommand.Parameters.AddWithValue("NumberOrder", TbOrder.Text);
                sqlCommand.Parameters.AddWithValue("DateOrder", DpDateOfOrder.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("Comment", TbComment.Text);
                sqlCommand.ExecuteNonQuery(); 
                ClassFolder.ClassMB.MBInformation("Студент добавлен");
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadStudent(TbSNILS, TbINN, TbNumberPhone, TbEmail);
            //LoadBDImage(TbImage.Text);
           
        }








        //отец и мать
        public void MomDad()
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Registration(" +
                    "PostcodeReg, IdCity, IdStreet, HouseReg, EnclosureReg, AppartmentReg) " +
                    "Values(" +
                    "@PostcodeReg, @IdCity, @IdStreet, @HouseReg, @EnclosureReg, @AppartmentReg)",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("PostcodeReg", Int32.Parse(TbRegPostcode.Text));
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRegCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRegStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("HouseReg", TbRegHouse.Text);
                sqlCommand.Parameters.AddWithValue("EnclosureReg", TbRegEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("AppartmentReg", Int32.Parse(TbRegAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadRegistration(CbRegCity, CbRegStreet, TbRegPostcode, TbRegHouse, TbRegEnclosure, TbRegAppartment);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Passport(" +
                    "LastName, FirstName, MiddleName, Series, Number, IdIssuedByWhom, " +
                    "DateOfIssue, CodeDivision, IdGender, DateOfBorn, IdPlaceOfBorn, FamilyPosition, " +
                    "IdRegistration) " +
                    "Values(" +
                    "@LastName, @FirstName, @MiddleName, @Series, @Number, @IdIssuedByWhom, " +
                    "@DateOfIssue, @CodeDivision, @IdGender, @DateOfBorn, @IdPlaceOfBorn, @FamilyPosition, " +
                    "@IdRegistration)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastName", TbLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstName", TbFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleName", TbMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("Series", Int32.Parse(TbSeries.Text));
                sqlCommand.Parameters.AddWithValue("Number", Int32.Parse(TbNumber.Text));
                sqlCommand.Parameters.AddWithValue("IdIssuedByWhom", Int32.Parse(CbIsuedByWhom.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfIssue", DpDateOfIsue.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("CodeDivision", TbCode.Text);
                sqlCommand.Parameters.AddWithValue("IdGender", Int32.Parse(CbGender.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfBorn", DpDateOfBorn.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("IdPlaceOfBorn", Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("FamilyPosition", ChbFamilyPosition.IsChecked);
                sqlCommand.Parameters.AddWithValue("IdRegistration", ClassFolder.TableFolder.ClassRegistration.IdReg);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadPassport(TbLastName, TbFirstName, TbMiddleName, TbSeries, TbNumber, CbIsuedByWhom,
                DpDateOfIsue, TbCode, CbGender, DpDateOfBorn, CbPlaceOfBorn);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Address(" +
                    "Postcode, IdCity, IdStreet, House, Enclosure, Appartment) " +
                    "Values(" +
                    "@Postcode, @IdCity, @IdStreet, @House, @Enclosure, @Appartment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("Postcode", TbRealPostcode.Text);
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRealCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRealStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("House", TbRealHouse.Text);
                sqlCommand.Parameters.AddWithValue("Enclosure", TbRealEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("Appartment", Int32.Parse(TbRealAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadAddress(CbRealCity, CbRealStreet, TbRealPostcode, TbRealHouse, TbRealEnclosure, TbRealAppartment);


            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Dad(LastNameDad, FirstNameDad, " +
                    "MiddleNameDad, NumberPhoneDad) " +
                    "values(@LastNameDad, @FirstNameDad, @MiddleNameDad, @NumberPhoneDad)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameDad", TbDadLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstNameDad", TbDadFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleNameDad", TbDadMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("NumberPhoneDad", TbDadNumberPhone.Text);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadDad(TbDadLastName, TbDadFirstName, TbDadMiddleName, TbDadNumberPhone);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Mom(LastNameMom, FirstNameMom, " +
                    "MiddleNameMom, NumberPhoneMom) " +
                    "values(@LastNameMom, @FirstNameMom, @MiddleNameMom, @NumberPhoneMom)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameMom", TbMomLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstNameMom", TbMomFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleNameMom", TbMomMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("NumberPhoneMom", TbMomNumberPhone.Text);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadMom(TbMomLastName, TbMomFirstName, TbMomMiddleName, TbMomNumberPhone);


            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.TemporaryRegistration " +
                    "(PostcodeTemp, IdCity, IdStreet, HouseTemp, EnclosureTemp, AppartmentTemp) " +
                    "Values(@PostcodeTemp, @IdCity, @IdStreet, @HouseTemp, @EnclosureTemp, @AppartmentTemp)",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("PostcodeTemp", TbVremPostcode.Text);
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbVremCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbVremStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("HouseTemp", TbVremHouse.Text);
                sqlCommand.Parameters.AddWithValue("EnclosureTemp", TbVremEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("AppartmentTemp", TbVremAppartment.Text);
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }

            classRead.VremRegistration(CbVremCity, CbVremStreet, TbVremPostcode, TbVremHouse, TbVremEnclosure, TbVremAppartment);
            classAdd.AddNullDadGuard();
            classRead.ReadNullDadGuard();
            classAdd.AddNullMomGuard();
            classRead.ReadNullMomGuard();

            try
            {
                string iFile = TbImage.Text;
                // конвертация изображения в байты
                byte[] imageData = null;
                FileInfo fInfo = new FileInfo(iFile);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                imageData = br.ReadBytes((int)numBytes);
                //  получение расширения файла изображения не забыв удалить точку перед расширением
                string iImageExtension = (System.IO.Path.GetExtension(iFile)).Replace(".", "").ToLower();

                using (SqlConnection sql = new SqlConnection(s))
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("declare @idImages int; " +
                        "set @idImages =(select max(IdImage) from [Image]) + 1; " +
                        "insert into dbo.[Image] (idImage, Title, Photo) values " +
                        $"(@idImages, @Title, @Photo)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Title", iImageExtension);
                    sqlCommand.Parameters.AddWithValue("Photo", imageData);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                ReadImage();

                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Student(" +
                    "IdPassport, IdGroup, SNILS, INN, IdAddress, IdFamily, IdFamilyStatus, NumberPhone, " +
                    "Email, IdMom, IdDad, HospitalPolice, IdImage, IdTemporaryRegistration, IdStatus, " +
                    "IdMomGuradian, IdDadGuardina, NumberOrder, DateOrder, Comment) " +
                    "values(@IdPassport, @IdGroup, @SNILS, @INN, " +
                    "@IdAddress, @IdFamily, @IdFamilyStatus, @NumberPhone, " +
                    "@Email, @IdMom, @IdDad, @HospitalPolice, @IdImage, @IdTemporaryRegistration, @IdStatus, " +
                    "@IdMomGuradian, @IdDadGuardina, @NumberOrder, @DateOrder, @Comment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("IdPassport", ClassFolder.TableFolder.ClassPassport.IdPassport);
                sqlCommand.Parameters.AddWithValue("IdGroup", ClassFolder.TableFolder.ClassUser.IdGroup);
                sqlCommand.Parameters.AddWithValue("SNILS", TbSNILS.Text);
                sqlCommand.Parameters.AddWithValue("INN", TbINN.Text);
                sqlCommand.Parameters.AddWithValue("IdAddress", ClassFolder.TableFolder.ClassAddress.IdAddress);
                sqlCommand.Parameters.AddWithValue("IdFamily", Int32.Parse(CbFamily.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdFamilyStatus", Int32.Parse(CbFamilyStatus.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("NumberPhone", TbNumberPhone.Text);
                sqlCommand.Parameters.AddWithValue("Email", TbEmail.Text);
                sqlCommand.Parameters.AddWithValue("IdMom", ClassFolder.TableFolder.ClassParents.IdMom);
                sqlCommand.Parameters.AddWithValue("IdDad", ClassFolder.TableFolder.ClassParents.IdDad);
                sqlCommand.Parameters.AddWithValue("HospitalPolice", TbHospital.Text);
                sqlCommand.Parameters.AddWithValue("IdStatus", 1);
                sqlCommand.Parameters.AddWithValue("IdMomGuradian", ClassFolder.TableFolder.ClassParentGuard.IdMomGuradian);
                sqlCommand.Parameters.AddWithValue("IdDadGuardina", ClassFolder.TableFolder.ClassParentGuard.IdDadGuradian);
                sqlCommand.Parameters.AddWithValue("IdImage", ClassFolder.TableFolder.ClassImage.IdImage);
                sqlCommand.Parameters.AddWithValue("IdTemporaryRegistration", ClassFolder.TableFolder.ClassVremAddress.IdVremReg);
                sqlCommand.Parameters.AddWithValue("NumberOrder", TbOrder.Text);
                sqlCommand.Parameters.AddWithValue("DateOrder", DpDateOfOrder.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("Comment", TbComment.Text);
                sqlCommand.ExecuteNonQuery(); 
                ClassFolder.ClassMB.MBInformation("Студент добавлен");
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadStudent(TbSNILS, TbINN, TbNumberPhone, TbEmail);
            //LoadBDImage(TbImage.Text);
           
        }









        //мама и (отец опекун)
        public void MomDadGuard()
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Registration(" +
                    "PostcodeReg, IdCity, IdStreet, HouseReg, EnclosureReg, AppartmentReg) " +
                    "Values(" +
                    "@PostcodeReg, @IdCity, @IdStreet, @HouseReg, @EnclosureReg, @AppartmentReg)",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("PostcodeReg", Int32.Parse(TbRegPostcode.Text));
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRegCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRegStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("HouseReg", TbRegHouse.Text);
                sqlCommand.Parameters.AddWithValue("EnclosureReg", TbRegEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("AppartmentReg", Int32.Parse(TbRegAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadRegistration(CbRegCity, CbRegStreet, TbRegPostcode, TbRegHouse, TbRegEnclosure, TbRegAppartment);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Passport(" +
                    "LastName, FirstName, MiddleName, Series, Number, IdIssuedByWhom, " +
                    "DateOfIssue, CodeDivision, IdGender, DateOfBorn, IdPlaceOfBorn, FamilyPosition, " +
                    "IdRegistration) " +
                    "Values(" +
                    "@LastName, @FirstName, @MiddleName, @Series, @Number, @IdIssuedByWhom, " +
                    "@DateOfIssue, @CodeDivision, @IdGender, @DateOfBorn, @IdPlaceOfBorn, @FamilyPosition, " +
                    "@IdRegistration)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastName", TbLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstName", TbFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleName", TbMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("Series", Int32.Parse(TbSeries.Text));
                sqlCommand.Parameters.AddWithValue("Number", Int32.Parse(TbNumber.Text));
                sqlCommand.Parameters.AddWithValue("IdIssuedByWhom", Int32.Parse(CbIsuedByWhom.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfIssue", DpDateOfIsue.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("CodeDivision", TbCode.Text);
                sqlCommand.Parameters.AddWithValue("IdGender", Int32.Parse(CbGender.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfBorn", DpDateOfBorn.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("IdPlaceOfBorn", Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("FamilyPosition", ChbFamilyPosition.IsChecked);
                sqlCommand.Parameters.AddWithValue("IdRegistration", ClassFolder.TableFolder.ClassRegistration.IdReg);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadPassport(TbLastName, TbFirstName, TbMiddleName, TbSeries, TbNumber, CbIsuedByWhom,
                DpDateOfIsue, TbCode, CbGender, DpDateOfBorn, CbPlaceOfBorn);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Address(" +
                    "Postcode, IdCity, IdStreet, House, Enclosure, Appartment) " +
                    "Values(" +
                    "@Postcode, @IdCity, @IdStreet, @House, @Enclosure, @Appartment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("Postcode", TbRealPostcode.Text);
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRealCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRealStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("House", TbRealHouse.Text);
                sqlCommand.Parameters.AddWithValue("Enclosure", TbRealEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("Appartment", Int32.Parse(TbRealAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadAddress(CbRealCity, CbRealStreet, TbRealPostcode, TbRealHouse, TbRealEnclosure, TbRealAppartment);


            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Mom(LastNameMom, FirstNameMom, " +
                    "MiddleNameMom, NumberPhoneMom) " +
                    "values(@LastNameMom, @FirstNameMom, @MiddleNameMom, @NumberPhoneMom)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameMom", TbMomLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstNameMom", TbMomFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleNameMom", TbMomMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("NumberPhoneMom", TbMomNumberPhone.Text);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadMom(TbMomLastName, TbMomFirstName, TbMomMiddleName, TbMomNumberPhone);


            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.GuardianDad(LastNameGuardianDad, " +
                    "FirstNameGuardianDad, MiddleNameGuardianDad, NumberPhoneGuardianDad) " +
                    "values(@LastNameGuardianDad, @FirstNameGuardianDad, " +
                    "@MiddleNameGuardianDad, @NumberPhoneGuardianDad)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameGuardianDad", TbDadLastNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("FirstNameGuardianDad", TbDadFirstNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("MiddleNameGuardianDad", TbDadMiddleNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("NumberPhoneGuardianDad", TbDadNumberPhoneGuard.Text);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadGuardianDad(TbDadLastNameGuard, TbDadFirstNameGuard, TbDadMiddleNameGuard, TbDadNumberPhoneGuard);



            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.TemporaryRegistration " +
                    "(PostcodeTemp, IdCity, IdStreet, HouseTemp, EnclosureTemp, AppartmentTemp) " +
                    "Values(@PostcodeTemp, @IdCity, @IdStreet, @HouseTemp, @EnclosureTemp, @AppartmentTemp)",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("PostcodeTemp", TbVremPostcode.Text);
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbVremCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbVremStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("HouseTemp", TbVremHouse.Text);
                sqlCommand.Parameters.AddWithValue("EnclosureTemp", TbVremEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("AppartmentTemp", TbVremAppartment.Text);
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }

            classRead.VremRegistration(CbVremCity, CbVremStreet, TbVremPostcode, TbVremHouse, TbVremEnclosure, TbVremAppartment);

            classAdd.AddNullDad();
            classRead.ReadNullDad();
            classAdd.AddNullMomGuard();
            classRead.ReadNullMomGuard();
            try
            {
                string iFile = TbImage.Text;
                // конвертация изображения в байты
                byte[] imageData = null;
                FileInfo fInfo = new FileInfo(iFile);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                imageData = br.ReadBytes((int)numBytes);
                //  получение расширения файла изображения не забыв удалить точку перед расширением
                string iImageExtension = (System.IO.Path.GetExtension(iFile)).Replace(".", "").ToLower();

                using (SqlConnection sql = new SqlConnection(s))
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("declare @idImages int; " +
                        "set @idImages =(select max(IdImage) from [Image]) + 1; " +
                        "insert into dbo.[Image] (idImage, Title, Photo) values " +
                        $"(@idImages, @Title, @Photo)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Title", iImageExtension);
                    sqlCommand.Parameters.AddWithValue("Photo", imageData);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                ReadImage();

                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Student(" +
                    "IdPassport, IdGroup, SNILS, INN, IdAddress, IdFamily, IdFamilyStatus, NumberPhone, " +
                    "Email, IdMom, IdDad, HospitalPolice, IdImage, IdTemporaryRegistration, IdStatus, " +
                    "IdMomGuradian, IdDadGuardina, NumberOrder, DateOrder, Comment) " +
                    "values(@IdPassport, @IdGroup, @SNILS, @INN, " +
                    "@IdAddress, @IdFamily, @IdFamilyStatus, @NumberPhone, " +
                    "@Email, @IdMom, @IdDad, @HospitalPolice, @IdImage, @IdTemporaryRegistration, @IdStatus, " +
                    "@IdMomGuradian, @IdDadGuardina, @NumberOrder, @DateOrder, @Comment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("IdPassport", ClassFolder.TableFolder.ClassPassport.IdPassport);
                sqlCommand.Parameters.AddWithValue("IdGroup", ClassFolder.TableFolder.ClassUser.IdGroup);
                sqlCommand.Parameters.AddWithValue("SNILS", TbSNILS.Text);
                sqlCommand.Parameters.AddWithValue("INN", TbINN.Text);
                sqlCommand.Parameters.AddWithValue("IdAddress", ClassFolder.TableFolder.ClassAddress.IdAddress);
                sqlCommand.Parameters.AddWithValue("IdFamily", Int32.Parse(CbFamily.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdFamilyStatus", Int32.Parse(CbFamilyStatus.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("NumberPhone", TbNumberPhone.Text);
                sqlCommand.Parameters.AddWithValue("Email", TbEmail.Text);
                sqlCommand.Parameters.AddWithValue("IdMom", ClassFolder.TableFolder.ClassParents.IdMom);
                sqlCommand.Parameters.AddWithValue("IdDad", ClassFolder.TableFolder.ClassParents.IdDad);
                sqlCommand.Parameters.AddWithValue("HospitalPolice", TbHospital.Text);
                sqlCommand.Parameters.AddWithValue("IdStatus", 1);
                sqlCommand.Parameters.AddWithValue("IdMomGuradian", ClassFolder.TableFolder.ClassParentGuard.IdMomGuradian);
                sqlCommand.Parameters.AddWithValue("IdDadGuardina", ClassFolder.TableFolder.ClassParentGuard.IdDadGuradian);
                sqlCommand.Parameters.AddWithValue("IdImage", ClassFolder.TableFolder.ClassImage.IdImage);
                sqlCommand.Parameters.AddWithValue("IdTemporaryRegistration", ClassFolder.TableFolder.ClassVremAddress.IdVremReg);
                sqlCommand.Parameters.AddWithValue("NumberOrder", TbOrder.Text);
                sqlCommand.Parameters.AddWithValue("DateOrder", DpDateOfOrder.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("Comment", TbComment.Text);
                sqlCommand.ExecuteNonQuery();
                ClassFolder.ClassMB.MBInformation("Студент добавлен");
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadStudent(TbSNILS, TbINN, TbNumberPhone, TbEmail);
            //LoadBDImage(TbImage.Text);
            
        }











        //отец и (мать опекун)
        public void MomGuardDad()
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Registration(" +
                    "PostcodeReg, IdCity, IdStreet, HouseReg, EnclosureReg, AppartmentReg) " +
                    "Values(" +
                    "@PostcodeReg, @IdCity, @IdStreet, @HouseReg, @EnclosureReg, @AppartmentReg)",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("PostcodeReg", Int32.Parse(TbRegPostcode.Text));
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRegCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRegStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("HouseReg", TbRegHouse.Text);
                sqlCommand.Parameters.AddWithValue("EnclosureReg", TbRegEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("AppartmentReg", Int32.Parse(TbRegAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadRegistration(CbRegCity, CbRegStreet, TbRegPostcode, TbRegHouse, TbRegEnclosure, TbRegAppartment);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Passport(" +
                    "LastName, FirstName, MiddleName, Series, Number, IdIssuedByWhom, " +
                    "DateOfIssue, CodeDivision, IdGender, DateOfBorn, IdPlaceOfBorn, FamilyPosition, " +
                    "IdRegistration) " +
                    "Values(" +
                    "@LastName, @FirstName, @MiddleName, @Series, @Number, @IdIssuedByWhom, " +
                    "@DateOfIssue, @CodeDivision, @IdGender, @DateOfBorn, @IdPlaceOfBorn, @FamilyPosition, " +
                    "@IdRegistration)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastName", TbLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstName", TbFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleName", TbMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("Series", Int32.Parse(TbSeries.Text));
                sqlCommand.Parameters.AddWithValue("Number", Int32.Parse(TbNumber.Text));
                sqlCommand.Parameters.AddWithValue("IdIssuedByWhom", Int32.Parse(CbIsuedByWhom.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfIssue", DpDateOfIsue.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("CodeDivision", TbCode.Text);
                sqlCommand.Parameters.AddWithValue("IdGender", Int32.Parse(CbGender.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("DateOfBorn", DpDateOfBorn.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("IdPlaceOfBorn", Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("FamilyPosition", ChbFamilyPosition.IsChecked);
                sqlCommand.Parameters.AddWithValue("IdRegistration", ClassFolder.TableFolder.ClassRegistration.IdReg);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadPassport(TbLastName, TbFirstName, TbMiddleName, TbSeries, TbNumber, CbIsuedByWhom,
                DpDateOfIsue, TbCode, CbGender, DpDateOfBorn, CbPlaceOfBorn);
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Address(" +
                    "Postcode, IdCity, IdStreet, House, Enclosure, Appartment) " +
                    "Values(" +
                    "@Postcode, @IdCity, @IdStreet, @House, @Enclosure, @Appartment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("Postcode", TbRealPostcode.Text);
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbRealCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbRealStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("House", TbRealHouse.Text);
                sqlCommand.Parameters.AddWithValue("Enclosure", TbRealEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("Appartment", Int32.Parse(TbRealAppartment.Text));
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadAddress(CbRealCity, CbRealStreet, TbRealPostcode, TbRealHouse, TbRealEnclosure, TbRealAppartment);


            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.GuardianMom(LastNameGuardianMom, FirstNameGuardianMom, " +
                    "MiddleNameGuardianMom, NumberPhoneGuardianMom) " +
                    "values(@LastNameGuardianMom, @FirstNameGuardianMom, " +
                    "@MiddleNameGuardianMom, @NumberPhoneGuardianMom)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameGuardianMom", TbMomLastNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("FirstNameGuardianMom", TbMomFirstNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("MiddleNameGuardianMom", TbMomMiddleNameGuard.Text);
                sqlCommand.Parameters.AddWithValue("NumberPhoneGuardianMom", TbMomNumberPhoneGuard.Text);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadGuardianMom(TbMomLastNameGuard, TbMomFirstNameGuard, TbMomMiddleNameGuard, TbMomNumberPhoneGuard);

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Dad(LastNameDad, FirstNameDad, " +
                    "MiddleNameDad, NumberPhoneDad) " +
                    "values(@LastNameDad, @FirstNameDad, @MiddleNameDad, @NumberPhoneDad)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameDad", TbDadLastName.Text);
                sqlCommand.Parameters.AddWithValue("FirstNameDad", TbDadFirstName.Text);
                sqlCommand.Parameters.AddWithValue("MiddleNameDad", TbDadMiddleName.Text);
                sqlCommand.Parameters.AddWithValue("NumberPhoneDad", TbDadNumberPhone.Text);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadDad(TbDadLastName, TbDadFirstName, TbDadMiddleName, TbDadNumberPhone);

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.TemporaryRegistration " +
                    "(PostcodeTemp, IdCity, IdStreet, HouseTemp, EnclosureTemp, AppartmentTemp) " +
                    "Values(@PostcodeTemp, @IdCity, @IdStreet, @HouseTemp, @EnclosureTemp, @AppartmentTemp)",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("PostcodeTemp", TbVremPostcode.Text);
                sqlCommand.Parameters.AddWithValue("IdCity", Int32.Parse(CbVremCity.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdStreet", Int32.Parse(CbVremStreet.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("HouseTemp", TbVremHouse.Text);
                sqlCommand.Parameters.AddWithValue("EnclosureTemp", TbVremEnclosure.Text);
                sqlCommand.Parameters.AddWithValue("AppartmentTemp", TbVremAppartment.Text);
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }

            classRead.VremRegistration(CbVremCity, CbVremStreet, TbVremPostcode, TbVremHouse, TbVremEnclosure, TbVremAppartment);
            classAdd.AddNullMom();
            classRead.ReadNullMom();
            classAdd.AddNullDadGuard();
            classRead.ReadNullDadGuard();

            try
            {
                string iFile = TbImage.Text;
                // конвертация изображения в байты
                byte[] imageData = null;
                FileInfo fInfo = new FileInfo(iFile);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                imageData = br.ReadBytes((int)numBytes);
                //  получение расширения файла изображения не забыв удалить точку перед расширением
                string iImageExtension = (System.IO.Path.GetExtension(iFile)).Replace(".", "").ToLower();

                using (SqlConnection sql = new SqlConnection(s))
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("declare @idImages int; " +
                        "set @idImages =(select max(IdImage) from [Image]) + 1; " +
                        "insert into dbo.[Image] (idImage, Title, Photo) values " +
                        $"(@idImages, @Title, @Photo)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Title", iImageExtension);
                    sqlCommand.Parameters.AddWithValue("Photo", imageData);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                ReadImage();

                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Student(" +
                    "IdPassport, IdGroup, SNILS, INN, IdAddress, IdFamily, IdFamilyStatus, NumberPhone, " +
                    "Email, IdMom, IdDad, HospitalPolice, IdImage, IdTemporaryRegistration, IdStatus, " +
                    "IdMomGuradian, IdDadGuardina, NumberOrder, DateOrder, Comment) " +
                    "values(@IdPassport, @IdGroup, @SNILS, @INN, " +
                    "@IdAddress, @IdFamily, @IdFamilyStatus, @NumberPhone, " +
                    "@Email, @IdMom, @IdDad, @HospitalPolice, @IdImage, @IdTemporaryRegistration, @IdStatus, " +
                    "@IdMomGuradian, @IdDadGuardina, @NumberOrder, @DateOrder, @Comment)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("IdPassport", ClassFolder.TableFolder.ClassPassport.IdPassport);
                sqlCommand.Parameters.AddWithValue("IdGroup", ClassFolder.TableFolder.ClassUser.IdGroup);
                sqlCommand.Parameters.AddWithValue("SNILS", TbSNILS.Text);
                sqlCommand.Parameters.AddWithValue("INN", TbINN.Text);
                sqlCommand.Parameters.AddWithValue("IdAddress", ClassFolder.TableFolder.ClassAddress.IdAddress);
                sqlCommand.Parameters.AddWithValue("IdFamily", Int32.Parse(CbFamily.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("IdFamilyStatus", Int32.Parse(CbFamilyStatus.SelectedValue.ToString()));
                sqlCommand.Parameters.AddWithValue("NumberPhone", TbNumberPhone.Text);
                sqlCommand.Parameters.AddWithValue("Email", TbEmail.Text);
                sqlCommand.Parameters.AddWithValue("IdMom", ClassFolder.TableFolder.ClassParents.IdMom);
                sqlCommand.Parameters.AddWithValue("IdDad", ClassFolder.TableFolder.ClassParents.IdDad);
                sqlCommand.Parameters.AddWithValue("HospitalPolice", TbHospital.Text);
                sqlCommand.Parameters.AddWithValue("IdStatus", 1);
                sqlCommand.Parameters.AddWithValue("IdMomGuradian", ClassFolder.TableFolder.ClassParentGuard.IdMomGuradian);
                sqlCommand.Parameters.AddWithValue("IdDadGuardina", ClassFolder.TableFolder.ClassParentGuard.IdDadGuradian);
                sqlCommand.Parameters.AddWithValue("IdImage", ClassFolder.TableFolder.ClassImage.IdImage);
                sqlCommand.Parameters.AddWithValue("IdTemporaryRegistration", ClassFolder.TableFolder.ClassVremAddress.IdVremReg);
                sqlCommand.Parameters.AddWithValue("NumberOrder", TbOrder.Text);
                sqlCommand.Parameters.AddWithValue("DateOrder", DpDateOfOrder.SelectedDate.GetValueOrDefault());
                sqlCommand.Parameters.AddWithValue("Comment", TbComment.Text);
                sqlCommand.ExecuteNonQuery();
                ClassFolder.ClassMB.MBInformation("Студент добавлен");
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError("Неверные данные");
            }
            finally
            {
                sqlConnection.Close();
            }
            classRead.ReadStudent(TbSNILS, TbINN, TbNumberPhone, TbEmail);
            //LoadBDImage(TbImage.Text);
            


        }
        
        private void ChbNoMom_Checked(object sender, RoutedEventArgs e)
        {            
                TbMomLastName.Text = null;
                TbMomFirstName.Text = null;
                TbMomMiddleName.Text = null;
                TbMomNumberPhone.Text = null;
                TbMomLastName.IsReadOnly = true;
                TbMomFirstName.IsReadOnly = true;             
                TbMomMiddleName.IsReadOnly = true;
                TbMomNumberPhone.IsReadOnly = true;          
        }       

        private void ChbNoPap_Checked(object sender, RoutedEventArgs e)
        {
            TbDadLastName.Text = null;
            TbDadFirstName.Text = null;
            TbDadMiddleName.Text = null;
            TbDadNumberPhone.Text = null;
            TbDadLastName.IsReadOnly = true;
            TbDadFirstName.IsReadOnly = true;
            TbDadMiddleName.IsReadOnly = true;
            TbDadNumberPhone.IsReadOnly = true;           
        }

        private void ChbNoMomGuard_Checked(object sender, RoutedEventArgs e)
        {
            TbMomLastNameGuard.Text = null;
            TbMomFirstNameGuard.Text = null;
            TbMomMiddleNameGuard.Text = null;
            TbMomNumberPhoneGuard.Text = null;
            TbMomLastNameGuard.IsReadOnly = true;
            TbMomFirstNameGuard.IsReadOnly = true;
            TbMomMiddleNameGuard.IsReadOnly = true;
            TbMomNumberPhoneGuard.IsReadOnly = true;           
        }

        private void ChbNoPapGuard_Checked(object sender, RoutedEventArgs e)
        {
            TbDadLastNameGuard.Text = null;
            TbDadFirstNameGuard.Text = null;
            TbDadMiddleNameGuard.Text = null;
            TbDadNumberPhoneGuard.Text = null;
            TbDadLastNameGuard.IsReadOnly = true;
            TbDadFirstNameGuard.IsReadOnly = true;
            TbDadMiddleNameGuard.IsReadOnly = true;
            TbDadNumberPhoneGuard.IsReadOnly = true;            
        }

        private void ChbNoMom_Unchecked(object sender, RoutedEventArgs e)
        {
            TbMomLastName.IsReadOnly = false;
            TbMomFirstName.IsReadOnly = false;
            TbMomMiddleName.IsReadOnly = false;
            TbMomNumberPhone.IsReadOnly = false;
        }

        private void ChbNoPap_Unchecked(object sender, RoutedEventArgs e)
        {
            TbDadLastName.IsReadOnly = false;
            TbDadFirstName.IsReadOnly = false;
            TbDadMiddleName.IsReadOnly = false;
            TbDadNumberPhone.IsReadOnly = false;
        }

        private void ChbNoMomGuard_Unchecked(object sender, RoutedEventArgs e)
        {
            TbMomLastNameGuard.IsReadOnly = false;
            TbMomFirstNameGuard.IsReadOnly = false;
            TbMomMiddleNameGuard.IsReadOnly = false;
            TbMomNumberPhoneGuard.IsReadOnly = false;
        }

        private void ChbNoPapGuard_Unchecked(object sender, RoutedEventArgs e)
        {
            TbDadLastNameGuard.IsReadOnly = false;
            TbDadFirstNameGuard.IsReadOnly = false;
            TbDadMiddleNameGuard.IsReadOnly = false;
            TbDadNumberPhoneGuard.IsReadOnly = false;
        }

        private void btnAddIsuuedByWhom_Click(object sender, RoutedEventArgs e)
        {
            WindowFolder.WindowAdd.WinAddIssuedByWhom winAddIssuedByWhom = new WindowFolder.WindowAdd.WinAddIssuedByWhom();
            winAddIssuedByWhom.ShowDialog();
            classCB.LoadAuthority(CbIsuedByWhom);
        }

        private void btnPlaceOfBorn_Click(object sender, RoutedEventArgs e)
        {
            WindowFolder.WindowAdd.WinAddPlaceOfBorn winAddPlaceOfBorn = new WindowFolder.WindowAdd.WinAddPlaceOfBorn();
            winAddPlaceOfBorn.ShowDialog();
            classCB.LoadPlaceOfBorn(CbPlaceOfBorn);
        }

        private void btnAddRegCity_Click(object sender, RoutedEventArgs e)
        {
            WindowFolder.WindowAdd.WinAddCity winAddCity = new WindowFolder.WindowAdd.WinAddCity();
            winAddCity.ShowDialog();
            classCB.LoadCity(CbRegCity);
            classCB.LoadCity(CbRealCity);
            classCB.LoadCity(CbVremCity);
        }

        private void btnRegStreet_Click(object sender, RoutedEventArgs e)
        {
            WindowFolder.WindowAdd.WinAddStreet winAddStreet = new WindowFolder.WindowAdd.WinAddStreet();
            winAddStreet.ShowDialog();
            classCB.LoadStreet(CbRegStreet);
            classCB.LoadStreet(CbRealStreet);
            classCB.LoadStreet(CbVremStreet);
        }

        private void btnAddRealCity_Click(object sender, RoutedEventArgs e)
        {
            WindowFolder.WindowAdd.WinAddCity winAddCity = new WindowFolder.WindowAdd.WinAddCity();
            winAddCity.ShowDialog();
            classCB.LoadCity(CbRegCity);
            classCB.LoadCity(CbRealCity);
            classCB.LoadCity(CbVremCity);
        }

        private void btnRealStreet_Click(object sender, RoutedEventArgs e)
        {
            WindowFolder.WindowAdd.WinAddStreet winAddStreet = new WindowFolder.WindowAdd.WinAddStreet();
            winAddStreet.ShowDialog();
            classCB.LoadStreet(CbRegStreet);
            classCB.LoadStreet(CbRealStreet);
            classCB.LoadStreet(CbVremStreet);
        }

        private void btnAddVremCity_Click(object sender, RoutedEventArgs e)
        {
            WindowFolder.WindowAdd.WinAddCity winAddCity = new WindowFolder.WindowAdd.WinAddCity();
            winAddCity.ShowDialog();
            classCB.LoadCity(CbRegCity);
            classCB.LoadCity(CbRealCity);
            classCB.LoadCity(CbVremCity);
        }

        private void btnVremStreet_Click(object sender, RoutedEventArgs e)
        {
            WindowFolder.WindowAdd.WinAddStreet winAddStreet = new WindowFolder.WindowAdd.WinAddStreet();
            winAddStreet.ShowDialog();
            classCB.LoadStreet(CbRegStreet);
            classCB.LoadStreet(CbRealStreet);
            classCB.LoadStreet(CbVremStreet);
        }

        private void CbFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CbFamily.SelectedValue.ToString() == "1")
                {
                    ChbNoMomGuard.IsChecked = true;
                    ChbNoPapGuard.IsChecked = true;
                    ChbNoMom.IsChecked = false;
                    ChbNoPap.IsChecked = false;
                }
                else if (CbFamily.SelectedValue.ToString() == "3")
                {
                    ChbNoMom.IsChecked = true;
                    ChbNoPap.IsChecked = true;
                    ChbNoMomGuard.IsChecked = false;
                    ChbNoPapGuard.IsChecked = false;
                }
                else
                {

                }
            }
            catch
            {
                
            }
            
        }

        private void btnClearTempReg_Click(object sender, RoutedEventArgs e)
        {
            CbVremCity.SelectedIndex = -1;
            CbVremStreet.SelectedIndex = -1;
            TbVremAppartment.Clear();
            TbVremEnclosure.Clear();
            TbVremHouse.Clear();
            TbVremPostcode.Clear();
        }
        
    }
}
 