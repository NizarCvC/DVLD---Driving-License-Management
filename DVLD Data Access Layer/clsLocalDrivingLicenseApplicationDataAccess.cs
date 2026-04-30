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

    public static class clsLocalDrivingLicenseApplicationDataAccess {

        public static bool GetLDLApplicationByLDLAppID(int LDLApplicationID, ref int ApplicationID, ref int LicenseClassID) {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID 
                             FROM LocalDrivingLicenseApplications 
                             where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLApplicationID);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {

                    IsFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
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

        public static bool GetLDLApplicationByApplicationID(ref int LDLApplicationID, int ApplicationID, ref int LicenseClassID) {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID 
                             FROM LocalDrivingLicenseApplications 
                             where ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {

                    IsFound = true;

                    LDLApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }
                else {

                    IsFound = false;
                }

                reader.Close();
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"],
                    ex.ToString(), EventLogEntryType.Error);
                IsFound = false;
            }
            finally {

                connection.Close();
            }

            return IsFound;
        }

        public static int AddNewLDLApplication(int ApplicationID, int LicenseClassID) {

            int LDLApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID)
                             VALUES (@ApplicationID, @LicenseClassID)
                             SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try {

                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int NewID)) 
                    LDLApplicationID = NewID;
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"], ex.ToString(), EventLogEntryType.Error);
                LDLApplicationID = -1;
            }
            finally { 
                
                connection.Close(); 
            }

            return LDLApplicationID;
        }
    
        public static bool UpdateLDLApplication(int LDLApplicationID, int ApplicationID, int LicenseClassID) {

            byte RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE LocalDrivingLicenseApplications
                             SET ApplicationID = @ApplicationID,
                                 LicenseClassID = @LicenseClassID
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLApplicationID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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

        public static bool DeleteLDLApplication(int LDLApplicationID, int ApplicationID) {

            bool IsDeleted = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand("sp_DeleteAllLDLApplicationInfo", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try {

                connection.Open();
                command.ExecuteNonQuery();
                IsDeleted = true;
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"],
                    ex.ToString(), EventLogEntryType.Error);
                IsDeleted = false;
            }
            finally {

                connection.Close();
            }

            return IsDeleted;
        }

        public static bool IsLDLApplicationExist(int LDLApplicationID) {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT FOUND = 1 FROM LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLApplicationID);

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

        public static DataTable GetAllLDLApplications() {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT LDLAppID AS [L.D.L. App ID], DrivingClass as [Driving Class], NationalNo as [National No],
                             FullName as [Full Name], ApplicationDate as [Application Date], PassedTests as [Passed Tests],
                             ApplicationStatus as [Application Status] FROM LDLApplicationInfo
                             ORDER BY ApplicationDate DESC";

            SqlCommand command = new SqlCommand(query, connection);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"],
                    ex.ToString(), EventLogEntryType.Error);
                dt = null;
            }
            finally {

                connection.Close();
            }

            return dt;
        }

        // Sql Injection need to fix later 
        public static DataTable FilterLDLApplications(string Column, string Filter) {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = string.Empty;

            if (Column == "FullName" || Column == "NationalNo") {

                query = $@"SELECT LDLAppID AS [L.D.L. App ID], DrivingClass as [Driving Class], NationalNo as [National No],
                             FullName as [Full Name], ApplicationDate as [Application Date], PassedTests as [Passed Tests],
                             ApplicationStatus as [Application Status] FROM LDLApplicationInfo
                             WHERE {Column} LIKE '' + @Filter + '%'";

            }
            else {

                query = $@"SELECT LDLAppID AS [L.D.L. App ID], DrivingClass as [Driving Class], NationalNo as [National No],
                             FullName as [Full Name], ApplicationDate as [Application Date], PassedTests as [Passed Tests],
                             ApplicationStatus as [Application Status] FROM LDLApplicationInfo
                             WHERE {Column} = @Filter ";
            }

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("Filter", Filter);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"],
                    ex.ToString(), EventLogEntryType.Error);
                dt = null;
            }
            finally {

                connection.Close();
            }

            return dt;
        }

        public static bool PersonHasNewLDLApplicationInLicenseClass(int ApplicantPersonID, int LicenseClassID)  {

            bool IsNew = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT TRUE = 1 FROM LocalDrivingLicenseApplications
                             INNER JOIN Applications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                             INNER JOIN LicenseClasses ON LicenseClasses.LicenseClassID = LocalDrivingLicenseApplications.LicenseClassID
                             WHERE ApplicantPersonID = @ApplicantPersonID AND ApplicationStatus = 1 AND LicenseClasses.LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                IsNew = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"], ex.ToString(), EventLogEntryType.Error);
                IsNew = false;
            }
            finally {

                connection.Close();
            }

            return IsNew;
        }

        public static bool PersonHasAnActiveLicenseInClass(int ApplicantPersonID, int LicenseClassID) {

            bool IsExists = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT 1 FROM LocalDrivingLicenseApplications LDL
                             INNER JOIN Applications A ON A.ApplicationID = LDL.ApplicationID
                             INNER JOIN Licenses L ON L.ApplicationID = A.ApplicationID
                             WHERE A.ApplicantPersonID = @ApplicantPersonID AND
                             LDL.LicenseClassID = @LicenseClassID AND L.IsActive = 1 AND
                             GETDATE() <= L.ExpirationDate";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                IsExists = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"],
                    ex.ToString(), EventLogEntryType.Error);
                IsExists = false;
            }
            finally {

                connection.Close();
            }

            return IsExists;
        }

        public static bool CancelLDLApplication(int LDLApplication) {

            byte rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Applications
                             SET ApplicationStatus = 0,
                                 LastStatusDate = GETDATE()
                             WHERE ApplicationID = (
	                         SELECT LocalDrivingLicenseApplications.ApplicationID FROM LocalDrivingLicenseApplications
	                         WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLApplication);

            try {

                connection.Open();
                rowsAffected = (byte)command.ExecuteNonQuery();
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"], ex.ToString(), EventLogEntryType.Error);
                rowsAffected = 0;
            }
            finally {

                connection.Close();
            }

            return rowsAffected > 0;
        }

        public static byte NumberOfTrailsPerTest(int LDLApplication, int TestTypeID) {

            byte Trials = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT COUNT(*) FROM LocalDrivingLicenseApplications LDL
                             INNER JOIN TestAppointments TestApp ON TestApp.LocalDrivingLicenseApplicationID = LDL.LocalDrivingLicenseApplicationID
                             INNER JOIN Tests ON Tests.TestAppointmentID = TestApp.TestAppointmentID
                             WHERE LDL.LocalDrivingLicenseApplicationID = @LDLApplication AND TestApp.TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDLApplication", LDLApplication);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try {

                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && byte.TryParse(Result.ToString(), out byte num))
                    Trials = num;
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"], ex.ToString(), EventLogEntryType.Error);
                Trials = 0;
            }
            finally {

                connection.Close();
            }

            return Trials;
        }

        public static bool IsThereAnActiveScheduledTest(int LDLApplicationID, int TestTypeID) {

            bool IsNotAvailable = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT 1 WHERE EXISTS (

	                            SELECT 1 FROM LocalDrivingLicenseApplications LDL
	                            INNER JOIN TestAppointments TA ON TA.LocalDrivingLicenseApplicationID = LDL.LocalDrivingLicenseApplicationID
	                            WHERE LDL.LocalDrivingLicenseApplicationID = @LDLApplicationID AND TA.TestTypeID = @TestTypeID AND TA.IsLocked = 0
                             )";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                IsNotAvailable = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"], ex.ToString(), EventLogEntryType.Error);
                IsNotAvailable = false;
            }
            finally {

                connection.Close();
            }

            return IsNotAvailable;
        }

        public static bool IsHavePassedTest(int LDLApplicationID, int TestTypeID) {

            bool IsHavePassed = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT 1 FROM TestAppointments
                             INNER JOIN Tests ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                             INNER JOIN LocalDrivingLicenseApplications LDL ON LDL.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                             WHERE LDL.LocalDrivingLicenseApplicationID = @LDLApplicationID AND TestAppointments.TestTypeID = @TestTypeID AND Tests.TestResult = 1";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                IsHavePassed = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"], ex.ToString(), EventLogEntryType.Error);
                IsHavePassed = false;
            }
            finally {

                connection.Close();
            }

            return IsHavePassed;
        }

        public static bool IsHaveFaildTest(int LDLApplicationID, int TestTypeID) {

            bool IsHaveFailed = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT 1 FROM TestAppointments
                             INNER JOIN Tests ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                             INNER JOIN LocalDrivingLicenseApplications LDL ON LDL.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                             WHERE LDL.LocalDrivingLicenseApplicationID = @LDLApplicationID AND TestAppointments.TestTypeID = @TestTypeID AND Tests.TestResult = 0";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                IsHaveFailed = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"], ex.ToString(), EventLogEntryType.Error);
                IsHaveFailed = false;
            }
            finally {

                connection.Close();
            }

            return IsHaveFailed;
        }

    }
}