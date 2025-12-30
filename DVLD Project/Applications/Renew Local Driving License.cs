using DVLD_Business_Layer;
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

namespace DVLD_Project {

    public partial class frmRenewLocalDrivingLicense : Form {

        private clsLicense _OldLicense;
        private clsLicense _RenewedLicense;

        public frmRenewLocalDrivingLicense() => InitializeComponent();

        private void btnRenew_Click(object sender, EventArgs e) {

            if (!_OldLicense.IsActive) {

                MessageBox.Show("Connot renew this license because it is not active.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_OldLicense.IsLicenseExpired()) {

                MessageBox.Show($"The license is still under Expiration Date." +
                    $"\n it will be Expired in {_OldLicense.ExpirationDate}", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clsDetainedLicense.IsLicenseDetained(_OldLicense.LicenseID)) {

                MessageBox.Show("Connot renew this license because it is detained.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to renew this license?", "Confirm Save",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            _RenewedLicense = _OldLicense.RenewLicense(txtNotes.Text, clsGlobalSettings.CurrentUser.UserID);

            if (_RenewedLicense != null) {

                MessageBox.Show($"Licensed Renewed Successfully with ID: {_RenewedLicense.LicenseID}", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnRenew.Enabled = false;
                ctrlFilterLicense1.FilterEnabled = false;
                lnklblShowRenewedLicInfo.Enabled = true;
                _DisplayRenewedLicenseApplicationInfo();
            }
            else {

                MessageBox.Show("Faild to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctrlFilterLicense1_OnLicenseIDFound(object sender, User_Controls.ctrlFilterLicense.LicenseIDEventArgs e) {

            _OldLicense = clsLicense.FindByLicenseID(e.LicenseID);
        }

        // Display Info
        private void _DisplayRenewedLicenseApplicationInfo() {

            lblRenewLicAppID.Text = _RenewedLicense.ApplicationID.ToString();
            lblApplicationDate.Text = _RenewedLicense.Application.ApplicationDate.ToShortDateString();
            lblIssueDate.Text = _RenewedLicense.IssueDate.ToShortDateString();
            lblApplicationFees.Text = _RenewedLicense.Application.PaidFees.ToString();
            lblLicenseFees.Text = _RenewedLicense.PaidFees.ToString();
            lblRenewedLicID.Text = _RenewedLicense.LicenseID.ToString();
            lblOldLicense.Text = _OldLicense.LicenseID.ToString();
            lblExpirationDate.Text = _RenewedLicense.ExpirationDate.ToShortDateString();
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.Username;
            lblTotalFees.Text = (_RenewedLicense.Application.PaidFees + _RenewedLicense.PaidFees).ToString();
        }

        // Links
        private void lnklblShowLocalLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

            if (_OldLicense != null) {

                frmLicenseDetails frm = new frmLicenseDetails(_OldLicense.LicenseID, frmLicenseDetails.enIDType.LicenseID);
                frm.ShowDialog();
            }
            else {

                MessageBox.Show("There is no local license found yet.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lnklblShowRenewedLicInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

            frmLicenseDetails frm = new frmLicenseDetails(_RenewedLicense.LicenseID, frmLicenseDetails.enIDType.LicenseID);
            frm.ShowDialog();
        }

        // Close
        private void btnCancle_Click(object sender, EventArgs e) => Close();

    }
}