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

namespace DVLD_Project.Manage_People_Screens {

    public partial class ctrlUserInfo : UserControl {

        public ctrlUserInfo() {

            InitializeComponent();
        }

        // Loading data
        public void LoadUserInfo(int UserID) {

            if (UserID < 1) {

                _ResetInfoToDefault();
                return;
            }

            clsUser User = clsUser.Find(UserID);

            if (User == null) return;

            _DisplayUserInfo(User);
        }

        public void LoadUserInfo(string Username) {

            if (Username == "") {

                _ResetInfoToDefault();
                return;
            }

            clsUser User = clsUser.Find(Username);

            if (User == null) return;

            _DisplayUserInfo(User);
        }

        private void _DisplayUserInfo(clsUser User) {

            ctrlPersonInfo.LoadPersonInfo(User.PersonID);
            lblUserID.Text = User.UserID.ToString();
            lblUsername.Text = User.Username;
            lblIsActive.Text = (User.IsActive) ? "Yes" : "No";
        }

        private void _ResetInfoToDefault() {

            ctrlPersonInfo.LoadPersonInfo(-1);
            lblUserID.Text = "None";
            lblUsername.Text = "None";
            lblIsActive.Text = "None";
        }

    }
}