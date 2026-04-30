using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.User_Controls {

    public partial class ctrlLocalLicenseInfo : UserControl {

        public ctrlLocalLicenseInfo() {

            InitializeComponent();
        }

        public void LoadLicenseInfoByAppID(int ApplicationID) {

            if (ApplicationID == -1) {

                _ResetInfoToDefailt();
                return;
            }

            clsLicense License = clsLicense.FindByApplicationID(ApplicationID);

            if (License == null) return;

            _DisplayLicenseInfo(License);
        }

        public void LoadLicenseInfoByLicenseID(int LicenseID) {

            if (LicenseID == -1) {

                _ResetInfoToDefailt();
                return;
            }

            clsLicense License = clsLicense.FindByLicenseID(LicenseID);
            if (License == null) return;

            _DisplayLicenseInfo(License);
        }

        private string _HandleIssueReason(clsLicense.enIssueReason IssueReason) {

            switch (IssueReason) {

                case clsLicense.enIssueReason.FirstTime:
                return "First Time";
                case clsLicense.enIssueReason.Renew:
                return "Renew";
                case clsLicense.enIssueReason.ReplacementForLost:
                return "Replaced For Lost";
                case clsLicense.enIssueReason.ReplacementForDamaged:
                return "Replaced For Damaged";
                default:
                return "Unknown";
            }
        }

        private void _DisplayLicenseInfo(clsLicense License) {

            lblLicenseClass.Text = clsLicenseClass.Find(License.LicenseClassID).ClassName;
            lblFullName.Text = License.Driver.Person.FullName;
            lblLicenseID.Text = License.LicenseID.ToString();
            lblNationalNo.Text = License.Driver.Person.NationalNo;
            pbGender.Image = (License.Driver.Person.Gender == "Male") ? Properties.Resources.male : Properties.Resources.femenine;
            lblGender.Text = License.Driver.Person.Gender;
            lblIssueDate.Text = License.IssueDate.ToShortDateString();
            lblIssueReason.Text = _HandleIssueReason(License.IssueReason);
            lblNote.Text = (License.Notes == "") ? "No Notes" : License.Notes;
            lblIsActive.Text = (License.IsActive) ? "Yes" : "No";
            lblDateOfBirth.Text = License.Driver.Person.DateOfBirth.ToShortDateString();
            lblDriverID.Text = License.DriverID.ToString();
            lblExpirationDate.Text = License.ExpirationDate.ToShortDateString();
            lblIsDetained.Text = License.IsDetained ? "Yes" : "No";

            if ( License.Driver.Person.ImagePath != null) 
                pbPersonPicture.Load(License.Driver.Person.ImagePath);
            else 
                pbPersonPicture.Image = (License.Driver.Person.Gender == "Male") ? Properties.Resources.man : Properties.Resources.woman;
        }

        private void _ResetInfoToDefailt() {

            lblLicenseClass.Text = "N/A";
            lblFullName.Text = "N/A";
            lblLicenseID.Text = "N/A";
            lblNationalNo.Text = "N/A";
            lblGender.Text = "N/A";
            lblIssueDate.Text = "N/A";
            lblIssueReason.Text = "N/A";
            lblNote.Text = "N/A";
            lblIsActive.Text = "N/A";
            lblDateOfBirth.Text = "N/A";
            lblDriverID.Text = "N/A";
            lblExpirationDate.Text = "N/A";
            lblIsDetained.Text = "No";
            pbGender.Image = Properties.Resources.mars;
            pbPersonPicture.Image = Properties.Resources.man;
        }

    }
}