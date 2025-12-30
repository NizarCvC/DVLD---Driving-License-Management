using My_Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer {

    public static class clsInternationalLicenseDataAccess {

        public static bool GetInternationalLicenseByID(int InternationalLicenseID, ref int ApplicationID,
            ref int DriverID, ref int LocalLicneseID, ref DateTime IssueDate, ref DateTime ExpirationDate,
            ref bool IsActive, ref int CreatedByUserID) {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate,
                             ExpirationDate, IsActive, CreatedByUserID FROM InternationalLicenses
                             WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {

                    IsFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LocalLicneseID = (int)reader["IssuedUsingLocalLicenseID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                else {

                    IsFound = false;
                }

                reader.Close();
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"], ex.ToString(), EventLogEntryType.Error);
                IsFound = false;
            }
            finally {

                connection.Close();
            }

            return IsFound;
        }
    
        public static int AddNewInternationalLicense(int ApplicationID, int DriverID, int LocalLicneseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID) {

            int NewInternationalLicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO InternationalLicenses
                            (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate,
                                IsActive, CreatedByUserID) VALUES     
                           (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID,@IssueDate,
                            @ExpirationDate, @IsActive, @CreatedByUserID)
                            SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", LocalLicneseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try {

                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int NewID))
                    NewInternationalLicenseID = NewID;
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"], ex.ToString(), EventLogEntryType.Error);
                NewInternationalLicenseID = -1;
            }
            finally {

                connection.Close();
            }

            return NewInternationalLicenseID;

        }

        public static bool UpdateInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID, int LocalLicneseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID) {

            byte RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE InternationalLicenses
                             SET ApplicationID = @ApplicationID,
                                 DriverID = @DriverID,
                                 IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID,
                                 IssueDate = @IssueDate,
                                 ExpirationDate = @ExpirationDate,
                                 IsActive = @IsActive,
                                 CreatedByUserID = @CreatedByUserID
                             WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", LocalLicneseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try {

                connection.Open();
                RowsAffected = (byte)command.ExecuteNonQuery();
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"], ex.ToString(), EventLogEntryType.Error);
                RowsAffected = 0;
            }
            finally {

                connection.Close();
            }

            return RowsAffected > 0;
        }

        public static bool DeleteInternationalLicense(int InternationalLicenseID) {

            byte RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"DELETE FROM InternationalLicenses
                             WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

            try {

                connection.Open();
                RowsAffected = (byte)command.ExecuteNonQuery();
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"], ex.ToString(), EventLogEntryType.Error);
                RowsAffected = 0;
            }
            finally {

                connection.Close();
            }

            return RowsAffected > 0;
        }

        public static bool IsInternationalLicenseExists(int InternationalLicenseID) {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT 1 FROM InternationalLicenses
                             WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                IsFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"], ex.ToString(), EventLogEntryType.Error);
                IsFound = false;
            }
            finally {

                connection.Close();
            }

            return IsFound;
        }

        public static DataTable GetAllInternationalLicenses() {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT InternationalLicenseID AS [Inter Lic ID], ApplicationID AS [App ID], DriverID AS [Driver ID],
                             IssuedUsingLocalLicenseID AS [Local Lic ID], IssueDate AS [IssueDate], ExpirationDate AS [Expiration Date],
                             IsActive AS [Is Active] FROM InternationalLicenses";

            SqlCommand command = new SqlCommand(query, connection);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"], ex.ToString(), EventLogEntryType.Error);
                dt = null;
            }
            finally {

                connection.Close();
            }

            return dt;
        }

        public static DataTable GetAllInternationalLicensesForDriver(int DriverID) {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT InternationalLicenseID AS [Inter Lic ID], ApplicationID AS [App ID],
                             IssuedUsingLocalLicenseID AS [Local Lic ID], IssueDate AS [IssueDate], ExpirationDate AS [Expiration Date],
                             IsActive AS [Is Active] FROM InternationalLicenses
                             WHERE DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"], ex.ToString(), EventLogEntryType.Error);
                dt = null;
            }
            finally {

                connection.Close();
            }

            return dt;
        }

        public static DataTable FilterInternationalLicenses(string Column, string Filter) {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = $@"SELECT InternationalLicenseID AS [Inter Lic ID], ApplicationID AS [App ID], DriverID AS [Driver ID],
                             IssuedUsingLocalLicenseID AS [Local Lic ID], IssueDate AS [IssueDate], ExpirationDate AS [Expiration Date],
                             IsActive AS [Is Active] FROM InternationalLicenses
                             WHERE {Column} = @Filter";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Filter", Filter);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"], ex.ToString(), EventLogEntryType.Error);
                dt = null;
            }
            finally {

                connection.Close();
            }

            return dt;
        }

    }
}