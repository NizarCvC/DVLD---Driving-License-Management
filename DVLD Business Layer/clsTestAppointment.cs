using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer {

    public class clsTestAppointment {

        private enum enMode { AddNew, Update}
        private enMode _Mode = enMode.AddNew;

        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LDLApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }
        public clsLocalDrivingLicenseApplication LDLApplication { get; set; }
        public clsApplication RetakeTestApplication { get; set; }

        public clsTestAppointment(int LDLApplicationID) {

            TestAppointmentID = -1;
            TestTypeID = -1;
            this.LDLApplicationID = LDLApplicationID;
            AppointmentDate = DateTime.Now;
            PaidFees = -1;
            CreatedByUserID = -1;
            IsLocked = true;
            RetakeTestApplicationID = -1;
            _Mode = enMode.AddNew;
            LDLApplication = clsLocalDrivingLicenseApplication.FindByLDLAppID(LDLApplicationID);
        }

        public clsTestAppointment(int LDLApplicationID, int RetakeTestApplicationID) {

            TestAppointmentID = -1;
            TestTypeID = -1;
            this.LDLApplicationID = LDLApplicationID;
            AppointmentDate = DateTime.Now;
            PaidFees = -1;
            CreatedByUserID = -1;
            IsLocked = true;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            _Mode = enMode.AddNew;
            LDLApplication = clsLocalDrivingLicenseApplication.FindByLDLAppID(LDLApplicationID);
            RetakeTestApplication = clsApplication.Find(RetakeTestApplicationID);
        }

        private clsTestAppointment(int TestAppointmentID, int TestTypeID, int LDLApplicationID,
            DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked, 
            int RetakeTestApplicationID) {

            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LDLApplicationID = LDLApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            _Mode = enMode.Update;
            LDLApplication = clsLocalDrivingLicenseApplication.FindByLDLAppID(LDLApplicationID);
            if (RetakeTestApplicationID != -1) RetakeTestApplication = clsApplication.Find(RetakeTestApplicationID);
        }

        public static clsTestAppointment Find(int TestAppointmentID) {

            int TestTypeID = -1, LDLApplicationID = -1, CreatedByUserID = -1, RetakeTestApplicationID = -1;
            decimal PaidFees = -1;
            DateTime AppointmentDate = DateTime.Now;
            bool IsLocked = true;

            if (clsTestAppointmentDataAccess.GetTestAppointmentByID(TestAppointmentID,
                ref TestTypeID, ref LDLApplicationID, ref AppointmentDate, ref PaidFees,
                ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID)) {

                return new clsTestAppointment(TestAppointmentID, TestTypeID, LDLApplicationID,
                    AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            }
            else {

                return null;
            }
        }

        private bool _AddNewTestAppointment() {

            this.TestAppointmentID = clsTestAppointmentDataAccess.AddNewTestAppointment(this.TestTypeID,
                this.LDLApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID,
                this.IsLocked, this.RetakeTestApplicationID);

            return (this.TestAppointmentID != -1);
        }

        private bool _UpdateTestAppointment() {

            return clsTestAppointmentDataAccess.UpdateTestAppointment(this.TestAppointmentID, this.TestTypeID,
                this.LDLApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID,
                this.IsLocked, this.RetakeTestApplicationID);
        }

        public bool Save() {

            switch (_Mode) {

                case enMode.AddNew: {

                    if (_AddNewTestAppointment()) {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else {

                        return false;
                    }
                }
                case enMode.Update: {

                    return _UpdateTestAppointment();
                }
            }

            return false;
        }

        public static bool DeleteTestAppointment(int TestAppointmentID) {

            return clsTestAppointmentDataAccess.DeleteTestAppointment(TestAppointmentID);
        }

        public static bool LockTestAppointment(int TestAppointmentID) {

            return clsTestAppointmentDataAccess.LockTestAppointment(TestAppointmentID);
        }

        public static bool IsTestAppointmentExists(int TestAppointmentID) {

            return clsTestAppointmentDataAccess.IsTestAppointmentExists(TestAppointmentID);
        }

        public static bool IsTestAppointmentHaveRetakeTestApp(int TestAppointmentID) {

            return clsTestAppointmentDataAccess.IsTestAppointmentHasRetakeTestApp(TestAppointmentID);
        }

        public static DataTable GetAllAppointmentsByLDLAppID(int LDLApplicatioID, int TestTypeID) {

            return clsTestAppointmentDataAccess.GetAllAppointmentsByLDLAppID(LDLApplicatioID, TestTypeID);
        }

    }
}