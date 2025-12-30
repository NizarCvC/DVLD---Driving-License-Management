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

    public partial class frmSceduleTestAppointments : Form {

        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 }
        private enTestType _TestType = enTestType.VisionTest;
        private int _LDLApplicationID;

        public frmSceduleTestAppointments(int LDLApplicationID, enTestType TestType) {

            InitializeComponent();
            _LDLApplicationID = LDLApplicationID;
            _TestType = TestType;
        }

        private void frmSceduleTestAppointments_Load(object sender, EventArgs e) {

            ctrlLDLApplicationInfo1.LoadLDLApplicationInfo(_LDLApplicationID);
            _DisplayTestType();
            _RefreshAll();
        }

        // Refreshing Data
        private void _RefreshAppointmentList() {

            dgvTestAppointments.DataSource = clsTestAppointment.GetAllAppointmentsByLDLAppID(_LDLApplicationID, (int)_TestType);
        }

        private void _RefreshNumberOfRecords() {

            lblNumberOfRecords.Text = clsGuna2ControlHelper.NumberOfRecords(dgvTestAppointments).ToString();
        }

        private void _RefreshAll() {

            _RefreshAppointmentList();
            _RefreshNumberOfRecords();
        }

        // Change form style depends on test type mode
        private void _DisplayTestType() {

            switch (_TestType) {

                case enTestType.VisionTest: {

                    lblTestTilte.Text = "Vision Test Appointments";
                    this.Text = "Vision Test Appointments";
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

        private int IsThereRetakeTest(int TestAppointment) {

            return clsTestAppointment.IsTestAppointmentHaveRetakeTestApp(TestAppointment) ? 2 : 1;
        }

        private void btnAddNewTest_Click(object sender, EventArgs e) {

            if (clsLocalDrivingLicenseApplication.IsHavePassedTest(_LDLApplicationID, (int)_TestType)){

                MessageBox.Show("The applicant has already passed the test.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsLocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_LDLApplicationID, (int)_TestType)) {

                MessageBox.Show("You cannot add new appointment for this client.\nBecause he has already an Available appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            if (clsLocalDrivingLicenseApplication.IsHaveFaildTest(_LDLApplicationID, (int)_TestType)) {

                frmSceduleTest frm = new frmSceduleTest(-1, _LDLApplicationID, (int)_TestType, frmSceduleTest.enAppType.RetakeTest);
                frm.ShowDialog();
                _RefreshAll();
            }
            else {

                frmSceduleTest frm = new frmSceduleTest(-1, _LDLApplicationID, (int)_TestType);
                frm.ShowDialog();
                _RefreshAll();
            }
        }

        private void _CheckIfAppointmentLocked() {

            if ((bool)dgvTestAppointments.CurrentRow.Cells[3].Value == true) {

                editAppointmentToolStripMenuItem.Enabled = false;
                takeTestToolStripMenuItem.Enabled = false;
            }
            else {

                editAppointmentToolStripMenuItem.Enabled = true;
                takeTestToolStripMenuItem.Enabled = true;
            }
        }

        private void cmsAppointmentOptions_Opening(object sender, CancelEventArgs e) {

            _CheckIfAppointmentLocked();
        }

        private void editAppointmentToolStripMenuItem_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvTestAppointments))
                return;

            frmSceduleTest frm = new frmSceduleTest((int)dgvTestAppointments.CurrentRow.Cells[0].Value, _LDLApplicationID, (int)_TestType, (frmSceduleTest.enAppType)IsThereRetakeTest((int)dgvTestAppointments.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            _RefreshAll();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e) {

            frmTakeTest frm = new frmTakeTest((int)dgvTestAppointments.CurrentRow.Cells[0].Value, (int)_TestType);
            frm.ShowDialog();
            _RefreshAll();
        }

        // Close
        private void btnClose_Click(object sender, EventArgs e) => Close();

    }
}