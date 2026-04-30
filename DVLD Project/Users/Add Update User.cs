using DVLD_Business_Layer;
using DVLD_Project.Properties;
using Guna.UI2.WinForms;
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

    public partial class frmAddUpdateUser : Form {

        public enum enMode { AddNew, Update };
        private enMode _Mode;

        private int _PersonID, _UserID;
        private clsUser _User;

        public frmAddUpdateUser() {

            InitializeComponent();
            _Mode = enMode.AddNew;
            this.Text = "Add New User";
        }

        public frmAddUpdateUser(int UserID) {

            InitializeComponent();
            _UserID = UserID;
            _Mode = enMode.Update;
            this.Text = "Update User";
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e) {

            txtPassword.UseSystemPasswordChar = true;
            txtConfirmedPassword.UseSystemPasswordChar = true;

            if (_Mode == enMode.AddNew) {

                tcManuplationUser.SelectedIndex = 0;
            }
            else {

                tcManuplationUser.SelectedIndex = 1;
                ctrlPersonalInfo.Enabled = false;
                btnContinue.Enabled = false;
                _LoadData();
            }
        }

        private void _LoadData() {

            if (_Mode == enMode.AddNew) {

                _User = new clsUser();
                return;
            }

            _User = clsUser.Find(_UserID);

            if (_User == null) {

                MessageBox.Show($"The operation will be cancled because no user with ID {_User}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblUserID.Text = _User.UserID.ToString();
            _PersonID = _User.PersonID;
            txtUsername.Text = _User.Username; 
            chkIsActive.Checked = _User.IsActive;
        }

        private void btnSave_Click(object sender, EventArgs e) {

            if (!this.ValidateChildren()) {

                MessageBox.Show("Invalid information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtConfirmedPassword.Text != txtPassword.Text) {

                MessageBox.Show("The confirmed password doesn't match the new password.\nPlease confirm your password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to save this user?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            _User.PersonID = _PersonID;
            _User.Username = txtUsername.Text;
            _User.Password = txtConfirmedPassword.Text;
            _User.IsActive = chkIsActive.Checked;

            if (_User.Save()) {

                MessageBox.Show("Data Saved Successfully.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {

                MessageBox.Show("Data is Not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Mode = enMode.Update;
            this.Name = "Update User";
            _UserID = _User.UserID;
            lblUserID.Text = _User.UserID.ToString();
            ctrlPersonalInfo.Enabled = false;
            btnContinue.Enabled = false;
        }

        private void btnContinue_Click(object sender, EventArgs e) {

            if (_Mode == enMode.AddNew && _PersonID == 0) {

                MessageBox.Show("Please select a person first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tcManuplationUser.SelectedIndex = 0;
                return;
            }

            if (clsUser.IsPersonUser(_PersonID)) {

                MessageBox.Show("Selected person already is a user.\nSelect another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tcManuplationUser.SelectedIndex = 1;
            _LoadData();
        }

        private void tcManuplationUser_SelectedIndexChanged(object sender, EventArgs e) {

            if (tcManuplationUser.SelectedIndex == 1 && _Mode == enMode.AddNew && clsUser.IsPersonUser(_PersonID)) {

                MessageBox.Show("Selected person already is a user.\nSelect another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tcManuplationUser.SelectedIndex = 0;
                return;
            }

            if (tcManuplationUser.SelectedIndex == 1 && _Mode == enMode.AddNew && _PersonID == 0) {

                MessageBox.Show("Please select a person first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tcManuplationUser.SelectedIndex = 0;
                return;
            }

            _LoadData();
        }

        // Validation for data
        private void txtUsername_Validating(object sender, CancelEventArgs e) {

            if (string.IsNullOrWhiteSpace(txtUsername.Text)) {

                e.Cancel = true;
                txtUsername.Focus();
                errorProvider1.SetError(txtUsername, "Username shouldn't be empty!");
            }
            else if (clsUser.IsUserExist(txtUsername.Text) && _Mode == enMode.AddNew) {

                e.Cancel = true;
                txtUsername.Focus();
                errorProvider1.SetError(txtUsername, "Username is already used!");
            }
            else {

                e.Cancel = false;
                errorProvider1.SetError(txtUsername, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e) {

            clsGuna2ControlHelper.ValidateRequiredTextBox(txtPassword, e, errorProvider1, "Password shouldn't be empty!");
        }

        // Validation on key board
        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e) {

            if (char.IsWhiteSpace(e.KeyChar)) 
                e.Handled = true;
        }

        // Hide and show passwords
        private bool[] _PasswordVisibilityFlags = { false, false };

        private void txtPassword_IconRightClick(object sender, EventArgs e) {

            clsGuna2ControlHelper.TogglePasswordVisibility(txtPassword, ref _PasswordVisibilityFlags[0], Resources.visible2, Resources.hide2);
        }

        private void txtConfirmedPassword_IconRightClick(object sender, EventArgs e) {

            clsGuna2ControlHelper.TogglePasswordVisibility(txtConfirmedPassword, ref _PasswordVisibilityFlags[1], Resources.visible2, Resources.hide2);
        }

        private void ctrlPersonalInfo_OnPersonIDFound0(object sender, ctrlFilterPersonInfo.PersonIDEventArgs e) {

            _PersonID = e.PersonID;
        }

        // Close
        private void btnCancel_Click(object sender, EventArgs e) => Close();

    }
}