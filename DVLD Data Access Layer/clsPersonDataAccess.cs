using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using My_Libraries;
using System.Diagnostics;
using System.Configuration;

namespace DVLD_Data_Access_Layer {

    public static class clsPersonDataAccess {

        public static bool GetPersonInfoByID(int PersonID, ref string NationalNo, ref string FirstName,
            ref string SecondName, ref string ThirdName, ref string LastName,
            ref DateTime DateOfBirth, ref string Gender, ref string Address, ref string Phone,
            ref string Email, ref short NationalityID, ref string ImagePath) {

            try {

                using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (var command = new SqlCommand("sp_GetPersonByID", connection)) {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    connection.Open();

                    using (var reader = command.ExecuteReader(CommandBehavior.SingleRow)) {

                        if (!reader.Read()) return false;

                        NationalNo    = (string)reader["NationalNo"];
                        FirstName     = (string)reader["FirstName"];
                        SecondName    = (string)clsUtil.HandleNullValueInReader("SecondName", reader);
                        ThirdName     = (string)clsUtil.HandleNullValueInReader("ThirdName", reader);
                        LastName      = (string)reader["LastName"];
                        DateOfBirth   = (DateTime)reader["DateOfBirth"];
                        Gender        = clsUtil.HandleGender((byte)reader["Gender"]);
                        Address       = (string)reader["Address"];
                        Phone         = (string)reader["Phone"];
                        Email         = (string)clsUtil.HandleNullValueInReader("Email", reader);
                        NationalityID = (short)reader["NationalityID"];
                        ImagePath     = (string)clsUtil.HandleNullValueInReader("ImagePath", reader);

                        return true;
                    }
                }
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"],
                    ex.ToString(), EventLogEntryType.Error);
                return false;
            }
        }

