using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Manage_International_Licenses_Screens {

    public partial class frmInternationalLicenseDetails : Form {

        private int _InternationalLicenseID;

        public frmInternationalLicenseDetails(int internationalLicenseID) {

            InitializeComponent();
            _InternationalLicenseID = internationalLicenseID;
        }

        private void frmInternationalLicenseDetails_Load(object sender, EventArgs e) {

            ctrlInternationalLicenseInfo1.LoadInternationalLicenseInfo(_InternationalLicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

    }
}