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

namespace DVLD_Project.Manage_Local_Licenses_Screens {

    public partial class frmReplacementForDamagedOrLost : Form {

        private clsLicense _OldLicense;
        private clsLicense _ReplacedLicense;

        public frmReplacementForDamagedOrLost() => InitializeComponent();

        private clsLicense.enIssueReason _GetIssueReason() {

            return rbDamagedLicense.Checked ? clsLicense.enIssueReason.ReplacementForDamaged :
                clsLicense.enIssueReason.ReplacementForLost;
        }

        private void btnReplace_Click(object sender, EventArgs e) {

            if (!_OldLicense.IsActive) {

                MessageBox.Show("Connot replace this license because it is not active.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clsDetainedLicense.IsLicenseDetained(_OldLicense.LicenseID)) {

                MessageBox.Show("Connot renew this license because it is detained.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to replace this license?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            _ReplacedLicense = _OldLicense.ReplaceFor(_GetIssueReason(), clsGlobalSettings.CurrentUser.UserID);

            if (_ReplacedLicense != null) {

                MessageBox.Show($"Licensed Replaced Successfully with ID: {_ReplacedLicense.LicenseID}",
                    "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnReplace.Enabled = false;
                ctrlFilterLicense1.FilterEnabled = false;
                gbReplacementFor.Enabled = false;
                lnklblShowNewLicInfo.Enabled = true;
                _DisplayReplacementLicenseApplication();
            }
            else {

                MessageBox.Show("Faild to Issue a replacemnet for this  License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctrlFilterLicense1_OnLicenseIDFound(object sender, User_Controls.ctrlFilterLicense.LicenseIDEventArgs e) {

            _OldLicense = clsLicense.FindByLicenseID(e.LicenseID);
        }

        // Display Info
        private void _DisplayReplacementLicenseApplication() {

            lblReplacementAppID.Text = _ReplacedLicense.ApplicationID.ToString();
            lblApplicationDate.Text = _ReplacedLicense.Application.ApplicationDate.ToShortDateString();
            lblApplicationFees.Text = _ReplacedLicense.Application.PaidFees.ToString();
            lblReplacedLicID.Text = _ReplacedLicense.LicenseID.ToString();
            lblOldLicense.Text = _OldLicense.LicenseID.ToString();
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.Username;
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

        private void lnklblShowNewLicInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

            frmLicenseDetails frm = new frmLicenseDetails(_ReplacedLicense.LicenseID, frmLicenseDetails.enIDType.LicenseID);
            frm.ShowDialog();
        }

        // Close
        private void btnCancle_Click(object sender, EventArgs e) => Close();
    
    }
}