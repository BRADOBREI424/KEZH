using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEZH.ClassFolder
{
    class ClassAdd
    {
        SqlConnection sqlConnection =
       new SqlConnection(App.ConnectionString());
        string s = App.ConnectionString();
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        ClassCB classCB;
        ClassRead classRead;

        public void AddNullDad()
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Dad(LastNameDad, FirstNameDad, " +
                    "MiddleNameDad, NumberPhoneDad) " +
                    "values(@LastNameDad, @FirstNameDad, @MiddleNameDad, @NumberPhoneDad)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameDad", DBNull.Value);
                sqlCommand.Parameters.AddWithValue("FirstNameDad", DBNull.Value);
                sqlCommand.Parameters.AddWithValue("MiddleNameDad", DBNull.Value);
                sqlCommand.Parameters.AddWithValue("NumberPhoneDad", DBNull.Value);
                sqlCommand.ExecuteNonQuery();
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
        public void AddNullMom()
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.Mom(LastNameMom, FirstNameMom, " +
                    "MiddleNameMom, NumberPhoneMom) " +
                    "values(@LastNameMom, @FirstNameMom, @MiddleNameMom, @NumberPhoneMom)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameMom", DBNull.Value);
                sqlCommand.Parameters.AddWithValue("FirstNameMom", DBNull.Value);
                sqlCommand.Parameters.AddWithValue("MiddleNameMom", DBNull.Value);
                sqlCommand.Parameters.AddWithValue("NumberPhoneMom", DBNull.Value);
                sqlCommand.ExecuteNonQuery();
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
        public void AddNullDadGuard()
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.GuardianDad(LastNameGuardianDad, " +
                    "FirstNameGuardianDad, MiddleNameGuardianDad, NumberPhoneGuardianDad) " +
                    "values(@LastNameGuardianDad, @FirstNameGuardianDad, " +
                    "@MiddleNameGuardianDad, @NumberPhoneGuardianDad)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameGuardianDad", DBNull.Value);
                sqlCommand.Parameters.AddWithValue("FirstNameGuardianDad", DBNull.Value);
                sqlCommand.Parameters.AddWithValue("MiddleNameGuardianDad", DBNull.Value);
                sqlCommand.Parameters.AddWithValue("NumberPhoneGuardianDad", DBNull.Value);
                sqlCommand.ExecuteNonQuery();
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
        public void AddNullMomGuard()
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.GuardianMom(LastNameGuardianMom, FirstNameGuardianMom, " +
                    "MiddleNameGuardianMom, NumberPhoneGuardianMom) " +
                    "values(@LastNameGuardianMom, @FirstNameGuardianMom, " +
                    "@MiddleNameGuardianMom, @NumberPhoneGuardianMom)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("LastNameGuardianMom", DBNull.Value);
                sqlCommand.Parameters.AddWithValue("FirstNameGuardianMom", DBNull.Value);
                sqlCommand.Parameters.AddWithValue("MiddleNameGuardianMom", DBNull.Value);
                sqlCommand.Parameters.AddWithValue("NumberPhoneGuardianMom", DBNull.Value);
                sqlCommand.ExecuteNonQuery();
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
        public void AddNullTempReg()
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.TemporaryRegistration " +
                    "(PostcodeTemp, IdCity, IdStreet, HouseTemp, EnclosureTemp, AppartmentTemp) " +
                    "Values(@PostcodeTemp, @IdCity, @IdStreet, @HouseTemp, @EnclosureTemp, @AppartmentTemp)",
                    sqlConnection);
                sqlCommand.Parameters.AddWithValue("PostcodeTemp", DBNull.Value);
                sqlCommand.Parameters.AddWithValue("IdCity", DBNull.Value);
                sqlCommand.Parameters.AddWithValue("IdStreet", DBNull.Value);
                sqlCommand.Parameters.AddWithValue("HouseTemp", DBNull.Value);
                sqlCommand.Parameters.AddWithValue("EnclosureTemp", DBNull.Value);
                sqlCommand.Parameters.AddWithValue("AppartmentTemp", DBNull.Value);
                sqlCommand.ExecuteNonQuery();

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
