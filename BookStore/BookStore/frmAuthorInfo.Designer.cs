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
    partial class frmAuthorInfo {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(frmAuthorInfo));
            lblFirstName = new Label();
            lblLastName = new Label();
            lblPhoneNumber = new Label();
            lblAddress = new Label();
            lblCity = new Label();
            lblState = new Label();
            lblZip = new Label();
            lblContract = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtAddress = new TextBox();
            txtCity = new TextBox();
            rbYes = new RadioButton();
            rbNo = new RadioButton();
            btnSave = new Button();
            btnCancel = new Button();
            txtPhoneNumber = new MaskedTextBox();
            txtZip = new MaskedTextBox();
            btnClear = new Button();
            cboState = new ComboBox();
            SuspendLayout();
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Microsoft Sans Serif", 12F);
            lblFirstName.Location = new Point(274, 144);
            lblFirstName.Margin = new Padding(2, 0, 2, 0);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(137, 29);
            lblFirstName.TabIndex = 0;
            lblFirstName.Text = "First Name:";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Microsoft Sans Serif", 12F);
            lblLastName.Location = new Point(274, 184);
            lblLastName.Margin = new Padding(2, 0, 2, 0);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(134, 29);
            lblLastName.TabIndex = 0;
            lblLastName.Text = "Last Name:";
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Font = new Font("Microsoft Sans Serif", 12F);
            lblPhoneNumber.Location = new Point(228, 227);
            lblPhoneNumber.Margin = new Padding(2, 0, 2, 0);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(182, 29);
            lblPhoneNumber.TabIndex = 0;
            lblPhoneNumber.Text = "Phone Number:";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Microsoft Sans Serif", 12F);
            lblAddress.Location = new Point(300, 272);
            lblAddress.Margin = new Padding(2, 0, 2, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(108, 29);
            lblAddress.TabIndex = 0;
            lblAddress.Text = "Address:";
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Font = new Font("Microsoft Sans Serif", 12F);
            lblCity.Location = new Point(349, 312);
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
            lblState.Location = new Point(334, 353);
            lblState.Margin = new Padding(2, 0, 2, 0);
            lblState.Name = "lblState";
            lblState.Size = new Size(74, 29);
            lblState.TabIndex = 0;
            lblState.Text = "State:";
            // 
            // lblZip
            // 
            lblZip.AutoSize = true;
            lblZip.Font = new Font("Microsoft Sans Serif", 12F);
            lblZip.Location = new Point(354, 392);
            lblZip.Margin = new Padding(2, 0, 2, 0);
            lblZip.Name = "lblZip";
            lblZip.Size = new Size(55, 29);
            lblZip.TabIndex = 0;
            lblZip.Text = "ZIP:";
            // 
            // lblContract
            // 
            lblContract.AutoSize = true;
            lblContract.Font = new Font("Microsoft Sans Serif", 12F);
            lblContract.Location = new Point(299, 444);
            lblContract.Margin = new Padding(2, 0, 2, 0);
            lblContract.Name = "lblContract";
            lblContract.Size = new Size(108, 29);
            lblContract.TabIndex = 0;
            lblContract.Text = "Contract:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(462, 150);
            txtFirstName.Margin = new Padding(2, 3, 2, 3);
            txtFirstName.MaxLength = 100;
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(283, 31);
            txtFirstName.TabIndex = 0;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(462, 191);
            txtLastName.Margin = new Padding(2, 3, 2, 3);
            txtLastName.MaxLength = 100;
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(283, 31);
            txtLastName.TabIndex = 1;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(462, 272);
            txtAddress.Margin = new Padding(2, 3, 2, 3);
            txtAddress.MaxLength = 100;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(283, 31);
            txtAddress.TabIndex = 3;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(462, 312);
            txtCity.Margin = new Padding(2, 3, 2, 3);
            txtCity.MaxLength = 100;
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(283, 31);
            txtCity.TabIndex = 4;
            // 
            // rbYes
            // 
            rbYes.AutoSize = true;
            rbYes.Checked = true;
            rbYes.Location = new Point(464, 452);
            rbYes.Margin = new Padding(2, 3, 2, 3);
            rbYes.Name = "rbYes";
            rbYes.Size = new Size(62, 29);
            rbYes.TabIndex = 7;
            rbYes.TabStop = true;
            rbYes.Text = "Yes";
            rbYes.UseVisualStyleBackColor = true;
            // 
            // rbNo
            // 
            rbNo.AutoSize = true;
            rbNo.Location = new Point(551, 452);
            rbNo.Margin = new Padding(2, 3, 2, 3);
            rbNo.Name = "rbNo";
            rbNo.Size = new Size(61, 29);
            rbNo.TabIndex = 8;
            rbNo.Text = "No";
            rbNo.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(238, 680);
            btnSave.Margin = new Padding(2, 3, 2, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(176, 89);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(661, 680);
            btnCancel.Margin = new Padding(2, 3, 2, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(176, 89);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(462, 231);
            txtPhoneNumber.Margin = new Padding(2, 3, 2, 3);
            txtPhoneNumber.Mask = "(999) 000-0000";
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(283, 31);
            txtPhoneNumber.TabIndex = 2;
            // 
            // txtZip
            // 
            txtZip.Location = new Point(462, 397);
            txtZip.Margin = new Padding(2, 3, 2, 3);
            txtZip.Mask = "00000-9999";
            txtZip.Name = "txtZip";
            txtZip.Size = new Size(283, 31);
            txtZip.TabIndex = 6;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(450, 680);
            btnClear.Margin = new Padding(2, 3, 2, 3);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(176, 89);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click_1;
            // 
            // cboState
            // 
            cboState.DropDownStyle = ComboBoxStyle.DropDownList;
            cboState.FormattingEnabled = true;
            cboState.Items.AddRange(new object[] { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY" });
            cboState.Location = new Point(462, 352);
            cboState.Margin = new Padding(4, 5, 4, 5);
            cboState.Name = "cboState";
            cboState.Size = new Size(282, 33);
            cboState.TabIndex = 12;
            // 
            // frmAuthorInfo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 803);
            Controls.Add(cboState);
            Controls.Add(btnClear);
            Controls.Add(txtZip);
            Controls.Add(txtPhoneNumber);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(rbNo);
            Controls.Add(rbYes);
            Controls.Add(txtCity);
            Controls.Add(txtAddress);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(lblContract);
            Controls.Add(lblZip);
            Controls.Add(lblState);
            Controls.Add(lblCity);
            Controls.Add(lblAddress);
            Controls.Add(lblPhoneNumber);
            Controls.Add(lblLastName);
            Controls.Add(lblFirstName);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 3, 2, 3);
            Name = "frmAuthorInfo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Author Info";
            Load += frmAuthorInfo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFirstName;
        private Label lblLastName;
        private Label lblPhoneNumber;
        private Label lblAddress;
        private Label lblCity;
        private Label lblState;
        private Label lblZip;
        private Label lblContract;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtAddress;
        private TextBox txtCity;
        private RadioButton rbYes;
        private RadioButton rbNo;
        private Button btnSave;
        private Button btnCancel;
        private MaskedTextBox txtPhoneNumber;
        private MaskedTextBox txtZip;
        private Button btnClear;
        private ComboBox cboState;
    }
}
