using DVLD_Business_Layer;
using DVLD_Project.Manage_Detained_Licenses_Screens;
using DVLD_Project.Manage_Licenses_Screens;
using My_Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Manage_Detained_Licenses__Screens {

    public partial class frmListDetainedLicenses : Form {

        private string Column, Filter;

        public frmListDetainedLicenses() {

            InitializeComponent();
            _RefreshAll();
        }

        // Refreshing data
        private void _RefreshPeopleList() {

            dgvAllDetainedLicenses.DataSource = clsDetainedLicense.GetAllDetainedLicenses();
        }

        private void _RefreshNumberOfRecords() {

            lblNumberOfRecords.Text = clsGuna2ControlHelper.NumberOfRecords(dgvAllDetainedLicenses).ToString();
        }

        private void _RefreshAll() {

            _RefreshPeopleList();
            _RefreshNumberOfRecords();
        }

        private void cmsDetainedLicenseOptions_Opening(object sender, CancelEventArgs e) {

            releaseLicenseToolStripMenuItem.Enabled = 
                !(bool)dgvAllDetainedLicenses.CurrentRow.Cells[4].Value;
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e) {

            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            _RefreshAll();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvAllDetainedLicenses))
                return;

            frmPersonDetails frm = new frmPersonDetails((string)dgvAllDetainedLicenses.CurrentRow.Cells[6].Value);
            frm.ShowDialog();
            _RefreshAll();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvAllDetainedLicenses))
                return;

            frmLicenseDetails frm = new frmLicenseDetails((int)dgvAllDetainedLicenses.CurrentRow.Cells[1].Value, frmLicenseDetails.enIDType.LicenseID);
            frm.ShowDialog();
            _RefreshAll();
        }

        private void showDriverLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvAllDetainedLicenses))
                return;

            clsDriver driver = clsDriver.FindByDriverID(clsLicense.FindByLicenseID((int)dgvAllDetainedLicenses.CurrentRow.Cells[1].Value).DriverID);

            if (driver != null) {

                frmLicenseHistory frm = new frmLicenseHistory(driver.DriverID, frmLicenseHistory.enIDType.DriverID);
                frm.ShowDialog();
                _RefreshAll();
            }
            else {

                MessageBox.Show($"Cannot find a driver with this license: {(int)dgvAllDetainedLicenses.CurrentRow.Cells[1].Value}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvAllDetainedLicenses))
                return;

            if (clsDetainedLicense.IsLicenseDetained((int)dgvAllDetainedLicenses.CurrentRow.Cells[1].Value)) {

                frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense((int)dgvAllDetainedLicenses.CurrentRow.Cells[1].Value);
                frm.ShowDialog();
                _RefreshAll();
            }
            else {

                MessageBox.Show($"Cannot release the license becuase it have been released already.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Handle filter
        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e) {

            txtFilter.Clear();

            if (cbFilters.SelectedIndex == 0) {

                _RefreshAll();
                Filter = "";
                Column = "";
                txtFilter.Visible = false;
                cbIsReleased.Visible = false;
                return;
            }
            else if (cbFilters.SelectedIndex == 2) {

                cbIsReleased.Visible = true;
                txtFilter.Visible = false;
            }
            else {

                cbIsReleased.Visible = false;
                txtFilter.Visible = true;
            }

            Column = cbFilters.SelectedItem.ToString();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e) {

            if (txtFilter.Text == "") {

                _RefreshAll();
                return;
            }

            Filter = txtFilter.Text;
            dgvAllDetainedLicenses.DataSource = clsDetainedLicense.FilterDetainedLicenses(Column, Filter);
            _RefreshNumberOfRecords();
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e) {

            if (cbIsReleased.SelectedIndex == 0) {

                _RefreshAll();
                Filter = "";
                return;
            }

            Filter = ((cbIsReleased.SelectedIndex == 1) ? 1 : 0).ToString();
            dgvAllDetainedLicenses.DataSource = clsDetainedLicense.FilterDetainedLicenses(Column, Filter);
            _RefreshNumberOfRecords();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e) {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (cbFilters.SelectedIndex == 1 || cbFilters.SelectedIndex == 5))
                e.Handled = true;
        }

        // Close
        private void btnClose_Click(object sender, EventArgs e) => Close();

    }
}