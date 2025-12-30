using DVLD_Data_Access_Layer;
using My_Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer {

    public class clsInternationalLicense {

        private enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;

        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LocalLicneseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public clsApplication Application { get; set; }
        public clsDriver Driver { get; set; }

        public clsInternationalLicense() {

            InternationalLicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LocalLicneseID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            IsActive = false;
            CreatedByUserID = -1;
            _Mode = enMode.AddNew;
            Application = clsApplication.CreateNewInernationalLicenseApplication();
        }

        private clsInternationalLicense(int InternationalLicenseID, int ApplicationID,
            int DriverID, int LocalLicneseID, DateTime IssueDate, DateTime ExpirationDate,
            bool IsActive, int CreatedByUserID) {

            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LocalLicneseID = LocalLicneseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;
            _Mode = enMode.Update;
            Application = clsApplication.Find(ApplicationID);
            Driver = clsDriver.FindByDriverID(DriverID);
        }

        public static clsInternationalLicense Find(int InternationalLicenseID) {

            int ApplicationID = -1, DriverID = -1, LocalLicneseID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            bool IsActive = false;

            if (clsInternationalLicenseDataAccess.GetInternationalLicenseByID(InternationalLicenseID, ref ApplicationID,
                    ref DriverID, ref LocalLicneseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID)) {

                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, LocalLicneseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            }
            else {

                return null;
            }
        }

        private bool _AddNewInternationalLicense() {

            this.InternationalLicenseID = clsInternationalLicenseDataAccess.AddNewInternationalLicense(this.ApplicationID,
                this.DriverID, this.LocalLicneseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);

            return this.InternationalLicenseID != 0;
        }

        private bool _UpdateInternationalLicense() => clsInternationalLicenseDataAccess.UpdateInternationalLicense(this.InternationalLicenseID,
                this.ApplicationID, this.DriverID, this.LocalLicneseID, this.IssueDate,
                this.ExpirationDate, this.IsActive, this.CreatedByUserID);

        public bool Save() {

            if (!this.Application.Save()) 
                return false;

            this.ApplicationID = this.Application.ApplicationID;

            switch (_Mode) {

                case enMode.AddNew: {

                    if (_AddNewInternationalLicense()) {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else {

                        return false;
                    }
                }
                case enMode.Update: {

                    return _UpdateInternationalLicense();
                }
            }

            return false;
        }

        public static bool DeleteInternationalLicense(int InternationalLicenseID) => clsInternationalLicenseDataAccess.DeleteInternationalLicense(InternationalLicenseID);

        public static bool IsInternationalLicenseExists(int InternationalLicenseID) => clsInternationalLicenseDataAccess.IsInternationalLicenseExists(InternationalLicenseID);

        public static DataTable GetAllInternationalLicenses() => clsInternationalLicenseDataAccess.GetAllInternationalLicenses();

        public static DataTable GetAllInternationalLicensesForDriver(int DriverID) => clsInternationalLicenseDataAccess.GetAllInternationalLicensesForDriver(DriverID);

        public static DataTable FilterInternationalLicenses(string Column, string Filter) => clsInternationalLicenseDataAccess.FilterInternationalLicenses(clsUtil.RemoveChar(Column), Filter);

    }
}