using DVLD_Business_Layer;
using DVLD_Project.Manage_LDL_Applications;
using DVLD_Project.Manage_Licenses_Screens;
using DVLD_Project.User_Controls;
using My_Libraries;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_Project {

    public partial class frmLocalDrivingLicenseApplications : Form {

        private string Column, Filter;

        public frmLocalDrivingLicenseApplications() {

            InitializeComponent();
            _RefreshAll();
        }

        // Refreshing
        private void _RefreshLDLApplicationsList() {

            dgvLDLApplications.DataSource = clsLocalDrivingLicenseApplication.GetAllLDLApplications();
        }

        private void _RefreshNumberOfRecords() {

            lblNumberOfRecords.Text = clsGuna2ControlHelper.NumberOfRecords(dgvLDLApplications).ToString();
        }

        private void _RefreshAll() {

            _RefreshLDLApplicationsList();
            _RefreshNumberOfRecords();
            cbFilters.SelectedIndex = 0;
        }

        // Manuplating Data
        private void btnAddNewLDLApplication_Click(object sender, EventArgs e) {

            frmNewLDLApplication frm = new frmNewLDLApplication();
            frm.ShowDialog();
            _RefreshAll();
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvLDLApplications))
                return;

            frmLDLApplicationDetails frm = new frmLDLApplicationDetails((int)dgvLDLApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvLDLApplications))
                return;

            frmNewLDLApplication frm = new frmNewLDLApplication((int)dgvLDLApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshLDLApplicationsList();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvLDLApplications))
                return;

            if (MessageBox.Show("Are you sure you want to delete application [" + dgvLDLApplications.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes) {

                if (clsLocalDrivingLicenseApplication.DeleteLDLApplication((int)dgvLDLApplications.CurrentRow.Cells[0].Value)) {

                    MessageBox.Show("Application deleted successfully.", "successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshAll();
                }
                else {

                    MessageBox.Show("Failed to delete application.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvLDLApplications))
                return;

            if (MessageBox.Show("Are you sure you want to cancel application [" + dgvLDLApplications.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes) {

                if (clsLocalDrivingLicenseApplication.CancelLDLApplication((int)dgvLDLApplications.CurrentRow.Cells[0].Value)) {

                    MessageBox.Show("Application canceled successfully.", "successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshLDLApplicationsList();
                }
                else {

                    MessageBox.Show("Failed to cancel application.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void issueDrivingLicnseToolStripMenuItem_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvLDLApplications))
                return;

            frmIssueDLForTheFirstTime frm = new frmIssueDLForTheFirstTime((int)dgvLDLApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshAll();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvLDLApplications))
                return;

            clsLocalDrivingLicenseApplication LDLApplication = clsLocalDrivingLicenseApplication.FindByLDLAppID((int)dgvLDLApplications.CurrentRow.Cells[0].Value);

            if (LDLApplication == null) {

                MessageBox.Show("Cannot found the license for this aaplication.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmLicenseDetails frm = new frmLicenseDetails(LDLApplication.ApplicationID, frmLicenseDetails.enIDType.ApplicationID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvLDLApplications))
                return;

            frmLicenseHistory frm = new frmLicenseHistory((int)dgvLDLApplications.CurrentRow.Cells[0].Value, frmLicenseHistory.enIDType.LDLApplicationID);
            frm.ShowDialog();
        }

        // Sechduling tests
        private void sechduleTest(frmSceduleTestAppointments.enTestType testType) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvLDLApplications))
                return;

            frmSceduleTestAppointments frm = new frmSceduleTestAppointments((int)dgvLDLApplications.CurrentRow.Cells[0].Value, testType);
            frm.ShowDialog();
            _RefreshLDLApplicationsList();
        }

        private void sechduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e) {

            sechduleTest(frmSceduleTestAppointments.enTestType.VisionTest);
        }

        private void sechduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e) {

            sechduleTest(frmSceduleTestAppointments.enTestType.WrittenTest);
        }

        private void sechduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e) {

            sechduleTest(frmSceduleTestAppointments.enTestType.StreetTest);
        }

        // Menu Options Handling
        private void cmsLDLAppOptions_Opening(object sender, CancelEventArgs e) {

            if (_IsCompletedApplication((string)dgvLDLApplications.CurrentRow.Cells[6].Value)) {

                _HandleCompletedApplicationMenuOptions();
            }
            else if (_IsCancelledApplication((string)dgvLDLApplications.CurrentRow.Cells[6].Value)) {

                _HandleCancelledApplicationMenuOptions();
            }
            else {

                _HandlePassedTestsForMenuOptions((int)dgvLDLApplications.CurrentRow.Cells[5].Value);
            }
        }

        private void _HandlePassedTestsForMenuOptions(int PassedTests) {

            showApplicationDetailsToolStripMenuItem.Enabled = true;
            editApplicationToolStripMenuItem.Enabled = true;
            deleteApplicationToolStripMenuItem.Enabled = true;
            cancelApplicationToolStripMenuItem.Enabled = true;
            sechduleTestsToolStripMenuItem.Enabled = true;
            issueDrivingLicnseToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem.Enabled = false;

            switch (PassedTests) {

                case 0: {

                    sechduleVisionTestToolStripMenuItem.Enabled = true;
                    sechduleWrittenTestToolStripMenuItem.Enabled = false;
                    sechduleStreetTestToolStripMenuItem.Enabled = false;
                    break;
                }
                case 1: {

                    sechduleVisionTestToolStripMenuItem.Enabled = false;
                    sechduleWrittenTestToolStripMenuItem.Enabled = true;
                    sechduleStreetTestToolStripMenuItem.Enabled = false;
                    break;
                }
                case 2: {

                    sechduleVisionTestToolStripMenuItem.Enabled = false;
                    sechduleWrittenTestToolStripMenuItem.Enabled = false;
                    sechduleStreetTestToolStripMenuItem.Enabled = true;
                    break;
                }
                case 3: {

                    sechduleTestsToolStripMenuItem.Enabled = false;
                    issueDrivingLicnseToolStripMenuItem.Enabled = true;
                    break;
                }
            }
        }

        private void _HandleCancelledApplicationMenuOptions() {

            showApplicationDetailsToolStripMenuItem.Enabled = true;
            editApplicationToolStripMenuItem.Enabled = false;
            deleteApplicationToolStripMenuItem.Enabled = true;
            cancelApplicationToolStripMenuItem.Enabled = false;
            sechduleTestsToolStripMenuItem.Enabled = false;
            issueDrivingLicnseToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem.Enabled = false;
            showPersonLicenseHistoryToolStripMenuItem.Enabled = true;
        }

        private void _HandleCompletedApplicationMenuOptions() {

            showLicenseToolStripMenuItem.Enabled = true;
            editApplicationToolStripMenuItem.Enabled = false;
            deleteApplicationToolStripMenuItem.Enabled = false;
            cancelApplicationToolStripMenuItem.Enabled = false;
            sechduleTestsToolStripMenuItem.Enabled = false;
            issueDrivingLicnseToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem.Enabled = true;
            showPersonLicenseHistoryToolStripMenuItem.Enabled = true;
        }

        private static Predicate<string> _IsCancelledApplication = (Status) => Status == "Cancelled";

        private static Predicate<string> _IsCompletedApplication = (Status) => Status == "Completed";

        private string _HandleAppStatusNumber(int Index) {

            switch (Index) {

                case 1:
                return "Cancelled";
                case 2:
                return "New";
                case 3:
                return "Completed";
                default:
                return "New";
            }
        }

        // Filter data
        private void txtFilter_TextChanged(object sender, EventArgs e) {

            if (txtFilter.Text == "") {

                _RefreshAll();
                return;
            }

            Filter = txtFilter.Text;
            dgvLDLApplications.DataSource = clsLocalDrivingLicenseApplication.FilterLDLApplications(Column, Filter);
            _RefreshNumberOfRecords();
        }

        private void cbAppStatus_SelectedIndexChanged(object sender, EventArgs e) {

            if (cbAppStatus.SelectedIndex == 0) {

                _RefreshAll();
                Filter = "";
                return;
            }

            Filter = _HandleAppStatusNumber(cbAppStatus.SelectedIndex);
            dgvLDLApplications.DataSource = clsLocalDrivingLicenseApplication.FilterLDLApplications(Column, Filter);
            _RefreshNumberOfRecords();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e) {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && cbFilters.SelectedIndex == 1)
                e.Handled = true;
        }

        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e) {

            txtFilter.Text = "";

            if (cbFilters.SelectedIndex == 0) {

                _RefreshAll();
                Column = "";
                Filter = "";
                cbAppStatus.Visible = false;
                txtFilter.Visible = false;
            }
            else if (cbFilters.SelectedIndex == 4) {

                _RefreshAll();
                cbAppStatus.Visible = true;
                txtFilter.Visible = false;
                Column = "Application Status";
                return;
            }
            else {

                _RefreshAll();
                cbAppStatus.Visible = false;
                txtFilter.Visible = true;
            }

            if (cbFilters.SelectedIndex == 1) {

                Column = clsUtil.RemoveChar(cbFilters.SelectedItem.ToString(), '.');
                return;
            }

            Column = cbFilters.SelectedItem.ToString();
        }

        // Close
        private void btnClose_Click(object sender, EventArgs e) => Close();

    }
}