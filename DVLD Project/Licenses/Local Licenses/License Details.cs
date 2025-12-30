using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Manage_Licenses_Screens {

    public partial class frmLicenseDetails : Form {

        public enum enIDType { ApplicationID = 1, LicenseID = 2 }
        private enIDType _IDType;
        private int _ID;

        public frmLicenseDetails(int ID, enIDType IDType) {

            InitializeComponent();

            _ID = ID;
            _IDType = IDType;
        }

        private void frmLicenseDetails_Load(object sender, EventArgs e) {

            if (_IDType == enIDType.ApplicationID)
                ctrlLocalLicenseInfo1.LoadLicenseInfoByAppID(_ID);
            else
                ctrlLocalLicenseInfo1.LoadLicenseInfoByLicenseID(_ID);
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

    }
}