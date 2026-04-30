using DVLD_Business_Layer;
using DVLD_Project.Manage_People_Screens;
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

namespace DVLD_Project {

    public partial class frmManageUsers : Form {

        private string Column, Filter;

        public frmManageUsers() {

            InitializeComponent();
            _RefreshAll();
        }

        // Refreshing data
        private void _RefreshUsersList() {

            dgvAllUsers.DataSource = clsUser.GetAllUsers();
        }

        private void _RefreshNumberOfRecords() {

            lblNumberOfRecords.Text = clsGuna2ControlHelper.NumberOfRecords(dgvAllUsers).ToString();
        }

        private void _RefreshAll() {

            _RefreshUsersList();
            _RefreshNumberOfRecords();
        }

        // Manuplating data
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvAllUsers))
                return;

            frmUserDetails frm = new frmUserDetails((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshAll();
        }

        private void dgvAllUsers_DoubleClick(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvAllUsers))
                return;

            frmUserDetails frm = new frmUserDetails((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshAll();
        } 

        private void AddNewUser_Click(object sender, EventArgs e) {

            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();
            _RefreshAll();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvAllUsers))
                return;

            if (clsGlobalSettings.CurrentUser.UserID != 1) {

                MessageBox.Show("Sorry, you don’t have the required permissions to edit this user’s information.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmAddUpdateUser frm = new frmAddUpdateUser((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvAllUsers))
                return;

            if (clsGlobalSettings.CurrentUser.UserID != 1) {

                MessageBox.Show("Sorry, you don’t have the required permissions to delete this user’s information.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((int)dgvAllUsers.CurrentRow.Cells[0].Value == clsGlobalSettings.CurrentUser.UserID){

                MessageBox.Show("You cannot delete yourself.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete User [" + dgvAllUsers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes) {

                if (clsUser.DeleteUser((int)dgvAllUsers.CurrentRow.Cells[0].Value)) {

                    MessageBox.Show("User deleted successfully.", "successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshAll();
                }
                else {

                     MessageBox.Show("Cannot delete this user\nBecause he has info in the system", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvAllUsers))
                return;

            if (clsGlobalSettings.CurrentUser.UserID != 1) {

                MessageBox.Show("Sorry, you don’t have the required permissions to edit this user’s information.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmChangePassword frm = new frmChangePassword((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshUsersList();
        }

        // Need to implement later 
        private void ContactToolStripMenuItem_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvAllUsers))
                return;

            MessageBox.Show("Not implemented yet.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Filter data
        private void txtFilter_TextChanged(object sender, EventArgs e) {

            if (txtFilter.Text == "") {

                _RefreshAll();
                return;
            }

            Filter = txtFilter.Text;

            dgvAllUsers.DataSource = clsUser.FilterUsers(Column, Filter);
            _RefreshNumberOfRecords();
        }

        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e) {

            txtFilter.Clear();
            _RefreshAll();

            if (cbFilters.SelectedIndex == 0) {

                Filter = "";
                Column = "";
                cbActive.Visible = false;
                txtFilter.Visible = false;
                return;
            }
            else if (cbFilters.SelectedIndex == 5) {

                cbActive.Visible = true;
                txtFilter.Visible = false;
            }
            else {

                cbActive.Visible = false;
                txtFilter.Visible = true;
            }

            Column = cbFilters.SelectedItem.ToString();
        }

        private void cbActive_SelectedIndexChanged(object sender, EventArgs e) {

            if (cbActive.SelectedIndex == 0) {

                _RefreshAll();
                Filter = "";
                return;
            }

            // 1 for active, 0 for inactive
            Filter = ((cbActive.SelectedIndex == 1) ? 1 : 0).ToString();
            dgvAllUsers.DataSource = clsUser.FilterUsers(clsUtil.RemoveChar(Column), Filter);
            _RefreshNumberOfRecords();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e) {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (cbFilters.SelectedIndex == 1 || cbFilters.SelectedIndex == 2))
                e.Handled = true;
        }

        // Close
        private void btnClose_Click(object sender, EventArgs e) => Close();

    }
}