using DVLD_Business_Layer;
using Guna.UI2.WinForms;
using My_Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project {

    public partial class frmAddUpdatePerson : Form {

        public Action<object, int> PersonInfoBack;

        public enum enMode { AddNew, Update };
        private enMode _Mode;

        private int _PersonID;
        private clsPerson _Person;
    
        private bool _IsImageAdded = false;

        public frmAddUpdatePerson() {

            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdatePerson(int PersonID) {

            InitializeComponent();
            _PersonID = PersonID;
            _Mode = enMode.Update;
        }

        // Loading data
        private void frmAddUpdatePerson_Load(object sender, EventArgs e) {

            _InitializeDateTimePicker();
            _FillCountriesInComboBox();
            _LoadData();
        }

        private void _LoadData() {

            cbCountries.SelectedIndex = cbCountries.FindString("Saudi Arabia"); ;

            if (_Mode == enMode.AddNew) {

                lblMode.Text = "Add New Person";
                _Person = new clsPerson();
                return;
            }

            _Person = clsPerson.Find(_PersonID);

            if (_Person == null) {

                MessageBox.Show($"The operation will be cancled because no person with ID {_PersonID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblMode.Text = "Update Person";
            this.Text = lblMode.Text;
            lblPersonID.Text = _PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtEmail.Text = _Person.Email;
            txtNationalNo.Text = _Person.NationalNo;
            txtPhoneNumber.Text = _Person.Phone;
            txtAddress.Text = _Person.Address;
            dtpDateOfBirth.Value = _Person.DateOfBirth;

            if (!string.IsNullOrEmpty(_Person.ImagePath)) {

                pbPersonImage.ImageLocation = _Person.ImagePath;
                _IsImageAdded = true;
                lnklblRemove.Visible = true;
            }
            else {

                pbPersonImage.Image = (_Person.Gender == "Male") ? Properties.Resources.man : Properties.Resources.woman;
                _IsImageAdded = false;
                lnklblRemove.Visible = false;
            }

            if (_Person.Gender == "Male") 
                rbMale.Checked = true;
            else 
                rbFemale.Checked = true;

            cbCountries.SelectedIndex = cbCountries.FindString(_Person.Country.CountryName);
        }

        // Initialize Data in the screen
        private void _FillCountriesInComboBox() {

            DataTable dt = clsCountry.GetAllCountryNames();

            foreach (DataRow row in dt.Rows) 
                cbCountries.Items.Add(row["CountryName"]);
        }

        private void _InitializeDateTimePicker() {

            dtpDateOfBirth.MaxDate = DateTime.Today.AddYears(-18);
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
        }

        // Dealeing with image
        private bool _HandlePersonImage() {

            if (_Person.ImagePath != pbPersonImage.ImageLocation) {

                if (!string.IsNullOrEmpty(_Person.ImagePath)) {

                    try {

                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException ex) {

                        EventLog.WriteEntry(ConfigurationManager.AppSettings["sourceNameForLoggingInEventViewer"],
                            ex.ToString(), EventLogEntryType.Error);
                    }
                }

                if (pbPersonImage.ImageLocation != null) {

                    string SourceImageFile = pbPersonImage.ImageLocation.ToString();

                    if (clsHandleImage.CopyImageToProjectImagesFolder(ref SourceImageFile)) {

                        pbPersonImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else {

                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }

        private void lnklblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

            pbPersonImage.ImageLocation = null;
            pbPersonImage.Image = rbMale.Checked ? Properties.Resources.man : Properties.Resources.woman;

            lnklblRemove.Visible = false;
            _IsImageAdded = false;
        }

        private void lnklbSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

            if (ofdPickPicture.ShowDialog() == DialogResult.OK) {

                pbPersonImage.Load(ofdPickPicture.FileName);
                pbPersonImage.ImageLocation = ofdPickPicture.FileName;
                lnklblRemove.Visible = true;
                _IsImageAdded = true;
            }
        }

        // Confirm person info
        private void btnSave_Click(object sender, EventArgs e) {

             if (!this.ValidateChildren()) {

                MessageBox.Show("Some fields have invalid information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to save this person?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (!_HandlePersonImage()) {

                MessageBox.Show("Cannot handle person's image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Person.NationalNo    = txtNationalNo.Text;
            _Person.FirstName     = txtFirstName.Text;
            _Person.SecondName    = txtSecondName.Text;
            _Person.ThirdName     = txtThirdName.Text;
            _Person.LastName      = txtLastName.Text;
            _Person.Email         = txtEmail.Text;
            _Person.Address       = txtAddress.Text.Trim();
            _Person.Phone         = txtPhoneNumber.Text;
            _Person.Gender        = rbMale.Checked ? "Male" : "Female";
            _Person.DateOfBirth   = dtpDateOfBirth.Value;
            _Person.NationalityID = clsCountry.Find(cbCountries.Text).CountryID;

            _Person.ImagePath = (pbPersonImage.ImageLocation != null) ?
                pbPersonImage.ImageLocation : "";


            if (_Person.Save()) {

                MessageBox.Show("Data Saved Successfully.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {

                MessageBox.Show("Data is Not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Mode = enMode.Update;
            lblMode.Text = "Update Person";
            this.Name = lblMode.Text;
            lblPersonID.Text = _Person.PersonID.ToString();
            PersonInfoBack?.Invoke(this, _Person.PersonID);
        }

        // Gender choice
        private void rbMale_CheckedChanged(object sender, EventArgs e) {

            if (!_IsImageAdded) pbPersonImage.Image = Properties.Resources.man;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e) {

            if (!_IsImageAdded) pbPersonImage.Image = Properties.Resources.woman;
        }

        // Validation on keyboard
        private void txtFullName_KeyPress(object sender, KeyPressEventArgs e) {

            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsPunctuation(e.KeyChar);
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e) {

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e) {

            e.Handled = char.IsPunctuation(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtNationalNo_KeyPress(object sender, KeyPressEventArgs e) {

            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        // Validation for formatting

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e) {

            clsGuna2ControlHelper.ValidateRequiredTextBox((Guna2TextBox)sender, e, errorProvider, "This field is required!");
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e) {

            if (string.IsNullOrWhiteSpace(txtNationalNo.Text)) {

                e.Cancel = true;
                txtNationalNo.Focus();
                errorProvider.SetError(txtNationalNo, "National no shouldn't be empty!");
            }
            else if (txtNationalNo.Text != _Person.NationalNo && clsPerson.IsPersonExist(txtNationalNo.Text)) {

                e.Cancel = true;
                txtNationalNo.Focus();
                errorProvider.SetError(txtNationalNo, "National no is already used!");
            }
            else {

                //e.Cancel = false;
                errorProvider.SetError(txtNationalNo, null);
            }
        }

        private void txtPhoneNumber_Validating(object sender, CancelEventArgs e) {

            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text)) {

                e.Cancel = true;
                txtPhoneNumber.Focus();
                errorProvider.SetError(txtPhoneNumber, "Phone number shouldn't be empty!");
            }
            else if (txtPhoneNumber.Text.Length < 10) {

                e.Cancel = true;
                txtPhoneNumber.Focus();
                errorProvider.SetError(txtPhoneNumber, "Invalid number!");
            }
            else {

                e.Cancel = false;
                errorProvider.SetError(txtPhoneNumber, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e) {

            if (!clsUtil.IsValidEmail(txtEmail.Text) && txtEmail.Text != "") {

                e.Cancel = true;
                txtEmail.Focus();
                errorProvider.SetError(txtEmail, "Invalid email!");
            }
            else {

                e.Cancel = false;
                errorProvider.SetError(txtEmail, null);
            }
        }

        // Close
        private void btnCancel_Click(object sender, EventArgs e) => Close();

    }
}