        public static bool GetPersonInfoByNationalNo(ref int PersonID, string NationalNo,
            ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName,
            ref DateTime DateOfBirth, ref string Gender, ref string Address, ref string Phone,
            ref string Email, ref short NationalityID, ref string ImagePath) {
            
            try {

                using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (var command = new SqlCommand("sp_GetPersonByNationalNo", connection)) {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    connection.Open();

                    using (var reader = command.ExecuteReader(CommandBehavior.SingleRow)) {

                        if (!reader.Read()) return false;

                        PersonID      = (int)reader["PersonID"];
                        FirstName     = (string)reader["FirstName"];
                        SecondName    = (string)clsUtil.HandleNullValueInReader("SecondName", reader);
                        ThirdName     = (string)clsUtil.HandleNullValueInReader("ThirdName", reader);
                        LastName      = (string)reader["LastName"];
                        DateOfBirth   = (DateTime)reader["DateOfBirth"];
                        Gender        = clsUtil.HandleGender((byte)reader["Gender"]);
                        Address       = (string)reader["Address"];
                        Phone         = (string)reader["Phone"];
                        Email         = (string)clsUtil.HandleNullValueInReader("Email", reader);
                        NationalityID = (short)reader["NationalityID"];
                        ImagePath     = (string)clsUtil.HandleNullValueInReader("ImagePath", reader);

                        return true;
                    }
                }
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"],
                    ex.ToString(), EventLogEntryType.Error);
                return false;
            }
        }

        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName,
            string LastName, DateTime DateOfBirth, string Gender, string Address, string Phone,
            string Email, short NationalityID, string ImagePath) {
            
            try {

                using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (var command = new SqlCommand("sp_AddNewPerson", connection)) {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    clsUtil.HandleNullValueInCommand(SecondName, "@SecondName", command);
                    clsUtil.HandleNullValueInCommand(ThirdName, "@ThirdName", command);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", clsUtil.HandleGender(Gender));
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    clsUtil.HandleNullValueInCommand(Email, "@Email", command);
                    command.Parameters.AddWithValue("@NationalityID", NationalityID);
                    clsUtil.HandleNullValueInCommand(ImagePath, "@ImagePath", command);

                    SqlParameter parmOut = new SqlParameter("@NewPersonID", SqlDbType.Int) {

                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(parmOut);

                    connection.Open();
                    command.ExecuteNonQuery();

                    return (parmOut.Value == DBNull.Value) ? -1 : (int)parmOut.Value;
                }
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"],
                    ex.ToString(), EventLogEntryType.Error);
                return -1;
            }
        }

        public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName,
            string SecondName, string ThirdName, string LastName,
            DateTime DateOfBirth, string Gender, string Address, string Phone,
            string Email, short NationalityID, string ImagePath) {
            
            try {

                using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (var command = new SqlCommand("sp_UpdatePerson", connection)) {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    clsUtil.HandleNullValueInCommand(SecondName, "@SecondName", command);
                    clsUtil.HandleNullValueInCommand(ThirdName, "@ThirdName", command);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", clsUtil.HandleGender(Gender));
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    clsUtil.HandleNullValueInCommand(Email, "@Email", command);
                    command.Parameters.AddWithValue("@NationalityID", NationalityID);
                    clsUtil.HandleNullValueInCommand(ImagePath, "@ImagePath", command);

                    SqlParameter parmOut = new SqlParameter("@IsUpdated", SqlDbType.Bit) {

                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(parmOut);

                    connection.Open();
                    command.ExecuteNonQuery();

                    return (parmOut.Value != DBNull.Value) && (bool)parmOut.Value;
                }
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"],
                    ex.ToString(), EventLogEntryType.Error);
                return false;
            }
        }

        public static bool DeletePerson(int PersonID) {

            try {

                using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (var command = new SqlCommand("sp_DeletePerson", connection)) {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    SqlParameter parmOut = new SqlParameter("@IsDeleted", SqlDbType.Bit) {

                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(parmOut);

                    connection.Open();
                    command.ExecuteNonQuery();

                    return (parmOut.Value != DBNull.Value) && (bool)parmOut.Value;
                }
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"], ex.ToString(), EventLogEntryType.Error);
                return false;
            }
        }

        public static DataTable GetAllPeople() {
            
            try {

                using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (var command = new SqlCommand("sp_GetPeopleList", connection)) {

                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (var reader = command.ExecuteReader()) {

                        var dt = new DataTable();
                        if (reader.HasRows) dt.Load(reader);
                        return dt;
                    }
                }
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"],
                    ex.ToString(), EventLogEntryType.Error);
                return null;
            }
        }

        public static bool IsPersonExist(int PersonID) {

            try {

                using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (var command = new SqlCommand("sp_IsPersonExistsByID", connection)) {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    SqlParameter parmOut = new SqlParameter("@IsExists", SqlDbType.Bit) {

                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(parmOut);

                    connection.Open();
                    command.ExecuteNonQuery();

                    return (parmOut.Value != DBNull.Value) && (bool)parmOut.Value;
                }
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"], ex.ToString(), EventLogEntryType.Error);
                return false;
            }
        }

        public static bool IsPersonExist(string NationalNo) {

            try {

                using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (var command = new SqlCommand("sp_IsPersonExistsByNationalNo", connection)) {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);

                    SqlParameter parmOut = new SqlParameter("@IsExists", SqlDbType.Bit) {

                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(parmOut);

                    connection.Open();
                    command.ExecuteNonQuery();

                    return (parmOut.Value != DBNull.Value) && (bool)parmOut.Value;
                }
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"], ex.ToString(), EventLogEntryType.Error);
                return false;
            }
        }

        public static DataTable FilterData(string Column, string Filter) {

            HashSet<string> columns = new HashSet<string>() {

                "PersonID","NationalNo","FirstName","SecondName",
                "ThirdName","LastName","DateOfBirth","Gender",
                "Address","Phone","Email","NationalityID","ImagePath"
            };

            if (!columns.Contains(Column)) return null;

            DataTable dt = new DataTable();
            string query;

            if (Column == "PersonID" || Column == "Gender") {
                query = $@"SELECT 
                            People.PersonID   AS [Person ID], 
                            People.NationalNo AS [National No], 
                            People.FirstName  AS [First Name], 
                            People.SecondName AS [Second Name], 
                            People.ThirdName  AS [Third Name], 
                            People.LastName   AS [Last Name], 
                            Gender = CASE
                                        WHEN People.Gender = 0 THEN 'Male'
                                        WHEN People.Gender = 1 THEN 'Female'
                                        ELSE 'Unknown'
                                     END, 
                            People.DateOfBirth AS [Date of Birth], 
                            People.Address    AS [Address], 
                            Countries.CountryName AS [Country], 
                            People.Phone      AS [Phone], 
                            People.Email      AS [Email]
                           FROM People
                           INNER JOIN Countries ON People.NationalityID = Countries.CountryID
                           WHERE {Column} = @Filter";
            }
            else {
                query = $@"SELECT 
                              People.PersonID   AS [Person ID], 
                              People.NationalNo AS [National No], 
                              People.FirstName  AS [First Name], 
                              People.SecondName AS [Second Name], 
                              People.ThirdName  AS [Third Name], 
                              People.LastName   AS [Last Name], 
                              Gender = CASE
                                          WHEN People.Gender = 0 THEN 'Male'
                                          WHEN People.Gender = 1 THEN 'Female'
                                          ELSE 'Unknown'
                                       END, 
                              People.DateOfBirth AS [Date of Birth], 
                              People.Address    AS [Address], 
                              Countries.CountryName AS [Country], 
                              People.Phone      AS [Phone], 
                              People.Email      AS [Email]
                          FROM People
                          INNER JOIN Countries ON People.NationalityID = Countries.CountryID
                          WHERE {Column} LIKE '' + @Filter + '%'";
            }

            try {

                using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (var command = new SqlCommand(query, connection)) {

                    command.Parameters.AddWithValue("@Filter", Filter);
                    connection.Open();

                    using (var reader = command.ExecuteReader()) {

                        if (reader.HasRows) dt.Load(reader);
                        return dt;
                    }
                }
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"],
                    ex.ToString(), EventLogEntryType.Error);
                return null;
            }
        }
    
    }
}