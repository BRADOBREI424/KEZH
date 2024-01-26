using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEZH.ClassFolder
{
    class ClassEdit
    {
        SqlConnection sqlConnection =
            new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;

        public void Edit(string sqlCommand)
        {
            try
            {
                sqlConnection.Open();
                this.sqlCommand = new SqlCommand(sqlCommand, sqlConnection);
                this.sqlCommand.ExecuteNonQuery();
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
    }

}
