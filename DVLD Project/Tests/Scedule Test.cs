using DVLD_Business_Layer;
using My_Libraries;
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

    public partial class frmSceduleTest : Form {

        private enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 }
        private enTestType _TestType = enTestType.VisionTest;
        public enum enAppType { SceduleTest = 1, RetakeTest = 2}
        private enAppType _AppType = enAppType.SceduleTest;

        private int _TestAppointmentID, _LDLApplicationID;
        private clsTestAppointment _TestAppointment;
        private clsLocalDrivingLicenseApplication _LDLApplication;

        public frmSceduleTest(int TestAppointmentID, int LDLApplicationID, int TestTypeID, enAppType AppType = enAppType.SceduleTest) {

            InitializeComponent();

            if (TestAppointmentID == -1) 
                _Mode = enMode.AddNew;
            else 
                _Mode = enMode.Update;

            _TestAppointmentID = TestAppointmentID;
            _LDLApplicationID = LDLApplicationID;
            _LDLApplication = clsLocalDrivingLicenseApplication.FindByAppID(_LDLApplicationID);
            _TestType = (enTestType)TestTypeID;
            _AppType = AppType;
        }

        private void frmSceduleTest_Load(object sender, EventArgs e) {

            _DisplayTestType();
            _LoadData();
        }

        private void _InitializeDate() {

            dtpAppointmentDate.MinDate = DateTime.Now;
        }

        private bool _CreateRetakeTestApplication(ref int RetakeTestApplicationID) {

            clsApplication RetakeTestApp = clsApplication.CreateRetakeTestApplication();
            RetakeTestApp.ApplicantPersonID = _LDLApplication.Application.ApplicantPersonID;
            RetakeTestApp.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;

            if (RetakeTestApp.Save()) {

                RetakeTestApplicationID = RetakeTestApp.ApplicationID;
                return true;
            }
            else {

                return false;
            }
        }

        private void _LoadData() {

            _InitializeDate();

            if (_Mode == enMode.AddNew) {

                _TestAppointment = new clsTestAppointment(_LDLApplicationID);
                _DisplayLDLApplicationData(_TestAppointment);
                return;
            }

            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);

            if (_TestAppointment == null) {

                MessageBox.Show($"The operation will be cancled because no Appointment with ID {_TestAppointment}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            _DisplayLDLApplicationData(_TestAppointment);
        }

        private void btnSave_Click(object sender, EventArgs e) {

            if (MessageBox.Show("Are you sure you want to save this appointment?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            _TestAppointment.TestTypeID = (int)_TestType;
            _TestAppointment.AppointmentDate = dtpAppointmentDate.Value;
            _TestAppointment.PaidFees = clsUtil.CheckIfValidDecimal(lblFees.Text);
            _TestAppointment.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
            _TestAppointment.IsLocked = false;

            if (_Mode == enMode.AddNew && _AppType == enAppType.RetakeTest) {

                int RetakeTestApplicationID = -1;

                if (!_CreateRetakeTestApplication(ref RetakeTestApplicationID)) {

                    MessageBox.Show("Appointment is Not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _TestAppointment.RetakeTestApplicationID = RetakeTestApplicationID;

                if (_TestAppointment.Save())
                    MessageBox.Show("Appointment Saved Successfully.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Appointment is Not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {

                if (_TestAppointment.Save())
                    MessageBox.Show("Appointment Saved Successfully.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Appointment is Not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        // Displays info
        private void _DisplayLDLApplicationData(clsTestAppointment TestAppointment) {

            lblLDLAppID.Text = TestAppointment.LDLApplication.LDLApplicationID.ToString();
            lblFullName.Text = TestAppointment.LDLApplication.Application.PersonInfo.FullName;
            lblTrial.Text = clsLocalDrivingLicenseApplication.NumberOfTrailsPerTest(_LDLApplicationID, (int)_TestType).ToString();
            lblFees.Text = clsTestType.Find((clsTestType.enTestType)_TestType).Fees.ToString();
            lblAppliedLicense.Text = TestAppointment.LDLApplication.LicenseClass.ClassName;
            
            if (_Mode == enMode.Update) { 

                dtpAppointmentDate.MinDate = DateTime.Today;
                dtpAppointmentDate.Value = TestAppointment.AppointmentDate;
            }

            _DisplayRetakeTestInfo(TestAppointment);

            lblTotalFees.Text = (clsUtil.CheckIfValidDecimal(lblFees.Text) + clsUtil.CheckIfValidDecimal(lblRetakeTestAppFees.Text)).ToString();
        }

        private void _DisplayRetakeTestInfo(clsTestAppointment TestAppointment) {

            if (_AppType == enAppType.RetakeTest && _Mode == enMode.Update) {

                gbRetakeTestInfo.Enabled = true;
                lblRetakeTestAppID.Text = TestAppointment.RetakeTestApplication.ApplicationID.ToString();
                lblRetakeTestAppFees.Text = TestAppointment.RetakeTestApplication.PaidFees.ToString();
            }
            else if (_AppType == enAppType.RetakeTest && _Mode == enMode.AddNew) {

                gbRetakeTestInfo.Enabled = true;
                lblRetakeTestAppFees.Text = clsApplicationType.Find((int)clsApplicationType.enApplicationType.RetakeTest).Fees.ToString();
            }
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
        private void Close_Click(object sender, EventArgs e) => Close();

    }
}