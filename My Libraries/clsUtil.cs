using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.Versioning;
using System.Globalization;

namespace My_Libraries {

    public static class clsUtil {

        public static object HandleNullValueInReader(string ColumnName, SqlDataReader reader) {

            return (reader[ColumnName] == DBNull.Value) ? null : reader[ColumnName];
        }

        // Need to fix
        [Obsolete("Please don't use this method because it will be removed soon.\nUse HandleNullValueInReader instead")]
        public static object HandleNullValueInReaderOptional(string ColumnName, SqlDataReader reader) {

            return (reader[ColumnName] == DBNull.Value) ? "" : reader[ColumnName];
        }

        public static void HandleNullValueInCommand<T>(T Var, string ColumnName, SqlCommand command) {

            if (Var == null) {

                command.Parameters.AddWithValue(ColumnName, DBNull.Value);
            }
            else {

                command.Parameters.AddWithValue(ColumnName, Var);
            }
        }

        //public static void HandleNullValueInCommand(string Var, string ColumnName, SqlCommand command) {

        //    if (Var == "") {

        //        command.Parameters.AddWithValue(ColumnName, DBNull.Value);
        //    }
        //    else {

        //        command.Parameters.AddWithValue(ColumnName, Var);
        //    }
        //}

        public static void HandleNullValueInCommand(int Var, string ColumnName, SqlCommand command) {

            if (Var < 1) {

                command.Parameters.AddWithValue(ColumnName, DBNull.Value);
            }
            else {

                command.Parameters.AddWithValue(ColumnName, Var);
            }
        }

        public static void HandleNullValueInCommand(decimal Var, string ColumnName, SqlCommand command) {

            if (Var < 1) {

                command.Parameters.AddWithValue(ColumnName, DBNull.Value);
            }
            else {

                command.Parameters.AddWithValue(ColumnName, Var);
            }
        }

        public static void HandleNullValueInCommand(DateTime Var, string ColumnName, SqlCommand command) {

            if (Var == DateTime.MinValue) {

                command.Parameters.AddWithValue(ColumnName, DBNull.Value);
            }
            else {

                command.Parameters.AddWithValue(ColumnName, Var);
            }
        }

        public static string HandleGender(byte Gender) {

            return (Gender == 0) ? "Male" : "Female";
        }

        public static int HandleGender(string Gender) {

            return (Gender == "Male") ? 0 : 1;
        }

        public static string FullNameFormat(string FirstName, string LastName, string SecondName = "", string ThirdName = "") {

            return FirstName + (string.IsNullOrEmpty(SecondName) ? "" : (" " + SecondName)) + (string.IsNullOrEmpty(ThirdName) ? "" : (" " + ThirdName)) + " " + LastName;
        }

        public static bool IsValidEmail(string Email) {

            if (!Email.Contains("@") || !Email.Contains(".com") || Email[0] == '@' || Email[Email.Length - 1] == '@') return false;

            byte @Numbers = 0, ComNumbers = 0;
            bool IsReachedToAt = false;

            for (int i = 0; i < Email.Length; i++) {

                if (Email[i] == '.' && !IsReachedToAt) return false;

                if (Email[i] == '@') {

                    IsReachedToAt = true;
                    @Numbers++;
                }
                if (Email[i] == '.') ComNumbers++;

                if (Email[i] == '@' && i + 1 < Email.Length && Email[i + 1] == '.') return false;

                if (@Numbers > 1 || ComNumbers > 1) return false;

            }

            return true;
        }

        public static string RemoveChar(string Text, char Character = ' ') {

            if (!Text.Contains(Character)) return Text;

            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in Text) {

                if (c == Character) continue;

                stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }
        
        public static string UpperFirstLetter(string Text) {

            if (string.IsNullOrWhiteSpace(Text)) return "";
            return char.ToUpper(Text[0]) + Text.Substring(1);
        }

        public static DateTime CheckIsValidDate(string Text) {

            if (DateTime.TryParse(Text, out DateTime date))
                return date;
            else
                return DateTime.Now.Date;
        }

        public static decimal CheckIfValidDecimal(string Text) {

            if (decimal.TryParse(Text, out decimal number))
                return number;
            else
                return 0;
        }

        public static string GenerateGUID() => Guid.NewGuid().ToString();

    }
}