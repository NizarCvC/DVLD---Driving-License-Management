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

namespace DVLD_Project {

    public partial class ctrlFilterPersonInfo : UserControl {

        public event EventHandler<PersonIDEventArgs> OnPersonIDFound;
        public class PersonIDEventArgs : EventArgs {

            public int PersonID { get; }
            public PersonIDEventArgs(int personID) => PersonID = personID;
        }

        public void RaiseOnPersonIDFoundEvent(int PersonID) 
            => RaiseOnPersonIDFoundEvent(new PersonIDEventArgs(PersonID));

        protected virtual void RaiseOnPersonIDFoundEvent(PersonIDEventArgs e) 
            => OnPersonIDFound?.Invoke(this, e);

        public ctrlFilterPersonInfo() {

            InitializeComponent();
        }

        // Filter person
        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e) {

            txtFilter.Clear();

            bool HasFilter = (cbFilters.SelectedIndex != 0);
            btnSearchPerson.Enabled = HasFilter;
            txtFilter.Visible = HasFilter;
        }

        // Search Person
        private void btnSearchPerson_Click(object sender, EventArgs e) {

            if (cbFilters.SelectedIndex == 0 || txtFilter.Text == "") return;

            if (cbFilters.SelectedIndex == 1) {

                if (int.TryParse(txtFilter.Text, out int PersonID)) 
                    _SearchPersonByID(PersonID);
                else
                    MessageBox.Show("Invalid Person ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {

                _SearchByNationalNo(txtFilter.Text);
            }
        }

        private void _SearchPersonByID(int PersonID) {

            if (clsPerson.IsPersonExist(PersonID)) {

                ctrlPersonInfo.LoadPersonInfo(PersonID);
                RaiseOnPersonIDFoundEvent(PersonID);
            }
            else {

                MessageBox.Show("The ID is not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonInfo.LoadPersonInfo(-1);
                RaiseOnPersonIDFoundEvent(0);

                txtFilter.Clear();
            }
        }

        private void _SearchByNationalNo(string NationalNo) {

            if (clsPerson.IsPersonExist(NationalNo)) {

                ctrlPersonInfo.LoadPersonInfo(NationalNo);
                RaiseOnPersonIDFoundEvent(clsPerson.Find(NationalNo).PersonID);
            }
            else {

                MessageBox.Show("The National No is not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonInfo.LoadPersonInfo("");
                RaiseOnPersonIDFoundEvent(0);

                txtFilter.Clear();
            }
        }

        //Add Person
        private void btnAddNewPerson_Click(object sender, EventArgs e) {

            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.PersonInfoBack += NewPerson_DataBack;
            frm.ShowDialog();
        }

        private void NewPerson_DataBack(object sender, int PersonID) {

            ctrlPersonInfo.LoadPersonInfo(PersonID);
            cbFilters.SelectedIndex = 1;
            txtFilter.Text = PersonID.ToString();
            RaiseOnPersonIDFoundEvent(PersonID);
        }

        // Validation on keyboard
        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e) {

            if (cbFilters.SelectedIndex == 1 && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;

            if (cbFilters.SelectedIndex == 2 && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar)) 
                e.Handled = true;
        }

    }
}