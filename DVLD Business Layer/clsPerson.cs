using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data_Access_Layer;
using My_Libraries;

namespace DVLD_Business_Layer {

    public class clsPerson {

        private enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;

        private string _FirstName;
        private string _SecondName;
        private string _ThirdName;
        private string _LastName;
        private string _Email;
        private string _ImagePath;

        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName {

            get => _FirstName;

            set => _FirstName = clsUtil.UpperFirstLetter(value);
        }
        public string SecondName {

            get {

                return _SecondName;
            }

            set {

                _SecondName = string.IsNullOrEmpty(value) ? null :
                    clsUtil.UpperFirstLetter(value);
            }
        }
        public string ThirdName {

            get {

                return _ThirdName;
            }

            set {

                _ThirdName = string.IsNullOrEmpty(value) ? null :
                    clsUtil.UpperFirstLetter(value);
            }
        }
        public string LastName {

            get => _LastName;

            set => _LastName = clsUtil.UpperFirstLetter(value);
        }
        public string FullName {

            get => clsUtil.FullNameFormat(FirstName, LastName, SecondName, ThirdName);
        }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone {  get; set; }
        public string Email { 

            get => _Email;

            set => _Email = string.IsNullOrEmpty(value) ? null : value;
        }
        public short NationalityID { get; set; }
        public string ImagePath { 

            get => _ImagePath;

            set => _ImagePath = string.IsNullOrEmpty(value) ? null : value;
        }

        public clsCountry Country;

        public clsPerson() {

            PersonID = -1;
            NationalNo = string.Empty;
            FirstName = string.Empty;
            SecondName = null;
            ThirdName = null;
            LastName = string.Empty;
            DateOfBirth = DateTime.Now;
            Gender = string.Empty;
            Address = string.Empty;
            Phone = string.Empty;
            Email = null;
            NationalityID = -1;
            ImagePath = null;
            _Mode = enMode.AddNew;
        }

        private clsPerson(int PersonID, string NationalNo, string FirstName, string SecondName,
            string ThirdName, string LastName, DateTime DateOfBirth, string Gender, string Address,
            string Phone, string Email, short NationalityID, string ImagePath) {

            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityID = NationalityID;
            this.ImagePath = ImagePath;
            _Mode = enMode.Update;
            Country = clsCountry.Find(NationalityID);
        }

        public static clsPerson Find(int PersonID) {

            string NationalNo = "", FirstName = "", SecondName = "",
                ThirdName = "", LastName = "", Gender = "", Address = "", Phone = "",
                Email = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            short NationalityID = -1;

            if (clsPersonDataAccess.GetPersonInfoByID(PersonID, ref NationalNo,
                ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email,
                ref NationalityID, ref ImagePath)) {

                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName,
                    LastName, DateOfBirth, Gender, Address, Phone, Email,
                    NationalityID, ImagePath);
            }
            else {

                return null;
            }
        }
    
        public static clsPerson Find(string NationalNo) {

            int PersonID = -1;
            string FirstName = "", SecondName = "",
               ThirdName = "", LastName = "", Gender = "", Address = "", Phone = "",
               Email = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            short NationalityID = -1;

            if (clsPersonDataAccess.GetPersonInfoByNationalNo(ref PersonID, NationalNo,
                ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth,
                ref Gender, ref Address, ref Phone, ref Email,
                ref NationalityID, ref ImagePath)) {

                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName,
                    LastName, DateOfBirth, Gender, Address, Phone, Email,
                    NationalityID, ImagePath);
            }
            else {

                return null;
            }
        }

        public static bool IsPersonExist(int PersonID) => clsPersonDataAccess.IsPersonExist(PersonID);

        public static bool IsPersonExist(string NationalNo) => clsPersonDataAccess.IsPersonExist(NationalNo);

        public static DataTable GetAllPeople() => clsPersonDataAccess.GetAllPeople();

        public static bool DeletePerson(int PersonID) => clsPersonDataAccess.DeletePerson(PersonID);

        private bool _AddNewPerson() {

            this.PersonID = clsPersonDataAccess.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
                    this.LastName, this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email,
                    this.NationalityID, this.ImagePath);

            return this.PersonID != -1;
        }
    
        private bool _UpdatePerson() => clsPersonDataAccess.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName,
                this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gender,
                this.Address, this.Phone, this.Email, this.NationalityID, this.ImagePath);

        public bool Save() {

            switch (_Mode) {

                case enMode.AddNew: {

                    if (_AddNewPerson()) {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else {

                        return false;
                    }
                }
                case enMode.Update: {

                    return _UpdatePerson();
                }
            }

            return false;
        }

        public static DataTable FilterPeople(string Column, string Filter) 
            => clsPersonDataAccess.FilterData(clsUtil.RemoveChar(Column), Filter);

    }
}