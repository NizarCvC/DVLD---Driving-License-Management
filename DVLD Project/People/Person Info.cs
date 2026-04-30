using DVLD_Business_Layer;
using DVLD_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project {

    public partial class ctrlPersonInfo : UserControl {

        private int _PersonID;

        public ctrlPersonInfo() {

            InitializeComponent();
        }

        // Loading data
        public void LoadPersonInfo(int PersonID) {

            if (PersonID < 1) {

                _ResetInfoToDefault();
                return;
            }

            clsPerson Person = clsPerson.Find(PersonID);

            if (Person == null) return;

            _PersonID = PersonID;
            _DisplayPersonInfo(Person);
        }

        public void LoadPersonInfo(string NationalNo) {

            if (NationalNo == "") {

                _ResetInfoToDefault();
                return;
            }

            clsPerson Person = clsPerson.Find(NationalNo);

            if (Person == null) return;

            _PersonID = Person.PersonID;
            _DisplayPersonInfo(Person);
        }

        private void _LoadPersonImage(clsPerson Person) {

            if (Person.Gender == "Male")
                pbPersonImage.Image = Properties.Resources.man;
            else
                pbPersonImage.Image = Properties.Resources.woman;

            string ImagePath = Person.ImagePath;

            if (!string.IsNullOrEmpty(ImagePath)) {

                if (File.Exists(ImagePath))
                    pbPersonImage.Load(ImagePath);
                else
                    MessageBox.Show("Could not find the person's image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _DisplayPersonInfo(clsPerson Person) {

            lblPersonID.Text = Person.PersonID.ToString();
            lblFullName.Text = Person.FullName;
            lblNationalNo.Text = Person.NationalNo;
            lblEmail.Text = string.IsNullOrEmpty(Person.Email) ? "None" : Person.Email;
            lblPhoneNumber.Text = Person.Phone;
            lblAddress.Text = Person.Address;
            lblDateOfBirth.Text = Person.DateOfBirth.ToShortDateString();
            lblGender.Text = Person.Gender;
            lblCountry.Text = Person.Country.CountryName;
            pbGender.Image = (Person.Gender == "Male") ? Properties.Resources.male : Properties.Resources.femenine;
            _LoadPersonImage(Person);
            lnklblEditInfo.Enabled = true;
        }

        // Edit person by link
        private void lnklblEditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

            frmAddUpdatePerson frm = new frmAddUpdatePerson(_PersonID);

            frm.PersonInfoBack += UpdatePerson_DataBack;

            frm.ShowDialog();
        }

        private void UpdatePerson_DataBack(object sender, int PersonID) => LoadPersonInfo(PersonID);

        // Reset form
        private void _ResetInfoToDefault() {

            lnklblEditInfo.Enabled = false;
            lblPersonID.Text = "None";
            lblFullName.Text = "None";
            lblNationalNo.Text = "None";
            lblEmail.Text = "None";
            lblPhoneNumber.Text = "None";
            lblAddress.Text = "None";
            lblDateOfBirth.Text = "None";
            lblGender.Text = "None";
            lblCountry.Text = "None";
            pbGender.Image = Properties.Resources.mars;
            pbPersonImage.Image = Properties.Resources.man;
        }

    }
}