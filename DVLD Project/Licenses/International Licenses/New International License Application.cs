using DVLD_Business_Layer;
using DVLD_Project.Manage_International_Licenses_Screens;
using DVLD_Project.Manage_Licenses_Screens;
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

    public partial class frmNewInternationalLicenseApplication : Form {

        private int _LicenseID;
        private clsInternationalLicense _InternationalLicense;

        public frmNewInternationalLicenseApplication() => InitializeComponent();

        private void btnIssue_Click(object sender, EventArgs e) {

            clsLicense License = clsLicense.FindByLicenseID(_LicenseID);

            if (License.LicenseClassID != 3) {

                MessageBox.Show("The licnese must be an ordinary driving license to create an international license for it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!License.IsActive) {

                MessageBox.Show("Connot create an international license because the local license is not active.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsLicense.IsLocalLicenseHasAnActiveInternationalLicense(_LicenseID)) {

                MessageBox.Show("Connot create an international license because the local license is already has an active international liecnse.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to create inernational license for this driver?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            _InternationalLicense = new clsInternationalLicense();

            _InternationalLicense.Application.ApplicantPersonID = License.Driver.PersonID;
            _InternationalLicense.Application.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
            _InternationalLicense.DriverID = License.DriverID;
            _InternationalLicense.LocalLicneseID = _LicenseID;
            _InternationalLicense.IssueDate = DateTime.Now;
            _InternationalLicense.IsActive = true;
            _InternationalLicense.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
            // Need to add the valditiy length to settings
            _InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);

            if (_InternationalLicense.Save()) {

                MessageBox.Show("Data Saved Successfully.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {

                MessageBox.Show("Data is Not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnIssue.Enabled = false;
            ctrlFilterLicense1.FilterEnabled = false;
            lnklblShowInternationaLicInfo.Enabled = true;
            _DisplayInternationalLicenseApplicationInfo();
        }

        private void _DisplayInternationalLicenseApplicationInfo() {

            lblInternationalAppID.Text = _InternationalLicense.ApplicationID.ToString();
            lblApplicationDate.Text = _InternationalLicense.Application.ApplicationDate.ToShortDateString();
            lblIssueDate.Text = _InternationalLicense.IssueDate.ToShortDateString();
            lblFees.Text = _InternationalLicense.Application.PaidFees.ToString();
            lblInternationalLicID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            lblLocalLicense.Text = _InternationalLicense.LocalLicneseID.ToString();
            lblExpirationDate.Text = _InternationalLicense.ExpirationDate.ToShortDateString();
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.Username;
        }

        private void ctrlFilterLicense1_OnLicenseIDFound(object sender, User_Controls.ctrlFilterLicense.LicenseIDEventArgs e) {

            _LicenseID = e.LicenseID;
        }

        // Links
        private void lnklblShowLocalLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

            if (_LicenseID != 0) {

                frmLicenseDetails frm = new frmLicenseDetails(_LicenseID, frmLicenseDetails.enIDType.LicenseID);
                frm.ShowDialog();
            }
            else {

                MessageBox.Show("There is no local license found yet.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lnklblShowInternationaLicInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

            frmInternationalLicenseDetails frm = new frmInternationalLicenseDetails(_InternationalLicense.InternationalLicenseID);
            frm.ShowDialog();
        }

        // Close
        private void btnCancle_Click(object sender, EventArgs e) => Close();
    
    }
}