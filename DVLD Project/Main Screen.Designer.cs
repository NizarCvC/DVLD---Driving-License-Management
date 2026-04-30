namespace DVLD_Presentation_Layer {
    partial class frmMainScreen {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainScreen));
            this.msOptions = new System.Windows.Forms.MenuStrip();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drivingLicensesServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.replacementForLostOrDamagedLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseDetainedDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localDrivingLiecnseApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDetainedLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managesTestTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageLicenseClassesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbUsernamePicture = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTimeNow = new System.Windows.Forms.Label();
            this.msOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsernamePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // msOptions
            // 
            this.msOptions.AutoSize = false;
            this.msOptions.BackColor = System.Drawing.Color.White;
            this.msOptions.Font = new System.Drawing.Font("Cascadia Mono", 17F);
            this.msOptions.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.msOptions.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.msOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationsToolStripMenuItem,
            this.peopleToolStripMenuItem,
            this.driversToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.accountSettingsToolStripMenuItem});
            this.msOptions.Location = new System.Drawing.Point(0, 0);
            this.msOptions.Name = "msOptions";
            this.msOptions.Size = new System.Drawing.Size(2564, 102);
            this.msOptions.TabIndex = 1;
            this.msOptions.Text = "Options";
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drivingLicensesServicesToolStripMenuItem,
            this.manageApplicationsToolStripMenuItem,
            this.detainLicensesToolStripMenuItem,
            this.manageApplicationTypesToolStripMenuItem,
            this.managesTestTypesToolStripMenuItem,
            this.manageLicenseClassesToolStripMenuItem});
            this.applicationsToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Mono", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applicationsToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.application;
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            this.applicationsToolStripMenuItem.Size = new System.Drawing.Size(368, 98);
            this.applicationsToolStripMenuItem.Text = "&Applications";
            // 
            // drivingLicensesServicesToolStripMenuItem
            // 
            this.drivingLicensesServicesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDrivingLicenseToolStripMenuItem,
            this.renewDrivingLicenseToolStripMenuItem,
            this.toolStripMenuItem1,
            this.replacementForLostOrDamagedLicenseToolStripMenuItem,
            this.releaseDetainedDrivingLicenseToolStripMenuItem});
            this.drivingLicensesServicesToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Mono", 12.125F);
            this.drivingLicensesServicesToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.driving_license;
            this.drivingLicensesServicesToolStripMenuItem.Name = "drivingLicensesServicesToolStripMenuItem";
            this.drivingLicensesServicesToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 15, 0, 2);
            this.drivingLicensesServicesToolStripMenuItem.Size = new System.Drawing.Size(635, 65);
            this.drivingLicensesServicesToolStripMenuItem.Text = "Driving Licenses Services";
            this.drivingLicensesServicesToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // newDrivingLicenseToolStripMenuItem
            // 
            this.newDrivingLicenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localLicenseToolStripMenuItem,
            this.internationalLicenseToolStripMenuItem});
            this.newDrivingLicenseToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Mono", 10.125F);
            this.newDrivingLicenseToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.drivers_license;
            this.newDrivingLicenseToolStripMenuItem.Name = "newDrivingLicenseToolStripMenuItem";
            this.newDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(777, 44);
            this.newDrivingLicenseToolStripMenuItem.Text = "New Driving License";
            // 
            // localLicenseToolStripMenuItem
            // 
            this.localLicenseToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Mono", 9.125F);
            this.localLicenseToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.نسخة_٣_من_driving_license;
            this.localLicenseToolStripMenuItem.Name = "localLicenseToolStripMenuItem";
            this.localLicenseToolStripMenuItem.Size = new System.Drawing.Size(464, 44);
            this.localLicenseToolStripMenuItem.Text = "Local License";
            this.localLicenseToolStripMenuItem.Click += new System.EventHandler(this.localLicenseToolStripMenuItem_Click);
            // 
            // internationalLicenseToolStripMenuItem
            // 
            this.internationalLicenseToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Mono", 9.125F);
            this.internationalLicenseToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.نسخة_٢_من_driver_license;
            this.internationalLicenseToolStripMenuItem.Name = "internationalLicenseToolStripMenuItem";
            this.internationalLicenseToolStripMenuItem.Size = new System.Drawing.Size(464, 44);
            this.internationalLicenseToolStripMenuItem.Text = "International License";
            this.internationalLicenseToolStripMenuItem.Click += new System.EventHandler(this.internationalLicenseToolStripMenuItem_Click);
            // 
            // renewDrivingLicenseToolStripMenuItem
            // 
            this.renewDrivingLicenseToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Mono", 10.125F);
            this.renewDrivingLicenseToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.policy;
            this.renewDrivingLicenseToolStripMenuItem.Name = "renewDrivingLicenseToolStripMenuItem";
            this.renewDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(777, 44);
            this.renewDrivingLicenseToolStripMenuItem.Text = "Renew Driving License";
            this.renewDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.renewDrivingLicenseToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(774, 6);
            // 
            // replacementForLostOrDamagedLicenseToolStripMenuItem
            // 
            this.replacementForLostOrDamagedLicenseToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Mono", 10.125F);
            this.replacementForLostOrDamagedLicenseToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.testing;
            this.replacementForLostOrDamagedLicenseToolStripMenuItem.Name = "replacementForLostOrDamagedLicenseToolStripMenuItem";
            this.replacementForLostOrDamagedLicenseToolStripMenuItem.Size = new System.Drawing.Size(777, 44);
            this.replacementForLostOrDamagedLicenseToolStripMenuItem.Text = "Replacement for Lost or Damaged License";
            this.replacementForLostOrDamagedLicenseToolStripMenuItem.Click += new System.EventHandler(this.replacementForLostOrDamagedLicenseToolStripMenuItem_Click);
            // 
            // releaseDetainedDrivingLicenseToolStripMenuItem
            // 
            this.releaseDetainedDrivingLicenseToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Mono", 10.125F);
            this.releaseDetainedDrivingLicenseToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.open_hand;
            this.releaseDetainedDrivingLicenseToolStripMenuItem.Name = "releaseDetainedDrivingLicenseToolStripMenuItem";
            this.releaseDetainedDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(777, 44);
            this.releaseDetainedDrivingLicenseToolStripMenuItem.Text = "Release Detained Driving License";
            this.releaseDetainedDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.releaseDetainedDrivingLicenseToolStripMenuItem_Click);
            // 
            // manageApplicationsToolStripMenuItem
            // 
            this.manageApplicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localDrivingLiecnseApplicationsToolStripMenuItem,
            this.internationalLiToolStripMenuItem});
            this.manageApplicationsToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.manageApplicationsToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.open_enrollment;
            this.manageApplicationsToolStripMenuItem.Name = "manageApplicationsToolStripMenuItem";
            this.manageApplicationsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 15, 0, 2);
            this.manageApplicationsToolStripMenuItem.Size = new System.Drawing.Size(635, 65);
            this.manageApplicationsToolStripMenuItem.Text = "Manage Applications";
            // 
            // localDrivingLiecnseApplicationsToolStripMenuItem
            // 
            this.localDrivingLiecnseApplicationsToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Mono", 10F);
            this.localDrivingLiecnseApplicationsToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.profiles;
            this.localDrivingLiecnseApplicationsToolStripMenuItem.Name = "localDrivingLiecnseApplicationsToolStripMenuItem";
            this.localDrivingLiecnseApplicationsToolStripMenuItem.Size = new System.Drawing.Size(697, 44);
            this.localDrivingLiecnseApplicationsToolStripMenuItem.Text = "Local Driving License Applications";
            this.localDrivingLiecnseApplicationsToolStripMenuItem.Click += new System.EventHandler(this.localDrivingLiecnseApplicationsToolStripMenuItem_Click);
            // 
            // internationalLiToolStripMenuItem
            // 
            this.internationalLiToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Mono", 10F);
            this.internationalLiToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.earth;
            this.internationalLiToolStripMenuItem.Name = "internationalLiToolStripMenuItem";
            this.internationalLiToolStripMenuItem.Size = new System.Drawing.Size(697, 44);
            this.internationalLiToolStripMenuItem.Text = "International License Applications";
            this.internationalLiToolStripMenuItem.Click += new System.EventHandler(this.internationalLiToolStripMenuItem_Click);
            // 
            // detainLicensesToolStripMenuItem
            // 
            this.detainLicensesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageDetainedLicensesToolStripMenuItem,
            this.detainLicenseToolStripMenuItem,
            this.relToolStripMenuItem});
            this.detainLicensesToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.detainLicensesToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.banned;
            this.detainLicensesToolStripMenuItem.Name = "detainLicensesToolStripMenuItem";
            this.detainLicensesToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 15, 0, 2);
            this.detainLicensesToolStripMenuItem.Size = new System.Drawing.Size(635, 65);
            this.detainLicensesToolStripMenuItem.Text = "Detain Licenses";
            // 
            // manageDetainedLicensesToolStripMenuItem
            // 
            this.manageDetainedLicensesToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Mono", 10F);
            this.manageDetainedLicensesToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.fake;
            this.manageDetainedLicensesToolStripMenuItem.Name = "manageDetainedLicensesToolStripMenuItem";
            this.manageDetainedLicensesToolStripMenuItem.Size = new System.Drawing.Size(537, 44);
            this.manageDetainedLicensesToolStripMenuItem.Text = "Manage Detained Licenses";
            this.manageDetainedLicensesToolStripMenuItem.Click += new System.EventHandler(this.manageDetainedLicensesToolStripMenuItem_Click);
            // 
            // detainLicenseToolStripMenuItem
            // 
            this.detainLicenseToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Mono", 10F);
            this.detainLicenseToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.نسخة_من_cancel;
            this.detainLicenseToolStripMenuItem.Name = "detainLicenseToolStripMenuItem";
            this.detainLicenseToolStripMenuItem.Size = new System.Drawing.Size(537, 44);
            this.detainLicenseToolStripMenuItem.Text = "Detain License";
            this.detainLicenseToolStripMenuItem.Click += new System.EventHandler(this.detainLicenseToolStripMenuItem_Click);
            // 
            // relToolStripMenuItem
            // 
            this.relToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Mono", 10F);
            this.relToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.open_hand;
            this.relToolStripMenuItem.Name = "relToolStripMenuItem";
            this.relToolStripMenuItem.Size = new System.Drawing.Size(537, 44);
            this.relToolStripMenuItem.Text = "Release Detained License";
            this.relToolStripMenuItem.Click += new System.EventHandler(this.relToolStripMenuItem_Click);
            // 
            // manageApplicationTypesToolStripMenuItem
            // 
            this.manageApplicationTypesToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.manageApplicationTypesToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.نسخة_من_application;
            this.manageApplicationTypesToolStripMenuItem.Name = "manageApplicationTypesToolStripMenuItem";
            this.manageApplicationTypesToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 15, 0, 2);
            this.manageApplicationTypesToolStripMenuItem.Size = new System.Drawing.Size(635, 65);
            this.manageApplicationTypesToolStripMenuItem.Text = "Manage Application Types";
            this.manageApplicationTypesToolStripMenuItem.Click += new System.EventHandler(this.manageApplicationTypesToolStripMenuItem_Click);
            // 
            // managesTestTypesToolStripMenuItem
            // 
            this.managesTestTypesToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.managesTestTypesToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.test1;
            this.managesTestTypesToolStripMenuItem.Name = "managesTestTypesToolStripMenuItem";
            this.managesTestTypesToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 15, 0, 2);
            this.managesTestTypesToolStripMenuItem.Size = new System.Drawing.Size(635, 65);
            this.managesTestTypesToolStripMenuItem.Text = "Manage Test Types";
            this.managesTestTypesToolStripMenuItem.Click += new System.EventHandler(this.managesTestTypesToolStripMenuItem_Click);
            // 
            // manageLicenseClassesToolStripMenuItem
            // 
            this.manageLicenseClassesToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.manageLicenseClassesToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.نسخة_٢_من_driving_license;
            this.manageLicenseClassesToolStripMenuItem.Name = "manageLicenseClassesToolStripMenuItem";
            this.manageLicenseClassesToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 15, 0, 2);
            this.manageLicenseClassesToolStripMenuItem.Size = new System.Drawing.Size(635, 65);
            this.manageLicenseClassesToolStripMenuItem.Text = "Manage License Classes";
            this.manageLicenseClassesToolStripMenuItem.Click += new System.EventHandler(this.manageLicenseClassesToolStripMenuItem_Click);
            // 
            // peopleToolStripMenuItem
            // 
            this.peopleToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Mono", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.peopleToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.team;
            this.peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            this.peopleToolStripMenuItem.Size = new System.Drawing.Size(230, 98);
            this.peopleToolStripMenuItem.Text = "&People";
            this.peopleToolStripMenuItem.Click += new System.EventHandler(this.peopleToolStripMenuItem_Click);
            // 
            // driversToolStripMenuItem
            // 
            this.driversToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Mono", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driversToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.taxi_driver;
            this.driversToolStripMenuItem.Name = "driversToolStripMenuItem";
            this.driversToolStripMenuItem.Size = new System.Drawing.Size(253, 98);
            this.driversToolStripMenuItem.Text = "&Drivers";
            this.driversToolStripMenuItem.Click += new System.EventHandler(this.driversToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Mono", 17F);
            this.usersToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.management;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(232, 98);
            this.usersToolStripMenuItem.Text = "&Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // accountSettingsToolStripMenuItem
            // 
            this.accountSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentUserInfoToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.toolStripMenuItem3,
            this.signOutToolStripMenuItem});
            this.accountSettingsToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.settings;
            this.accountSettingsToolStripMenuItem.Name = "accountSettingsToolStripMenuItem";
            this.accountSettingsToolStripMenuItem.Size = new System.Drawing.Size(529, 98);
            this.accountSettingsToolStripMenuItem.Text = "A&ccount Settings";
            // 
            // currentUserInfoToolStripMenuItem
            // 
            this.currentUserInfoToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.currentUserInfoToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.businessman;
            this.currentUserInfoToolStripMenuItem.Name = "currentUserInfoToolStripMenuItem";
            this.currentUserInfoToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 15, 0, 2);
            this.currentUserInfoToolStripMenuItem.Size = new System.Drawing.Size(506, 75);
            this.currentUserInfoToolStripMenuItem.Text = "Current User Info";
            this.currentUserInfoToolStripMenuItem.Click += new System.EventHandler(this.currentUserInfoToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.changePasswordToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.password;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 15, 0, 2);
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(506, 75);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(503, 6);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Font = new System.Drawing.Font("Cascadia Mono", 12F);
            this.signOutToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.logout;
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 15, 0, 2);
            this.signOutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(506, 75);
            this.signOutToolStripMenuItem.Text = "Sign Out";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // pbUsernamePicture
            // 
            this.pbUsernamePicture.BackColor = System.Drawing.Color.Transparent;
            this.pbUsernamePicture.ImageRotate = 0F;
            this.pbUsernamePicture.Location = new System.Drawing.Point(2146, 12);
            this.pbUsernamePicture.Name = "pbUsernamePicture";
            this.pbUsernamePicture.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbUsernamePicture.Size = new System.Drawing.Size(83, 83);
            this.pbUsernamePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUsernamePicture.TabIndex = 2;
            this.pbUsernamePicture.TabStop = false;
            this.pbUsernamePicture.UseTransparentBackground = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2252, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 43);
            this.label2.TabIndex = 4;
            this.label2.Text = "Current User";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.White;
            this.lblUsername.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(2252, 52);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(95, 43);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "None";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblTimeNow
            // 
            this.lblTimeNow.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeNow.Font = new System.Drawing.Font("Segoe UI", 56F);
            this.lblTimeNow.ForeColor = System.Drawing.Color.White;
            this.lblTimeNow.Location = new System.Drawing.Point(2123, 102);
            this.lblTimeNow.Name = "lblTimeNow";
            this.lblTimeNow.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTimeNow.Size = new System.Drawing.Size(441, 199);
            this.lblTimeNow.TabIndex = 3;
            this.lblTimeNow.Text = "00:00";
            this.lblTimeNow.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.SaddleBrown;
            this.BackgroundImage = global::DVLD_Project.Properties.Resources.Blue_Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(2564, 1007);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTimeNow);
            this.Controls.Add(this.pbUsernamePicture);
            this.Controls.Add(this.msOptions);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msOptions;
            this.Name = "frmMainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Screen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainScreen_Load);
            this.msOptions.ResumeLayout(false);
            this.msOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsernamePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msOptions;
        private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drivingLicensesServicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managesTestTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renewDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem localLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replacementForLostOrDamagedLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localDrivingLiecnseApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDetainedLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentUserInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbUsernamePicture;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem manageLicenseClassesToolStripMenuItem;
        private System.Windows.Forms.Label lblTimeNow;
    }
}