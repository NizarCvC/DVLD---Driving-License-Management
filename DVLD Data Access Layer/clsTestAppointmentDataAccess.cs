using My_Libraries;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer {

    public static class clsTestAppointmentDataAccess {
    
        public static bool GetTestAppointmentByID(int TestAppointmentID, ref int TestTypeID,
            ref int LDLApplicationID, ref DateTime AppointmentDate, ref decimal PaidFees,
            ref int CreatedByUserID, ref bool IsLocked, ref int RetakeTestApplicationID) {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID,
                                    AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID 
                             FROM TestAppointments 
                             WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {

                    IsFound = true;

                    TestTypeID = (int)reader["TestTypeID"];
                    LDLApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];
                    object Result = clsUtil.HandleNullValueInReaderOptional("RetakeTestApplicationID", reader);
                    RetakeTestApplicationID = (Result.ToString() == "") ? -1 : (int)Result;
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
    
        public static int AddNewTestAppointment(int TestTypeID, int LDLApplicationID,
            DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, 
            bool IsLocked, int RetakeTestApplicationID) {

            int NewTestAppointmentID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO TestAppointments (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID)
                             VALUES (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, @IsLocked, @RetakeTestApplicationID)
                             SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            clsUtil.HandleNullValueInCommand(RetakeTestApplicationID, "@RetakeTestApplicationID", command);

            try {

                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int newID)) 
                    NewTestAppointmentID = newID;
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"], ex.ToString(), EventLogEntryType.Error);
                NewTestAppointmentID = -1;
            }
            finally {

                connection.Close();
            }

            return NewTestAppointmentID;
        }
    
        public static bool UpdateTestAppointment(int TestAppointmentID, int TestTypeID, int LDLApplicationID,
            DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID,
            bool IsLocked, int RetakeTestApplicationID) {

            byte RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE TestAppointments
                             SET TestTypeID = @TestTypeID,
                                 LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,
                                 AppointmentDate = @AppointmentDate,
                                 PaidFees = @PaidFees,
                                 CreatedByUserID = @CreatedByUserID,
                                 IsLocked = @IsLocked,
                                 RetakeTestApplicationID = @RetakeTestApplicationID
                             WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            clsUtil.HandleNullValueInCommand(RetakeTestApplicationID, "@RetakeTestApplicationID", command);

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
    
        public static bool DeleteTestAppointment(int TestAppointmentID) {

            byte RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"DELETE FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

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
    
        public static bool IsTestAppointmentExists(int TestAppointmentID) {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT 1 FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

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

        public static bool LockTestAppointment(int TestAppointmentID) {

            byte RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE TestAppointments
                             SET IsLocked = 1
                             WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

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

        public static bool IsTestAppointmentHasRetakeTestApp(int TestAppointmentID) {

            bool Result = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT 1 FROM TestAppointments TA
                             WHERE TA.TestAppointmentID = @TestAppointmentID AND TA.RetakeTestApplicationID IS NOT NULL";

            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                Result = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"],
                    ex.ToString(), EventLogEntryType.Error);
                Result = false;
            }
            finally {

                connection.Close();
            }

            return Result;
        }

        public static DataTable GetAllAppointmentsByLDLAppID(int LDLApplicationID, int TestTypeID) {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT TestAppointmentID AS [Test Appointment ID], AppointmentDate AS [Appointment Date], PaidFees AS [Paid Fees], IsLocked AS [Is Locked] FROM TestAppointments
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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