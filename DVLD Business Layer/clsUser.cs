using DVLD_Data_Access_Layer;
using My_Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLD_Business_Layer {

    public class clsUser {

        private enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;
        private string _storedPasswordHash;

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public clsPerson Person { get; set; }

        public clsUser() {

            UserID = -1;
            PersonID = -1;
            Username = string.Empty;
            Password = string.Empty;
            IsActive = false;
            _Mode = enMode.AddNew;
        }
    
        private clsUser(int UserID, int PersonID, string Username, string Password, bool IsActive){

            this.UserID = UserID;
            this.PersonID = PersonID;
            this.Username = Username;
            this.Password = Password;
            this.IsActive = IsActive;
            this.Person = clsPerson.Find(PersonID);
            this._storedPasswordHash = Password;
            _Mode = enMode.Update;
        }

        public static clsUser Find(int UserID) {

            int PersonID = -1;
            string Username = string.Empty, Password = string.Empty;
            bool IsActive = false;

            if (clsUserDataAccess.GetUserInfoByID(UserID, ref PersonID, ref Username, ref Password, ref IsActive)) 
                return new clsUser(UserID, PersonID, Username, Password, IsActive);
            else 
                return null;
        }

        public static clsUser Find(string Username) {

            int UserID = -1, PersonID = -1;
            string Password = string.Empty;
            bool IsActive = false;

            if (clsUserDataAccess.GetUserInfoByUsername(ref UserID, ref PersonID, Username, ref Password, ref IsActive))
                return new clsUser(UserID, PersonID, Username, Password, IsActive);
            else 
                return null;
        }
    
        private bool _AddNewUser() {

            this.UserID = clsUserDataAccess.AddNewUser(this.PersonID, this.Username, clsCryptographics.Hashing(this.Password), this.IsActive);

            return (UserID != -1);
        }

        private bool _UpdateUser() {

            if (this._storedPasswordHash == this.Password) 
                return clsUserDataAccess.UpdateUser(UserID, PersonID, Username, Password, IsActive);
            else
                return clsUserDataAccess.UpdateUser(UserID, PersonID, Username, clsCryptographics.Hashing(this.Password), IsActive);
        }

        public bool Save() {

            switch (_Mode) {

                case enMode.AddNew: {

                    if (_AddNewUser()) {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else {

                        return false;
                    }
                }
                case enMode.Update: {

                    return _UpdateUser();
                }
            }

            return false;
        }

        public static bool IsUserExist(int UserID) => clsUserDataAccess.IsUserExist(UserID);

        public static bool IsUserExist(string Username) => clsUserDataAccess.IsUserExist(Username);

        public static bool IsPersonUser(int PersonID) => clsUserDataAccess.IsPersonUser(PersonID);

        public static DataTable GetAllUsers() => clsUserDataAccess.GetAllUsers();

        public static bool DeleteUser(int UserID) => clsUserDataAccess.DeleteUser(UserID);

        public static DataTable FilterUsers(string Column, string Filter) {

            return clsUserDataAccess.FilterUsers(clsUtil.RemoveChar(Column), Filter);
        }
    
    }
}