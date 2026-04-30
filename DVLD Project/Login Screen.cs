using DVLD_Business_Layer;
using DVLD_Project;
using DVLD_Project.Properties;
using Microsoft.Win32;
using My_Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD_Presentation_Layer {

    public partial class frmLoginScreen : Form {

        private const string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
        private const string UsernameName = "Username";
        private const string PasswordName = "Password";
        private const string RememberName = "Is Remembered";

        public frmLoginScreen() => InitializeComponent();

        private void frmLoginScreen_Load(object sender, EventArgs e) { 

            txtPassword.UseSystemPasswordChar = true;
            _CheckIfThereRememberedUser();
        }

        private void _SetCurrentUserInfo(clsUser CurrentUser) => clsGlobalSettings.CurrentUser = CurrentUser;

        private bool IsValidLogin(string Username, string Password, ref bool IsActive) {

            clsUser User = clsUser.Find(Username);

            if (User == null || User.Password != clsCryptographics.Hashing(Password)) {
                
                return false;
            }

            _SetCurrentUserInfo(User);
            IsActive = User.IsActive;
            return true;
        }

        private void btnLogin_Click(object sender, EventArgs e) {

            if (!this.ValidateChildren()) {

                MessageBox.Show("Invalid information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool IsActive = false;

            if (IsValidLogin(txtUsername.Text, txtPassword.Text, ref IsActive)) {

                if (IsActive) {

                    this.DialogResult = DialogResult.OK;
                    _RememberCurrentUser(txtUsername.Text, txtPassword.Text);
                    this.Close();
                }
                else {

                    MessageBox.Show("Your account isn't active.\nPlease contact your admin.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else {

                MessageBox.Show("Incorrect username or password.\nPlease try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _CheckIfThereRememberedUser() {

            try {

                string val = Registry.GetValue(KeyPath, RememberName, null) as string;

                if (val != null) {

                    _FillUsernameAndPassword();
                }
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"],
                    ex.ToString(), EventLogEntryType.Error);
            }
        }

        private void _FillUsernameAndPassword() {

            try {

                string Username = Registry.GetValue(KeyPath, UsernameName, null) as string;
                string Password = clsCryptographics.Decrypt(Registry.GetValue(KeyPath, PasswordName, null) as string,
                    ConfigurationManager.AppSettings["keyForEncDecPassword"]);

                if (Username != null && Password != null) {

                    txtUsername.Text = Username;
                    txtPassword.Text = Password;
                    tsRememberMe.Checked = true;
                }
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"],
                    ex.ToString(), EventLogEntryType.Error);
            }
        }

        private void _UnRememberCurrentUser() {

            try {
                
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64)) {

                    using (RegistryKey key = baseKey.OpenSubKey(@"SOFTWARE\DVLD", true)) {

                        if (key != null) {
                            
                            key.DeleteValue(UsernameName);
                            key.DeleteValue(PasswordName);
                            key.DeleteValue(RememberName);
                        }
                    }
                }
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"],
                    ex.ToString(), EventLogEntryType.Error);
            }
        }

        private void _RememberCurrentUser(string Username, string Password) {

            if (!tsRememberMe.Checked) {

                _UnRememberCurrentUser();
                return;
            }

            try {

                Registry.SetValue(KeyPath, UsernameName, Username, RegistryValueKind.String);
                Registry.SetValue(KeyPath, PasswordName, clsCryptographics
                    .Encrypt(Password, ConfigurationManager.AppSettings["keyForEncDecPassword"]),
                    RegistryValueKind.String);
                Registry.SetValue(KeyPath, RememberName, "Remember", RegistryValueKind.String);
            }
            catch (Exception ex) {

                EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"],
                    ex.ToString(), EventLogEntryType.Error);
            }
        }

        // Handling password icon visible
        private bool _isPasswordVisible = false;
        private void txtPassword_IconRightClick(object sender, EventArgs e) 
            => clsGuna2ControlHelper.TogglePasswordVisibility(txtPassword, ref _isPasswordVisible,
                Resources.visible2, Resources.hide2);

        // Validation
        private void txtUsername_Validating(object sender, CancelEventArgs e) 
            => clsGuna2ControlHelper.ValidateRequiredTextBox(txtUsername, e, errorProvider,
                "Username shouldn't be empty!");

        private void txtPassword_Validating(object sender, CancelEventArgs e) 
            => clsGuna2ControlHelper.ValidateRequiredTextBox(txtPassword, e, errorProvider,
                "Password shouldn't be empty!");

    }
}