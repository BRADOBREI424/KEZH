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
    /// Логика взаимодействия для PageEditStudent.xaml
    /// </summary>
    public partial class PageEditStudent : Page
    {
        SqlConnection sqlConnection =
       new SqlConnection(App.ConnectionString());
        string s = App.ConnectionString();
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        ClassFolder.ClassCB classCB;
        ClassFolder.ClassRead classRead;
        ClassFolder.ClassEdit classEdit;
        
        public PageEditStudent()
        {
            InitializeComponent();
            classCB = new ClassFolder.ClassCB();
            classRead = new ClassFolder.ClassRead();
            classEdit = new ClassFolder.ClassEdit();
            
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

                ImagePhoto.Source = imageSource;
            }
            catch
            {

            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {            
            NavigationService.GoBack();
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
            GetImageBinaryFromDb();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Select * From dbo.ViewStudent " +
                    $"Where [IdStudent] = '{ClassFolder.TableFolder.ClassStudent.IdStudent}'", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                string f = dataReader[1].ToString();
                string[] fio = f.Split(' ');

                ClassFolder.TableFolder.ClassPassport.LastName = fio[0];
                ClassFolder.TableFolder.ClassPassport.FirstName = fio[1];
                ClassFolder.TableFolder.ClassPassport.MiddleName = fio[2];

                //Информация
                TbLastName.Text = ClassFolder.TableFolder.ClassPassport.LastName;
                TbFirstName.Text = ClassFolder.TableFolder.ClassPassport.FirstName;
                TbMiddleName.Text = ClassFolder.TableFolder.ClassPassport.MiddleName;
                CbGender.Text = dataReader[7].ToString();
                DpDateOfBorn.Text = dataReader[8].ToString();
                TbNumberPhone.Text = dataReader[26].ToString();
                CbFamily.Text = dataReader[27].ToString();
                CbFamilyStatus.Text = dataReader[28].ToString();
                TbEmail.Text = dataReader[29].ToString();
                ChbFamilyPosition.IsChecked = Boolean.Parse(dataReader[9].ToString());
                TbComment.Text = dataReader[66].ToString();

                //Документы
                TbSeries.Text = dataReader[2].ToString();
                TbNumber.Text = dataReader[3].ToString();
                CbIsuedByWhom.Text = dataReader[4].ToString();
                DpDateOfIsue.Text = dataReader[5].ToString();
                TbCode.Text = dataReader[6].ToString();
                CbPlaceOfBorn.Text = dataReader[55].ToString();
                TbHospital.Text = dataReader[38].ToString();
                TbINN.Text = dataReader[19].ToString();
                TbSNILS.Text = dataReader[18].ToString();
                TbOrder.Text = dataReader[64].ToString();
                DpDateOfOrder.Text = dataReader[65].ToString();

                //Прописка
                CbRegCity.Text = dataReader[11].ToString();
                CbRegStreet.Text = dataReader[12].ToString();
                TbRegPostcode.Text = dataReader[10].ToString();
                TbRegHouse.Text = dataReader[13].ToString();
                TbRegEnclosure.Text = dataReader[14].ToString();
                TbRegAppartment.Text = dataReader[15].ToString();

                //Фактический адрес
                CbRealCity.Text = dataReader[21].ToString();
                CbRealStreet.Text = dataReader[22].ToString();
                TbRealPostcode.Text = dataReader[20].ToString();
                TbRealHouse.Text = dataReader[23].ToString();
                TbRealEnclosure.Text = dataReader[24].ToString();
                TbRealAppartment.Text = dataReader[25].ToString();

                //Временная регистрация
                CbVremCity.Text = dataReader[41].ToString();
                CbVremStreet.Text = dataReader[42].ToString();
                TbVremPostcode.Text = dataReader[40].ToString();
                TbVremHouse.Text = dataReader[43].ToString();
                TbVremEnclosure.Text = dataReader[44].ToString();
                TbVremAppartment.Text = dataReader[45].ToString();

                //Родители
                TbMomLastName.Text = dataReader[30].ToString();
                TbMomFirstName.Text = dataReader[31].ToString();
                TbMomMiddleName.Text = dataReader[32].ToString();
                TbMomNumberPhone.Text = dataReader[33].ToString();
                TbDadLastName.Text = dataReader[34].ToString();
                TbDadFirstName.Text = dataReader[35].ToString();
                TbDadMiddleName.Text = dataReader[36].ToString();
                TbDadNumberPhone.Text = dataReader[37].ToString();

                //Опекун
                TbMomLastNameGuard.Text = dataReader[46].ToString();
                TbMomFirstNameGuard.Text = dataReader[47].ToString();
                TbMomMiddleNameGuard.Text = dataReader[48].ToString();
                TbMomNumberPhoneGuard.Text = dataReader[49].ToString();
                TbDadLastNameGuard.Text = dataReader[50].ToString();
                TbDadFirstNameGuard.Text = dataReader[51].ToString();
                TbDadMiddleNameGuard.Text = dataReader[52].ToString();
                TbDadNumberPhoneGuard.Text = dataReader[53].ToString();

                
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
            //загрузка Id в глобальные переменные
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Select * from dbo.ViewIdToEditStudent " +
                    $"where IdStudent='{ClassFolder.TableFolder.ClassStudent.IdStudent}'", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();

                ClassFolder.TableFolder.ClassAddress.IdAddress = Int32.Parse(dataReader[1].ToString());
                try
                {
                    ClassFolder.TableFolder.ClassVremAddress.IdVremReg = Int32.Parse(dataReader[2].ToString());
                }
                catch
                {


                }


                try
                {
                    ClassFolder.TableFolder.ClassParents.IdMom = Int32.Parse(dataReader[3].ToString());
                }
                catch
                {

                }

                try
                {
                    ClassFolder.TableFolder.ClassParents.IdDad = Int32.Parse(dataReader[4].ToString());
                }
                catch
                {

                }

                try
                {
                    ClassFolder.TableFolder.ClassParentGuard.IdMomGuradian = Int32.Parse(dataReader[5].ToString());
                }
                catch
                {

                }
                try
                {
                    ClassFolder.TableFolder.ClassParentGuard.IdDadGuradian = Int32.Parse(dataReader[6].ToString());
                }
                catch
                {

                }

                ClassFolder.TableFolder.ClassPassport.IdPassport = Int32.Parse(dataReader[7].ToString());
                ClassFolder.TableFolder.ClassRegistration.IdReg = Int32.Parse(dataReader[8].ToString());                
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
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
                ImagePhoto.Source = bmp;
            }
            sqlConnection.Close();

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            //if (string.IsNullOrEmpty(CbVremCity.Text) && string.IsNullOrEmpty(CbVremStreet.Text) && string.IsNullOrEmpty(TbVremPostcode.Text)
            //    && string.IsNullOrEmpty(TbVremHouse.Text) && string.IsNullOrEmpty(TbVremEnclosure.Text) && string.IsNullOrEmpty(TbVremAppartment.Text)
            //   && ChbNoMom.IsChecked == true && ChbNoPap.IsChecked == true && ChbNoMomGuard.IsChecked == true)
            //{
            //    //+
            //    EditAllNullAddDadGuard();
            //}
            //else if (string.IsNullOrEmpty(CbVremCity.Text) && string.IsNullOrEmpty(CbVremStreet.Text) && string.IsNullOrEmpty(TbVremPostcode.Text)
            //    && string.IsNullOrEmpty(TbVremHouse.Text) && string.IsNullOrEmpty(TbVremEnclosure.Text) && string.IsNullOrEmpty(TbVremAppartment.Text)
            //   && ChbNoMom.IsChecked == true && ChbNoPap.IsChecked == true && ChbNoPapGuard.IsChecked == true)
            //{
            //    //+
            //    EditAllNullAddMomGuard();
            //}
            //else if (string.IsNullOrEmpty(CbVremCity.Text) && string.IsNullOrEmpty(CbVremStreet.Text) && string.IsNullOrEmpty(TbVremPostcode.Text)
            //    && string.IsNullOrEmpty(TbVremHouse.Text) && string.IsNullOrEmpty(TbVremEnclosure.Text) && string.IsNullOrEmpty(TbVremAppartment.Text)
            //   && ChbNoMom.IsChecked == true && ChbNoPap.IsChecked == true)
            //{
            //    //+
            //    EditAllNullMomGuardDadGuard();
            //}
            //else if (string.IsNullOrEmpty(CbVremCity.Text) && string.IsNullOrEmpty(CbVremStreet.Text) && string.IsNullOrEmpty(TbVremPostcode.Text)
            //    && string.IsNullOrEmpty(TbVremHouse.Text) && string.IsNullOrEmpty(TbVremEnclosure.Text) && string.IsNullOrEmpty(TbVremAppartment.Text)
            //   && ChbNoMomGuard.IsChecked == true && ChbNoPap.IsChecked == true && ChbNoPapGuard.IsChecked == true)
            //{
            //    //+
            //    EditAllNullAddMom();
            //}
            //else if (string.IsNullOrEmpty(CbVremCity.Text) && string.IsNullOrEmpty(CbVremStreet.Text) && string.IsNullOrEmpty(TbVremPostcode.Text)
            //    && string.IsNullOrEmpty(TbVremHouse.Text) && string.IsNullOrEmpty(TbVremEnclosure.Text) && string.IsNullOrEmpty(TbVremAppartment.Text)
            //   && ChbNoMomGuard.IsChecked == true && ChbNoMom.IsChecked == true && ChbNoPapGuard.IsChecked == true)
            //{
            //    //+
            //    EditAllNullAddDad();
            //}
            //else if (string.IsNullOrEmpty(CbVremCity.Text) && string.IsNullOrEmpty(CbVremStreet.Text) && string.IsNullOrEmpty(TbVremPostcode.Text)
            //    && string.IsNullOrEmpty(TbVremHouse.Text) && string.IsNullOrEmpty(TbVremEnclosure.Text) && string.IsNullOrEmpty(TbVremAppartment.Text)
            //   && ChbNoMomGuard.IsChecked == true && ChbNoPapGuard.IsChecked == true)
            //{
            //    //+
            //    EditAllNullMomDad();
            //}
            //else if (string.IsNullOrEmpty(CbVremCity.Text) && string.IsNullOrEmpty(CbVremStreet.Text) && string.IsNullOrEmpty(TbVremPostcode.Text)
            //   && string.IsNullOrEmpty(TbVremHouse.Text) && string.IsNullOrEmpty(TbVremEnclosure.Text) && string.IsNullOrEmpty(TbVremAppartment.Text)
            //  && ChbNoPap.IsChecked == true && ChbNoMomGuard.IsChecked == true)
            //{
            //    //+
            //    EditAllNullMomDadGuard();
            //}
            //else if (string.IsNullOrEmpty(CbVremCity.Text) && string.IsNullOrEmpty(CbVremStreet.Text) && string.IsNullOrEmpty(TbVremPostcode.Text)
            //   && string.IsNullOrEmpty(TbVremHouse.Text) && string.IsNullOrEmpty(TbVremEnclosure.Text) && string.IsNullOrEmpty(TbVremAppartment.Text)
            //  && ChbNoMom.IsChecked == true && ChbNoPapGuard.IsChecked == true)
            //{
            //    //+
            //    EditAllNullMomGuardDad();
            //}
            //else if (ChbNoMom.IsChecked == true && ChbNoPap.IsChecked == true && ChbNoMomGuard.IsChecked == true)
            //{
            //    //+
            //    EditDadGuard();
            //}
            //else if (ChbNoMom.IsChecked == true && ChbNoPap.IsChecked == true && ChbNoPapGuard.IsChecked == true)
            //{
            //    //+
            //    EditMomGuard();
            //}
            //else if (ChbNoMom.IsChecked == true && ChbNoPap.IsChecked == true)
            //{
            //    //+
            //    EditGuardDadGuard();
            //}
            //else if (ChbNoMomGuard.IsChecked == true && ChbNoPap.IsChecked == true && ChbNoPapGuard.IsChecked == true)
            //{
            //    //+
            //    EditMom();
            //}
            //else if (ChbNoMomGuard.IsChecked == true && ChbNoMom.IsChecked == true && ChbNoPapGuard.IsChecked == true)
            //{
            //    //+
            //    EditDad();
            //}
            //else if (ChbNoMomGuard.IsChecked == true && ChbNoPapGuard.IsChecked == true)
            //{
            //    //+
            //    MomDad();
            //}
            //else if (ChbNoPap.IsChecked == true && ChbNoMomGuard.IsChecked == true)
            //{
            //    //+
            //    MomDadGuard();
            //}
            //else if (ChbNoMom.IsChecked == true && ChbNoPapGuard.IsChecked == true)
            //{
            //    //+
            //    MomGuardDad();
            //}
            
            
            //Адрес проживания
            
            classEdit.Edit("Update dbo.Address " +
               $"Set  PostCode='{TbRealPostcode.Text}', " +
               $"IdCity='{Int32.Parse(CbRealCity.SelectedValue.ToString())}', " +
               $"IdStreet ='{Int32.Parse(CbRealStreet.SelectedValue.ToString())}', " +
               $"House ='{TbRealHouse.Text}', " +
               $"Enclosure ='{TbRealEnclosure.Text}', " +
               $"Appartment ='{TbRealAppartment.Text}' " +
               $"Where IdAddress = '{ClassFolder.TableFolder.ClassAddress.IdAddress}'");

            //Временная прописка
            if (CbVremCity.SelectedItem == null && CbVremStreet.SelectedItem != null)
            {
                classEdit.Edit("Update dbo.TemporaryRegistration " +
               $"Set PostcodeTemp='{DBNull.Value}', " +
               $"IdCity='3', " +
               $"IdStreet ='3', " +
               $"HouseTemp ='{TbVremHouse.Text}', " +
               $"EnclosureTemp ='{TbVremEnclosure.Text}', " +
               $"AppartmentTemp ='{DBNull.Value}' " +
               $"Where IdTemporaryRegistration = '{ClassFolder.TableFolder.ClassVremAddress.IdVremReg}'");
            }
            else if (CbVremStreet.SelectedItem == null && CbVremCity.SelectedItem != null)
            {
                classEdit.Edit("Update dbo.TemporaryRegistration " +
               $"Set PostcodeTemp='{DBNull.Value}', " +
               $"IdCity='3', " +
               $"IdStreet ='3', " +
               $"HouseTemp ='{TbVremHouse.Text}', " +
               $"EnclosureTemp ='{TbVremEnclosure.Text}', " +
               $"AppartmentTemp ='{DBNull.Value}' " +
               $"Where IdTemporaryRegistration = '{ClassFolder.TableFolder.ClassVremAddress.IdVremReg}'");
            }
            else if (CbVremCity.SelectedItem == null && CbVremStreet.SelectedItem == null)
            {
                classEdit.Edit("Update dbo.TemporaryRegistration " +
               $"Set PostcodeTemp='{DBNull.Value}', " +
               $"IdCity='3', " +
               $"IdStreet ='3', " +
               $"HouseTemp ='{TbVremHouse.Text}', " +
               $"EnclosureTemp ='{TbVremEnclosure.Text}', " +
               $"AppartmentTemp ='{DBNull.Value}' " +
               $"Where IdTemporaryRegistration = '{ClassFolder.TableFolder.ClassVremAddress.IdVremReg}'");
            }
            else
            {
                classEdit.Edit("Update dbo.TemporaryRegistration " +
                   $"Set PostcodeTemp='{TbVremPostcode.Text}', " +
                   $"IdCity='{Int32.Parse(CbVremCity.SelectedValue.ToString())}', " +
                   $"IdStreet ='{Int32.Parse(CbVremStreet.SelectedValue.ToString())}', " +
                   $"HouseTemp ='{TbVremHouse.Text}', " +
                   $"EnclosureTemp ='{TbVremEnclosure.Text}', " +
                   $"AppartmentTemp ='{TbVremAppartment.Text}' " +
                   $"Where IdTemporaryRegistration = '{ClassFolder.TableFolder.ClassVremAddress.IdVremReg}'");
            }

            //Адрес прописки
            classEdit.Edit("Update dbo.Registration " +
               $"Set PostcodeReg='{TbRegPostcode.Text}', " +
               $"IdCity='{Int32.Parse(CbRegCity.SelectedValue.ToString())}', " +
               $"IdStreet ='{Int32.Parse(CbRegStreet.SelectedValue.ToString())}', " +
               $"HouseReg ='{TbRegHouse.Text}', " +
               $"EnclosureReg ='{TbRegEnclosure.Text}', " +
               $"AppartmentReg ='{TbRegAppartment.Text}' " +
               $"Where IdRegistration = '{ClassFolder.TableFolder.ClassRegistration.IdReg}'");

            //Мама
            classEdit.Edit("Update dbo.Mom " +
               $"Set LastNameMom='{TbMomLastName.Text}', " +
               $"FirstNameMom='{TbMomFirstName.Text}', " +
               $"MiddleNameMom ='{TbMomMiddleName.Text}', " +
               $"NumberPhoneMom ='{TbMomNumberPhone.Text}' " +
               $"Where IdMom = '{ClassFolder.TableFolder.ClassParents.IdMom}'");

            //Папа
            classEdit.Edit("Update dbo.Dad " +
               $"Set LastNameDad='{TbDadLastName.Text}', " +
               $"FirstNameDad='{TbDadFirstName.Text}', " +
               $"MiddleNameDad ='{TbDadMiddleName.Text}', " +
               $"NumberPhoneDad ='{TbDadNumberPhone.Text}' " +
               $"Where IdDad = '{ClassFolder.TableFolder.ClassParents.IdDad}'");

            //Опекун Ж
            classEdit.Edit("Update dbo.GuardianMom " +
               $"Set LastNameGuardianMom='{TbMomLastNameGuard.Text}', " +
               $"FirstNameGuardianMom='{TbMomFirstNameGuard.Text}', " +
               $"MiddleNameGuardianMom ='{TbMomMiddleNameGuard.Text}', " +
               $"NumberPhoneGuardianMom ='{TbMomNumberPhoneGuard.Text}' " +
               $"Where IdGuardianMom = '{ClassFolder.TableFolder.ClassParentGuard.IdMomGuradian}'");

            //Опекун М
            classEdit.Edit("Update dbo.GuardianDad " +
               $"Set LastNameGuardianDad='{TbDadLastNameGuard.Text}', " +
               $"FirstNameGuardianDad='{TbDadFirstNameGuard.Text}', " +
               $"MiddleNameGuardianDad ='{TbDadMiddleNameGuard.Text}', " +
               $"NumberPhoneGuardianDad ='{TbDadNumberPhoneGuard.Text}' " +
               $"Where IdGuardianDad = '{ClassFolder.TableFolder.ClassParentGuard.IdDadGuradian}'");

            //Паспорт
            classEdit.Edit("Update dbo.Passport " +
               $"Set LastName='{TbLastName.Text}', " +
               $"FirstName='{TbFirstName.Text}', " +
               $"MiddleName ='{TbMiddleName.Text}', " +
               $"Series ='{TbSeries.Text}', " +
               $"Number ='{TbNumber.Text}', " +
               $"IdIssuedByWhom ='{Int32.Parse(CbIsuedByWhom.SelectedValue.ToString())}', " +
               $"DateOfIssue='{DpDateOfIsue.Text}', " +
               $"CodeDivision ='{TbCode.Text}', " +
               $"IdGender ='{Int32.Parse(CbGender.SelectedValue.ToString())}', " +
               $"DateOfBorn ='{DpDateOfBorn.Text}', " +
               $"IdPlaceOfBorn ='{Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString())}', " +
               $"FamilyPosition='{ChbFamilyPosition.IsChecked}' " +
               $"Where IdPassport = '{ClassFolder.TableFolder.ClassPassport.IdPassport}'");

            //Студент
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
            }
            catch
            {

            }
            classEdit.Edit("Update dbo.Student " +
               $"Set SNILS='{TbSNILS.Text}', " +
               $"INN='{TbINN.Text}', " +
               $"NumberPhone ='{TbNumberPhone.Text}', " +
               $"IdFamily ='{Int32.Parse(CbFamily.SelectedValue.ToString())}', " +
               $"IdFamilyStatus ='{Int32.Parse(CbFamilyStatus.SelectedValue.ToString())}', " +
               $"Email ='{TbEmail.Text}', " +
               $"HospitalPolice='{TbHospital.Text}', " +
               $"IdImage='{ClassFolder.TableFolder.ClassImage.IdImage}', " +
               $"NumberOrder='{TbOrder.Text}', " +
               $"DateOrder='{DpDateOfOrder.Text}', " +
               $"Comment='{TbComment.Text}' " +
               $"Where IdStudent = '{ClassFolder.TableFolder.ClassStudent.IdStudent}'");

            ClassFolder.ClassMB.MBInformation("Данные отректированы");


        }

        //private void MomGuardDad()
        //{
        //    //Адрес проживания
        //    classEdit.Edit("Update dbo.Address " +
        //       $"Set  PostCode='{TbRealPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRealCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRealStreet.SelectedValue.ToString())}', " +
        //       $"House ='{TbRealHouse.Text}', " +
        //       $"Enclosure ='{TbRealEnclosure.Text}', " +
        //       $"Appartment ='{TbRealAppartment.Text}' " +
        //       $"Where IdAddress = '{ClassFolder.TableFolder.ClassAddress.IdAddress}'");

        //    //Временная прописка
        //    classEdit.Edit("Update dbo.TemporaryRegistration " +
        //       $"Set PostcodeTemp='{TbVremPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbVremCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbVremStreet.SelectedValue.ToString())}', " +
        //       $"HouseTemp ='{TbVremHouse.Text}', " +
        //       $"EnclosureTemp ='{TbVremEnclosure.Text}', " +
        //       $"AppartmentTemp ='{TbVremAppartment.Text}' " +
        //       $"Where IdTemporaryRegistration = '{ClassFolder.TableFolder.ClassVremAddress.IdVremReg}'");

        //    //Адрес прописки
        //    classEdit.Edit("Update dbo.Registration " +
        //       $"Set PostcodeReg='{TbRegPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRegCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRegStreet.SelectedValue.ToString())}', " +
        //       $"HouseReg ='{TbRegHouse.Text}', " +
        //       $"EnclosureReg ='{TbRegEnclosure.Text}', " +
        //       $"AppartmentReg ='{TbRegAppartment.Text}' " +
        //       $"Where IdRegistration = '{ClassFolder.TableFolder.ClassRegistration.IdReg}'");

            

        //    //Папа
        //    classEdit.Edit("Update dbo.Dad " +
        //       $"Set LastNameDad='{TbDadLastName.Text}', " +
        //       $"FirstNameDad='{TbDadFirstName.Text}', " +
        //       $"MiddleNameDad ='{TbDadMiddleName.Text}', " +
        //       $"NumberPhoneDad ='{TbDadNumberPhone.Text}' " +
        //       $"Where IdDad = '{ClassFolder.TableFolder.ClassParents.IdDad}'");

        //    //Опекун Ж
        //    classEdit.Edit("Update dbo.GuardianMom " +
        //       $"Set LastNameGuardianMom='{TbMomLastNameGuard.Text}', " +
        //       $"FirstNameGuardianMom='{TbMomFirstNameGuard.Text}', " +
        //       $"MiddleNameGuardianMom ='{TbMomMiddleNameGuard.Text}', " +
        //       $"NumberPhoneGuardianMom ='{TbMomNumberPhoneGuard.Text}' " +
        //       $"Where IdGuardianMom = '{ClassFolder.TableFolder.ClassParentGuard.IdMomGuradian}'");

           

        //    //Паспорт
        //    classEdit.Edit("Update dbo.Passport " +
        //       $"Set LastName='{TbLastName.Text}', " +
        //       $"FirstName='{TbFirstName.Text}', " +
        //       $"MiddleName ='{TbMiddleName.Text}', " +
        //       $"Series ='{TbSeries.Text}', " +
        //       $"Number ='{TbNumber.Text}', " +
        //       $"IdIssuedByWhom ='{Int32.Parse(CbIsuedByWhom.SelectedValue.ToString())}', " +
        //       $"DateOfIssue='{DpDateOfIsue.Text}', " +
        //       $"CodeDivision ='{TbCode.Text}', " +
        //       $"IdGender ='{Int32.Parse(CbGender.SelectedValue.ToString())}', " +
        //       $"DateOfBorn ='{DpDateOfBorn.Text}', " +
        //       $"IdPlaceOfBorn ='{Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString())}' " +
        //       $"Where IdPassport = '{ClassFolder.TableFolder.ClassPassport.IdPassport}'");

        //    //Студент
        //    try
        //    {



        //        string iFile = TbImage.Text;
        //        // конвертация изображения в байты
        //        byte[] imageData = null;
        //        FileInfo fInfo = new FileInfo(iFile);
        //        long numBytes = fInfo.Length;
        //        FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
        //        BinaryReader br = new BinaryReader(fStream);
        //        imageData = br.ReadBytes((int)numBytes);
        //        //  получение расширения файла изображения не забыв удалить точку перед расширением
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
        //    }
        //    catch
        //    {

        //    }
        //    classEdit.Edit("Update dbo.Student " +
        //       $"Set SNILS='{TbSNILS.Text}', " +
        //       $"INN='{TbINN.Text}', " +
        //       $"NumberPhone ='{TbNumberPhone.Text}', " +
        //       $"IdFamily ='{Int32.Parse(CbFamily.SelectedValue.ToString())}', " +
        //       $"IdFamilyStatus ='{Int32.Parse(CbFamilyStatus.SelectedValue.ToString())}', " +
        //       $"Email ='{TbEmail.Text}', " +
        //       $"HospitalPolice='{TbHospital.Text}', " +
        //       $"IdImage='{ClassFolder.TableFolder.ClassImage.IdImage}'" +
        //       $"Where IdStudent = '{ClassFolder.TableFolder.ClassStudent.IdStudent}'");

        //    ClassFolder.ClassMB.MBInformation("Данные отректированы");
        //}       

        //private void MomDadGuard()
        //{
        //    //Адрес проживания
        //    classEdit.Edit("Update dbo.Address " +
        //       $"Set  PostCode='{TbRealPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRealCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRealStreet.SelectedValue.ToString())}', " +
        //       $"House ='{TbRealHouse.Text}', " +
        //       $"Enclosure ='{TbRealEnclosure.Text}', " +
        //       $"Appartment ='{TbRealAppartment.Text}' " +
        //       $"Where IdAddress = '{ClassFolder.TableFolder.ClassAddress.IdAddress}'");

        //    //Временная прописка
        //    classEdit.Edit("Update dbo.TemporaryRegistration " +
        //       $"Set PostcodeTemp='{TbVremPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbVremCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbVremStreet.SelectedValue.ToString())}', " +
        //       $"HouseTemp ='{TbVremHouse.Text}', " +
        //       $"EnclosureTemp ='{TbVremEnclosure.Text}', " +
        //       $"AppartmentTemp ='{TbVremAppartment.Text}' " +
        //       $"Where IdTemporaryRegistration = '{ClassFolder.TableFolder.ClassVremAddress.IdVremReg}'");

        //    //Адрес прописки
        //    classEdit.Edit("Update dbo.Registration " +
        //       $"Set PostcodeReg='{TbRegPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRegCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRegStreet.SelectedValue.ToString())}', " +
        //       $"HouseReg ='{TbRegHouse.Text}', " +
        //       $"EnclosureReg ='{TbRegEnclosure.Text}', " +
        //       $"AppartmentReg ='{TbRegAppartment.Text}' " +
        //       $"Where IdRegistration = '{ClassFolder.TableFolder.ClassRegistration.IdReg}'");

        //    //Мама
        //    classEdit.Edit("Update dbo.Mom " +
        //       $"Set LastNameMom='{TbMomLastName.Text}', " +
        //       $"FirstNameMom='{TbMomFirstName.Text}', " +
        //       $"MiddleNameMom ='{TbMomMiddleName.Text}', " +
        //       $"NumberPhoneMom ='{TbMomNumberPhone.Text}' " +
        //       $"Where IdMom = '{ClassFolder.TableFolder.ClassParents.IdMom}'");

            

            

        //    //Опекун М
        //    classEdit.Edit("Update dbo.GuardianDad " +
        //       $"Set LastNameGuardianDad='{TbDadLastNameGuard.Text}', " +
        //       $"FirstNameGuardianDad='{TbDadFirstNameGuard.Text}', " +
        //       $"MiddleNameGuardianDad ='{TbDadMiddleNameGuard.Text}', " +
        //       $"NumberPhoneGuardianDad ='{TbDadNumberPhoneGuard.Text}' " +
        //       $"Where IdGuardianDad = '{ClassFolder.TableFolder.ClassParentGuard.IdDadGuradian}'");

        //    //Паспорт
        //    classEdit.Edit("Update dbo.Passport " +
        //       $"Set LastName='{TbLastName.Text}', " +
        //       $"FirstName='{TbFirstName.Text}', " +
        //       $"MiddleName ='{TbMiddleName.Text}', " +
        //       $"Series ='{TbSeries.Text}', " +
        //       $"Number ='{TbNumber.Text}', " +
        //       $"IdIssuedByWhom ='{Int32.Parse(CbIsuedByWhom.SelectedValue.ToString())}', " +
        //       $"DateOfIssue='{DpDateOfIsue.Text}', " +
        //       $"CodeDivision ='{TbCode.Text}', " +
        //       $"IdGender ='{Int32.Parse(CbGender.SelectedValue.ToString())}', " +
        //       $"DateOfBorn ='{DpDateOfBorn.Text}', " +
        //       $"IdPlaceOfBorn ='{Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString())}' " +
        //       $"Where IdPassport = '{ClassFolder.TableFolder.ClassPassport.IdPassport}'");

        //    //Студент
        //    try
        //    {



        //        string iFile = TbImage.Text;
        //        // конвертация изображения в байты
        //        byte[] imageData = null;
        //        FileInfo fInfo = new FileInfo(iFile);
        //        long numBytes = fInfo.Length;
        //        FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
        //        BinaryReader br = new BinaryReader(fStream);
        //        imageData = br.ReadBytes((int)numBytes);
        //        //  получение расширения файла изображения не забыв удалить точку перед расширением
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
        //    }
        //    catch
        //    {

        //    }
        //    classEdit.Edit("Update dbo.Student " +
        //       $"Set SNILS='{TbSNILS.Text}', " +
        //       $"INN='{TbINN.Text}', " +
        //       $"NumberPhone ='{TbNumberPhone.Text}', " +
        //       $"IdFamily ='{Int32.Parse(CbFamily.SelectedValue.ToString())}', " +
        //       $"IdFamilyStatus ='{Int32.Parse(CbFamilyStatus.SelectedValue.ToString())}', " +
        //       $"Email ='{TbEmail.Text}', " +
        //       $"HospitalPolice='{TbHospital.Text}', " +
        //       $"IdImage='{ClassFolder.TableFolder.ClassImage.IdImage}'" +
        //       $"Where IdStudent = '{ClassFolder.TableFolder.ClassStudent.IdStudent}'");

        //    ClassFolder.ClassMB.MBInformation("Данные отректированы");
        //}

        //private void MomDad()
        //{
        //    //Адрес проживания
        //    classEdit.Edit("Update dbo.Address " +
        //       $"Set  PostCode='{TbRealPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRealCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRealStreet.SelectedValue.ToString())}', " +
        //       $"House ='{TbRealHouse.Text}', " +
        //       $"Enclosure ='{TbRealEnclosure.Text}', " +
        //       $"Appartment ='{TbRealAppartment.Text}' " +
        //       $"Where IdAddress = '{ClassFolder.TableFolder.ClassAddress.IdAddress}'");

        //    //Временная прописка
        //    classEdit.Edit("Update dbo.TemporaryRegistration " +
        //       $"Set PostcodeTemp='{TbVremPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbVremCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbVremStreet.SelectedValue.ToString())}', " +
        //       $"HouseTemp ='{TbVremHouse.Text}', " +
        //       $"EnclosureTemp ='{TbVremEnclosure.Text}', " +
        //       $"AppartmentTemp ='{TbVremAppartment.Text}' " +
        //       $"Where IdTemporaryRegistration = '{ClassFolder.TableFolder.ClassVremAddress.IdVremReg}'");

        //    //Адрес прописки
        //    classEdit.Edit("Update dbo.Registration " +
        //       $"Set PostcodeReg='{TbRegPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRegCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRegStreet.SelectedValue.ToString())}', " +
        //       $"HouseReg ='{TbRegHouse.Text}', " +
        //       $"EnclosureReg ='{TbRegEnclosure.Text}', " +
        //       $"AppartmentReg ='{TbRegAppartment.Text}' " +
        //       $"Where IdRegistration = '{ClassFolder.TableFolder.ClassRegistration.IdReg}'");

        //    //Мама
        //    classEdit.Edit("Update dbo.Mom " +
        //       $"Set LastNameMom='{TbMomLastName.Text}', " +
        //       $"FirstNameMom='{TbMomFirstName.Text}', " +
        //       $"MiddleNameMom ='{TbMomMiddleName.Text}', " +
        //       $"NumberPhoneMom ='{TbMomNumberPhone.Text}' " +
        //       $"Where IdMom = '{ClassFolder.TableFolder.ClassParents.IdMom}'");

        //    //Папа
        //    classEdit.Edit("Update dbo.Dad " +
        //       $"Set LastNameDad='{TbDadLastName.Text}', " +
        //       $"FirstNameDad='{TbDadFirstName.Text}', " +
        //       $"MiddleNameDad ='{TbDadMiddleName.Text}', " +
        //       $"NumberPhoneDad ='{TbDadNumberPhone.Text}' " +
        //       $"Where IdDad = '{ClassFolder.TableFolder.ClassParents.IdDad}'");
            

        //    //Паспорт
        //    classEdit.Edit("Update dbo.Passport " +
        //       $"Set LastName='{TbLastName.Text}', " +
        //       $"FirstName='{TbFirstName.Text}', " +
        //       $"MiddleName ='{TbMiddleName.Text}', " +
        //       $"Series ='{TbSeries.Text}', " +
        //       $"Number ='{TbNumber.Text}', " +
        //       $"IdIssuedByWhom ='{Int32.Parse(CbIsuedByWhom.SelectedValue.ToString())}', " +
        //       $"DateOfIssue='{DpDateOfIsue.Text}', " +
        //       $"CodeDivision ='{TbCode.Text}', " +
        //       $"IdGender ='{Int32.Parse(CbGender.SelectedValue.ToString())}', " +
        //       $"DateOfBorn ='{DpDateOfBorn.Text}', " +
        //       $"IdPlaceOfBorn ='{Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString())}' " +
        //       $"Where IdPassport = '{ClassFolder.TableFolder.ClassPassport.IdPassport}'");

        //    //Студент
        //    try
        //    {



        //        string iFile = TbImage.Text;
        //        // конвертация изображения в байты
        //        byte[] imageData = null;
        //        FileInfo fInfo = new FileInfo(iFile);
        //        long numBytes = fInfo.Length;
        //        FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
        //        BinaryReader br = new BinaryReader(fStream);
        //        imageData = br.ReadBytes((int)numBytes);
        //        //  получение расширения файла изображения не забыв удалить точку перед расширением
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
        //    }
        //    catch
        //    {

        //    }
        //    classEdit.Edit("Update dbo.Student " +
        //       $"Set SNILS='{TbSNILS.Text}', " +
        //       $"INN='{TbINN.Text}', " +
        //       $"NumberPhone ='{TbNumberPhone.Text}', " +
        //       $"IdFamily ='{Int32.Parse(CbFamily.SelectedValue.ToString())}', " +
        //       $"IdFamilyStatus ='{Int32.Parse(CbFamilyStatus.SelectedValue.ToString())}', " +
        //       $"Email ='{TbEmail.Text}', " +
        //       $"HospitalPolice='{TbHospital.Text}', " +
        //       $"IdImage='{ClassFolder.TableFolder.ClassImage.IdImage}'" +
        //       $"Where IdStudent = '{ClassFolder.TableFolder.ClassStudent.IdStudent}'");

        //    ClassFolder.ClassMB.MBInformation("Данные отректированы");
        //}

        //private void EditDad()
        //{
        //    //Адрес проживания
        //    classEdit.Edit("Update dbo.Address " +
        //       $"Set  PostCode='{TbRealPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRealCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRealStreet.SelectedValue.ToString())}', " +
        //       $"House ='{TbRealHouse.Text}', " +
        //       $"Enclosure ='{TbRealEnclosure.Text}', " +
        //       $"Appartment ='{TbRealAppartment.Text}' " +
        //       $"Where IdAddress = '{ClassFolder.TableFolder.ClassAddress.IdAddress}'");

        //    //Временная прописка
        //    classEdit.Edit("Update dbo.TemporaryRegistration " +
        //       $"Set PostcodeTemp='{TbVremPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbVremCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbVremStreet.SelectedValue.ToString())}', " +
        //       $"HouseTemp ='{TbVremHouse.Text}', " +
        //       $"EnclosureTemp ='{TbVremEnclosure.Text}', " +
        //       $"AppartmentTemp ='{TbVremAppartment.Text}' " +
        //       $"Where IdTemporaryRegistration = '{ClassFolder.TableFolder.ClassVremAddress.IdVremReg}'");

        //    //Адрес прописки
        //    classEdit.Edit("Update dbo.Registration " +
        //       $"Set PostcodeReg='{TbRegPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRegCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRegStreet.SelectedValue.ToString())}', " +
        //       $"HouseReg ='{TbRegHouse.Text}', " +
        //       $"EnclosureReg ='{TbRegEnclosure.Text}', " +
        //       $"AppartmentReg ='{TbRegAppartment.Text}' " +
        //       $"Where IdRegistration = '{ClassFolder.TableFolder.ClassRegistration.IdReg}'");

           

        //    //Папа
        //    classEdit.Edit("Update dbo.Dad " +
        //       $"Set LastNameDad='{TbDadLastName.Text}', " +
        //       $"FirstNameDad='{TbDadFirstName.Text}', " +
        //       $"MiddleNameDad ='{TbDadMiddleName.Text}', " +
        //       $"NumberPhoneDad ='{TbDadNumberPhone.Text}' " +
        //       $"Where IdDad = '{ClassFolder.TableFolder.ClassParents.IdDad}'");

            

        //    //Паспорт
        //    classEdit.Edit("Update dbo.Passport " +
        //       $"Set LastName='{TbLastName.Text}', " +
        //       $"FirstName='{TbFirstName.Text}', " +
        //       $"MiddleName ='{TbMiddleName.Text}', " +
        //       $"Series ='{TbSeries.Text}', " +
        //       $"Number ='{TbNumber.Text}', " +
        //       $"IdIssuedByWhom ='{Int32.Parse(CbIsuedByWhom.SelectedValue.ToString())}', " +
        //       $"DateOfIssue='{DpDateOfIsue.Text}', " +
        //       $"CodeDivision ='{TbCode.Text}', " +
        //       $"IdGender ='{Int32.Parse(CbGender.SelectedValue.ToString())}', " +
        //       $"DateOfBorn ='{DpDateOfBorn.Text}', " +
        //       $"IdPlaceOfBorn ='{Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString())}' " +
        //       $"Where IdPassport = '{ClassFolder.TableFolder.ClassPassport.IdPassport}'");

        //    //Студент
        //    try
        //    {



        //        string iFile = TbImage.Text;
        //        // конвертация изображения в байты
        //        byte[] imageData = null;
        //        FileInfo fInfo = new FileInfo(iFile);
        //        long numBytes = fInfo.Length;
        //        FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
        //        BinaryReader br = new BinaryReader(fStream);
        //        imageData = br.ReadBytes((int)numBytes);
        //        //  получение расширения файла изображения не забыв удалить точку перед расширением
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
        //    }
        //    catch
        //    {

        //    }
        //    classEdit.Edit("Update dbo.Student " +
        //       $"Set SNILS='{TbSNILS.Text}', " +
        //       $"INN='{TbINN.Text}', " +
        //       $"NumberPhone ='{TbNumberPhone.Text}', " +
        //       $"IdFamily ='{Int32.Parse(CbFamily.SelectedValue.ToString())}', " +
        //       $"IdFamilyStatus ='{Int32.Parse(CbFamilyStatus.SelectedValue.ToString())}', " +
        //       $"Email ='{TbEmail.Text}', " +
        //       $"HospitalPolice='{TbHospital.Text}', " +
        //       $"IdImage='{ClassFolder.TableFolder.ClassImage.IdImage}'" +
        //       $"Where IdStudent = '{ClassFolder.TableFolder.ClassStudent.IdStudent}'");

        //    ClassFolder.ClassMB.MBInformation("Данные отректированы");
        //}

        //private void EditMom()
        //{
        //    //Адрес проживания
        //    classEdit.Edit("Update dbo.Address " +
        //       $"Set  PostCode='{TbRealPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRealCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRealStreet.SelectedValue.ToString())}', " +
        //       $"House ='{TbRealHouse.Text}', " +
        //       $"Enclosure ='{TbRealEnclosure.Text}', " +
        //       $"Appartment ='{TbRealAppartment.Text}' " +
        //       $"Where IdAddress = '{ClassFolder.TableFolder.ClassAddress.IdAddress}'");

        //    //Временная прописка
        //    classEdit.Edit("Update dbo.TemporaryRegistration " +
        //       $"Set PostcodeTemp='{TbVremPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbVremCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbVremStreet.SelectedValue.ToString())}', " +
        //       $"HouseTemp ='{TbVremHouse.Text}', " +
        //       $"EnclosureTemp ='{TbVremEnclosure.Text}', " +
        //       $"AppartmentTemp ='{TbVremAppartment.Text}' " +
        //       $"Where IdTemporaryRegistration = '{ClassFolder.TableFolder.ClassVremAddress.IdVremReg}'");

        //    //Адрес прописки
        //    classEdit.Edit("Update dbo.Registration " +
        //       $"Set PostcodeReg='{TbRegPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRegCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRegStreet.SelectedValue.ToString())}', " +
        //       $"HouseReg ='{TbRegHouse.Text}', " +
        //       $"EnclosureReg ='{TbRegEnclosure.Text}', " +
        //       $"AppartmentReg ='{TbRegAppartment.Text}' " +
        //       $"Where IdRegistration = '{ClassFolder.TableFolder.ClassRegistration.IdReg}'");

        //    //Мама
        //    classEdit.Edit("Update dbo.Mom " +
        //       $"Set LastNameMom='{TbMomLastName.Text}', " +
        //       $"FirstNameMom='{TbMomFirstName.Text}', " +
        //       $"MiddleNameMom ='{TbMomMiddleName.Text}', " +
        //       $"NumberPhoneMom ='{TbMomNumberPhone.Text}' " +
        //       $"Where IdMom = '{ClassFolder.TableFolder.ClassParents.IdMom}'");            

        //    //Паспорт
        //    classEdit.Edit("Update dbo.Passport " +
        //       $"Set LastName='{TbLastName.Text}', " +
        //       $"FirstName='{TbFirstName.Text}', " +
        //       $"MiddleName ='{TbMiddleName.Text}', " +
        //       $"Series ='{TbSeries.Text}', " +
        //       $"Number ='{TbNumber.Text}', " +
        //       $"IdIssuedByWhom ='{Int32.Parse(CbIsuedByWhom.SelectedValue.ToString())}', " +
        //       $"DateOfIssue='{DpDateOfIsue.Text}', " +
        //       $"CodeDivision ='{TbCode.Text}', " +
        //       $"IdGender ='{Int32.Parse(CbGender.SelectedValue.ToString())}', " +
        //       $"DateOfBorn ='{DpDateOfBorn.Text}', " +
        //       $"IdPlaceOfBorn ='{Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString())}' " +
        //       $"Where IdPassport = '{ClassFolder.TableFolder.ClassPassport.IdPassport}'");

        //    //Студент
        //    try
        //    {



        //        string iFile = TbImage.Text;
        //        // конвертация изображения в байты
        //        byte[] imageData = null;
        //        FileInfo fInfo = new FileInfo(iFile);
        //        long numBytes = fInfo.Length;
        //        FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
        //        BinaryReader br = new BinaryReader(fStream);
        //        imageData = br.ReadBytes((int)numBytes);
        //        //  получение расширения файла изображения не забыв удалить точку перед расширением
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
        //    }
        //    catch
        //    {

        //    }
        //    classEdit.Edit("Update dbo.Student " +
        //       $"Set SNILS='{TbSNILS.Text}', " +
        //       $"INN='{TbINN.Text}', " +
        //       $"NumberPhone ='{TbNumberPhone.Text}', " +
        //       $"IdFamily ='{Int32.Parse(CbFamily.SelectedValue.ToString())}', " +
        //       $"IdFamilyStatus ='{Int32.Parse(CbFamilyStatus.SelectedValue.ToString())}', " +
        //       $"Email ='{TbEmail.Text}', " +
        //       $"HospitalPolice='{TbHospital.Text}', " +
        //       $"IdImage='{ClassFolder.TableFolder.ClassImage.IdImage}'" +
        //       $"Where IdStudent = '{ClassFolder.TableFolder.ClassStudent.IdStudent}'");

        //    ClassFolder.ClassMB.MBInformation("Данные отректированы");
        //}

        //private void EditGuardDadGuard()
        //{
        //    //Адрес проживания
        //    classEdit.Edit("Update dbo.Address " +
        //       $"Set  PostCode='{TbRealPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRealCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRealStreet.SelectedValue.ToString())}', " +
        //       $"House ='{TbRealHouse.Text}', " +
        //       $"Enclosure ='{TbRealEnclosure.Text}', " +
        //       $"Appartment ='{TbRealAppartment.Text}' " +
        //       $"Where IdAddress = '{ClassFolder.TableFolder.ClassAddress.IdAddress}'");

        //    //Временная прописка
        //    classEdit.Edit("Update dbo.TemporaryRegistration " +
        //       $"Set PostcodeTemp='{TbVremPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbVremCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbVremStreet.SelectedValue.ToString())}', " +
        //       $"HouseTemp ='{TbVremHouse.Text}', " +
        //       $"EnclosureTemp ='{TbVremEnclosure.Text}', " +
        //       $"AppartmentTemp ='{TbVremAppartment.Text}' " +
        //       $"Where IdTemporaryRegistration = '{ClassFolder.TableFolder.ClassVremAddress.IdVremReg}'");

        //    //Адрес прописки
        //    classEdit.Edit("Update dbo.Registration " +
        //       $"Set PostcodeReg='{TbRegPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRegCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRegStreet.SelectedValue.ToString())}', " +
        //       $"HouseReg ='{TbRegHouse.Text}', " +
        //       $"EnclosureReg ='{TbRegEnclosure.Text}', " +
        //       $"AppartmentReg ='{TbRegAppartment.Text}' " +
        //       $"Where IdRegistration = '{ClassFolder.TableFolder.ClassRegistration.IdReg}'");
            

        //    //Опекун Ж
        //    classEdit.Edit("Update dbo.GuardianMom " +
        //       $"Set LastNameGuardianMom='{TbMomLastNameGuard.Text}', " +
        //       $"FirstNameGuardianMom='{TbMomFirstNameGuard.Text}', " +
        //       $"MiddleNameGuardianMom ='{TbMomMiddleNameGuard.Text}', " +
        //       $"NumberPhoneGuardianMom ='{TbMomNumberPhoneGuard.Text}' " +
        //       $"Where IdGuardianMom = '{ClassFolder.TableFolder.ClassParentGuard.IdMomGuradian}'");

        //    //Опекун М
        //    classEdit.Edit("Update dbo.GuardianDad " +
        //       $"Set LastNameGuardianDad='{TbDadLastNameGuard.Text}', " +
        //       $"FirstNameGuardianDad='{TbDadFirstNameGuard.Text}', " +
        //       $"MiddleNameGuardianDad ='{TbDadMiddleNameGuard.Text}', " +
        //       $"NumberPhoneGuardianDad ='{TbDadNumberPhoneGuard.Text}' " +
        //       $"Where IdGuardianDad = '{ClassFolder.TableFolder.ClassParentGuard.IdDadGuradian}'");

        //    //Паспорт
        //    classEdit.Edit("Update dbo.Passport " +
        //       $"Set LastName='{TbLastName.Text}', " +
        //       $"FirstName='{TbFirstName.Text}', " +
        //       $"MiddleName ='{TbMiddleName.Text}', " +
        //       $"Series ='{TbSeries.Text}', " +
        //       $"Number ='{TbNumber.Text}', " +
        //       $"IdIssuedByWhom ='{Int32.Parse(CbIsuedByWhom.SelectedValue.ToString())}', " +
        //       $"DateOfIssue='{DpDateOfIsue.Text}', " +
        //       $"CodeDivision ='{TbCode.Text}', " +
        //       $"IdGender ='{Int32.Parse(CbGender.SelectedValue.ToString())}', " +
        //       $"DateOfBorn ='{DpDateOfBorn.Text}', " +
        //       $"IdPlaceOfBorn ='{Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString())}' " +
        //       $"Where IdPassport = '{ClassFolder.TableFolder.ClassPassport.IdPassport}'");

        //    //Студент
        //    try
        //    {



        //        string iFile = TbImage.Text;
        //        // конвертация изображения в байты
        //        byte[] imageData = null;
        //        FileInfo fInfo = new FileInfo(iFile);
        //        long numBytes = fInfo.Length;
        //        FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
        //        BinaryReader br = new BinaryReader(fStream);
        //        imageData = br.ReadBytes((int)numBytes);
        //        //  получение расширения файла изображения не забыв удалить точку перед расширением
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
        //    }
        //    catch
        //    {

        //    }
        //    classEdit.Edit("Update dbo.Student " +
        //       $"Set SNILS='{TbSNILS.Text}', " +
        //       $"INN='{TbINN.Text}', " +
        //       $"NumberPhone ='{TbNumberPhone.Text}', " +
        //       $"IdFamily ='{Int32.Parse(CbFamily.SelectedValue.ToString())}', " +
        //       $"IdFamilyStatus ='{Int32.Parse(CbFamilyStatus.SelectedValue.ToString())}', " +
        //       $"Email ='{TbEmail.Text}', " +
        //       $"HospitalPolice='{TbHospital.Text}', " +
        //       $"IdImage='{ClassFolder.TableFolder.ClassImage.IdImage}'" +
        //       $"Where IdStudent = '{ClassFolder.TableFolder.ClassStudent.IdStudent}'");

        //    ClassFolder.ClassMB.MBInformation("Данные отректированы");
        //}

        //private void EditMomGuard()
        //{
        //    //Адрес проживания
        //    classEdit.Edit("Update dbo.Address " +
        //       $"Set  PostCode='{TbRealPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRealCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRealStreet.SelectedValue.ToString())}', " +
        //       $"House ='{TbRealHouse.Text}', " +
        //       $"Enclosure ='{TbRealEnclosure.Text}', " +
        //       $"Appartment ='{TbRealAppartment.Text}' " +
        //       $"Where IdAddress = '{ClassFolder.TableFolder.ClassAddress.IdAddress}'");

        //    //Временная прописка
        //    classEdit.Edit("Update dbo.TemporaryRegistration " +
        //       $"Set PostcodeTemp='{TbVremPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbVremCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbVremStreet.SelectedValue.ToString())}', " +
        //       $"HouseTemp ='{TbVremHouse.Text}', " +
        //       $"EnclosureTemp ='{TbVremEnclosure.Text}', " +
        //       $"AppartmentTemp ='{TbVremAppartment.Text}' " +
        //       $"Where IdTemporaryRegistration = '{ClassFolder.TableFolder.ClassVremAddress.IdVremReg}'");

        //    //Адрес прописки
        //    classEdit.Edit("Update dbo.Registration " +
        //       $"Set PostcodeReg='{TbRegPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRegCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRegStreet.SelectedValue.ToString())}', " +
        //       $"HouseReg ='{TbRegHouse.Text}', " +
        //       $"EnclosureReg ='{TbRegEnclosure.Text}', " +
        //       $"AppartmentReg ='{TbRegAppartment.Text}' " +
        //       $"Where IdRegistration = '{ClassFolder.TableFolder.ClassRegistration.IdReg}'");

           
        //    //Опекун Ж
        //    classEdit.Edit("Update dbo.GuardianMom " +
        //       $"Set LastNameGuardianMom='{TbMomLastNameGuard.Text}', " +
        //       $"FirstNameGuardianMom='{TbMomFirstNameGuard.Text}', " +
        //       $"MiddleNameGuardianMom ='{TbMomMiddleNameGuard.Text}', " +
        //       $"NumberPhoneGuardianMom ='{TbMomNumberPhoneGuard.Text}' " +
        //       $"Where IdGuardianMom = '{ClassFolder.TableFolder.ClassParentGuard.IdMomGuradian}'");
           

        //    //Паспорт
        //    classEdit.Edit("Update dbo.Passport " +
        //       $"Set LastName='{TbLastName.Text}', " +
        //       $"FirstName='{TbFirstName.Text}', " +
        //       $"MiddleName ='{TbMiddleName.Text}', " +
        //       $"Series ='{TbSeries.Text}', " +
        //       $"Number ='{TbNumber.Text}', " +
        //       $"IdIssuedByWhom ='{Int32.Parse(CbIsuedByWhom.SelectedValue.ToString())}', " +
        //       $"DateOfIssue='{DpDateOfIsue.Text}', " +
        //       $"CodeDivision ='{TbCode.Text}', " +
        //       $"IdGender ='{Int32.Parse(CbGender.SelectedValue.ToString())}', " +
        //       $"DateOfBorn ='{DpDateOfBorn.Text}', " +
        //       $"IdPlaceOfBorn ='{Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString())}' " +
        //       $"Where IdPassport = '{ClassFolder.TableFolder.ClassPassport.IdPassport}'");

        //    //Студент
        //    try
        //    {



        //        string iFile = TbImage.Text;
        //        // конвертация изображения в байты
        //        byte[] imageData = null;
        //        FileInfo fInfo = new FileInfo(iFile);
        //        long numBytes = fInfo.Length;
        //        FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
        //        BinaryReader br = new BinaryReader(fStream);
        //        imageData = br.ReadBytes((int)numBytes);
        //        //  получение расширения файла изображения не забыв удалить точку перед расширением
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
        //    }
        //    catch
        //    {

        //    }
        //    classEdit.Edit("Update dbo.Student " +
        //       $"Set SNILS='{TbSNILS.Text}', " +
        //       $"INN='{TbINN.Text}', " +
        //       $"NumberPhone ='{TbNumberPhone.Text}', " +
        //       $"IdFamily ='{Int32.Parse(CbFamily.SelectedValue.ToString())}', " +
        //       $"IdFamilyStatus ='{Int32.Parse(CbFamilyStatus.SelectedValue.ToString())}', " +
        //       $"Email ='{TbEmail.Text}', " +
        //       $"HospitalPolice='{TbHospital.Text}', " +
        //       $"IdImage='{ClassFolder.TableFolder.ClassImage.IdImage}'" +
        //       $"Where IdStudent = '{ClassFolder.TableFolder.ClassStudent.IdStudent}'");

        //    ClassFolder.ClassMB.MBInformation("Данные отректированы");
        //}

        //private void EditDadGuard()
        //{
        //    //Адрес проживания
        //    classEdit.Edit("Update dbo.Address " +
        //       $"Set  PostCode='{TbRealPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRealCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRealStreet.SelectedValue.ToString())}', " +
        //       $"House ='{TbRealHouse.Text}', " +
        //       $"Enclosure ='{TbRealEnclosure.Text}', " +
        //       $"Appartment ='{TbRealAppartment.Text}' " +
        //       $"Where IdAddress = '{ClassFolder.TableFolder.ClassAddress.IdAddress}'");

        //    //Временная прописка
        //    classEdit.Edit("Update dbo.TemporaryRegistration " +
        //       $"Set PostcodeTemp='{TbVremPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbVremCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbVremStreet.SelectedValue.ToString())}', " +
        //       $"HouseTemp ='{TbVremHouse.Text}', " +
        //       $"EnclosureTemp ='{TbVremEnclosure.Text}', " +
        //       $"AppartmentTemp ='{TbVremAppartment.Text}' " +
        //       $"Where IdTemporaryRegistration = '{ClassFolder.TableFolder.ClassVremAddress.IdVremReg}'");

        //    //Адрес прописки
        //    classEdit.Edit("Update dbo.Registration " +
        //       $"Set PostcodeReg='{TbRegPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRegCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRegStreet.SelectedValue.ToString())}', " +
        //       $"HouseReg ='{TbRegHouse.Text}', " +
        //       $"EnclosureReg ='{TbRegEnclosure.Text}', " +
        //       $"AppartmentReg ='{TbRegAppartment.Text}' " +
        //       $"Where IdRegistration = '{ClassFolder.TableFolder.ClassRegistration.IdReg}'");
           
        //    //Опекун М
        //    classEdit.Edit("Update dbo.GuardianDad " +
        //       $"Set LastNameGuardianDad='{TbDadLastNameGuard.Text}', " +
        //       $"FirstNameGuardianDad='{TbDadFirstNameGuard.Text}', " +
        //       $"MiddleNameGuardianDad ='{TbDadMiddleNameGuard.Text}', " +
        //       $"NumberPhoneGuardianDad ='{TbDadNumberPhoneGuard.Text}' " +
        //       $"Where IdGuardianDad = '{ClassFolder.TableFolder.ClassParentGuard.IdDadGuradian}'");

        //    //Паспорт
        //    classEdit.Edit("Update dbo.Passport " +
        //       $"Set LastName='{TbLastName.Text}', " +
        //       $"FirstName='{TbFirstName.Text}', " +
        //       $"MiddleName ='{TbMiddleName.Text}', " +
        //       $"Series ='{TbSeries.Text}', " +
        //       $"Number ='{TbNumber.Text}', " +
        //       $"IdIssuedByWhom ='{Int32.Parse(CbIsuedByWhom.SelectedValue.ToString())}', " +
        //       $"DateOfIssue='{DpDateOfIsue.Text}', " +
        //       $"CodeDivision ='{TbCode.Text}', " +
        //       $"IdGender ='{Int32.Parse(CbGender.SelectedValue.ToString())}', " +
        //       $"DateOfBorn ='{DpDateOfBorn.Text}', " +
        //       $"IdPlaceOfBorn ='{Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString())}' " +
        //       $"Where IdPassport = '{ClassFolder.TableFolder.ClassPassport.IdPassport}'");

        //    //Студент
        //    try
        //    {



        //        string iFile = TbImage.Text;
        //        // конвертация изображения в байты
        //        byte[] imageData = null;
        //        FileInfo fInfo = new FileInfo(iFile);
        //        long numBytes = fInfo.Length;
        //        FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
        //        BinaryReader br = new BinaryReader(fStream);
        //        imageData = br.ReadBytes((int)numBytes);
        //        //  получение расширения файла изображения не забыв удалить точку перед расширением
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
        //    }
        //    catch
        //    {

        //    }
        //    classEdit.Edit("Update dbo.Student " +
        //       $"Set SNILS='{TbSNILS.Text}', " +
        //       $"INN='{TbINN.Text}', " +
        //       $"NumberPhone ='{TbNumberPhone.Text}', " +
        //       $"IdFamily ='{Int32.Parse(CbFamily.SelectedValue.ToString())}', " +
        //       $"IdFamilyStatus ='{Int32.Parse(CbFamilyStatus.SelectedValue.ToString())}', " +
        //       $"Email ='{TbEmail.Text}', " +
        //       $"HospitalPolice='{TbHospital.Text}', " +
        //       $"IdImage='{ClassFolder.TableFolder.ClassImage.IdImage}'" +
        //       $"Where IdStudent = '{ClassFolder.TableFolder.ClassStudent.IdStudent}'");

        //    ClassFolder.ClassMB.MBInformation("Данные отректированы");
        //}

        //private void EditAllNullMomGuardDad()
        //{
        //    //Адрес проживания
        //    classEdit.Edit("Update dbo.Address " +
        //       $"Set  PostCode='{TbRealPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRealCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRealStreet.SelectedValue.ToString())}', " +
        //       $"House ='{TbRealHouse.Text}', " +
        //       $"Enclosure ='{TbRealEnclosure.Text}', " +
        //       $"Appartment ='{TbRealAppartment.Text}' " +
        //       $"Where IdAddress = '{ClassFolder.TableFolder.ClassAddress.IdAddress}'");            

        //    //Адрес прописки
        //    classEdit.Edit("Update dbo.Registration " +
        //       $"Set PostcodeReg='{TbRegPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRegCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRegStreet.SelectedValue.ToString())}', " +
        //       $"HouseReg ='{TbRegHouse.Text}', " +
        //       $"EnclosureReg ='{TbRegEnclosure.Text}', " +
        //       $"AppartmentReg ='{TbRegAppartment.Text}' " +
        //       $"Where IdRegistration = '{ClassFolder.TableFolder.ClassRegistration.IdReg}'");            

        //    //Папа
        //    classEdit.Edit("Update dbo.Dad " +
        //       $"Set LastNameDad='{TbDadLastName.Text}', " +
        //       $"FirstNameDad='{TbDadFirstName.Text}', " +
        //       $"MiddleNameDad ='{TbDadMiddleName.Text}', " +
        //       $"NumberPhoneDad ='{TbDadNumberPhone.Text}' " +
        //       $"Where IdDad = '{ClassFolder.TableFolder.ClassParents.IdDad}'");

        //    //Опекун Ж
        //    classEdit.Edit("Update dbo.GuardianMom " +
        //       $"Set LastNameGuardianMom='{TbMomLastNameGuard.Text}', " +
        //       $"FirstNameGuardianMom='{TbMomFirstNameGuard.Text}', " +
        //       $"MiddleNameGuardianMom ='{TbMomMiddleNameGuard.Text}', " +
        //       $"NumberPhoneGuardianMom ='{TbMomNumberPhoneGuard.Text}' " +
        //       $"Where IdGuardianMom = '{ClassFolder.TableFolder.ClassParentGuard.IdMomGuradian}'");            

        //    //Паспорт
        //    classEdit.Edit("Update dbo.Passport " +
        //       $"Set LastName='{TbLastName.Text}', " +
        //       $"FirstName='{TbFirstName.Text}', " +
        //       $"MiddleName ='{TbMiddleName.Text}', " +
        //       $"Series ='{TbSeries.Text}', " +
        //       $"Number ='{TbNumber.Text}', " +
        //       $"IdIssuedByWhom ='{Int32.Parse(CbIsuedByWhom.SelectedValue.ToString())}', " +
        //       $"DateOfIssue='{DpDateOfIsue.Text}', " +
        //       $"CodeDivision ='{TbCode.Text}', " +
        //       $"IdGender ='{Int32.Parse(CbGender.SelectedValue.ToString())}', " +
        //       $"DateOfBorn ='{DpDateOfBorn.Text}', " +
        //       $"IdPlaceOfBorn ='{Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString())}' " +
        //       $"Where IdPassport = '{ClassFolder.TableFolder.ClassPassport.IdPassport}'");

        //    //Студент
        //    try
        //    {



        //        string iFile = TbImage.Text;
        //        // конвертация изображения в байты
        //        byte[] imageData = null;
        //        FileInfo fInfo = new FileInfo(iFile);
        //        long numBytes = fInfo.Length;
        //        FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
        //        BinaryReader br = new BinaryReader(fStream);
        //        imageData = br.ReadBytes((int)numBytes);
        //        //  получение расширения файла изображения не забыв удалить точку перед расширением
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
        //    }
        //    catch
        //    {

        //    }
        //    classEdit.Edit("Update dbo.Student " +
        //       $"Set SNILS='{TbSNILS.Text}', " +
        //       $"INN='{TbINN.Text}', " +
        //       $"NumberPhone ='{TbNumberPhone.Text}', " +
        //       $"IdFamily ='{Int32.Parse(CbFamily.SelectedValue.ToString())}', " +
        //       $"IdFamilyStatus ='{Int32.Parse(CbFamilyStatus.SelectedValue.ToString())}', " +
        //       $"Email ='{TbEmail.Text}', " +
        //       $"HospitalPolice='{TbHospital.Text}', " +
        //       $"IdImage='{ClassFolder.TableFolder.ClassImage.IdImage}'" +
        //       $"Where IdStudent = '{ClassFolder.TableFolder.ClassStudent.IdStudent}'");

        //    ClassFolder.ClassMB.MBInformation("Данные отректированы");
        //}

        //private void EditAllNullMomDadGuard()
        //{
        //    //Адрес проживания
        //    classEdit.Edit("Update dbo.Address " +
        //       $"Set  PostCode='{TbRealPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRealCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRealStreet.SelectedValue.ToString())}', " +
        //       $"House ='{TbRealHouse.Text}', " +
        //       $"Enclosure ='{TbRealEnclosure.Text}', " +
        //       $"Appartment ='{TbRealAppartment.Text}' " +
        //       $"Where IdAddress = '{ClassFolder.TableFolder.ClassAddress.IdAddress}'");

           
        //    //Адрес прописки
        //    classEdit.Edit("Update dbo.Registration " +
        //       $"Set PostcodeReg='{TbRegPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRegCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRegStreet.SelectedValue.ToString())}', " +
        //       $"HouseReg ='{TbRegHouse.Text}', " +
        //       $"EnclosureReg ='{TbRegEnclosure.Text}', " +
        //       $"AppartmentReg ='{TbRegAppartment.Text}' " +
        //       $"Where IdRegistration = '{ClassFolder.TableFolder.ClassRegistration.IdReg}'");

        //    //Мама
        //    classEdit.Edit("Update dbo.Mom " +
        //       $"Set LastNameMom='{TbMomLastName.Text}', " +
        //       $"FirstNameMom='{TbMomFirstName.Text}', " +
        //       $"MiddleNameMom ='{TbMomMiddleName.Text}', " +
        //       $"NumberPhoneMom ='{TbMomNumberPhone.Text}' " +
        //       $"Where IdMom = '{ClassFolder.TableFolder.ClassParents.IdMom}'");

           

        //    //Опекун М
        //    classEdit.Edit("Update dbo.GuardianDad " +
        //       $"Set LastNameGuardianDad='{TbDadLastNameGuard.Text}', " +
        //       $"FirstNameGuardianDad='{TbDadFirstNameGuard.Text}', " +
        //       $"MiddleNameGuardianDad ='{TbDadMiddleNameGuard.Text}', " +
        //       $"NumberPhoneGuardianDad ='{TbDadNumberPhoneGuard.Text}' " +
        //       $"Where IdGuardianDad = '{ClassFolder.TableFolder.ClassParentGuard.IdDadGuradian}'");

        //    //Паспорт
        //    classEdit.Edit("Update dbo.Passport " +
        //       $"Set LastName='{TbLastName.Text}', " +
        //       $"FirstName='{TbFirstName.Text}', " +
        //       $"MiddleName ='{TbMiddleName.Text}', " +
        //       $"Series ='{TbSeries.Text}', " +
        //       $"Number ='{TbNumber.Text}', " +
        //       $"IdIssuedByWhom ='{Int32.Parse(CbIsuedByWhom.SelectedValue.ToString())}', " +
        //       $"DateOfIssue='{DpDateOfIsue.Text}', " +
        //       $"CodeDivision ='{TbCode.Text}', " +
        //       $"IdGender ='{Int32.Parse(CbGender.SelectedValue.ToString())}', " +
        //       $"DateOfBorn ='{DpDateOfBorn.Text}', " +
        //       $"IdPlaceOfBorn ='{Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString())}' " +
        //       $"Where IdPassport = '{ClassFolder.TableFolder.ClassPassport.IdPassport}'");

        //    //Студент
        //    try
        //    {



        //        string iFile = TbImage.Text;
        //        // конвертация изображения в байты
        //        byte[] imageData = null;
        //        FileInfo fInfo = new FileInfo(iFile);
        //        long numBytes = fInfo.Length;
        //        FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
        //        BinaryReader br = new BinaryReader(fStream);
        //        imageData = br.ReadBytes((int)numBytes);
        //        //  получение расширения файла изображения не забыв удалить точку перед расширением
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
        //    }
        //    catch
        //    {

        //    }
        //    classEdit.Edit("Update dbo.Student " +
        //       $"Set SNILS='{TbSNILS.Text}', " +
        //       $"INN='{TbINN.Text}', " +
        //       $"NumberPhone ='{TbNumberPhone.Text}', " +
        //       $"IdFamily ='{Int32.Parse(CbFamily.SelectedValue.ToString())}', " +
        //       $"IdFamilyStatus ='{Int32.Parse(CbFamilyStatus.SelectedValue.ToString())}', " +
        //       $"Email ='{TbEmail.Text}', " +
        //       $"HospitalPolice='{TbHospital.Text}', " +
        //       $"IdImage='{ClassFolder.TableFolder.ClassImage.IdImage}'" +
        //       $"Where IdStudent = '{ClassFolder.TableFolder.ClassStudent.IdStudent}'");

        //    ClassFolder.ClassMB.MBInformation("Данные отректированы");
        //}

        //public void EditAllNullMomDad()
        //{
        //    //Адрес проживания
        //    classEdit.Edit("Update dbo.Address " +
        //       $"Set  PostCode='{TbRealPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRealCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRealStreet.SelectedValue.ToString())}', " +
        //       $"House ='{TbRealHouse.Text}', " +
        //       $"Enclosure ='{TbRealEnclosure.Text}', " +
        //       $"Appartment ='{TbRealAppartment.Text}' " +
        //       $"Where IdAddress = '{ClassFolder.TableFolder.ClassAddress.IdAddress}'");

        //    //Адрес прописки
        //    classEdit.Edit("Update dbo.Registration " +
        //       $"Set PostcodeReg='{TbRegPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRegCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRegStreet.SelectedValue.ToString())}', " +
        //       $"HouseReg ='{TbRegHouse.Text}', " +
        //       $"EnclosureReg ='{TbRegEnclosure.Text}', " +
        //       $"AppartmentReg ='{TbRegAppartment.Text}' " +
        //       $"Where IdRegistration = '{ClassFolder.TableFolder.ClassRegistration.IdReg}'");

        //    //Мама
        //    classEdit.Edit("Update dbo.Mom " +
        //       $"Set LastNameMom='{TbMomLastName.Text}', " +
        //       $"FirstNameMom='{TbMomFirstName.Text}', " +
        //       $"MiddleNameMom ='{TbMomMiddleName.Text}', " +
        //       $"NumberPhoneMom ='{TbMomNumberPhone.Text}' " +
        //       $"Where IdMom = '{ClassFolder.TableFolder.ClassParents.IdMom}'");

        //    //Папа
        //    classEdit.Edit("Update dbo.Dad " +
        //       $"Set LastNameDad='{TbDadLastName.Text}', " +
        //       $"FirstNameDad='{TbDadFirstName.Text}', " +
        //       $"MiddleNameDad ='{TbDadMiddleName.Text}', " +
        //       $"NumberPhoneDad ='{TbDadNumberPhone.Text}' " +
        //       $"Where IdDad = '{ClassFolder.TableFolder.ClassParents.IdDad}'");


        //    //Паспорт
        //    classEdit.Edit("Update dbo.Passport " +
        //       $"Set LastName='{TbLastName.Text}', " +
        //       $"FirstName='{TbFirstName.Text}', " +
        //       $"MiddleName ='{TbMiddleName.Text}', " +
        //       $"Series ='{TbSeries.Text}', " +
        //       $"Number ='{TbNumber.Text}', " +
        //       $"IdIssuedByWhom ='{Int32.Parse(CbIsuedByWhom.SelectedValue.ToString())}', " +
        //       $"DateOfIssue='{DpDateOfIsue.Text}', " +
        //       $"CodeDivision ='{TbCode.Text}', " +
        //       $"IdGender ='{Int32.Parse(CbGender.SelectedValue.ToString())}', " +
        //       $"DateOfBorn ='{DpDateOfBorn.Text}', " +
        //       $"IdPlaceOfBorn ='{Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString())}' " +
        //       $"Where IdPassport = '{ClassFolder.TableFolder.ClassPassport.IdPassport}'");

        //    //Студент
        //    try
        //    {



        //        string iFile = TbImage.Text;
        //        // конвертация изображения в байты
        //        byte[] imageData = null;
        //        FileInfo fInfo = new FileInfo(iFile);
        //        long numBytes = fInfo.Length;
        //        FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
        //        BinaryReader br = new BinaryReader(fStream);
        //        imageData = br.ReadBytes((int)numBytes);
        //        //  получение расширения файла изображения не забыв удалить точку перед расширением
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
        //    }
        //    catch
        //    {

        //    }
        //    classEdit.Edit("Update dbo.Student " +
        //       $"Set SNILS='{TbSNILS.Text}', " +
        //       $"INN='{TbINN.Text}', " +
        //       $"NumberPhone ='{TbNumberPhone.Text}', " +
        //       $"IdFamily ='{Int32.Parse(CbFamily.SelectedValue.ToString())}', " +
        //       $"IdFamilyStatus ='{Int32.Parse(CbFamilyStatus.SelectedValue.ToString())}', " +
        //       $"Email ='{TbEmail.Text}', " +
        //       $"HospitalPolice='{TbHospital.Text}', " +
        //       $"IdImage='{ClassFolder.TableFolder.ClassImage.IdImage}'" +
        //       $"Where IdStudent = '{ClassFolder.TableFolder.ClassStudent.IdStudent}'");

        //    ClassFolder.ClassMB.MBInformation("Данные отректированы");


        //}
        //public void EditAllNullAddDadGuard()
        //{
        //    //Адрес проживания
        //    classEdit.Edit("Update dbo.Address " +
        //       $"Set  PostCode='{TbRealPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRealCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRealStreet.SelectedValue.ToString())}', " +
        //       $"House ='{TbRealHouse.Text}', " +
        //       $"Enclosure ='{TbRealEnclosure.Text}', " +
        //       $"Appartment ='{TbRealAppartment.Text}' " +
        //       $"Where IdAddress = '{ClassFolder.TableFolder.ClassAddress.IdAddress}'");
            

        //    //Адрес прописки
        //    classEdit.Edit("Update dbo.Registration " +
        //       $"Set PostcodeReg='{TbRegPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRegCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRegStreet.SelectedValue.ToString())}', " +
        //       $"HouseReg ='{TbRegHouse.Text}', " +
        //       $"EnclosureReg ='{TbRegEnclosure.Text}', " +
        //       $"AppartmentReg ='{TbRegAppartment.Text}' " +
        //       $"Where IdRegistration = '{ClassFolder.TableFolder.ClassRegistration.IdReg}'");            

        //    //Опекун М
        //    classEdit.Edit("Update dbo.GuardianDad " +
        //       $"Set LastNameGuardianDad='{TbDadLastNameGuard.Text}', " +
        //       $"FirstNameGuardianDad='{TbDadFirstNameGuard.Text}', " +
        //       $"MiddleNameGuardianDad ='{TbDadMiddleNameGuard.Text}', " +
        //       $"NumberPhoneGuardianDad ='{TbDadNumberPhoneGuard.Text}' " +
        //       $"Where IdGuardianDad = '{ClassFolder.TableFolder.ClassParentGuard.IdDadGuradian}'");

        //    //Паспорт
        //    classEdit.Edit("Update dbo.Passport " +
        //       $"Set LastName='{TbLastName.Text}', " +
        //       $"FirstName='{TbFirstName.Text}', " +
        //       $"MiddleName ='{TbMiddleName.Text}', " +
        //       $"Series ='{TbSeries.Text}', " +
        //       $"Number ='{TbNumber.Text}', " +
        //       $"IdIssuedByWhom ='{Int32.Parse(CbIsuedByWhom.SelectedValue.ToString())}', " +
        //       $"DateOfIssue='{DpDateOfIsue.Text}', " +
        //       $"CodeDivision ='{TbCode.Text}', " +
        //       $"IdGender ='{Int32.Parse(CbGender.SelectedValue.ToString())}', " +
        //       $"DateOfBorn ='{DpDateOfBorn.Text}', " +
        //       $"IdPlaceOfBorn ='{Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString())}' " +
        //       $"Where IdPassport = '{ClassFolder.TableFolder.ClassPassport.IdPassport}'");

        //    //Студент
        //    try
        //    {



        //        string iFile = TbImage.Text;
        //        // конвертация изображения в байты
        //        byte[] imageData = null;
        //        FileInfo fInfo = new FileInfo(iFile);
        //        long numBytes = fInfo.Length;
        //        FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
        //        BinaryReader br = new BinaryReader(fStream);
        //        imageData = br.ReadBytes((int)numBytes);
        //        //  получение расширения файла изображения не забыв удалить точку перед расширением
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
        //    }
        //    catch
        //    {

        //    }
        //    classEdit.Edit("Update dbo.Student " +
        //       $"Set SNILS='{TbSNILS.Text}', " +
        //       $"INN='{TbINN.Text}', " +
        //       $"NumberPhone ='{TbNumberPhone.Text}', " +
        //       $"IdFamily ='{Int32.Parse(CbFamily.SelectedValue.ToString())}', " +
        //       $"IdFamilyStatus ='{Int32.Parse(CbFamilyStatus.SelectedValue.ToString())}', " +
        //       $"Email ='{TbEmail.Text}', " +
        //       $"HospitalPolice='{TbHospital.Text}', " +
        //       $"IdImage='{ClassFolder.TableFolder.ClassImage.IdImage}'" +
        //       $"Where IdStudent = '{ClassFolder.TableFolder.ClassStudent.IdStudent}'");

        //    ClassFolder.ClassMB.MBInformation("Данные отректированы");
        //}
        //public void EditAllNullAddMomGuard()
        //{
        //    //Адрес проживания
        //    classEdit.Edit("Update dbo.Address " +
        //       $"Set  PostCode='{TbRealPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRealCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRealStreet.SelectedValue.ToString())}', " +
        //       $"House ='{TbRealHouse.Text}', " +
        //       $"Enclosure ='{TbRealEnclosure.Text}', " +
        //       $"Appartment ='{TbRealAppartment.Text}' " +
        //       $"Where IdAddress = '{ClassFolder.TableFolder.ClassAddress.IdAddress}'");
            

        //    //Адрес прописки
        //    classEdit.Edit("Update dbo.Registration " +
        //       $"Set PostcodeReg='{TbRegPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRegCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRegStreet.SelectedValue.ToString())}', " +
        //       $"HouseReg ='{TbRegHouse.Text}', " +
        //       $"EnclosureReg ='{TbRegEnclosure.Text}', " +
        //       $"AppartmentReg ='{TbRegAppartment.Text}' " +
        //       $"Where IdRegistration = '{ClassFolder.TableFolder.ClassRegistration.IdReg}'");            

        //    //Опекун Ж
        //    classEdit.Edit("Update dbo.GuardianMom " +
        //       $"Set LastNameGuardianMom='{TbMomLastNameGuard.Text}', " +
        //       $"FirstNameGuardianMom='{TbMomFirstNameGuard.Text}', " +
        //       $"MiddleNameGuardianMom ='{TbMomMiddleNameGuard.Text}', " +
        //       $"NumberPhoneGuardianMom ='{TbMomNumberPhoneGuard.Text}' " +
        //       $"Where IdGuardianMom = '{ClassFolder.TableFolder.ClassParentGuard.IdMomGuradian}'");            

        //    //Паспорт
        //    classEdit.Edit("Update dbo.Passport " +
        //       $"Set LastName='{TbLastName.Text}', " +
        //       $"FirstName='{TbFirstName.Text}', " +
        //       $"MiddleName ='{TbMiddleName.Text}', " +
        //       $"Series ='{TbSeries.Text}', " +
        //       $"Number ='{TbNumber.Text}', " +
        //       $"IdIssuedByWhom ='{Int32.Parse(CbIsuedByWhom.SelectedValue.ToString())}', " +
        //       $"DateOfIssue='{DpDateOfIsue.Text}', " +
        //       $"CodeDivision ='{TbCode.Text}', " +
        //       $"IdGender ='{Int32.Parse(CbGender.SelectedValue.ToString())}', " +
        //       $"DateOfBorn ='{DpDateOfBorn.Text}', " +
        //       $"IdPlaceOfBorn ='{Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString())}' " +
        //       $"Where IdPassport = '{ClassFolder.TableFolder.ClassPassport.IdPassport}'");

        //    //Студент
        //    try
        //    {



        //        string iFile = TbImage.Text;
        //        // конвертация изображения в байты
        //        byte[] imageData = null;
        //        FileInfo fInfo = new FileInfo(iFile);
        //        long numBytes = fInfo.Length;
        //        FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
        //        BinaryReader br = new BinaryReader(fStream);
        //        imageData = br.ReadBytes((int)numBytes);
        //        //  получение расширения файла изображения не забыв удалить точку перед расширением
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
        //    }
        //    catch
        //    {

        //    }
        //    classEdit.Edit("Update dbo.Student " +
        //       $"Set SNILS='{TbSNILS.Text}', " +
        //       $"INN='{TbINN.Text}', " +
        //       $"NumberPhone ='{TbNumberPhone.Text}', " +
        //       $"IdFamily ='{Int32.Parse(CbFamily.SelectedValue.ToString())}', " +
        //       $"IdFamilyStatus ='{Int32.Parse(CbFamilyStatus.SelectedValue.ToString())}', " +
        //       $"Email ='{TbEmail.Text}', " +
        //       $"HospitalPolice='{TbHospital.Text}', " +
        //       $"IdImage='{ClassFolder.TableFolder.ClassImage.IdImage}'" +
        //       $"Where IdStudent = '{ClassFolder.TableFolder.ClassStudent.IdStudent}'");

        //    ClassFolder.ClassMB.MBInformation("Данные отректированы");
        //}
        //public void EditAllNullMomGuardDadGuard()
        //{
        //    //Адрес проживания
        //    classEdit.Edit("Update dbo.Address " +
        //       $"Set  PostCode='{TbRealPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRealCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRealStreet.SelectedValue.ToString())}', " +
        //       $"House ='{TbRealHouse.Text}', " +
        //       $"Enclosure ='{TbRealEnclosure.Text}', " +
        //       $"Appartment ='{TbRealAppartment.Text}' " +
        //       $"Where IdAddress = '{ClassFolder.TableFolder.ClassAddress.IdAddress}'");
            

        //    //Адрес прописки
        //    classEdit.Edit("Update dbo.Registration " +
        //       $"Set PostcodeReg='{TbRegPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRegCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRegStreet.SelectedValue.ToString())}', " +
        //       $"HouseReg ='{TbRegHouse.Text}', " +
        //       $"EnclosureReg ='{TbRegEnclosure.Text}', " +
        //       $"AppartmentReg ='{TbRegAppartment.Text}' " +
        //       $"Where IdRegistration = '{ClassFolder.TableFolder.ClassRegistration.IdReg}'");
            

        //    //Опекун Ж
        //    classEdit.Edit("Update dbo.GuardianMom " +
        //       $"Set LastNameGuardianMom='{TbMomLastNameGuard.Text}', " +
        //       $"FirstNameGuardianMom='{TbMomFirstNameGuard.Text}', " +
        //       $"MiddleNameGuardianMom ='{TbMomMiddleNameGuard.Text}', " +
        //       $"NumberPhoneGuardianMom ='{TbMomNumberPhoneGuard.Text}' " +
        //       $"Where IdGuardianMom = '{ClassFolder.TableFolder.ClassParentGuard.IdMomGuradian}'");

        //    //Опекун М
        //    classEdit.Edit("Update dbo.GuardianDad " +
        //       $"Set LastNameGuardianDad='{TbDadLastNameGuard.Text}', " +
        //       $"FirstNameGuardianDad='{TbDadFirstNameGuard.Text}', " +
        //       $"MiddleNameGuardianDad ='{TbDadMiddleNameGuard.Text}', " +
        //       $"NumberPhoneGuardianDad ='{TbDadNumberPhoneGuard.Text}' " +
        //       $"Where IdGuardianDad = '{ClassFolder.TableFolder.ClassParentGuard.IdDadGuradian}'");

        //    //Паспорт
        //    classEdit.Edit("Update dbo.Passport " +
        //       $"Set LastName='{TbLastName.Text}', " +
        //       $"FirstName='{TbFirstName.Text}', " +
        //       $"MiddleName ='{TbMiddleName.Text}', " +
        //       $"Series ='{TbSeries.Text}', " +
        //       $"Number ='{TbNumber.Text}', " +
        //       $"IdIssuedByWhom ='{Int32.Parse(CbIsuedByWhom.SelectedValue.ToString())}', " +
        //       $"DateOfIssue='{DpDateOfIsue.Text}', " +
        //       $"CodeDivision ='{TbCode.Text}', " +
        //       $"IdGender ='{Int32.Parse(CbGender.SelectedValue.ToString())}', " +
        //       $"DateOfBorn ='{DpDateOfBorn.Text}', " +
        //       $"IdPlaceOfBorn ='{Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString())}' " +
        //       $"Where IdPassport = '{ClassFolder.TableFolder.ClassPassport.IdPassport}'");

        //    //Студент
        //    try
        //    {



        //        string iFile = TbImage.Text;
        //        // конвертация изображения в байты
        //        byte[] imageData = null;
        //        FileInfo fInfo = new FileInfo(iFile);
        //        long numBytes = fInfo.Length;
        //        FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
        //        BinaryReader br = new BinaryReader(fStream);
        //        imageData = br.ReadBytes((int)numBytes);
        //        //  получение расширения файла изображения не забыв удалить точку перед расширением
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
        //    }
        //    catch
        //    {

        //    }
        //    classEdit.Edit("Update dbo.Student " +
        //       $"Set SNILS='{TbSNILS.Text}', " +
        //       $"INN='{TbINN.Text}', " +
        //       $"NumberPhone ='{TbNumberPhone.Text}', " +
        //       $"IdFamily ='{Int32.Parse(CbFamily.SelectedValue.ToString())}', " +
        //       $"IdFamilyStatus ='{Int32.Parse(CbFamilyStatus.SelectedValue.ToString())}', " +
        //       $"Email ='{TbEmail.Text}', " +
        //       $"HospitalPolice='{TbHospital.Text}', " +
        //       $"IdImage='{ClassFolder.TableFolder.ClassImage.IdImage}'" +
        //       $"Where IdStudent = '{ClassFolder.TableFolder.ClassStudent.IdStudent}'");

        //    ClassFolder.ClassMB.MBInformation("Данные отректированы");
        //}
        //public void EditAllNullAddMom()
        //{
        //    //Адрес проживания
        //    classEdit.Edit("Update dbo.Address " +
        //       $"Set  PostCode='{TbRealPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRealCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRealStreet.SelectedValue.ToString())}', " +
        //       $"House ='{TbRealHouse.Text}', " +
        //       $"Enclosure ='{TbRealEnclosure.Text}', " +
        //       $"Appartment ='{TbRealAppartment.Text}' " +
        //       $"Where IdAddress = '{ClassFolder.TableFolder.ClassAddress.IdAddress}'");
           

        //    //Адрес прописки
        //    classEdit.Edit("Update dbo.Registration " +
        //       $"Set PostcodeReg='{TbRegPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRegCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRegStreet.SelectedValue.ToString())}', " +
        //       $"HouseReg ='{TbRegHouse.Text}', " +
        //       $"EnclosureReg ='{TbRegEnclosure.Text}', " +
        //       $"AppartmentReg ='{TbRegAppartment.Text}' " +
        //       $"Where IdRegistration = '{ClassFolder.TableFolder.ClassRegistration.IdReg}'");

        //    //Мама
        //    classEdit.Edit("Update dbo.Mom " +
        //       $"Set LastNameMom='{TbMomLastName.Text}', " +
        //       $"FirstNameMom='{TbMomFirstName.Text}', " +
        //       $"MiddleNameMom ='{TbMomMiddleName.Text}', " +
        //       $"NumberPhoneMom ='{TbMomNumberPhone.Text}' " +
        //       $"Where IdMom = '{ClassFolder.TableFolder.ClassParents.IdMom}'");
            

        //    //Паспорт
        //    classEdit.Edit("Update dbo.Passport " +
        //       $"Set LastName='{TbLastName.Text}', " +
        //       $"FirstName='{TbFirstName.Text}', " +
        //       $"MiddleName ='{TbMiddleName.Text}', " +
        //       $"Series ='{TbSeries.Text}', " +
        //       $"Number ='{TbNumber.Text}', " +
        //       $"IdIssuedByWhom ='{Int32.Parse(CbIsuedByWhom.SelectedValue.ToString())}', " +
        //       $"DateOfIssue='{DpDateOfIsue.Text}', " +
        //       $"CodeDivision ='{TbCode.Text}', " +
        //       $"IdGender ='{Int32.Parse(CbGender.SelectedValue.ToString())}', " +
        //       $"DateOfBorn ='{DpDateOfBorn.Text}', " +
        //       $"IdPlaceOfBorn ='{Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString())}' " +
        //       $"Where IdPassport = '{ClassFolder.TableFolder.ClassPassport.IdPassport}'");

        //    //Студент
        //    try
        //    {



        //        string iFile = TbImage.Text;
        //        // конвертация изображения в байты
        //        byte[] imageData = null;
        //        FileInfo fInfo = new FileInfo(iFile);
        //        long numBytes = fInfo.Length;
        //        FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
        //        BinaryReader br = new BinaryReader(fStream);
        //        imageData = br.ReadBytes((int)numBytes);
        //        //  получение расширения файла изображения не забыв удалить точку перед расширением
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
        //    }
        //    catch
        //    {

        //    }
        //    classEdit.Edit("Update dbo.Student " +
        //       $"Set SNILS='{TbSNILS.Text}', " +
        //       $"INN='{TbINN.Text}', " +
        //       $"NumberPhone ='{TbNumberPhone.Text}', " +
        //       $"IdFamily ='{Int32.Parse(CbFamily.SelectedValue.ToString())}', " +
        //       $"IdFamilyStatus ='{Int32.Parse(CbFamilyStatus.SelectedValue.ToString())}', " +
        //       $"Email ='{TbEmail.Text}', " +
        //       $"HospitalPolice='{TbHospital.Text}', " +
        //       $"IdImage='{ClassFolder.TableFolder.ClassImage.IdImage}'" +
        //       $"Where IdStudent = '{ClassFolder.TableFolder.ClassStudent.IdStudent}'");

        //    ClassFolder.ClassMB.MBInformation("Данные отректированы");
        //}
        //public void EditAllNullAddDad()
        //{
        //    //Адрес проживания
        //    classEdit.Edit("Update dbo.Address " +
        //       $"Set  PostCode='{TbRealPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRealCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRealStreet.SelectedValue.ToString())}', " +
        //       $"House ='{TbRealHouse.Text}', " +
        //       $"Enclosure ='{TbRealEnclosure.Text}', " +
        //       $"Appartment ='{TbRealAppartment.Text}' " +
        //       $"Where IdAddress = '{ClassFolder.TableFolder.ClassAddress.IdAddress}'");

        //    //Временная прописка
        //    classEdit.Edit("Update dbo.TemporaryRegistration " +
        //       $"Set PostcodeTemp='{TbVremPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbVremCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbVremStreet.SelectedValue.ToString())}', " +
        //       $"HouseTemp ='{TbVremHouse.Text}', " +
        //       $"EnclosureTemp ='{TbVremEnclosure.Text}', " +
        //       $"AppartmentTemp ='{TbVremAppartment.Text}' " +
        //       $"Where IdTemporaryRegistration = '{ClassFolder.TableFolder.ClassVremAddress.IdVremReg}'");

        //    //Адрес прописки
        //    classEdit.Edit("Update dbo.Registration " +
        //       $"Set PostcodeReg='{TbRegPostcode.Text}', " +
        //       $"IdCity='{Int32.Parse(CbRegCity.SelectedValue.ToString())}', " +
        //       $"IdStreet ='{Int32.Parse(CbRegStreet.SelectedValue.ToString())}', " +
        //       $"HouseReg ='{TbRegHouse.Text}', " +
        //       $"EnclosureReg ='{TbRegEnclosure.Text}', " +
        //       $"AppartmentReg ='{TbRegAppartment.Text}' " +
        //       $"Where IdRegistration = '{ClassFolder.TableFolder.ClassRegistration.IdReg}'");


        //    //Папа
        //    classEdit.Edit("Update dbo.Dad " +
        //       $"Set LastNameDad='{TbDadLastName.Text}', " +
        //       $"FirstNameDad='{TbDadFirstName.Text}', " +
        //       $"MiddleNameDad ='{TbDadMiddleName.Text}', " +
        //       $"NumberPhoneDad ='{TbDadNumberPhone.Text}' " +
        //       $"Where IdDad = '{ClassFolder.TableFolder.ClassParents.IdDad}'");

            
        //    //Паспорт
        //    classEdit.Edit("Update dbo.Passport " +
        //       $"Set LastName='{TbLastName.Text}', " +
        //       $"FirstName='{TbFirstName.Text}', " +
        //       $"MiddleName ='{TbMiddleName.Text}', " +
        //       $"Series ='{TbSeries.Text}', " +
        //       $"Number ='{TbNumber.Text}', " +
        //       $"IdIssuedByWhom ='{Int32.Parse(CbIsuedByWhom.SelectedValue.ToString())}', " +
        //       $"DateOfIssue='{DpDateOfIsue.Text}', " +
        //       $"CodeDivision ='{TbCode.Text}', " +
        //       $"IdGender ='{Int32.Parse(CbGender.SelectedValue.ToString())}', " +
        //       $"DateOfBorn ='{DpDateOfBorn.Text}', " +
        //       $"IdPlaceOfBorn ='{Int32.Parse(CbPlaceOfBorn.SelectedValue.ToString())}' " +
        //       $"Where IdPassport = '{ClassFolder.TableFolder.ClassPassport.IdPassport}'");

        //    //Студент
        //    try
        //    {



        //        string iFile = TbImage.Text;
        //        // конвертация изображения в байты
        //        byte[] imageData = null;
        //        FileInfo fInfo = new FileInfo(iFile);
        //        long numBytes = fInfo.Length;
        //        FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
        //        BinaryReader br = new BinaryReader(fStream);
        //        imageData = br.ReadBytes((int)numBytes);
        //        //  получение расширения файла изображения не забыв удалить точку перед расширением
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
        //    }
        //    catch
        //    {

        //    }
        //    classEdit.Edit("Update dbo.Student " +
        //       $"Set SNILS='{TbSNILS.Text}', " +
        //       $"INN='{TbINN.Text}', " +
        //       $"NumberPhone ='{TbNumberPhone.Text}', " +
        //       $"IdFamily ='{Int32.Parse(CbFamily.SelectedValue.ToString())}', " +
        //       $"IdFamilyStatus ='{Int32.Parse(CbFamilyStatus.SelectedValue.ToString())}', " +
        //       $"Email ='{TbEmail.Text}', " +
        //       $"HospitalPolice='{TbHospital.Text}', " +
        //       $"IdImage='{ClassFolder.TableFolder.ClassImage.IdImage}'" +
        //       $"Where IdStudent = '{ClassFolder.TableFolder.ClassStudent.IdStudent}'");

        //    ClassFolder.ClassMB.MBInformation("Данные отректированы");
        //}



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
        private void CbFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
