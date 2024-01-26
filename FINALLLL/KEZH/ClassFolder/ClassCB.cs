using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KEZH.ClassFolder
{
    class ClassCB
    {
        SqlConnection sqlConnection =
       new SqlConnection(App.ConnectionString());
        SqlDataAdapter dataAdapter;
        SqlCommand sqlCommand;
        DataSet dataSet;
        SqlDataReader dataReader;

        public void LoadSemestr(ComboBox cbSemestr)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select IdSemester, " +
                    "NumberSemester from dbo.Semestr order by IdSemester ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Semestr");
                cbSemestr.ItemsSource = dataSet.Tables["Semestr"].DefaultView;
                cbSemestr.DisplayMemberPath = dataSet.Tables["Semestr"].Columns["NumberSemester"].ToString();
                cbSemestr.SelectedValuePath = dataSet.Tables["Semestr"].Columns["IdSemester"].ToString();
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
        public void LoadSemestrToTimeTable(ComboBox cbSemestr)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select IdSemester, " +
                    "NumberSemester from dbo.Semestr " +
                    "where NumberSemester<3 " +
                    "order by IdSemester ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Semestr");
                cbSemestr.ItemsSource = dataSet.Tables["Semestr"].DefaultView;
                cbSemestr.DisplayMemberPath = dataSet.Tables["Semestr"].Columns["NumberSemester"].ToString();
                cbSemestr.SelectedValuePath = dataSet.Tables["Semestr"].Columns["IdSemester"].ToString();
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
        public void LoadDiscipline(ComboBox cbDiscipline)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("select * from dbo.Discipline " +
                    $"where IdGroup='{TableFolder.ClassUser.IdGroup}' " +
                    $"order by IdDiscipline ASC", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    cbDiscipline.Items.Add(dataReader[1].ToString() + "_" + dataReader[2].ToString());
                }
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
        public void LoadDisciplineForTimeTable(ComboBox cbDiscipline)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("select * from dbo.DiscipplineToTimeTable " +
                    $"where IdGroup='{TableFolder.ClassUser.IdGroup}' " +
                    $"order by IdDisciplineT ASC", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    cbDiscipline.Items.Add(dataReader[1].ToString() + "_" + dataReader[2].ToString());
                }
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
        public void LoadDisciplineToTimeTable(ComboBox cbDiscipline)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("select * from dbo.Discipline " +
                    $"where IdGroup='{TableFolder.ClassUser.IdGroup}' and " +
                    $"IdSemestr='{TableFolder.ClassSemestr.IdSemestr}'" +
                    $"order by IdDiscipline ASC", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    cbDiscipline.Items.Add(dataReader[1].ToString() + "_" + dataReader[2].ToString());
                }
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
        public void LoadDisciplineChange(ComboBox cbDiscipline, ComboBox cbSemestr)
        {
            try
            {
                sqlConnection.Open();
                if (cbSemestr.SelectedItem == null)
                {
                    sqlCommand = new SqlCommand("select * from dbo.Discipline " +
                   $"where IdGroup='{TableFolder.ClassUser.IdGroup}' " +
                   $"order by IdDiscipline ASC", sqlConnection);
                }
                else
                {
                    sqlCommand = new SqlCommand("select * from dbo.Discipline " +
                        $"where (IdGroup='{TableFolder.ClassUser.IdGroup}' and  " +
                        $"IdSemestr='{Int32.Parse(cbSemestr.SelectedValue.ToString())}')" +
                        $"order by IdDiscipline ASC", sqlConnection);
                }
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    cbDiscipline.Items.Add(dataReader[1].ToString() + "_" + dataReader[2].ToString());
                }
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
        public void LoadDisciplineChangeForTimeTable(ComboBox cbDiscipline, ComboBox cbSemestr)
        {
            try
            {
                sqlConnection.Open();
                if (cbSemestr.SelectedItem == null)
                {
                    sqlCommand = new SqlCommand("select * from dbo.DiscipplineToTimeTable " +
                   $"where IdGroup='{TableFolder.ClassUser.IdGroup}' " +
                   $"order by IdDisciplineT ASC", sqlConnection);
                }
                else
                {
                    sqlCommand = new SqlCommand("select * from dbo.DiscipplineToTimeTable " +
                        $"where (IdGroup='{TableFolder.ClassUser.IdGroup}' and  " +
                        $"IdSemestr='{Int32.Parse(cbSemestr.SelectedValue.ToString())}')" +
                        $"order by IdDisciplineT ASC", sqlConnection);
                }
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    cbDiscipline.Items.Add(dataReader[1].ToString() + "_" + dataReader[2].ToString());
                }
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
        public void LoadDisciplineChangeInEdit(ComboBox cbDiscipline, int ibSemestr)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("select * from dbo.Discipline " +
                    $"where (IdGroup='{TableFolder.ClassUser.IdGroup}' and  " +
                    $"IdSemestr='{TableFolder.ClassSemestr.IdSemestr}')" +
                    $"order by IdDiscipline ASC", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    cbDiscipline.Items.Add(dataReader[1].ToString() + "_" + dataReader[2].ToString());
                }
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
        public void LoadDisciplineInEditForTimeTable(ComboBox cbDiscipline)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("select * from dbo.DiscipplineToTimeTable " +
                    $"where (IdGroup='{TableFolder.ClassUser.IdGroup}' and  " +
                    $"IdSemestr='{TableFolder.ClassSemestr.IdSemestr}')" +
                    $"order by IdDisciplineT ASC", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    cbDiscipline.Items.Add(dataReader[1].ToString() + "_" + dataReader[2].ToString());
                }
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
        public void LoadMarks(ComboBox cbMark)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select IdMark, " +
                    "NumberMark from dbo.Mark order by IdMark ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Mark");
                cbMark.ItemsSource = dataSet.Tables["Mark"].DefaultView;
                cbMark.DisplayMemberPath = dataSet.Tables["Mark"].Columns["NumberMark"].ToString();
                cbMark.SelectedValuePath = dataSet.Tables["Mark"].Columns["IdMark"].ToString();
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

        public void LoadGender(ComboBox cbGender)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select IdGender, " +
                    "NameGender from dbo.Gender order by IdGender ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[Gender]");
                cbGender.ItemsSource = dataSet.Tables["[Gender]"].DefaultView;
                cbGender.DisplayMemberPath = dataSet.Tables["[Gender]"].Columns["NameGender"].ToString();
                cbGender.SelectedValuePath = dataSet.Tables["[Gender]"].Columns["IdGender"].ToString();
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
        public void LoadPlaceOfBorn(ComboBox cbPlaceOfBorn)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select IdPlaceOfBorn, " +
                    "NamePlaceOfBorn from dbo.PlaceOfBorn order by IdPlaceOfBorn ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "PlaceOfBorn");
                cbPlaceOfBorn.ItemsSource = dataSet.Tables["PlaceOfBorn"].DefaultView;
                cbPlaceOfBorn.DisplayMemberPath = dataSet.Tables["PlaceOfBorn"].Columns["NamePlaceOfBorn"].ToString();
                cbPlaceOfBorn.SelectedValuePath = dataSet.Tables["PlaceOfBorn"].Columns["IdPlaceOfBorn"].ToString();
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
        public void LoadFamilyStatus(ComboBox cbFamilyStatus)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select IdFamilyStatus, " +
                    "NameFamilyStatus from dbo.FamilyStatus order by IdFamilyStatus ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "FamilyStatus");
                cbFamilyStatus.ItemsSource = dataSet.Tables["FamilyStatus"].DefaultView;
                cbFamilyStatus.DisplayMemberPath = dataSet.Tables["FamilyStatus"].Columns["NameFamilyStatus"].ToString();
                cbFamilyStatus.SelectedValuePath = dataSet.Tables["FamilyStatus"].Columns["IdFamilyStatus"].ToString();
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
        public void LoadCity(ComboBox cbCity)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select IdCity, " +
                    "NameCity from dbo.City " +
                    "where IdCity!='3' " +
                    "order by IdCity ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "City");
                cbCity.ItemsSource = dataSet.Tables["City"].DefaultView;
                cbCity.DisplayMemberPath = dataSet.Tables["City"].Columns["NameCity"].ToString();
                cbCity.SelectedValuePath = dataSet.Tables["City"].Columns["IdCity"].ToString();
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
        public void LoadStreet(ComboBox cbStreet)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select IdStreet, " +
                    "NameStreet from dbo.Street " +
                    "where IdStreet!='3' " +
                    "order by IdStreet ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Street");
                cbStreet.ItemsSource = dataSet.Tables["Street"].DefaultView;
                cbStreet.DisplayMemberPath = dataSet.Tables["Street"].Columns["NameStreet"].ToString();
                cbStreet.SelectedValuePath = dataSet.Tables["Street"].Columns["IdStreet"].ToString();
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
        public void LoadAuthority(ComboBox cbAuthority)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select IdAuthority, " +
                    "NameAuthority from dbo.IssuedByWhom order by IdAuthority ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "IssuedByWhom");
                cbAuthority.ItemsSource = dataSet.Tables["IssuedByWhom"].DefaultView;
                cbAuthority.DisplayMemberPath = dataSet.Tables["IssuedByWhom"].Columns["NameAuthority"].ToString();
                cbAuthority.SelectedValuePath = dataSet.Tables["IssuedByWhom"].Columns["IdAuthority"].ToString();
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
        public void LoadOrder(ComboBox cbOrder)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select IdStatus, " +
                    "NameStatus from dbo.Status where NameStatus!='Активен' " +
                    "order by IdStatus ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Status");
                cbOrder.ItemsSource = dataSet.Tables["Status"].DefaultView;
                cbOrder.DisplayMemberPath = dataSet.Tables["Status"].Columns["NameStatus"].ToString();
                cbOrder.SelectedValuePath = dataSet.Tables["Status"].Columns["IdStatus"].ToString();
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
        public void LoadFamily(ComboBox cbFamily)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select IdFamily, " +
                    "NameFamily from dbo.Family order by IdFamily ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Family");
                cbFamily.ItemsSource = dataSet.Tables["Family"].DefaultView;
                cbFamily.DisplayMemberPath = dataSet.Tables["Family"].Columns["NameFamily"].ToString();
                cbFamily.SelectedValuePath = dataSet.Tables["Family"].Columns["IdFamily"].ToString();
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
        public void LoadAttendance(ComboBox cbAttendance)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select IdStatusAttendance, " +
                    "NameStusAttendance from dbo.StatusAttendance order by IdStatusAttendance ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "StatusAttendance");
                cbAttendance.ItemsSource = dataSet.Tables["StatusAttendance"].DefaultView;
                cbAttendance.DisplayMemberPath = dataSet.Tables["StatusAttendance"].Columns["NameStusAttendance"].ToString();
                cbAttendance.SelectedValuePath = dataSet.Tables["StatusAttendance"].Columns["IdStatusAttendance"].ToString();
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
        public void LoadDayWeek(ComboBox cbDayWeek)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select IdDayWeek, " +
                    "DayWeek from dbo.DayWeek order by IdDayWeek ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "DayWeek");
                cbDayWeek.ItemsSource = dataSet.Tables["DayWeek"].DefaultView;
                cbDayWeek.DisplayMemberPath = dataSet.Tables["DayWeek"].Columns["DayWeek"].ToString();
                cbDayWeek.SelectedValuePath = dataSet.Tables["DayWeek"].Columns["IdDayWeek"].ToString();
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



        public void LoadGroup(ComboBox cbGroup)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter($"Select IdGroup, " +
                    $"NameGroup from dbo.[Group] " +
                    $"where IdGroup!='11'" +
                    $"order by IdGroup ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[Group]");
                cbGroup.ItemsSource = dataSet.Tables["[Group]"].DefaultView;
                cbGroup.DisplayMemberPath = dataSet.Tables["[Group]"].Columns["NameGroup"].ToString();
                cbGroup.SelectedValuePath = dataSet.Tables["[Group]"].Columns["IdGroup"].ToString();
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

        public void LoadNumber(ComboBox cbNumber)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select IdNumber, " +
                    "Number from dbo.Number order by IdNumber ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Number");
                cbNumber.ItemsSource = dataSet.Tables["Number"].DefaultView;
                cbNumber.DisplayMemberPath = dataSet.Tables["Number"].Columns["Number"].ToString();
                cbNumber.SelectedValuePath = dataSet.Tables["Number"].Columns["IdNumber"].ToString();
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

        public void LoadSpecialization(ComboBox cbSpecialization)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select IdSpecialization, " +
                    "NameSpecialization from dbo.Specialization order by IdSpecialization ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Specialization");
                cbSpecialization.ItemsSource = dataSet.Tables["Specialization"].DefaultView;
                cbSpecialization.DisplayMemberPath = dataSet.Tables["Specialization"].Columns["NameSpecialization"].ToString();
                cbSpecialization.SelectedValuePath = dataSet.Tables["Specialization"].Columns["IdSpecialization"].ToString();
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

        public void LoadGroupChange(ComboBox cbGroup, ComboBox cbSpecialization)
        {
            try
            {
                sqlConnection.Close();
                sqlConnection.Open();
                if (cbSpecialization.SelectedItem == null)
                {
                    dataAdapter = new SqlDataAdapter("Select IdGroup, " +
                        "NameGroup from dbo.[Group] order by IdGroup ASC",
                        sqlConnection);

                }
                else
                {
                    dataAdapter = new SqlDataAdapter($"Select IdGroup, " +
                        $"NameGroup from dbo.[Group] " +
                        $"where IdSpecialization='{Int32.Parse(cbSpecialization.SelectedValue.ToString())}' " +
                        $"order by IdGroup ASC",
                        sqlConnection);
                }
                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "[Group]");
                    cbGroup.ItemsSource = dataSet.Tables["[Group]"].DefaultView;
                    cbGroup.DisplayMemberPath = dataSet.Tables["[Group]"].Columns["NameGroup"].ToString();
                    cbGroup.SelectedValuePath = dataSet.Tables["[Group]"].Columns["IdGroup"].ToString();
                
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
