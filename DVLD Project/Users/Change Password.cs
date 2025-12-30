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

    public partial class frmChangePassword : Form {

        private int _UserID;
        private clsUser _User;

        public frmChangePassword(int UserID) {

            InitializeComponent();
            _UserID = UserID;
        }

        private void frmChangePassword_Load(object sender, EventArgs e) {

            _User = clsUser.Find(_UserID);

            if (_User == null) {

                MessageBox.Show($"Cannot find the user with ID: {_UserID}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlUserInfo.LoadUserInfo(_UserID);
            txtCurrentPassword.UseSystemPasswordChar = true;
            txtNewPassword.UseSystemPasswordChar = true;
            txtConfirmedPassword.UseSystemPasswordChar = true;
        }

        private void btnSave_Click(object sender, EventArgs e) {

            if (!this.ValidateChildren()) {

                MessageBox.Show("Invalid information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.Equals(clsCryptographics.Hashing(txtCurrentPassword.Text), _User.Password, StringComparison.Ordinal)) {

                MessageBox.Show("The current password is invalid, becuase it doesn't match your current password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.Equals(clsCryptographics.Hashing(txtNewPassword.Text), _User.Password, StringComparison.Ordinal)) {

                MessageBox.Show("New password cannot be the same as the current password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to change the password?", "Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            _User.Password = txtNewPassword.Text;

            if (_User.Save()) 
                MessageBox.Show("Password Saved Successfully.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else 
                MessageBox.Show("Password is Not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.Close();
        }

        // Validations on password
        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e) {

            clsGuna2ControlHelper.ValidateRequiredTextBox(txtCurrentPassword, e, errorProvider, "Password shouldn't be empty!");
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e) {

            clsGuna2ControlHelper.ValidateRequiredTextBox(txtNewPassword, e, errorProvider, "Password shouldn't be empty!");
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e) {

            if (!string.Equals(txtConfirmedPassword.Text, txtNewPassword.Text, StringComparison.Ordinal)) {

                txtConfirmedPassword.Focus();
                e.Cancel = true;
                errorProvider.SetError(txtConfirmedPassword, "Password should be equal!");
            }
            else {

                e.Cancel = false;
                errorProvider.SetError(txtConfirmedPassword, null);
            }
        }

        // Hide and show passwords
        private bool[] _PasswordVisibilityFlags = {false, false, false};
        private void txtCurrentPassword_IconRightClick(object sender, EventArgs e) {

            clsGuna2ControlHelper.TogglePasswordVisibility(txtCurrentPassword, ref _PasswordVisibilityFlags[0], Resources.visible2, Resources.hide2);
        }

        private void txtNewPassword_IconRightClick(object sender, EventArgs e) {

            clsGuna2ControlHelper.TogglePasswordVisibility(txtNewPassword, ref _PasswordVisibilityFlags[1], Resources.visible2, Resources.hide2);
        }

        private void txtConfirmedPassword_IconRightClick(object sender, EventArgs e) {

            clsGuna2ControlHelper.TogglePasswordVisibility(txtConfirmedPassword, ref _PasswordVisibilityFlags[2], Resources.visible2, Resources.hide2);
        }

        // Close
        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }
}