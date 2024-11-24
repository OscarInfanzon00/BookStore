namespace BookStore
{
    partial class frmEmployee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployee));
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblMiddleName = new System.Windows.Forms.Label();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblJoblvl = new System.Windows.Forms.Label();
            this.lblHiringDate = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtJoblvl = new System.Windows.Forms.TextBox();
            this.maskedTextBoxHiringDate = new System.Windows.Forms.MaskedTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.lblJob = new System.Windows.Forms.Label();
            this.ComboBoxJob = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(176, 93);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(90, 20);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(289, 95);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(171, 20);
            this.txtFirstName.TabIndex = 1;
            // 
            // lblMiddleName
            // 
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiddleName.Location = new System.Drawing.Point(161, 130);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Size = new System.Drawing.Size(105, 20);
            this.lblMiddleName.TabIndex = 2;
            this.lblMiddleName.Text = "Middle Name:";
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Location = new System.Drawing.Point(289, 129);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(171, 20);
            this.txtMiddleName.TabIndex = 3;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(178, 168);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(90, 20);
            this.lblLastName.TabIndex = 4;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblJoblvl
            // 
            this.lblJoblvl.AutoSize = true;
            this.lblJoblvl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJoblvl.Location = new System.Drawing.Point(206, 208);
            this.lblJoblvl.Name = "lblJoblvl";
            this.lblJoblvl.Size = new System.Drawing.Size(56, 20);
            this.lblJoblvl.TabIndex = 5;
            this.lblJoblvl.Text = "Job lvl:";
            // 
            // lblHiringDate
            // 
            this.lblHiringDate.AutoSize = true;
            this.lblHiringDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHiringDate.Location = new System.Drawing.Point(173, 288);
            this.lblHiringDate.Name = "lblHiringDate";
            this.lblHiringDate.Size = new System.Drawing.Size(93, 20);
            this.lblHiringDate.TabIndex = 6;
            this.lblHiringDate.Text = "Hiring Date:";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(289, 168);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(171, 20);
            this.txtLastName.TabIndex = 7;
            // 
            // txtJoblvl
            // 
            this.txtJoblvl.Location = new System.Drawing.Point(289, 208);
            this.txtJoblvl.Name = "txtJoblvl";
            this.txtJoblvl.Size = new System.Drawing.Size(171, 20);
            this.txtJoblvl.TabIndex = 8;
            // 
            // maskedTextBoxHiringDate
            // 
            this.maskedTextBoxHiringDate.Location = new System.Drawing.Point(289, 288);
            this.maskedTextBoxHiringDate.Mask = "00/00/0000";
            this.maskedTextBoxHiringDate.Name = "maskedTextBoxHiringDate";
            this.maskedTextBoxHiringDate.Size = new System.Drawing.Size(171, 20);
            this.maskedTextBoxHiringDate.TabIndex = 9;
            this.maskedTextBoxHiringDate.ValidatingType = typeof(System.DateTime);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(146, 342);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 46);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(400, 342);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 46);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(272, 342);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(106, 46);
            this.buttonClear.TabIndex = 12;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // lblJob
            // 
            this.lblJob.AutoSize = true;
            this.lblJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJob.Location = new System.Drawing.Point(227, 251);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(39, 20);
            this.lblJob.TabIndex = 13;
            this.lblJob.Text = "Job:";
            // 
            // ComboBoxJob
            // 
            this.ComboBoxJob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxJob.FormattingEnabled = true;
            this.ComboBoxJob.Items.AddRange(new object[] {
            "Option 1",
            "Option 2",
            "Option 3"});
            this.ComboBoxJob.Location = new System.Drawing.Point(289, 249);
            this.ComboBoxJob.Name = "ComboBoxJob";
            this.ComboBoxJob.Size = new System.Drawing.Size(171, 21);
            this.ComboBoxJob.TabIndex = 14;
            // 
            // frmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 418);
            this.Controls.Add(this.ComboBoxJob);
            this.Controls.Add(this.lblJob);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.maskedTextBoxHiringDate);
            this.Controls.Add(this.txtJoblvl);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblHiringDate);
            this.Controls.Add(this.lblJoblvl);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtMiddleName);
            this.Controls.Add(this.lblMiddleName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmployee";
            this.Text = "Employee Info";
            this.Load += new System.EventHandler(this.frmEmployee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblMiddleName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblJoblvl;
        private System.Windows.Forms.Label lblHiringDate;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtJoblvl;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxHiringDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.ComboBox ComboBoxJob;
    }
}

