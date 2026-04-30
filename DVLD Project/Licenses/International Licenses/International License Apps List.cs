using DVLD_Business_Layer;
using DVLD_Project.Manage_International_Licenses_Screens;
using DVLD_Project.Manage_Licenses_Screens;
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

namespace DVLD_Project.Manage_Inernational_Licenses_Screens {

    public partial class frmInernationalLicenseApplicationsList : Form {

        private string Column, Filter;

        public frmInernationalLicenseApplicationsList() {

            InitializeComponent();
            _RefreshAll();
        }

        // Refreshing
        private void _RefreshInernationalLicenseApplicationsList() {

            dgvInternationalLicList.DataSource = clsInternationalLicense.GetAllInternationalLicenses();
        }

        private void _RefreshNumberOfRecords() {

            lblNumberOfRecords.Text = clsGuna2ControlHelper.NumberOfRecords(dgvInternationalLicList).ToString();
        }

        private void _RefreshAll() {

            _RefreshInernationalLicenseApplicationsList();
            _RefreshNumberOfRecords();
        }

        private void btnAddNewInernationalLicApplication_Click(object sender, EventArgs e) {

            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog();
            _RefreshAll();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvInternationalLicList))
                return;

            frmInternationalLicenseDetails frm = new frmInternationalLicenseDetails((int)dgvInternationalLicList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        // Filters
        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e) {

            txtFilter.Clear();

            if (cbFilters.SelectedIndex == 0) {

                _RefreshAll();
                Filter = "";
                Column = "";
                txtFilter.Visible = false;
                cbIsActive.Visible = false;
                return;
            }
            else if (cbFilters.SelectedIndex == 5) {

                cbIsActive.Visible = true;
                txtFilter.Visible = false;
            }
            else {

                cbIsActive.Visible = false;
                txtFilter.Visible = true;
            }

            Column = _HandleNamesOfColumns(cbFilters.SelectedItem.ToString());
        }

        private string _HandleNamesOfColumns(string Column) {

            switch (Column) {

                case "Inter Lic ID":
                return "InternationalLicenseID";
                case "App ID":
                return "ApplicationID";
                case "Driver ID":
                return "DriverID";
                case "Local Lic ID":
                return "IssuedUsingLocalLicenseID";
                case "Is Active":
                return "IsActive";
                default:
                return "";
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e) {

            if (txtFilter.Text == "") {

                _RefreshAll();
                return;
            }

            Filter = txtFilter.Text;
            dgvInternationalLicList.DataSource = clsInternationalLicense.FilterInternationalLicenses(Column, Filter);
            _RefreshNumberOfRecords();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e) {

            if (cbIsActive.SelectedIndex == 0) {

                _RefreshAll();
                Filter = "";
                return;
            }

            Filter = ((cbIsActive.SelectedIndex == 1) ? 1 : 0).ToString();
            dgvInternationalLicList.DataSource = clsInternationalLicense.FilterInternationalLicenses(Column, Filter);
            _RefreshNumberOfRecords();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e) {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        // Close
        private void btnClose_Click(object sender, EventArgs e) => Close();

    }
}