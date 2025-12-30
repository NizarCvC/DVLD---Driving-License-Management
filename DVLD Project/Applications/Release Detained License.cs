using DVLD_Business_Layer;
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

namespace DVLD_Project.Manage_Detained_Licenses_Screens {

    public partial class frmReleaseDetainedLicense : Form {

        private int _LicenseID;
        private clsLicense _LicenseInfo;

        public frmReleaseDetainedLicense(int LicenseID = -1) {

            InitializeComponent();

            if (LicenseID != -1) {

                _LicenseInfo = clsLicense.FindByLicenseID(LicenseID);
                ctrlFilterLicense1.LicenseIDValue = LicenseID;
            }
            else {

                _LicenseInfo = null;
            }
        }

        private void btnRelease_Click(object sender, EventArgs e) {

            if (!_LicenseInfo.IsDetained) {

                MessageBox.Show("Cannot release this license, because it is not detained.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to release this license?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (_LicenseInfo == null)
                _LicenseInfo = clsLicense.FindByLicenseID(_LicenseID);

            if (_LicenseInfo.ReleasedDetainedLicense(clsGlobalSettings.CurrentUser.UserID)) {

                MessageBox.Show("License released Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {

                MessageBox.Show("License is Not released Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnRelease.Enabled = false;
            lnklblShowReleasedLicInfo.Enabled = true;
            ctrlFilterLicense1.FilterEnabled = false;
            _DisplayReleasedLicenseInfo();
        }

        private void _DisplayReleasedLicenseInfo() {

            lblDetainID.Text = _LicenseInfo.DetainedLicenseInfo.DetainID.ToString();
            lblDetainDate.Text = _LicenseInfo.DetainedLicenseInfo.DetainDate.ToShortDateString();
            lblApplicationFees.Text = _LicenseInfo.DetainedLicenseInfo.ReleaseApplication.PaidFees.ToString();
            lblLicenseID.Text = _LicenseInfo.LicenseID.ToString();
            lblCreatedBy.Text = _LicenseInfo.DetainedLicenseInfo.ReleasedByUserInfo.Username;
            lblFineFees.Text = _LicenseInfo.DetainedLicenseInfo.FineFees.ToString();
            lblReleaseAppID.Text = _LicenseInfo.DetainedLicenseInfo.ReleaseApplication.ApplicationID.ToString();
            lblTotalFees.Text = (_LicenseInfo.DetainedLicenseInfo.FineFees + _LicenseInfo.DetainedLicenseInfo.ReleaseApplication.PaidFees).ToString();
        }

        private void ctrlFilterLicense1_OnLicenseIDFound(object sender, User_Controls.ctrlFilterLicense.LicenseIDEventArgs e) {

            _LicenseInfo = clsLicense.FindByLicenseID(e.LicenseID);
        }

        // Links
        private void lnklblShowReleasedLicInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

            frmLicenseDetails frm = new frmLicenseDetails(_LicenseInfo.DetainedLicenseInfo.LicenseID, frmLicenseDetails.enIDType.LicenseID);
            frm.ShowDialog();
        }

        // Close
        private void btnCancle_Click(object sender, EventArgs e) => Close();

    }
}