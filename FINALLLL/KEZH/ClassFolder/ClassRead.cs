using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KEZH.ClassFolder
{
    class ClassRead
    {
        SqlConnection sqlConnection =
            new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;


        public void ReadDiscipline1(ComboBox cbDiscipline)
        {
            try
            {
                string[] Discipline = cbDiscipline.SelectedValue.ToString().Split
                    (new char[] { '_' });
                string NameDiscipline = Discipline[1];
                string Cypher = Discipline[0];


                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select IdDiscipline from dbo.Discipline " +
                    $"where Cypher='{Cypher}' and NameDiscipline='{NameDiscipline}' and IdSemestr='1'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassDiscipline.IdDiscipline = Int32.Parse(dataReader[0].ToString());

            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadDiscipline2(ComboBox cbDiscipline)
        {
            try
            {
                string[] Discipline = cbDiscipline.SelectedValue.ToString().Split
                    (new char[] { '_' });
                string NameDiscipline = Discipline[1];
                string Cypher = Discipline[0];


                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select IdDiscipline from dbo.Discipline " +
                    $"where Cypher='{Cypher}' and NameDiscipline='{NameDiscipline}' and IdSemestr='2'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassDiscipline.IdDiscipline = Int32.Parse(dataReader[0].ToString());

            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadDisciplineT1(ComboBox cbDiscipline)
        {
            try
            {
                string[] Discipline = cbDiscipline.SelectedValue.ToString().Split
                    (new char[] { '_' });
                string NameDiscipline = Discipline[1];
                string Cypher = Discipline[0];


                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select IdDisciplineT from dbo.DiscipplineToTimeTable " +
                    $"where Cypher='{Cypher}' and NameDiscipline='{NameDiscipline}' and IdSemestr='1'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassDiscipline.IdDiscipline = Int32.Parse(dataReader[0].ToString());

            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadDisciplineT2(ComboBox cbDiscipline)
        {
            try
            {
                string[] Discipline = cbDiscipline.SelectedValue.ToString().Split
                    (new char[] { '_' });
                string NameDiscipline = Discipline[1];
                string Cypher = Discipline[0];


                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select IdDisciplineT from dbo.DiscipplineToTimeTable " +
                    $"where Cypher='{Cypher}' and NameDiscipline='{NameDiscipline}' and IdSemestr='2'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassDiscipline.IdDiscipline = Int32.Parse(dataReader[0].ToString());

            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadDiscipline3(ComboBox cbDiscipline)
        {
            try
            {
                string[] Discipline = cbDiscipline.SelectedValue.ToString().Split
                    (new char[] { '_' });
                string NameDiscipline = Discipline[1];
                string Cypher = Discipline[0];


                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select IdDiscipline from dbo.Discipline " +
                    $"where Cypher='{Cypher}' and NameDiscipline='{NameDiscipline}' and IdSemestr='3'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassDiscipline.IdDiscipline = Int32.Parse(dataReader[0].ToString());

            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadDiscipline4(ComboBox cbDiscipline)
        {
            try
            {
                string[] Discipline = cbDiscipline.SelectedValue.ToString().Split
                    (new char[] { '_' });
                string NameDiscipline = Discipline[1];
                string Cypher = Discipline[0];


                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select IdDiscipline from dbo.Discipline " +
                    $"where Cypher='{Cypher}' and NameDiscipline='{NameDiscipline}' and IdSemestr='4'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassDiscipline.IdDiscipline = Int32.Parse(dataReader[0].ToString());

            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadDiscipline5(ComboBox cbDiscipline)
        {
            try
            {
                string[] Discipline = cbDiscipline.SelectedValue.ToString().Split
                    (new char[] { '_' });
                string NameDiscipline = Discipline[1];
                string Cypher = Discipline[0];


                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select IdDiscipline from dbo.Discipline " +
                    $"where Cypher='{Cypher}' and NameDiscipline='{NameDiscipline}' and IdSemestr='5'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassDiscipline.IdDiscipline = Int32.Parse(dataReader[0].ToString());

            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadDiscipline6(ComboBox cbDiscipline)
        {
            try
            {
                string[] Discipline = cbDiscipline.SelectedValue.ToString().Split
                    (new char[] { '_' });
                string NameDiscipline = Discipline[1];
                string Cypher = Discipline[0];


                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select IdDiscipline from dbo.Discipline " +
                    $"where Cypher='{Cypher}' and NameDiscipline='{NameDiscipline}' and IdSemestr='6'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassDiscipline.IdDiscipline = Int32.Parse(dataReader[0].ToString());

            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadDiscipline7(ComboBox cbDiscipline)
        {
            try
            {
                string[] Discipline = cbDiscipline.SelectedValue.ToString().Split
                    (new char[] { '_' });
                string NameDiscipline = Discipline[1];
                string Cypher = Discipline[0];


                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select IdDiscipline from dbo.Discipline " +
                    $"where Cypher='{Cypher}' and NameDiscipline='{NameDiscipline}' and IdSemestr='7'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassDiscipline.IdDiscipline = Int32.Parse(dataReader[0].ToString());

            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadDiscipline8(ComboBox cbDiscipline)
        {
            try
            {
                string[] Discipline = cbDiscipline.SelectedValue.ToString().Split
                    (new char[] { '_' });
                string NameDiscipline = Discipline[1];
                string Cypher = Discipline[0];


                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select IdDiscipline from dbo.Discipline " +
                    $"where Cypher='{Cypher}' and NameDiscipline='{NameDiscipline}' and IdSemestr='8'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassDiscipline.IdDiscipline = Int32.Parse(dataReader[0].ToString());

            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void RedDisciplineTimeTable(int idTemiTable)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("Select IdDisciplineT, NumberSemester from dbo.ViewTimeTable " +
                    $"where IdTimeTable='{TableFolder.ClassTimeTable.IdTimeTable}'", sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();

                TableFolder.ClassDiscipline.IdDiscipline = Int32.Parse(dataReader[0].ToString());
                TableFolder.ClassSemestr.IdSemestr = Int32.Parse(dataReader[1].ToString());
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void ReadStudentToFinalMark(TextBlock lblFIO,
            Label lblGroup)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("Select * from dbo.ViewFinalMark " +
                    $"where IdStudent='{TableFolder.ClassStudent.IdStudent}' and " +
                    $"IdGroup='{TableFolder.ClassUser.IdGroup}'", sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                lblFIO.Text = dataReader[5].ToString();
                lblGroup.Content = dataReader[6].ToString();


                TableFolder.ClassImage.IdImage = Int32.Parse(dataReader[9].ToString());

            }
            catch
            {

            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadMiddleMarkSem1(Label lblFinallMark)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("declare @MiddleMark decimal(10,2);" +
                    "set @MiddleMark = (select AVG(NumberMark) from dbo.ViewFinalMark " +
                    $"where IdStudent = '{TableFolder.ClassStudent.IdStudent}' and " +
                    $"IdGroup='{TableFolder.ClassUser.IdGroup}' and IdSemestr='1')" +

                    "select @MiddleMark ", sqlConnection);

                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                lblFinallMark.Content = dataReader[0].ToString();
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadMiddleMarkSem2(Label lblFinallMark)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("declare @MiddleMark decimal(10,2);" +
                    "set @MiddleMark = (select AVG(NumberMark) from dbo.ViewFinalMark " +
                    $"where IdStudent = '{TableFolder.ClassStudent.IdStudent}' and " +
                    $"IdGroup='{TableFolder.ClassUser.IdGroup}' and IdSemestr='2')" +

                    "select @MiddleMark ", sqlConnection);

                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                lblFinallMark.Content = dataReader[0].ToString();
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadMiddleMarkSem3(Label lblFinallMark)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("declare @MiddleMark decimal(10,2);" +
                    "set @MiddleMark = (select AVG(NumberMark) from dbo.ViewFinalMark " +
                    $"where IdStudent = '{TableFolder.ClassStudent.IdStudent}' and " +
                    $"IdGroup='{TableFolder.ClassUser.IdGroup}' and IdSemestr='3')" +

                    "select @MiddleMark ", sqlConnection);

                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                lblFinallMark.Content = dataReader[0].ToString();
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadMiddleMarkSem4(Label lblFinallMark)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("declare @MiddleMark decimal(10,2);" +
                    "set @MiddleMark = (select AVG(NumberMark) from dbo.ViewFinalMark " +
                    $"where IdStudent = '{TableFolder.ClassStudent.IdStudent}' and " +
                    $"IdGroup='{TableFolder.ClassUser.IdGroup}' and IdSemestr='4')" +

                    "select @MiddleMark ", sqlConnection);

                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                lblFinallMark.Content = dataReader[0].ToString();
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadMiddleMarkSem5(Label lblFinallMark)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("declare @MiddleMark decimal(10,2);" +
                    "set @MiddleMark = (select AVG(NumberMark) from dbo.ViewFinalMark " +
                    $"where IdStudent = '{TableFolder.ClassStudent.IdStudent}' and " +
                    $"IdGroup='{TableFolder.ClassUser.IdGroup}' and IdSemestr='5')" +

                    "select @MiddleMark ", sqlConnection);

                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                lblFinallMark.Content = dataReader[0].ToString();
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadMiddleMarkSem6(Label lblFinallMark)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("declare @MiddleMark decimal(10,2);" +
                    "set @MiddleMark = (select AVG(NumberMark) from dbo.ViewFinalMark " +
                    $"where IdStudent = '{TableFolder.ClassStudent.IdStudent}' and " +
                    $"IdGroup='{TableFolder.ClassUser.IdGroup}' and IdSemestr='6')" +

                    "select @MiddleMark ", sqlConnection);

                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                lblFinallMark.Content = dataReader[0].ToString();
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadMiddleMarkSem7(Label lblFinallMark)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("declare @MiddleMark decimal(10,2);" +
                    "set @MiddleMark = (select AVG(NumberMark) from dbo.ViewFinalMark " +
                    $"where IdStudent = '{TableFolder.ClassStudent.IdStudent}' and " +
                    $"IdGroup='{TableFolder.ClassUser.IdGroup}' and IdSemestr='7')" +

                    "select @MiddleMark ", sqlConnection);

                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                lblFinallMark.Content = dataReader[0].ToString();
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadMiddleMarkSem8(Label lblFinallMark)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("declare @MiddleMark decimal(10,2);" +
                    "set @MiddleMark = (select AVG(NumberMark) from dbo.ViewFinalMark " +
                    $"where IdStudent = '{TableFolder.ClassStudent.IdStudent}' and " +
                    $"IdGroup='{TableFolder.ClassUser.IdGroup}' and IdSemestr='8')" +

                    "select @MiddleMark ", sqlConnection);

                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                lblFinallMark.Content = dataReader[0].ToString();
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void ReadRegistration(ComboBox cbRegCity, ComboBox cbRegStreet,
            TextBox tbRegPostcode, TextBox tbRegHouse, TextBox tbRegenclosure,
            TextBox tbRegApartment)
        {
            try
            {
                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select IdRegistration from dbo.Registration " +
                    $"where PostcodeReg='{Int32.Parse(tbRegPostcode.Text)}' and " +
                    $"IdCity='{Int32.Parse(cbRegCity.SelectedValue.ToString())}' and " +
                    $"IdStreet='{Int32.Parse(cbRegStreet.SelectedValue.ToString())}' and " +
                    $"HouseReg='{tbRegHouse.Text}' and " +
                    $"EnclosureReg='{tbRegenclosure.Text}' and " +
                    $"AppartmentReg='{Int32.Parse(tbRegApartment.Text)}'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                TableFolder.ClassRegistration.IdReg = Int32.Parse(dataReader[0].ToString());
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadPassport(TextBox tbLastName, TextBox tbFirstName, TextBox tbMiddleName,
            TextBox tbSeries, TextBox tbNumber, ComboBox cbIsuedByWhom, DatePicker dpDateOfIssue,
            TextBox tbCode, ComboBox cbGender, DatePicker dpDateOfBorn, ComboBox cbPlaceOfBorn)
        {
            try
            {
                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select IdPassport from dbo.Passport " +
                    $"where LastName='{tbLastName.Text}' and " +
                    $"FirstName='{tbFirstName.Text}' and " +
                    $"MiddleName='{tbMiddleName.Text}' and " +
                    $"Series='{Int32.Parse(tbSeries.Text)}' and " +
                    $"Number='{Int32.Parse(tbNumber.Text)}' and " +
                    $"IdIssuedByWhom='{Int32.Parse(cbIsuedByWhom.SelectedValue.ToString())}' and " +
                    $"DateOfIssue='{dpDateOfIssue.SelectedDate.GetValueOrDefault()}' and " +
                    $"CodeDivision='{tbCode.Text}' and " +
                    $"IdGender='{Int32.Parse(cbGender.SelectedValue.ToString())}' and " +
                    $"DateOfBorn='{dpDateOfBorn.SelectedDate.GetValueOrDefault()}' and " +
                    $"IdPlaceOfBorn='{cbPlaceOfBorn.SelectedValue.ToString()}'", sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                TableFolder.ClassPassport.IdPassport = Int32.Parse(dataReader[0].ToString());
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }

        }
        public void ReadAddress(ComboBox cbRealCity, ComboBox cbRealStreet,
           TextBox tbRealPostcode, TextBox tbRealHouse, TextBox tbRealenclosure,
           TextBox tbRealApartment)
        {
            try
            {
                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select IdAddress from dbo.Address " +
                    $"where Postcode='{Int32.Parse(tbRealPostcode.Text)}' and " +
                    $"IdCity='{Int32.Parse(cbRealCity.SelectedValue.ToString())}' and " +
                    $"IdStreet='{Int32.Parse(cbRealStreet.SelectedValue.ToString())}' and " +
                    $"House='{tbRealHouse.Text}' and " +
                    $"Enclosure='{tbRealenclosure.Text}' and " +
                    $"Appartment='{Int32.Parse(tbRealApartment.Text)}'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                TableFolder.ClassAddress.IdAddress = Int32.Parse(dataReader[0].ToString());
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void VremRegistration(ComboBox cbVremCity, ComboBox cbVremStreet,
           TextBox tbVremPostcode, TextBox tbVremHouse, TextBox tbVremenclosure,
           TextBox tbVremApartment)
        {
            try
            {
                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select IdTemporaryRegistration from dbo.TemporaryRegistration " +
                    $"where PostcodeTemp='{Int32.Parse(tbVremPostcode.Text)}' and " +
                    $"IdCity='{Int32.Parse(cbVremCity.SelectedValue.ToString())}' and " +
                    $"IdStreet='{Int32.Parse(cbVremStreet.SelectedValue.ToString())}' and " +
                    $"HouseTemp='{tbVremHouse.Text}' and " +
                    $"EnclosureTemp='{tbVremenclosure.Text}' and " +
                    $"AppartmentTemp='{Int32.Parse(tbVremApartment.Text)}'",
                    sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                TableFolder.ClassVremAddress.IdVremReg = Int32.Parse(dataReader[0].ToString());
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadStudent(TextBox tbSNILS, TextBox tbINN, TextBox tbNumberPhone, TextBox Email)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("Select IdStudent from dbo.Student " +
                    $"where SNILS='{tbSNILS.Text}' and " +
                    $"INN='{tbINN.Text}' and " +
                    $"NumberPhone='{tbNumberPhone.Text}' and " +
                    $"Email='{Email.Text}'", sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                TableFolder.ClassStudent.IdStudent = Int32.Parse(dataReader[0].ToString());
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadDad(TextBox tbLastName, TextBox tbFirstName, TextBox tbMiddleName, TextBox tbNumberPhone)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("Select IdDad from dbo.Dad " +
                    $"where LastNameDad='{tbLastName.Text}' and " +
                    $"FirstNameDad='{tbFirstName.Text}' and " +
                    $"MiddleNameDad='{tbMiddleName.Text}' and " +
                    $"NumberPhoneDad='{tbNumberPhone.Text}'", sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                TableFolder.ClassParents.IdDad = Int32.Parse(dataReader[0].ToString());
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadMom(TextBox tbLastName, TextBox tbFirstName, TextBox tbMiddleName, TextBox tbNumberPhone)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("Select IdMom from dbo.Mom " +
                    $"where LastNameMom='{tbLastName.Text}' and " +
                    $"FirstNameMom='{tbFirstName.Text}' and " +
                    $"MiddleNameMom='{tbMiddleName.Text}' and " +
                    $"NumberPhoneMom='{tbNumberPhone.Text}'", sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                TableFolder.ClassParents.IdMom = Int32.Parse(dataReader[0].ToString());
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void ReadGuardianDad(TextBox tbGuardianDadLastName, TextBox tbGuardianDadFirstName, TextBox tbGuardianDadMiddleName, TextBox tbGuardianDadNumberPhone)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("Select IdGuardianDad from dbo.GuardianDad " +
                    $"where LastNameGuardianDad='{tbGuardianDadLastName.Text}' and " +
                    $"FirstNameGuardianDad='{tbGuardianDadFirstName.Text}' and " +
                    $"MiddleNameGuardianDad='{tbGuardianDadMiddleName.Text}' and " +
                    $"NumberPhoneGuardianDad='{tbGuardianDadNumberPhone.Text}'", sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                TableFolder.ClassParentGuard.IdDadGuradian = Int32.Parse(dataReader[0].ToString());
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadGuardianMom(TextBox tbLastName, TextBox tbFirstName, TextBox tbMiddleName, TextBox tbNumberPhone)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("Select IdGuardianMom from dbo.GuardianMom " +
                    $"where LastNameGuardianMom='{tbLastName.Text}' and " +
                    $"FirstNameGuardianMom='{tbFirstName.Text}' and " +
                    $"MiddleNameGuardianMom='{tbMiddleName.Text}' and " +
                    $"NumberPhoneGuardianMom='{tbNumberPhone.Text}'", sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                TableFolder.ClassParentGuard.IdMomGuradian = Int32.Parse(dataReader[0].ToString());
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void ReadImage(Image image)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("Select IdImage from dbo.Image " +
                    $"where Photo='{image}'", sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                TableFolder.ClassImage.IdImage = Int32.Parse(dataReader[0].ToString());
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void DisciplineToEdit(int idDiscipline)
        {
            try
            {
                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select Cypher, NameDiscipline from dbo.Discipline " +
                    $"where IdDiscipline='{idDiscipline}'", sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
               

                TableFolder.ClassDiscipline.NameDiscipline = dataReader[0].ToString() + "_" + dataReader[1].ToString();
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void DisciplineForTimeTableToEdit(int idDiscipline)
        {
            try
            {
                sqlConnection.Open();

                this.sqlCommand = new SqlCommand("Select Cypher, NameDiscipline from dbo.DiscipplineToTimeTable " +
                    $"where IdDisciplineT='{idDiscipline}'", sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();


                TableFolder.ClassDiscipline.NameDiscipline = dataReader[0].ToString() + "_" + dataReader[1].ToString();
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadIdImage(int IdStudent)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("Select IdImage from dbo.Student " +
                    $"where IdStudent='{IdStudent}'", sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                TableFolder.ClassImage.IdImage = Int32.Parse(dataReader[0].ToString());
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadNullDad()
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("declare @idDad int;" +
                    "set @idDad = (select max(IdDad) from dbo.Dad);" +
                    "select IdDad from dbo.Dad where IdDad=@idDad", sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                TableFolder.ClassParents.IdDad = Int32.Parse(dataReader[0].ToString());
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadNullMom()
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("declare @idMom int;" +
                    "set @idMom = (select max(IdMom) from dbo.Mom);" +
                    "select IdMom from dbo.Mom where IdMom=@idMom", sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                TableFolder.ClassParents.IdMom = Int32.Parse(dataReader[0].ToString());
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadNullDadGuard()
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("declare @idDadGuard int;" +
                    "set @idDadGuard = (select max(IdGuardianDad) from dbo.GuardianDad);" +
                    "select IdGuardianDad from dbo.GuardianDad where IdGuardianDad=@idDadGuard", sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                TableFolder.ClassParentGuard.IdDadGuradian = Int32.Parse(dataReader[0].ToString());
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadNullMomGuard()
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("declare @idMomGuard int;" +
                    "set @idMomGuard = (select max(IdGuardianMom) from dbo.GuardianMom);" +
                    "select IdGuardianMom from dbo.GuardianMom where IdGuardianMom=@idMomGuard", sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                TableFolder.ClassParentGuard.IdMomGuradian = Int32.Parse(dataReader[0].ToString());
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadNullTempReg()
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("declare @idTempReg int;" +
                    "set @idTempReg = (select max(IdTemporaryRegistration) from dbo.TemporaryRegistration);" +
                    "select IdTemporaryRegistration from dbo.TemporaryRegistration where IdTemporaryRegistration=@idTempReg", sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                TableFolder.ClassVremAddress.IdVremReg = Int32.Parse(dataReader[0].ToString());
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void ReadIdSemestr(int idTimeTable)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand("Select IdSemestr from dbo.TimeTable " +
                    $"where IdTimeTable='{idTimeTable}'", sqlConnection);
                this.dataReader = this.sqlCommand.ExecuteReader();
                this.dataReader.Read();
                TableFolder.ClassSemestr.IdSemestr = Int32.Parse(dataReader[0].ToString());
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
