using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Manage_LDL_Applications {

    public partial class frmTakeTest : Form {

        private enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 }
        private enTestType _TestType = enTestType.VisionTest;
        private enum enAppType { SceduleTest = 1, RetakeTest = 2 }
        private enAppType _AppType = enAppType.SceduleTest;

        private int _TestAppointmentID;
        private clsTest _Test;

        public frmTakeTest(int TestAppointmentID, int TestType, byte AppType = 1) {

            InitializeComponent();

            _TestAppointmentID = TestAppointmentID;
            _TestType = (enTestType)TestType;
            _AppType = (enAppType)AppType;
        }

        private void frmTakeTest_Load(object sender, EventArgs e) {

            _DisplayTestType();
            _LoadData();
        }

        private void _LoadData() {

            _Test = new clsTest(_TestAppointmentID);
            _DisplayTestAppointmentInfo(_Test.TestAppointment);
        }

        private void btnSave_Click(object sender, EventArgs e) {

            if (MessageBox.Show("Are you sure you want to save this test result?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            _Test.TestResult = _GetTestResult();
            _Test.TestAppointment.IsLocked = true;
            _Test.Notes = txtNotes.Text.Trim();
            _Test.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;

            if (UpdateRetakeTestInfo(_Test) && _Test.Save())
                MessageBox.Show("Test result Saved Successfully.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Test result is Not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            lblTestID.Text = _Test.TestID.ToString();
            gbTestInfo.Enabled = false;
            btnSave.Enabled = false;
        }

        private bool UpdateRetakeTestInfo(clsTest Test) {

            if (_AppType == enAppType.SceduleTest) return true;

            Test.TestAppointment.RetakeTestApplication.LastStatusDate = DateTime.Now;
            Test.TestAppointment.RetakeTestApplication.ApplicationStatusTemp = (byte)(_GetTestResult() ? 2 : 0);

            if (Test.TestAppointment.RetakeTestApplication.Save())
                return true;
            else
                return false;
        }

        private bool _GetTestResult() {

            return (rbPass.Checked);
        }

        // Displaying info
        private void _DisplayTestAppointmentInfo(clsTestAppointment TestAppointment) {

            lblLDLAppID.Text = TestAppointment.LDLApplication.LDLApplicationID.ToString();
            lblFullName.Text = TestAppointment.LDLApplication.Application.PersonInfo.FullName;
            lblTrial.Text = clsLocalDrivingLicenseApplication.NumberOfTrailsPerTest(TestAppointment.LDLApplicationID, TestAppointment.TestTypeID).ToString();
            lblDate.Text = TestAppointment.AppointmentDate.ToShortDateString();
            lblFees.Text = TestAppointment.PaidFees.ToString();
            lblAppliedLicense.Text = TestAppointment.LDLApplication.LicenseClass.ClassName;
        }

        private void _DisplayTestType() {

            switch (_TestType) {

                case enTestType.VisionTest: {

                    lblTestTilte.Text = "Scedule Vision Test";
                    this.Text = "Scedule Vision Test";
                    pbTestImage.Image = Properties.Resources.eye_scan;
                    break;
                }
                case enTestType.WrittenTest: {

                    lblTestTilte.Text = "Written Test Appointments";
                    this.Text = "Written Test Appointments";
                    pbTestImage.Image = Properties.Resources.writing;
                    break;
                }
                case enTestType.StreetTest: {

                    lblTestTilte.Text = "Street Test Appointments";
                    this.Text = "Street Test Appointments";
                    pbTestImage.Image = Properties.Resources.cone;
                    break;
                }
            }
        }

        // Close
        private void ctrlbClose_Click(object sender, EventArgs e) {

            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e) {

            this.Close();
        }

    }
}