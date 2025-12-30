using DVLD_Project;
using DVLD_Project.Manage_Application_Types_Screens;
using DVLD_Project.Manage_Detained_Licenses__Screens;
using DVLD_Project.Manage_Detained_Licenses_Screens;
using DVLD_Project.Manage_Inernational_Licenses_Screens;
using DVLD_Project.Manage_License_Classes_Screens;
using DVLD_Project.Manage_Licenses_Screens;
using DVLD_Project.Manage_Local_Licenses_Screens;
using DVLD_Project.Manage_People_Screens;
using DVLD_Project.Manage_Test_Types_Screens;
using DVLD_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer {

    public partial class frmMainScreen : Form {

        public frmMainScreen() {

            InitializeComponent();
        }

        private void frmMainScreen_Load(object sender, EventArgs e) {

            timer1.Start();
            _PrepareCurrentUserInfo();
            msOptions.Renderer = new CustomMenuRenderer();
        }

        private void _PrepareCurrentUserInfo() {

            lblUsername.Text = clsGlobalSettings.CurrentUser.Username;

            if (clsGlobalSettings.CurrentUser.Person.ImagePath != null) {

                pbUsernamePicture.Load(clsGlobalSettings.CurrentUser.Person.ImagePath);
                return;
            }

            pbUsernamePicture.Image = (clsGlobalSettings.CurrentUser.Person.Gender == "Male") ? Resources.man : Resources.woman;
        }

        private void timer1_Tick(object sender, EventArgs e) {

            lblTimeNow.Text = DateTime.Now.ToString("H:mm");
        }

        // People
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e) {

            frmManagePeople frm = new frmManagePeople();
            frm.ShowDialog();
        }

        // Users
        private void usersToolStripMenuItem_Click(object sender, EventArgs e) {

            frmManageUsers frm = new frmManageUsers();
            frm.ShowDialog();
        }

        // Drivers
        private void driversToolStripMenuItem_Click(object sender, EventArgs e) {

            frmDriversList frm = new frmDriversList();
            frm.ShowDialog();
        }

        // Account settings options
        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e) {

            frmUserDetails frm = new frmUserDetails(clsGlobalSettings.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e) {

            frmChangePassword frm = new frmChangePassword(clsGlobalSettings.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e) {

            this.Hide();
            clsGlobalSettings.CurrentUser = null;
            frmLoginScreen frmLoginScreen = new frmLoginScreen();

            if (frmLoginScreen.ShowDialog() == DialogResult.OK) {

                _PrepareCurrentUserInfo();
                this.Show();
            }
            else {

                Application.Exit();
            }
        }

        // Applications options
        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e) {

            frmManageApplicationTypes frm = new frmManageApplicationTypes();
            frm.ShowDialog();
        }

        private void managesTestTypesToolStripMenuItem_Click(object sender, EventArgs e) {

            frmManageTestTypes frm = new frmManageTestTypes();
            frm.ShowDialog();
        }

        private void localDrivingLiecnseApplicationsToolStripMenuItem_Click(object sender, EventArgs e) {

            frmLocalDrivingLicenseApplications frm = new frmLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e) {

            frmNewLDLApplication frm = new frmNewLDLApplication();
            frm.ShowDialog();
        }

        private void internationalLiToolStripMenuItem_Click(object sender, EventArgs e) {

            frmInernationalLicenseApplicationsList frm = new frmInernationalLicenseApplicationsList();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e) {

            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e) {

            frmRenewLocalDrivingLicense frm = new frmRenewLocalDrivingLicense();
            frm.ShowDialog();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e) {

            frmReplacementForDamagedOrLost frm = new frmReplacementForDamagedOrLost();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e) {

            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e) {

            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void relToolStripMenuItem_Click(object sender, EventArgs e) {

            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e) {

            frmListDetainedLicenses frm = new frmListDetainedLicenses();
            frm.ShowDialog();
        }

        private void manageLicenseClassesToolStripMenuItem_Click(object sender, EventArgs e) {

            frmManageLicenseClasses frm = new frmManageLicenseClasses();
            frm.ShowDialog();
        }
    
    }

    // For make some changes to the menu strip 
    public class CustomMenuRenderer : ToolStripProfessionalRenderer {

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e) {

            int arrowSize = 10;

            using (Brush b = new SolidBrush(e.ArrowColor)) {

                Point center = new Point(
                    e.ArrowRectangle.Left + e.ArrowRectangle.Width / 2,
                    e.ArrowRectangle.Top + e.ArrowRectangle.Height / 2);

                Point[] arrow = new Point[] {

                    new Point(center.X - arrowSize / 2, center.Y - arrowSize),
                    new Point(center.X - arrowSize / 2, center.Y + arrowSize),
                    new Point(center.X + arrowSize / 2, center.Y)
                };

                e.Graphics.FillPolygon(b, arrow);
            }
        }

        //protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e) {

        //    Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);

        //    if (e.Item.Selected) {

        //        using (SolidBrush brush = new SolidBrush(Color.Silver)) {  // حط اللون اللي تبغاه

        //            e.Graphics.FillRectangle(brush, rc);
        //        }

        //        e.Graphics.DrawRectangle(Pens.DodgerBlue, 0, 0, rc.Width - 1, rc.Height - 1);
        //    }
        //    else {

        //        base.OnRenderMenuItemBackground(e);
        //    }
        //}

    }

}