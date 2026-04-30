namespace DVLD_Project {
    partial class ctrlFilterPersonInfo {
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
            this.ctrlFilter = new Guna.UI2.WinForms.Guna2GroupBox();
            this.cbFilters = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlPersonInfo = new DVLD_Project.ctrlPersonInfo();
            this.txtFilter = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSearchPerson = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnAddNewPerson = new Guna.UI2.WinForms.Guna2ImageButton();
            this.ctrlFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlFilter
            // 
            this.ctrlFilter.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ctrlFilter.Controls.Add(this.txtFilter);
            this.ctrlFilter.Controls.Add(this.btnSearchPerson);
            this.ctrlFilter.Controls.Add(this.btnAddNewPerson);
            this.ctrlFilter.Controls.Add(this.cbFilters);
            this.ctrlFilter.Controls.Add(this.label2);
            this.ctrlFilter.CustomBorderColor = System.Drawing.Color.DeepSkyBlue;
            this.ctrlFilter.CustomBorderThickness = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.ctrlFilter.FillColor = System.Drawing.Color.PaleTurquoise;
            this.ctrlFilter.Font = new System.Drawing.Font("Cascadia Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlFilter.ForeColor = System.Drawing.Color.Black;
            this.ctrlFilter.Location = new System.Drawing.Point(0, 0);
            this.ctrlFilter.Name = "ctrlFilter";
            this.ctrlFilter.Size = new System.Drawing.Size(1296, 260);
            this.ctrlFilter.TabIndex = 1;
            this.ctrlFilter.Text = "Filter";
            // 
            // cbFilters
            // 
            this.cbFilters.AutoRoundedCorners = true;
            this.cbFilters.BackColor = System.Drawing.Color.Transparent;
            this.cbFilters.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilters.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilters.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilters.Font = new System.Drawing.Font("Cascadia Mono", 7.875F);
            this.cbFilters.ForeColor = System.Drawing.Color.Black;
            this.cbFilters.ItemHeight = 33;
            this.cbFilters.Items.AddRange(new object[] {
            "None",
            "Person ID",
            "National No"});
            this.cbFilters.Location = new System.Drawing.Point(149, 142);
            this.cbFilters.Name = "cbFilters";
            this.cbFilters.Size = new System.Drawing.Size(243, 39);
            this.cbFilters.StartIndex = 0;
            this.cbFilters.TabIndex = 10;
            this.cbFilters.SelectedIndexChanged += new System.EventHandler(this.cbFilters_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cascadia Mono", 9.125F);
            this.label2.Location = new System.Drawing.Point(10, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 33);
            this.label2.TabIndex = 9;
            this.label2.Text = "Filter :";
            // 
            // ctrlPersonInfo
            // 
            this.ctrlPersonInfo.AutoSize = true;
            this.ctrlPersonInfo.Location = new System.Drawing.Point(0, 260);
            this.ctrlPersonInfo.Name = "ctrlPersonInfo";
            this.ctrlPersonInfo.Size = new System.Drawing.Size(1296, 628);
            this.ctrlPersonInfo.TabIndex = 0;
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
            this.txtFilter.Location = new System.Drawing.Point(416, 142);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.PlaceholderText = "";
            this.txtFilter.SelectedText = "";
            this.txtFilter.Size = new System.Drawing.Size(271, 40);
            this.txtFilter.TabIndex = 16;
            this.txtFilter.Visible = false;
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // btnSearchPerson
            // 
            this.btnSearchPerson.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchPerson.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnSearchPerson.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSearchPerson.Enabled = false;
            this.btnSearchPerson.HoverState.ImageSize = new System.Drawing.Size(75, 75);
            this.btnSearchPerson.Image = global::DVLD_Project.Properties.Resources.magnifying_glass;
            this.btnSearchPerson.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnSearchPerson.ImageRotate = 0F;
            this.btnSearchPerson.ImageSize = new System.Drawing.Size(65, 65);
            this.btnSearchPerson.Location = new System.Drawing.Point(734, 90);
            this.btnSearchPerson.Name = "btnSearchPerson";
            this.btnSearchPerson.PressedState.ImageSize = new System.Drawing.Size(85, 85);
            this.btnSearchPerson.Size = new System.Drawing.Size(184, 124);
            this.btnSearchPerson.TabIndex = 15;
            this.btnSearchPerson.Click += new System.EventHandler(this.btnSearchPerson_Click);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewPerson.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnAddNewPerson.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAddNewPerson.HoverState.ImageSize = new System.Drawing.Size(70, 70);
            this.btnAddNewPerson.Image = global::DVLD_Project.Properties.Resources.add_user_2;
            this.btnAddNewPerson.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnAddNewPerson.ImageRotate = 0F;
            this.btnAddNewPerson.ImageSize = new System.Drawing.Size(60, 60);
            this.btnAddNewPerson.Location = new System.Drawing.Point(950, 107);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.PressedState.ImageSize = new System.Drawing.Size(80, 80);
            this.btnAddNewPerson.Size = new System.Drawing.Size(184, 112);
            this.btnAddNewPerson.TabIndex = 14;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // ctrlFilterPersonInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlFilter);
            this.Controls.Add(this.ctrlPersonInfo);
            this.Name = "ctrlFilterPersonInfo";
            this.Size = new System.Drawing.Size(1294, 889);
            this.ctrlFilter.ResumeLayout(false);
            this.ctrlFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlPersonInfo ctrlPersonInfo;
        private Guna.UI2.WinForms.Guna2GroupBox ctrlFilter;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilters;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ImageButton btnSearchPerson;
        private Guna.UI2.WinForms.Guna2ImageButton btnAddNewPerson;
        private Guna.UI2.WinForms.Guna2TextBox txtFilter;
    }
}
