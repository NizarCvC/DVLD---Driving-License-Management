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

namespace DVLD_Project.Manage_Licenses_Screens {

    public partial class frmDriversList : Form {

        private string Column, Filter;

        public frmDriversList() {

            InitializeComponent();
            _RefreshAll();
        }

        // Refreshing data
        private void _RefreshDriverList() {

            dgvDriversList.DataSource = clsDriver.GetAllDrivers();
        }

        private void _RefreshNumberOfRecords() {

            lblNumberOfRecords.Text = clsGuna2ControlHelper.NumberOfRecords(dgvDriversList).ToString();
        }

        private void _RefreshAll() {

            _RefreshDriverList();
            _RefreshNumberOfRecords();
        }

        // Show driver details
        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvDriversList))
                return;

            frmLicenseHistory frm = new frmLicenseHistory((int)dgvDriversList.CurrentRow.Cells[0].Value, frmLicenseHistory.enIDType.DriverID);
            frm.ShowDialog();
        }

        private void showPersonDetailsToolStripMenuItem1_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvDriversList))
                return;

            frmPersonDetails frm = new frmPersonDetails((int)dgvDriversList.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        // Filter
        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e) {

            txtFilter.Clear();

            if (cbFilters.SelectedIndex == 0) {

                txtFilter.Visible = false;
                _RefreshAll();
                Column = "";
                Filter = "";
            }
            else {

                txtFilter.Visible = true;
                Column = cbFilters.SelectedItem.ToString();
                _RefreshAll();
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e) {

            if (txtFilter.Text == "") {

                _RefreshAll();
                return;
            }

            Filter = txtFilter.Text;
            dgvDriversList.DataSource = clsDriver.FilterDrivers(Column, Filter);
            _RefreshNumberOfRecords();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e) {

            if ((cbFilters.SelectedIndex == 1 || cbFilters.SelectedIndex == 2) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        // Close
        private void btnClose_Click(object sender, EventArgs e) {

            this.Close();
        }

    }
}