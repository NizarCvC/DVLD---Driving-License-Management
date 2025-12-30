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

    public partial class ctrlInternationalLicenseInfo : UserControl {

        public ctrlInternationalLicenseInfo() {

            InitializeComponent();
        }

        public void LoadInternationalLicenseInfo(int InternationalLicenseID) {

            if (InternationalLicenseID == -1) {

                _ResetInternationalLicenseScreen();
                return;
            }

            clsInternationalLicense InternationalLicense = clsInternationalLicense.Find(InternationalLicenseID);

            if (InternationalLicense == null) return;

            _DisplayInernationalInfo(InternationalLicense);
        }

        public void _DisplayInernationalInfo(clsInternationalLicense InternationalLicense) {

            lblFullName.Text = InternationalLicense.Driver.Person.FullName;
            lblInternationalLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
            lblLocalLicenseID.Text = InternationalLicense.LocalLicneseID.ToString();
            lblNationalNo.Text = InternationalLicense.Driver.Person.NationalNo;
            lblIssueDate.Text = InternationalLicense.IssueDate.ToShortDateString();
            lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
            lblIsActive.Text = (InternationalLicense.IsActive == true) ? "Yes" : "No";
            lblDateOfBirth.Text = InternationalLicense.Driver.Person.DateOfBirth.ToShortDateString();
            lblDriverID.Text = InternationalLicense.DriverID.ToString();
            lblExpirationDate.Text = InternationalLicense.ExpirationDate.ToShortDateString();

            pbGender.Image = (InternationalLicense.Driver.Person.Gender == "Male") ? Properties.Resources.male : Properties.Resources.femenine;

            if (!string.IsNullOrEmpty(InternationalLicense.Driver.Person.ImagePath))
                pbPersonPicture.Load(InternationalLicense.Driver.Person.ImagePath);
            else
                pbPersonPicture.Image = (InternationalLicense.Driver.Person.Gender == "Male") ? Properties.Resources.man : Properties.Resources.woman;
        }

        private void _ResetInternationalLicenseScreen() {

            lblFullName.Text = "N/A";
            lblInternationalLicenseID.Text = "N/A";
            lblLocalLicenseID.Text = "N/A";
            lblNationalNo.Text = "N/A";
            lblIssueDate.Text = "N/A";
            lblApplicationID.Text = "N/A";
            lblIsActive.Text = "N/A";
            lblDateOfBirth.Text = "N/A";
            lblDriverID.Text = "N/A";
            lblExpirationDate.Text = "N/A";
            pbGender.Image = Properties.Resources.mars;
            pbPersonPicture.Image = Properties.Resources.man;
        }

    }
}