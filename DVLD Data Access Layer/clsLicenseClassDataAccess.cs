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

    public static class clsLicenseClassDataAccess {

        public static bool GetLicenseClassByID(int LicenseClassID, ref string ClassName,
            ref string ClassDescription, ref byte MinimumAllowedAge,
            ref byte DefaultValidityLength, ref decimal ClassFees) {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees 
                             FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {

                    IsFound = true;

                    ClassName = (string)reader["ClassName"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees = (decimal)reader["ClassFees"];
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

        public static bool GetLicenseClassByClassName(ref int LicenseClassID, string ClassName,
            ref string ClassDescription, ref byte MinimumAllowedAge,
            ref byte DefaultValidityLength, ref decimal ClassFees) {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees 
                             FROM LicenseClasses WHERE ClassName = @ClassName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {

                    IsFound = true;

                    LicenseClassID = (int)reader["LicenseClassID"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees = (decimal)reader["ClassFees"];
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

        // No need to add new according to the system requirments

        public static bool UpdateLicenseClass(int LicenseClassID, string ClassName, string ClassDescription,
            byte MinimumAllowedAge, byte DefaultValidityLength, decimal ClassFees) {

            byte RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE LicenseClasses
                             SET ClassName = @ClassName,
                                 ClassDescription = @ClassDescription,
                                 MinimumAllowedAge = @MinimumAllowedAge,
                                 DefaultValidityLength = @DefaultValidityLength,
                                 ClassFees = @ClassFees
                             WHERE LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);

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

        // No need to delete according to the system requirments

        public static DataTable GetAllLicenseClasses() {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT LicenseClassID AS [License Class ID], ClassName AS [Class Name],
                                ClassDescription AS [Class Description], MinimumAllowedAge AS [Minimum Allowed Age],
                                DefaultValidityLength AS [Default Validity Length], ClassFees AS [Class Fees]
                             FROM LicenseClasses";

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

        public static DataTable GetAllLicenseClassNames() {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT ClassName FROM LicenseClasses";

            SqlCommand command = new SqlCommand(query, connection);

            try {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) {

                    dt.Load(reader);
                }
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

        // No need to seacrh if type exist according to the system requirments

        public static int NumberOfLicenseClasses() {

            int CountClass = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT COUNT(*) FROM LicenseClasses";

            SqlCommand command = new SqlCommand(query, connection);

            try {

                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int num)) {

                    CountClass = num;
                }
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"], ex.ToString(), EventLogEntryType.Error);
                CountClass = 0;
            }
            finally {

                connection.Close();
            }

            return CountClass;
        }

        // No need to filter according to the system requirments
    }
}