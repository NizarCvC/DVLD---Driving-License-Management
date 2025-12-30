using My_Libraries;
using System;
using System.Collections;
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

    public static class clsDetainedLicenseDataAccess {

        public static bool GetDetainedLicenseInfoByDetainID(int DetainID, ref int LicenseID, ref DateTime DetainDate,
            ref decimal FineFees, ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleaseDate,
            ref int ReleasedByUserID, ref int ReleaseApplicationID) {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID
                             FROM DetainedLicenses WHERE DetainID = @DetainID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {

                    IsFound = true;

                    LicenseID = (int)reader["LicenseID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = (decimal)reader["FineFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];
                    object Date = clsUtil.HandleNullValueInReaderOptional("ReleaseDate", reader);
                    ReleaseDate = (Date.ToString() == "") ? DateTime.MinValue : (DateTime)Date;
                    object ID1 = clsUtil.HandleNullValueInReaderOptional("ReleasedByUserID", reader);
                    ReleasedByUserID = (ID1.ToString() == "") ? -1 : (int)ID1;
                    object ID2 = clsUtil.HandleNullValueInReaderOptional("ReleaseApplicationID", reader);
                    ReleaseApplicationID = (ID2.ToString() == "") ? -1 : (int)ID2;
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

        public static bool GetDetainedLicenseInfoByLicenseID(ref int DetainID, int LicenseID, ref DateTime DetainDate,
            ref decimal FineFees, ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleaseDate,
            ref int ReleasedByUserID, ref int ReleaseApplicationID) {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT top 1 DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID
                             FROM DetainedLicenses WHERE LicenseID = @LicenseID
							 ORDER BY DetainDate DESC";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {

                    IsFound = true;

                    DetainID = (int)reader["DetainID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = (decimal)reader["FineFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];
                    object Date = clsUtil.HandleNullValueInReaderOptional("ReleaseDate", reader);
                    ReleaseDate = (Date.ToString() == "") ? DateTime.MinValue : (DateTime)Date;
                    object ID1 = clsUtil.HandleNullValueInReaderOptional("ReleasedByUserID", reader);
                    ReleasedByUserID = (ID1.ToString() == "") ? -1 : (int)ID1;
                    object ID2 = clsUtil.HandleNullValueInReaderOptional("ReleaseApplicationID", reader);
                    ReleaseApplicationID = (ID2.ToString() == "") ? -1 : (int)ID2;
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

        public static int AddNewDetainedLicense(int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID,
            bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID,  int ReleaseApplicationID) {

            int NewDetainID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO DetainedLicenses
                                (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID)
                             VALUES (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased, @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID)
                             SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            clsUtil.HandleNullValueInCommand(ReleaseDate, "@ReleaseDate", command);
            clsUtil.HandleNullValueInCommand(ReleasedByUserID, "@ReleasedByUserID", command);
            clsUtil.HandleNullValueInCommand(ReleaseApplicationID, "@ReleaseApplicationID", command);

            try {

                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int newID))
                    NewDetainID = newID;
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"], ex.ToString(), EventLogEntryType.Error);
                NewDetainID = -1;
            }
            finally {

                connection.Close();
            }

            return NewDetainID;
        }

        public static bool UpdateDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID,
            bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID) {

            byte RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE DetainedLicenses
                             SET LicenseID = @LicenseID,
                                 DetainDate = @DetainDate,
                                 FineFees = @FineFees,
                                 CreatedByUserID = @CreatedByUserID,
                                 IsReleased = @IsReleased,
                                 ReleaseDate = @ReleaseDate,
                                 ReleasedByUserID = @ReleasedByUserID,
                                 ReleaseApplicationID = @ReleaseApplicationID
                             WHERE DetainID = @DetainID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            clsUtil.HandleNullValueInCommand(ReleaseDate, "@ReleaseDate", command);
            clsUtil.HandleNullValueInCommand(ReleasedByUserID, "@ReleasedByUserID", command);
            clsUtil.HandleNullValueInCommand(ReleaseApplicationID, "@ReleaseApplicationID", command);

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

        public static bool DeleteDetainedLicense(int DetainID) {

            byte RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"DELETE FROM DetainedLicenses WHERE DetainID = @DetainID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);

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

        public static DataTable GetAllDetainedLicenses() {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT DetainID AS [DetainID], LicenseID AS [License ID],
                             DetainDate AS [Detain Date], FineFees AS [Fine Fees], IsReleased AS [Is Released],
                             ReleaseDate AS [Release Date], NationalNo AS [National No], FullName AS [Full Name],
                             ReleaseApplicationID AS [Release App ID] FROM DetainedLicenseSInfo";

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

        public static bool IsDetainedLicenseExists(int DetainID) {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT 1 FROM DetainedLicenses WHERE DetainID = @DetainID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);

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

        public static bool IsLicenseDetained(int LicenseID) {

            bool IsDetained = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT 1 FROM DetainedLicenses WHERE LicenseID = @LicenseID AND IsReleased = 0";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                IsDetained = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"],
                    ex.ToString(), EventLogEntryType.Error);
                IsDetained = false;
            }
            finally {
                    
                connection.Close();
            }

            return IsDetained;
        }

        public static DataTable FilterDetainedLicenses(string Column, string Filter) {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = string.Empty;

            if (Column == "DetainID" || Column == "ReleaseApplicationID") {

                query = $@"SELECT DetainID AS [DetainID], LicenseID AS [License ID],
                                DetainDate AS [Detain Date], FineFees AS [Fine Fees], IsReleased AS [Is Released],
                                ReleaseDate AS [Release Date], NationalNo AS [National No], FullName AS [Full Name],
                                ReleaseApplicationID AS [Release App ID] FROM DetainedLicenseSInfo
                                WHERE {Column} = @Filter";
            }
            else {

                query = $@"SELECT DetainID AS [DetainID], LicenseID AS [License ID],
                                DetainDate AS [Detain Date], FineFees AS [Fine Fees], IsReleased AS [Is Released],
                                ReleaseDate AS [Release Date], NationalNo AS [National No], FullName AS [Full Name],
                                ReleaseApplicationID AS [Release App ID] FROM DetainedLicenseSInfo
                                WHERE {Column} LIKE '' + @Filter + '%'";
            }


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