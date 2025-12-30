using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer {

    public class clsLicense {

        private enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;

        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enum enIssueReason { FirstTime = 1, Renew = 2, ReplacementForLost = 3, ReplacementForDamaged = 4 }
        public enIssueReason IssueReason { get; set; }
        public int CreatedByUserID { get; set; }
        public clsDriver Driver { get; set; }
        public clsApplication Application { get; set; }
        public clsLicenseClass LicenseClass { get; set; }
        public bool IsDetained {

            get => clsDetainedLicense.IsLicenseDetained(this.LicenseID);
        }
        public clsDetainedLicense DetainedLicenseInfo { get; set; }

        public clsLicense() {

            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = string.Empty;
            PaidFees = -1;
            IsActive = false;
            IssueReason = 0;
            CreatedByUserID = -1;
            _Mode = enMode.AddNew;
        }

        private clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClassID,
                   DateTime IssueDate, DateTime ExpirationDate, string Notes,
                   decimal PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID) {

            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicenseClassID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;
            _Mode = enMode.Update;
            Driver = clsDriver.FindByDriverID(DriverID);
            Application = clsApplication.Find(ApplicationID);
            LicenseClass = clsLicenseClass.Find(LicenseClassID);
            DetainedLicenseInfo = clsDetainedLicense.FindByLicenseID(LicenseID);
        }

        public static clsLicense FindByLicenseID(int LicenseID) {

            int LicenseClassID = -1, ApplicationID = -1, DriverID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = string.Empty;
            decimal PaidFees = -1;
            bool IsActive = false;
            byte IssueReason = 0;

            if (clsLicenseDataAccess.GetLicenseByLicenseID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID,
                ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID)) {

                return new clsLicense(LicenseID, ApplicationID, DriverID,
                    LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees,
                    IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            }
            else {

                return null;
            }
        }

        public static clsLicense FindByDriverID(int DriverID) {

            int LicenseClassID = -1, ApplicationID = -1, LicenseID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = string.Empty;
            decimal PaidFees = -1;
            bool IsActive = false;
            byte IssueReason = 0;

            if (clsLicenseDataAccess.GetLicenseByDriverID(ref LicenseID, ref ApplicationID, DriverID, ref LicenseClassID,
                ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID)) {

                return new clsLicense(LicenseID, ApplicationID, DriverID,
                    LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees,
                    IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            }
            else {

                return null;
            }
        }

        public static clsLicense FindByApplicationID(int ApplicationID) {

            int LicenseClassID = -1, DriverID = -1, LicenseID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = string.Empty;
            decimal PaidFees = -1;
            bool IsActive = false;
            byte IssueReason = 0;

            if (clsLicenseDataAccess.GetLicenseByApplicationID(ref LicenseID, ApplicationID, ref DriverID, ref LicenseClassID,
                ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID)) {

                return new clsLicense(LicenseID, ApplicationID, DriverID,
                    LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees,
                    IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            }
            else {

                return null;
            }
        }

        private bool _AddNewLicense() {

            this.LicenseID = clsLicenseDataAccess.AddNewLicense(this.ApplicationID,
                this.DriverID, this.LicenseClassID, this.IssueDate, this.ExpirationDate,
                this.Notes, this.PaidFees, this.IsActive, (byte)this.IssueReason,
                this.CreatedByUserID);

            return this.LicenseID != 0;
        }

        private bool _UpdateLicense() => clsLicenseDataAccess.UpdateLicense(this.LicenseID, this.ApplicationID,
                this.DriverID, this.LicenseClassID, this.IssueDate, this.ExpirationDate,
                this.Notes, this.PaidFees, this.IsActive, (byte)this.IssueReason,
                this.CreatedByUserID);

        public bool Save() {

            switch (_Mode) {

                case enMode.AddNew: {

                    if (_AddNewLicense()) {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else {

                        return false;
                    }
                }
                case enMode.Update: {

                    return _UpdateLicense();
                }
            }

            return false;
        }

        public static bool DeleteLicense(int LicenseID) => clsLicenseDataAccess.DeleteLicense(LicenseID);

        public static bool DeactivateLicense(int LicenseID) => clsLicenseDataAccess.DeactivateLicense(LicenseID);

        public static bool IsLicenseExists(int LicenseID) => clsLicenseDataAccess.IsLicenseExists(LicenseID);

        public static DataTable GetAllLocalLicensesForDriver(int DriverID) 
            => clsLicenseDataAccess.GetAllLocalLicensesForDriver(DriverID);

        public static bool IsLocalLicenseHasAnActiveInternationalLicense(int LicenseID) 
            => clsLicenseDataAccess.IsLocalLicenseHasAnActiveInternationalLicense(LicenseID);

        public static bool IsLicenseActive(int LicenseID) => clsLicenseDataAccess.IsLicenseActive(LicenseID);

        public bool IsLicenseExpired() => this.ExpirationDate <= DateTime.Now;

        public clsLicense RenewLicense(string notes, int createdByUserID) {

            clsApplication RenewLicenseApp = clsApplication.CreateRenewDrivingLicenseApplication();
            RenewLicenseApp.ApplicantPersonID = this.Driver.PersonID;
            RenewLicenseApp.PersonInfo = clsPerson.Find(this.Driver.PersonID);
            RenewLicenseApp.CreatedByUserID = createdByUserID;
            RenewLicenseApp.CreatedByUserInfo = clsUser.Find(createdByUserID);

            if (!RenewLicenseApp.Save())
                return null;

            clsLicense RenewedLicense = new clsLicense() {

                Application = clsApplication.Find(RenewLicenseApp.ApplicationID),
                ApplicationID = RenewLicenseApp.ApplicationID,
                DriverID = this.DriverID,
                Driver = this.Driver,
                LicenseClassID = this.LicenseClassID,
                LicenseClass = this.LicenseClass,
                IssueDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears(this.LicenseClass.DefaultValidityLength),
                Notes = notes,
                PaidFees = this.PaidFees,
                IsActive = true,
                IssueReason = enIssueReason.Renew,
                CreatedByUserID = createdByUserID,
            };

            if (!RenewedLicense.Save())
                return null;

            DeactivateLicense(this.LicenseID);

            return RenewedLicense;
        }

        public clsLicense ReplaceFor(enIssueReason issueReason, int createdByUserID) {

            if (!(issueReason == enIssueReason.ReplacementForDamaged || issueReason == enIssueReason.ReplacementForLost))
                return null;

            clsApplication ReplaceForApplication = issueReason == 
                enIssueReason.ReplacementForDamaged ?
                clsApplication.CreateReplacementForDamagedDrivingLicenseApplication() :
                clsApplication.CreateReplacementForLostDrivingLicenseApplication();

            ReplaceForApplication.ApplicantPersonID = this.Driver.PersonID;
            ReplaceForApplication.PersonInfo = clsPerson.Find(this.Driver.PersonID);
            ReplaceForApplication.CreatedByUserID = createdByUserID;
            ReplaceForApplication.CreatedByUserInfo = clsUser.Find(createdByUserID);

            if (!ReplaceForApplication.Save())
                return null;

            clsLicense ReplacedLicense = new clsLicense() {

                Application = ReplaceForApplication,
                ApplicationID = ReplaceForApplication.ApplicationID,
                DriverID = this.DriverID,
                Driver = this.Driver,
                LicenseClassID = this.LicenseClassID,
                LicenseClass = this.LicenseClass,
                IssueDate = this.IssueDate,
                ExpirationDate = this.ExpirationDate,
                Notes = this.Notes,
                PaidFees = 0,
                IsActive = true,
                IssueReason = issueReason,
                CreatedByUserID = createdByUserID
            };

            if (!ReplacedLicense.Save())
                return null;

            DeactivateLicense(this.LicenseID);

            return ReplacedLicense;
        }

        public clsDetainedLicense DetainLicense(decimal fineFees, int createdByUserID) {

            if (fineFees < 1) 
                return null;

            clsDetainedLicense detainedLicense = new clsDetainedLicense() {

                LicenseID = this.LicenseID,
                DetainDate = DateTime.Now,
                FineFees = fineFees,
                CreatedByUserID = createdByUserID,
                CreatedByUserInfo = clsUser.Find(createdByUserID),
                IsReleased = false
            };

            return detainedLicense.Save() ? detainedLicense : null;
        }

        public bool ReleasedDetainedLicense(int releasedByUserID) {

            clsApplication ReleaseDetainedLicenseApp = clsApplication.CreateReleaseDetainedDrivingLicsenseApplication();
            ReleaseDetainedLicenseApp.ApplicantPersonID = this.Driver.PersonID;
            ReleaseDetainedLicenseApp.PersonInfo = clsPerson.Find(this.Driver.PersonID);
            ReleaseDetainedLicenseApp.CreatedByUserID = releasedByUserID;
            ReleaseDetainedLicenseApp.CreatedByUserInfo = clsUser.Find(releasedByUserID);

            if (!ReleaseDetainedLicenseApp.Save())
                return false;

            this.DetainedLicenseInfo.IsReleased = true;
            this.DetainedLicenseInfo.ReleaseDate = DateTime.Now;
            this.DetainedLicenseInfo.ReleasedByUserID = releasedByUserID;
            this.DetainedLicenseInfo.ReleasedByUserInfo = clsUser.Find(releasedByUserID);
            this.DetainedLicenseInfo.ReleaseApplicationID = ReleaseDetainedLicenseApp.ApplicationID;
            this.DetainedLicenseInfo.ReleaseApplication = ReleaseDetainedLicenseApp;

            return DetainedLicenseInfo.Save();
        }

    }
}