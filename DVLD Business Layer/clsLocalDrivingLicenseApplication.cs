using DVLD_Data_Access_Layer;
using My_Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Business_Layer {

    public class clsLocalDrivingLicenseApplication { 

        private enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;

        public int LDLApplicationID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public clsApplication Application { get; set; }

        public clsLicenseClass LicenseClass { get; set; }

        public clsLocalDrivingLicenseApplication() {

            LDLApplicationID = -1;
            ApplicationID = -1;
            LicenseClassID = -1;
            _Mode = enMode.AddNew;
            this.Application = clsApplication.CreateLocalDrivingLicenseApplication();
        }

        private clsLocalDrivingLicenseApplication(int LDLApplicationID, int ApplicationID, int LicenseClassID) {

            this.LDLApplicationID = LDLApplicationID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
            _Mode = enMode.Update;
            this.Application = clsApplication.Find(ApplicationID);
            this.LicenseClass = clsLicenseClass.Find(LicenseClassID);
        }
    
        public static clsLocalDrivingLicenseApplication FindByLDLAppID(int LDLApplicationID) {

            int ApplicationID = -1, LicenseClassID = -1;

            if (clsLocalDrivingLicenseApplicationDataAccess.GetLDLApplicationByLDLAppID(LDLApplicationID, ref ApplicationID, ref LicenseClassID)) 
                return new clsLocalDrivingLicenseApplication(LDLApplicationID, ApplicationID, LicenseClassID);
            else 
                return null;
        }

        public static clsLocalDrivingLicenseApplication FindByAppID(int ApplicationID) {

            int LDLApplicationID = -1, LicenseClassID = -1;

            if (clsLocalDrivingLicenseApplicationDataAccess.GetLDLApplicationByApplicationID(ref LDLApplicationID, ApplicationID, ref LicenseClassID))
                return new clsLocalDrivingLicenseApplication(LDLApplicationID, ApplicationID, LicenseClassID);
            else
                return null;
        }

        private bool _AddNewLDLApplication() {

            this.LDLApplicationID = clsLocalDrivingLicenseApplicationDataAccess.AddNewLDLApplication(this.ApplicationID, this.LicenseClassID);

            return this.LDLApplicationID != -1;
        }

        private bool _UpdateLDLApplication() 
            => clsLocalDrivingLicenseApplicationDataAccess.UpdateLDLApplication(LDLApplicationID, ApplicationID, LicenseClassID);

        public bool Save() {

            if (!Application.Save())
                return false;

            this.ApplicationID = this.Application.ApplicationID;

            switch (_Mode) {

                case enMode.AddNew: {

                    if (_AddNewLDLApplication()) {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else {

                        return false;
                    }
                }
                case enMode.Update: {

                    return _UpdateLDLApplication();
                }
            }

            return false;
        }

        public static bool DeleteLDLApplication(int LDLApplicationID) {

            int ApplicationID = -1, LicenseClassID = -1;

            if (clsLocalDrivingLicenseApplicationDataAccess.GetLDLApplicationByLDLAppID(LDLApplicationID, ref ApplicationID, ref LicenseClassID)) {

                return clsLocalDrivingLicenseApplicationDataAccess.DeleteLDLApplication(LDLApplicationID, ApplicationID);
            }

            return false;
        }

        public static bool CancelLDLApplication(int LDLApplicationID)
            => clsLocalDrivingLicenseApplicationDataAccess.CancelLDLApplication(LDLApplicationID);

        public static bool IsLDLApplicationExist(int LDLApplicationID) 
            => clsLocalDrivingLicenseApplicationDataAccess.IsLDLApplicationExist(LDLApplicationID);

        public static DataTable GetAllLDLApplications() 
            => clsLocalDrivingLicenseApplicationDataAccess.GetAllLDLApplications();

        public static DataTable FilterLDLApplications(string Column, string Filter) 
            => clsLocalDrivingLicenseApplicationDataAccess.FilterLDLApplications(clsUtil.RemoveChar(Column), Filter);

        public static bool PersonHasNewLDLApplicationInLicenseClass(int ApplicantPersonID, int LicenseClassID) 
            => clsLocalDrivingLicenseApplicationDataAccess.PersonHasNewLDLApplicationInLicenseClass(ApplicantPersonID, LicenseClassID);

        public static bool IsPersonHasAnActiveLicenseInClass(int ApplicantPersonID, int LicenseClassID) 
            => clsLocalDrivingLicenseApplicationDataAccess.PersonHasAnActiveLicenseInClass(ApplicantPersonID, LicenseClassID);

        public bool IsPassedAllTests() {

            return clsTest.NumberOfPassedTests(this.LDLApplicationID) == 3;
        }

        public static byte NumberOfTrailsPerTest(int LDLApplication, int TestTypeID) 
            => clsLocalDrivingLicenseApplicationDataAccess.NumberOfTrailsPerTest(LDLApplication, TestTypeID);

        public static bool IsThereAnActiveScheduledTest(int LDLApplicationID, int TestTypeID) {

            return clsLocalDrivingLicenseApplicationDataAccess.IsThereAnActiveScheduledTest(LDLApplicationID, TestTypeID);
        }

        public static bool IsHavePassedTest(int LDLApplicationID, int TestTypeID) {

            return clsLocalDrivingLicenseApplicationDataAccess.IsHavePassedTest(LDLApplicationID, TestTypeID);
        }

        public static bool IsHaveFaildTest(int LDLApplicationID, int TestTypeID) {

            return clsLocalDrivingLicenseApplicationDataAccess.IsHaveFaildTest(LDLApplicationID, TestTypeID);
        }

        public int IssueLicenseForTheFirstTime(string notes, int createdByUserID) {

            int DriverID = -1;
            clsDriver driver = clsDriver.FindByPersonID(Application.ApplicantPersonID);

            if (driver == null) {

                driver = new clsDriver(Application.ApplicantPersonID) {

                    CreatedByUserID = createdByUserID,
                    CreatedDate = DateTime.Now,
                };

                if (driver.Save())
                    DriverID = driver.DriverID;
                else
                    return -1;
            }
            else {

                DriverID = driver.DriverID;
            }

            clsLicense NewLicense = new clsLicense();
            NewLicense.ApplicationID = this.ApplicationID;
            NewLicense.DriverID = DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(this.LicenseClass.DefaultValidityLength);
            NewLicense.Notes = notes;
            NewLicense.PaidFees = this.LicenseClass.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = clsLicense.enIssueReason.FirstTime;
            NewLicense.CreatedByUserID = createdByUserID;

            if (NewLicense.Save()) {

                this.Application.SetComplete();
                return NewLicense.LicenseID;
            }
            else {

                return -1;
            }
        }

    }
}