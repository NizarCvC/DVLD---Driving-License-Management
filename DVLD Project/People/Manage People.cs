using DVLD_Business_Layer;
using Guna.UI2.WinForms;
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

namespace DVLD_Project {

    public partial class frmManagePeople : Form {

        private string Column, Filter;

        public frmManagePeople() {

            InitializeComponent();
            _RefreshAll();
        }

        // Refreshing data
        private void _RefreshPeopleList() {

            dgvAllPeople.DataSource = clsPerson.GetAllPeople();
        }

        private void _RefreshNumberOfRecords() {

            lblNumberOfRecords.Text = clsGuna2ControlHelper.NumberOfRecords(dgvAllPeople).ToString();
        }

        private void _RefreshAll() {

            _RefreshPeopleList();
            _RefreshNumberOfRecords();
        }

        // Manuplating data
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvAllPeople))
                return;

            frmPersonDetails frm = new frmPersonDetails((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshAll();
        }

        private void dgvAllPeople_DoubleClick(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvAllPeople))
                return;

            frmPersonDetails frm = new frmPersonDetails((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshAll();
        }

        private void AddNewPerson_Click(object sender, EventArgs e) {

            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();
            _RefreshAll();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvAllPeople))
                return;

            frmAddUpdatePerson frm = new frmAddUpdatePerson((int) dgvAllPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshAll();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvAllPeople))
                return;

            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvAllPeople.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes) {

                if (clsPerson.DeletePerson((int)dgvAllPeople.CurrentRow.Cells[0].Value)) {

                    MessageBox.Show("Person deleted successfully.", "successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshAll();
                }
                else {

                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Need to implement later 
        private void ContactToolStripMenuItem_Click(object sender, EventArgs e) { 

            if (!clsGuna2ControlHelper.IsDataGridViewRowSelected(dgvAllPeople))
                return;

            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        // Filter data
        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e) {

            txtFilter.Clear();

            if (cbFilters.SelectedIndex == 0) {

                txtFilter.Visible = false;
                cbFilterGender.Visible = false;
                _RefreshAll();
                Column = "";
                Filter = "";
            }
            else if (cbFilters.SelectedIndex == 8) {

                txtFilter.Visible = false;
                cbFilterGender.Visible = true;
                Column = "Gender";
                _RefreshAll();
            }
            else {

                txtFilter.Visible = true;
                cbFilterGender.Visible = false;
                Column = (cbFilters.SelectedIndex == 7) ? "CountryName" : cbFilters.SelectedItem.ToString();
                _RefreshAll();
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e) {

            if (txtFilter.Text == "") {

                _RefreshAll();
                return;
            }

            Filter = txtFilter.Text;
            dgvAllPeople.DataSource = clsPerson.FilterPeople(Column, Filter);
            _RefreshNumberOfRecords();
        }

        private void cbFilterGender_SelectedIndexChanged(object sender, EventArgs e) {

            if (cbFilterGender.SelectedIndex == 0) {

                Filter = "";
                _RefreshAll();
                return;
            }

            // 0 for male, 1 for female
            Filter = ((cbFilterGender.SelectedIndex == 1) ? 0 : 1).ToString();

            dgvAllPeople.DataSource = clsPerson.FilterPeople(Column, Filter);
            _RefreshNumberOfRecords();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e) {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (cbFilters.SelectedIndex == 1 || cbFilters.SelectedIndex == 9)) {

                e.Handled = true;
                return;
            }

            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsPunctuation(e.KeyChar) && (cbFilters.SelectedIndex == 3 || cbFilters.SelectedIndex == 4 || cbFilters.SelectedIndex == 5 || cbFilters.SelectedIndex == 6))
                e.Handled = true;
        }

        // Close
        private void btnClose_Click(object sender, EventArgs e) => Close();

    }
}