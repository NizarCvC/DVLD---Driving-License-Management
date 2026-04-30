using DVLD_Data_Access_Layer;
using My_Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer {

    public class clsDriver {

        private enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;

        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public clsPerson Person { get; set; }

        public clsDriver(int PersonID) {

            DriverID = -1;
            this.PersonID = PersonID;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;
            _Mode = enMode.AddNew;
        }

        private clsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate) {

            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
            _Mode = enMode.Update;
            Person = clsPerson.Find(PersonID);
        }

        public static clsDriver FindByDriverID(int DriverID) {

            int PersonID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (clsDriverDataAccess.GetDriverByDriverID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate)) 
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;
        }

        public static clsDriver FindByPersonID(int PersonID) {

            int DriverID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (clsDriverDataAccess.GetDriverByPersonID(ref DriverID, PersonID, ref CreatedByUserID, ref CreatedDate))
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;
        }

        private bool _AddNewDriver() {

            this.DriverID = clsDriverDataAccess.AddNewDriver(this.PersonID, this.CreatedByUserID, this.CreatedDate);

            return this.DriverID != -1;
        }

        private bool _UpdateDriver() => clsDriverDataAccess.UpdateDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);

        public bool Save() {

            switch (_Mode) {

                case enMode.AddNew: {

                    if (_AddNewDriver()) {

                         _Mode = enMode.Update;
                        return true;
                    }
                    else {

                        return false;
                    }
                }
                case enMode.Update: {

                    return _UpdateDriver();
                }
            }

            return false;
        }

        public static bool DeleteDriver(int DriverID) => clsDriverDataAccess.DeleteDriver(DriverID);

        public static bool IsDriverExists(int DriverID) => clsDriverDataAccess.IsDriverExists(DriverID);

        public static bool IsPersonDriver(int PersonID) => clsDriverDataAccess.IsPersonDriver(PersonID);

        public static DataTable GetAllDrivers() => clsDriverDataAccess.GetAllDrivers();

        public static DataTable FilterDrivers(string Column, string Filter) 
            => clsDriverDataAccess.FilterDrivers(clsUtil.RemoveChar(Column), Filter);
    
    }
}