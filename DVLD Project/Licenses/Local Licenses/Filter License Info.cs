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

    public partial class ctrlFilterLicense : UserControl {

        private int _LicenseIDValue;

        public bool FilterEnabled {

            get => gbFilterLicense.Enabled;

            set => gbFilterLicense.Enabled = value;
        }

        public int LicenseIDValue { 
            
            get => _LicenseIDValue;

            set {

                _LicenseIDValue = value;
                txtFilter.Text = value > 0 ? value.ToString() : string.Empty;
                gbFilterLicense.Enabled = value <= 0;
                ctrlLocalLicenseInfo1.LoadLicenseInfoByLicenseID(value > 0 ? value : -1);
                RaiseLicenseIDFoundEvent(_LicenseIDValue);
            }
        }

        public event EventHandler<LicenseIDEventArgs> OnLicenseIDFound;
        public class LicenseIDEventArgs : EventArgs {

            public int LicenseID { get; }

            public LicenseIDEventArgs(int LicenseID) => this.LicenseID = LicenseID;
        }

        public void RaiseLicenseIDFoundEvent(int LicenseID)
            => RaiseLicenseIDFoundEvent(new LicenseIDEventArgs(LicenseID));

        protected virtual void RaiseLicenseIDFoundEvent(LicenseIDEventArgs e)
            => OnLicenseIDFound?.Invoke(this, e);

        public ctrlFilterLicense() => InitializeComponent();

        private void _SearchByLicenseID(int LicenseID) {

            if (clsLicense.IsLicenseExists(LicenseID)) {

                ctrlLocalLicenseInfo1.LoadLicenseInfoByLicenseID(LicenseID);
                RaiseLicenseIDFoundEvent(LicenseID);
            }
            else {

                MessageBox.Show("The ID is not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlLocalLicenseInfo1.LoadLicenseInfoByLicenseID(-1);
                RaiseLicenseIDFoundEvent(0);
                txtFilter.Clear();
            }
        }

        private void btnSearchLicense_Click(object sender, EventArgs e) {

            if (int.TryParse(txtFilter.Text, out int LicenseID))
                _SearchByLicenseID(LicenseID);
            else
                MessageBox.Show("Invalid License ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e) {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

    }
}