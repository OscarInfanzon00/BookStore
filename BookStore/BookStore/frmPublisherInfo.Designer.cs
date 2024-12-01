using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore {
    partial class frmPublisherInfo {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
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
        private void InitializeComponent () {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(frmPublisherInfo));
            lblName = new Label();
            lblCity = new Label();
            lblState = new Label();
            lblCountry = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            txtName = new TextBox();
            txtCity = new TextBox();
            btnClear = new Button();
            cboState = new ComboBox();
            cboCountry = new ComboBox();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Microsoft Sans Serif", 12F);
            lblName.Location = new Point(330, 219);
            lblName.Margin = new Padding(2, 0, 2, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(84, 29);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Font = new Font("Microsoft Sans Serif", 12F);
            lblCity.Location = new Point(350, 260);
            lblCity.Margin = new Padding(2, 0, 2, 0);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(59, 29);
            lblCity.TabIndex = 0;
            lblCity.Text = "City:";
            // 
            // lblState
            // 
            lblState.AutoSize = true;
            lblState.Font = new Font("Microsoft Sans Serif", 12F);
            lblState.Location = new Point(335, 304);
            lblState.Margin = new Padding(2, 0, 2, 0);
            lblState.Name = "lblState";
            lblState.Size = new Size(74, 29);
            lblState.TabIndex = 0;
            lblState.Text = "State:";
            // 
            // lblCountry
            // 
            lblCountry.AutoSize = true;
            lblCountry.Font = new Font("Microsoft Sans Serif", 12F);
            lblCountry.Location = new Point(308, 351);
            lblCountry.Margin = new Padding(2, 0, 2, 0);
            lblCountry.Name = "lblCountry";
            lblCountry.Size = new Size(101, 29);
            lblCountry.TabIndex = 0;
            lblCountry.Text = "Country:";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(238, 678);
            btnSave.Margin = new Padding(2, 3, 2, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(176, 89);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(662, 678);
            btnCancel.Margin = new Padding(2, 3, 2, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(176, 89);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(452, 217);
            txtName.Margin = new Padding(2, 3, 2, 3);
            txtName.MaxLength = 100;
            txtName.Name = "txtName";
            txtName.Size = new Size(283, 31);
            txtName.TabIndex = 0;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(452, 258);
            txtCity.Margin = new Padding(2, 3, 2, 3);
            txtCity.MaxLength = 100;
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(283, 31);
            txtCity.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(452, 678);
            btnClear.Margin = new Padding(2, 3, 2, 3);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(176, 89);
            btnClear.TabIndex = 6;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // cboState
            // 
            cboState.DropDownStyle = ComboBoxStyle.DropDownList;
            cboState.FormattingEnabled = true;
            cboState.Items.AddRange(new object[] { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY" });
            cboState.Location = new Point(452, 300);
            cboState.Margin = new Padding(4, 5, 4, 5);
            cboState.Name = "cboState";
            cboState.Size = new Size(283, 33);
            cboState.TabIndex = 7;
            // 
            // cboCountry
            // 
            cboCountry.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCountry.FormattingEnabled = true;
            cboCountry.Items.AddRange(new object[] { "Afghanistan", "Albania", "Algeria", "Andorra", "Angola", "Antigua and Barbuda", "Argentina", "Armenia", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bhutan", "Bolivia", "Bosnia and Herzegovina", "Botswana", "Brazil", "Brunei", "Bulgaria", "Burkina Faso", "Burundi", "Cabo Verde", "Cambodia", "Cameroon", "Canada", "Central African Republic", "Chad", "Chile", "China", "Colombia", "Comoros", "Congo (Congo-Brazzaville)", "Costa Rica", "Croatia", "Cuba", "Cyprus", "Czechia (Czech Republic)", "Denmark", "Djibouti", "Dominica", "Dominican Republic", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Eswatini (fmr. \"Swaziland\")", "Ethiopia", "Fiji", "Finland", "France", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Greece", "Grenada", "Guatemala", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Honduras", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Israel", "Italy", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Korea (North)", "Korea (South)", "Kosovo", "Kuwait", "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands", "Mauritania", "Mauritius", "Mexico", "Micronesia", "Moldova", "Monaco", "Mongolia", "Montenegro", "Morocco", "Mozambique", "Myanmar (Burma)", "Namibia", "Nauru", "Nepal", "Netherlands", "New Zealand", "Nicaragua", "Niger", "Nigeria", "North Macedonia", "Norway", "Oman", "Pakistan", "Palau", "Palestine State", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Qatar", "Romania", "Russia", "Rwanda", "Saint Kitts and Nevis", "Saint Lucia", "Saint Vincent and the Grenadines", "Samoa", "San Marino", "Sao Tome and Principe", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "South Sudan", "Spain", "Sri Lanka", "Sudan", "Suriname", "Sweden", "Switzerland", "Syria", "Tajikistan", "Tanzania", "Thailand", "Timor-Leste", "Togo", "Tonga", "Trinidad and Tobago", "Tunisia", "Turkey", "Turkmenistan", "Tuvalu", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "United States of America", "Uruguay", "Uzbekistan", "Vanuatu", "Vatican City", "Venezuela", "Vietnam", "Yemen", "Zambia", "Zimbabwe" });
            cboCountry.Location = new Point(452, 347);
            cboCountry.Margin = new Padding(4, 5, 4, 5);
            cboCountry.Name = "cboCountry";
            cboCountry.Size = new Size(283, 33);
            cboCountry.TabIndex = 8;
            // 
            // frmPublisherInfo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 803);
            Controls.Add(cboCountry);
            Controls.Add(cboState);
            Controls.Add(btnClear);
            Controls.Add(txtCity);
            Controls.Add(txtName);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblCountry);
            Controls.Add(lblState);
            Controls.Add(lblCity);
            Controls.Add(lblName);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 3, 2, 3);
            Name = "frmPublisherInfo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Publisher Info";
            Load += frmPublisherInfo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label lblCity;
        private Label lblState;
        private Label lblCountry;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtName;
        private TextBox txtCity;
        private Button btnClear;
        private ComboBox cboState;
        private ComboBox cboCountry;
    }
}