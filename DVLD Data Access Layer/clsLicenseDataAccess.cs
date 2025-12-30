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

    public static class clsLicenseDataAccess {

        public static bool GetLicenseByLicenseID(int LicenseID, ref int ApplicationID,
            ref int DriverID, ref int LicenseClassID, ref DateTime IssueDate,
            ref DateTime ExpirationDate, ref string Notes, ref decimal PaidFees,
            ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID) {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate,
                                    ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID 
                             FROM Licenses WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {

                    IsFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    Notes = (string)clsUtil.HandleNullValueInReaderOptional("Notes", reader);
                    PaidFees = (decimal)clsUtil.HandleNullValueInReaderOptional("PaidFees", reader);
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = (byte)reader["IssueReason"];
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

        public static bool GetLicenseByDriverID(ref int LicenseID, ref int ApplicationID,
            int DriverID, ref int LicenseClassID, ref DateTime IssueDate,
            ref DateTime ExpirationDate, ref string Notes, ref decimal PaidFees,
            ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID) {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate,
                                    ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID 
                             FROM Licenses WHERE DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {

                    IsFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseID = (int)reader["LicenseID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    Notes = (string)clsUtil.HandleNullValueInReaderOptional("Notes", reader);
                    PaidFees = (decimal)clsUtil.HandleNullValueInReaderOptional("PaidFees", reader);
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = (byte)reader["IssueReason"];
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

        public static bool GetLicenseByApplicationID(ref int LicenseID, int ApplicationID,
            ref int DriverID, ref int LicenseClassID, ref DateTime IssueDate,
            ref DateTime ExpirationDate, ref string Notes, ref decimal PaidFees,
            ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID) {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate,
                                    ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID 
                             FROM Licenses WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {

                    IsFound = true;

                    DriverID = (int)reader["DriverID"];
                    LicenseID = (int)reader["LicenseID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    Notes = (string)clsUtil.HandleNullValueInReaderOptional("Notes", reader);
                    PaidFees = (decimal)clsUtil.HandleNullValueInReaderOptional("PaidFees", reader);
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = (byte)reader["IssueReason"];
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

        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClassID,
            DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees,
            bool IsActive, byte IssueReason, int CreatedByUserID) {

            int NewLicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Licenses (ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
                             VALUES (@ApplicationID, @DriverID, @LicenseClassID, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID)
                             SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            clsUtil.HandleNullValueInCommand(Notes, "@Notes", command);
            clsUtil.HandleNullValueInCommand(PaidFees, "@PaidFees", command);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try {

                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int NewID))
                    NewLicenseID = NewID;
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"], ex.ToString(), EventLogEntryType.Error);
                NewLicenseID = -1;
            }
            finally {

                connection.Close();
            }

            return NewLicenseID;
        }

        public static bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClassID,
            DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees,
            bool IsActive, byte IssueReason, int CreatedByUserID) {

            byte RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Licenses
                             SET ApplicationID = @ApplicationID,
                                 DriverID = @DriverID,
                                 LicenseClassID = @LicenseClassID,
                                 IssueDate = @IssueDate,
                                 ExpirationDate = @ExpirationDate,
                                 Notes = @Notes,
                                 PaidFees = @PaidFees,
                                 IsActive = @IsActive,
                                 IssueReason = @IssueReason,
                                 CreatedByUserID = @CreatedByUserID
                             WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            clsUtil.HandleNullValueInCommand(Notes, "@Notes", command);
            clsUtil.HandleNullValueInCommand(PaidFees, "@PaidFees", command);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
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

        // No need to delete a license
        public static bool DeleteLicense(int LicenseID) {

            byte RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"DELETE FROM Licenses WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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

        public static bool DeactivateLicense(int LicenseID) {

            bool IsDeactivated = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            
            SqlCommand command = new SqlCommand("sp_DeactivateLocalLicense", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@LocalLicense", LicenseID);

            try {

                connection.Open();
                command.ExecuteNonQuery();
                IsDeactivated = true;
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"],
                    ex.ToString(), EventLogEntryType.Error);
                IsDeactivated = false;
            }
            finally {

                connection.Close();
            }

            return IsDeactivated;
        }

        public static bool IsLicenseExists(int LicenseID) {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT 1 FROM Licenses WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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

        public static DataTable GetAllLocalLicensesForDriver(int DriverID) {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT L.LicenseID AS [License ID], L.ApplicationID AS [Application ID], L.ClassName AS [Class Name],
                             L.IssueDate AS [Issue Date], L.ExpirationDate AS [Expiration Date], L.IsActive AS [Is Active]
                             FROM LocalLicensesInfo L
                             WHERE L.DriverID = @DriverID";

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

        public static bool IsLocalLicenseHasAnActiveInternationalLicense(int LicenseID) {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT 1 FROM Licenses L
                             INNER JOIN InternationalLicenses IL ON IL.IssuedUsingLocalLicenseID = L.LicenseID
                             WHERE L.LicenseID = @LicenseID AND IL.IsActive = 1 AND GETDATE() <= IL.ExpirationDate";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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

        public static bool IsLicenseActive(int LicenseID) {

            bool IsActive = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT 1 FROM Licenses WHERE LicenseID = @LicenseID AND IsActive = 1";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                IsActive = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"], ex.ToString(), EventLogEntryType.Error);
                IsActive = false;
            }
            finally {

                connection.Close();
            }

            return IsActive;
        }

    }
}