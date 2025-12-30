using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data_Access_Layer;

namespace DVLD_Business_Layer {

    public class clsApplication {

        private enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;

        public enum enApplicationStatus { Cancelled = 0, New = 1, Completed = 2 };

        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public clsApplicationType ApplicationTypeInfo;

        [Obsolete("Use ApplicationStatus instead")]
        public byte ApplicationStatusTemp { get; set; }
        public enApplicationStatus ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo;

        public clsApplication() {

            ApplicationID = -1;
            ApplicantPersonID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = -1;
            ApplicationStatusTemp = 0; 
            LastStatusDate = DateTime.Now;
            PaidFees = -1;
            CreatedByUserID = -1;
            _Mode = enMode.AddNew;
        }

        private clsApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
            int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate,
            decimal PaidFees, int CreatedByUserID) {

            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatusTemp = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            _Mode = enMode.Update;
            PersonInfo = clsPerson.Find(ApplicantPersonID);
            ApplicationTypeInfo = clsApplicationType.Find(ApplicationTypeID);
            CreatedByUserInfo = clsUser.Find(ApplicationTypeID);
        }

        public static clsApplication Find(int ApplicationID) {

            int ApplicantPersonID = -1, ApplicationTypeID = -1, CreatedByUserID = -1;
            DateTime ApplicationDate = DateTime.Now, LastStatusDate = DateTime.Now;
            byte ApplicationStatus = 0;
            decimal PaidFees = -1;

            if (clsApplicationDataAccess.GetApplicationInfoByID(ApplicationID, ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID)) 
                return new clsApplication(ApplicationID,ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            else 
                return null;
        }

        private bool _AddNewApplication() {

            this.ApplicationID = clsApplicationDataAccess.AddNewApplication(this.ApplicantPersonID,
                this.ApplicationDate, this.ApplicationTypeID, this.ApplicationStatusTemp,
                this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return this.ApplicationID != -1;
        }

        private bool _UpdateApplication() => clsApplicationDataAccess.UpdateApplication(
                this.ApplicationID, this.ApplicantPersonID,
                this.ApplicationDate, this.ApplicationTypeID, this.ApplicationStatusTemp,
                this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

        public bool Save() {

            switch (_Mode) {

                case enMode.AddNew: {

                    if (_AddNewApplication()) {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else {

                        return false;
                    }
                }
                case enMode.Update: {

                    return _UpdateApplication();
                }
            }

            return false;
        }
    
        public static bool DeleteApp(int ApplicationID) 
            => clsApplicationDataAccess.DeleteApplication(ApplicationID);

        public static bool IsApplicationExist(int ApplicationID) 
            => clsApplicationDataAccess.IsApplicationExist(ApplicationID);

        public static clsApplication CreateLocalDrivingLicenseApplication() {

            // Object initializer
            return new clsApplication {

                ApplicationDate = DateTime.Now.Date,
                ApplicationTypeID = (int)clsApplicationType.enApplicationType.NewDrivingLicense,
                ApplicationStatusTemp = (int)enApplicationStatus.New,
                LastStatusDate = DateTime.Now.Date,
                PaidFees = clsApplicationType.Find((int)clsApplicationType.enApplicationType.NewDrivingLicense).Fees
            };
        }
        
        public static clsApplication CreateRetakeTestApplication() {

            // Object initializer
            return new clsApplication {

                ApplicationDate = DateTime.Now.Date,
                ApplicationTypeID = (int)clsApplicationType.enApplicationType.RetakeTest,
                ApplicationStatusTemp = (int)enApplicationStatus.New,
                LastStatusDate = DateTime.Now.Date,
                PaidFees = clsApplicationType.Find((int)clsApplicationType.enApplicationType.RetakeTest).Fees
            };
        }
        
        public static clsApplication CreateNewInernationalLicenseApplication() {

            // Object initializer
            return new clsApplication {

                ApplicationDate = DateTime.Now.Date,
                ApplicationTypeID = (int)clsApplicationType.enApplicationType.NewInternationalLicense,
                ApplicationStatusTemp = (int)enApplicationStatus.Completed,
                LastStatusDate = DateTime.Now.Date,
                PaidFees = clsApplicationType.Find((int)clsApplicationType.enApplicationType.NewInternationalLicense).Fees
            };
        }
        
        public static clsApplication CreateRenewDrivingLicenseApplication() {

            return new clsApplication {

                ApplicationDate = DateTime.Now.Date,
                ApplicationTypeID = (int)clsApplicationType.enApplicationType.RenewDrivingLicense,
                ApplicationStatusTemp = (int)enApplicationStatus.Completed,
                LastStatusDate = DateTime.Now.Date,
                PaidFees = clsApplicationType.Find((int)clsApplicationType.enApplicationType.RenewDrivingLicense).Fees
            };
        }
        
        public static clsApplication CreateReplacementForLostDrivingLicenseApplication() {

            return new clsApplication {

                ApplicationDate = DateTime.Now.Date,
                ApplicationTypeID = (int)clsApplicationType.enApplicationType.ReplaceLostDrivingLicense,
                ApplicationStatusTemp = (int)enApplicationStatus.Completed,
                LastStatusDate = DateTime.Now.Date,
                PaidFees = clsApplicationType.Find((int)clsApplicationType.enApplicationType.ReplaceLostDrivingLicense).Fees
            };
        }
        
        public static clsApplication CreateReplacementForDamagedDrivingLicenseApplication() {

            return new clsApplication {

                ApplicationDate = DateTime.Now.Date,
                ApplicationTypeID = (int)clsApplicationType.enApplicationType.ReplaceDamagedDrivingLicense,
                ApplicationStatusTemp = (int)enApplicationStatus.Completed,
                LastStatusDate = DateTime.Now.Date,
                PaidFees = clsApplicationType.Find((int)clsApplicationType.enApplicationType.ReplaceDamagedDrivingLicense).Fees
            };
        }
        
        public static clsApplication CreateReleaseDetainedDrivingLicsenseApplication() {

            return new clsApplication {

                ApplicationDate = DateTime.Now.Date,
                ApplicationTypeID = (int)clsApplicationType.enApplicationType.ReleaseDetainedDrivingLicsense,
                ApplicationStatusTemp = (int)enApplicationStatus.Completed,
                LastStatusDate = DateTime.Now.Date,
                PaidFees = clsApplicationType.Find((int)clsApplicationType.enApplicationType.ReleaseDetainedDrivingLicsense).Fees
            };
        }

        // New methods must be used in the system
        public bool CancelApp()
            => clsApplicationDataAccess
            .UpdateStatus(this.ApplicationID, (int)enApplicationStatus.Cancelled);

        public bool SetComplete()
            => clsApplicationDataAccess
            .UpdateStatus(this.ApplicationID, (int)enApplicationStatus.Completed);

        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID) {

            return clsApplicationDataAccess.DoesPersonHaveActiveApplication(PersonID, ApplicationTypeID);
        }

        public bool DoesPersonHaveActiveApplication(int ApplicationTypeID) {

            return DoesPersonHaveActiveApplication(this.ApplicantPersonID, ApplicationTypeID);
        }

        public static int GetActiveApplicationID(int PersonID, clsApplicationType.enApplicationType ApplicationTypeID) {

            return clsApplicationDataAccess.GetActiveApplicationID(PersonID, (int)ApplicationTypeID);
        }

        public int GetActiveApplicationID(clsApplicationType.enApplicationType ApplicationTypeID) {

            return GetActiveApplicationID(this.ApplicantPersonID, ApplicationTypeID);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, clsApplicationType.enApplicationType ApplicationTypeID, int LicenseClassID) {

            return clsApplicationDataAccess.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }

    }
}