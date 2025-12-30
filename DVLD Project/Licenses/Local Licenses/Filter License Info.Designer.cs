namespace DVLD_Project.User_Controls {
    partial class ctrlFilterLicense {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.gbFilterLicense = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlLocalLicenseInfo1 = new DVLD_Project.User_Controls.ctrlLocalLicenseInfo();
            this.btnSearchLicense = new Guna.UI2.WinForms.Guna2ImageButton();
            this.txtFilter = new Guna.UI2.WinForms.Guna2TextBox();
            this.gbFilterLicense.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilterLicense
            // 
            this.gbFilterLicense.Controls.Add(this.btnSearchLicense);
            this.gbFilterLicense.Controls.Add(this.label2);
            this.gbFilterLicense.Controls.Add(this.txtFilter);
            this.gbFilterLicense.CustomBorderColor = System.Drawing.Color.DeepSkyBlue;
            this.gbFilterLicense.FillColor = System.Drawing.Color.PaleTurquoise;
            this.gbFilterLicense.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilterLicense.ForeColor = System.Drawing.Color.Black;
            this.gbFilterLicense.Location = new System.Drawing.Point(0, 0);
            this.gbFilterLicense.Name = "gbFilterLicense";
            this.gbFilterLicense.Size = new System.Drawing.Size(845, 239);
            this.gbFilterLicense.TabIndex = 1;
            this.gbFilterLicense.Text = "Filter License";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cascadia Mono", 11.125F);
            this.label2.Location = new System.Drawing.Point(29, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 40);
            this.label2.TabIndex = 18;
            this.label2.Text = "License ID:";
            // 
            // ctrlLocalLicenseInfo1
            // 
            this.ctrlLocalLicenseInfo1.Location = new System.Drawing.Point(0, 245);
            this.ctrlLocalLicenseInfo1.Name = "ctrlLocalLicenseInfo1";
            this.ctrlLocalLicenseInfo1.Size = new System.Drawing.Size(1352, 567);
            this.ctrlLocalLicenseInfo1.TabIndex = 2;
            // 
            // btnSearchLicense
            // 
            this.btnSearchLicense.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchLicense.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnSearchLicense.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSearchLicense.HoverState.ImageSize = new System.Drawing.Size(75, 75);
            this.btnSearchLicense.Image = global::DVLD_Project.Properties.Resources.credit;
            this.btnSearchLicense.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnSearchLicense.ImageRotate = 0F;
            this.btnSearchLicense.ImageSize = new System.Drawing.Size(65, 65);
            this.btnSearchLicense.Location = new System.Drawing.Point(658, 80);
            this.btnSearchLicense.Name = "btnSearchLicense";
            this.btnSearchLicense.PressedState.ImageSize = new System.Drawing.Size(85, 85);
            this.btnSearchLicense.Size = new System.Drawing.Size(184, 124);
            this.btnSearchLicense.TabIndex = 19;
            this.btnSearchLicense.Click += new System.EventHandler(this.btnSearchLicense_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Animated = true;
            this.txtFilter.AutoRoundedCorners = true;
            this.txtFilter.BackColor = System.Drawing.Color.Transparent;
            this.txtFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFilter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilter.DefaultText = "";
            this.txtFilter.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFilter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilter.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFilter.ForeColor = System.Drawing.Color.Black;
            this.txtFilter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilter.IconRight = global::DVLD_Project.Properties.Resources.search;
            this.txtFilter.IconRightOffset = new System.Drawing.Point(8, 0);
            this.txtFilter.Location = new System.Drawing.Point(253, 118);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.PlaceholderText = "";
            this.txtFilter.SelectedText = "";
            this.txtFilter.Size = new System.Drawing.Size(378, 40);
            this.txtFilter.TabIndex = 17;
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // ctrlFilterLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Controls.Add(this.ctrlLocalLicenseInfo1);
            this.Controls.Add(this.gbFilterLicense);
            this.Name = "ctrlFilterLicense";
            this.Size = new System.Drawing.Size(1352, 812);
            this.gbFilterLicense.ResumeLayout(false);
            this.gbFilterLicense.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox gbFilterLicense;
        private Guna.UI2.WinForms.Guna2TextBox txtFilter;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ImageButton btnSearchLicense;
        //private ctrlLocalLicenseInfo ctrlLocalLicenseInfo2;
        private ctrlLocalLicenseInfo ctrlLocalLicenseInfo1;
    }
}