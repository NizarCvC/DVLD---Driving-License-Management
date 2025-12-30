using DVLD_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer {

    public class clsTest {

        private enum enMode { AddNew, Update}
        private enMode _Mode = enMode.AddNew;

        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public clsTestAppointment TestAppointment { get; set; }

        public clsTest(int TestAppointmentID) {

            TestID = -1;
            this.TestAppointmentID = TestAppointmentID;
            TestResult = false;
            Notes = string.Empty;
            CreatedByUserID = -1;
            _Mode = enMode.AddNew;
            TestAppointment = clsTestAppointment.Find(TestAppointmentID);
        }

        private clsTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID) {

            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
            _Mode = enMode.Update;
            TestAppointment = clsTestAppointment.Find(TestAppointmentID);
        }

        public static clsTest Find(int TestID) {

            int TestAppointmentID = -1, CreatedByUserID = -1;
            string Notes = string.Empty;
            bool TestResult = false;

            if (clsTestDataAccess.GetTestByID(TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID))
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            else
                return null;
        }

        private bool _AddNewTest() {

            this.TestID = clsTestDataAccess.AddNewTest(
                this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);

            return this.TestID != -1;
        }

        private bool _UpdateTest() => clsTestDataAccess.UpdateTest(
            TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);

        public bool Save() {

            if (!TestAppointment.Save())
                return false;

            this.TestAppointmentID = TestAppointment.TestAppointmentID;

            switch (_Mode) {

                case enMode.AddNew: {

                    if (_AddNewTest()) {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else {

                        return false;
                    }
                }
                case enMode.Update: {

                    return _UpdateTest();
                }
            }

            return false;
        }

        public static bool DeleteTest(int TestID) => clsTestDataAccess.DeleteTest(TestID);

        public static bool IsTestExists(int TestID) => clsTestDataAccess.IsTestExists(TestID);

        public static sbyte NumberOfPassedTests(int LDLApplicationID)
            => clsTestDataAccess.NumberOfPassedTests(LDLApplicationID);

    }
}