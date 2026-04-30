using DVLD_Data_Access_Layer;
using My_Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer {

    public class clsDetainedLicense {

        private enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;

        public int DetainID { get; set; }              
        public int LicenseID { get; set; }             
        public DateTime DetainDate { get; set; }       
        public decimal FineFees { get; set; }          
        public int CreatedByUserID { get; set; }       
        public bool IsReleased { get; set; }           
        public DateTime ReleaseDate { get; set; }     
        public int ReleasedByUserID { get; set; }     
        public int ReleaseApplicationID { get; set; }
        public clsApplication ReleaseApplication { get; set; }
        public clsUser CreatedByUserInfo { get; set; }
        public clsUser ReleasedByUserInfo { get; set; }

        public clsDetainedLicense() {

            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now;   
            this.FineFees = 0;            
            this.CreatedByUserID = -1;
            this.IsReleased = false;        
            this.ReleaseDate = DateTime.MinValue; 
            this.ReleasedByUserID = -1;
            this.ReleaseApplicationID = -1;
            _Mode = enMode.AddNew;
        }

        private clsDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate, decimal FineFees,
            int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID) {

            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;
            _Mode = enMode.Update;
            if (ReleaseApplicationID != -1) ReleaseApplication = clsApplication.Find(ReleaseApplicationID);
            CreatedByUserInfo = clsUser.Find(CreatedByUserID);
            ReleasedByUserInfo = clsUser.Find(ReleasedByUserID);
        }

        public static clsDetainedLicense FindByDetainID(int DetainID) {

            int LicenseID = -1, CreatedByUserID = -1, ReleasedByUserID = -1, ReleaseApplicationID = -1;
            DateTime DetainDate = DateTime.Now, ReleaseDate = DateTime.MinValue;
            decimal FineFees = -1;
            bool IsReleased = false;

            if (clsDetainedLicenseDataAccess.GetDetainedLicenseInfoByDetainID(DetainID, ref LicenseID, ref DetainDate, ref FineFees,
                    ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID)) {

                return new clsDetainedLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate,
                    ReleasedByUserID, ReleaseApplicationID);
            }
            else {

                return null;
            }
        }

        public static clsDetainedLicense FindByLicenseID(int LicenseID) {

            int DetainID = -1, CreatedByUserID = -1, ReleasedByUserID = -1, ReleaseApplicationID = -1;
            DateTime DetainDate = DateTime.Now, ReleaseDate = DateTime.MinValue;
            decimal FineFees = -1;
            bool IsReleased = false;

            if (clsDetainedLicenseDataAccess.GetDetainedLicenseInfoByLicenseID(ref DetainID, LicenseID, ref DetainDate, ref FineFees,
                    ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID)) {

                return new clsDetainedLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate,
                    ReleasedByUserID, ReleaseApplicationID);
            }
            else {

                return null;
            }
        }

        private bool _AddNewDetainedLicense() {

            this.DetainID = clsDetainedLicenseDataAccess.AddNewDetainedLicense(
                this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID,
                this.IsReleased, this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID);

            return this.DetainID != -1;
        }

        private bool _UpdateDetainedLicense() => clsDetainedLicenseDataAccess.UpdateDetainedLicense(this.DetainID, this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID,
                this.IsReleased, this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID);

        public bool Save() {

            switch (_Mode) {

                case enMode.AddNew: {

                    if (_AddNewDetainedLicense()) {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                case enMode.Update: {

                    if (!ReleaseApplication.Save())
                        return false;

                    this.ReleaseApplicationID = this.ReleaseApplication.ApplicationID;
                    return _UpdateDetainedLicense();
                }
            }

            return false;
        }

        public static bool DeleteDetainedLicense(int DetainID) => clsDetainedLicenseDataAccess.DeleteDetainedLicense(DetainID);

        public static DataTable GetAllDetainedLicenses() => clsDetainedLicenseDataAccess.GetAllDetainedLicenses();

        public static bool IsDetainedLicenseExist(int DetainID) => clsDetainedLicenseDataAccess.IsDetainedLicenseExists(DetainID);

        public static bool IsLicenseDetained(int LicenseID) => clsDetainedLicenseDataAccess.IsLicenseDetained(LicenseID);

        public static DataTable FilterDetainedLicenses(string Column, string Filter) => clsDetainedLicenseDataAccess.FilterDetainedLicenses(clsUtil.RemoveChar(Column), Filter);

    }
}