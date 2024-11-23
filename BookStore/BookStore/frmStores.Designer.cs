namespace BookStoreTitleStores
{
    partial class frmStores
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
            this.txtStoreName = new System.Windows.Forms.RichTextBox();
            this.txtAddress = new System.Windows.Forms.RichTextBox();
            this.txtCity = new System.Windows.Forms.RichTextBox();
            this.txtState = new System.Windows.Forms.RichTextBox();
            this.lblStoreName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.MaskedTextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.lblZip = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtStoreName
            // 
            this.txtStoreName.Location = new System.Drawing.Point(320, 168);
            this.txtStoreName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtStoreName.MaxLength = 40;
            this.txtStoreName.Name = "txtStoreName";
            this.txtStoreName.Size = new System.Drawing.Size(223, 32);
            this.txtStoreName.TabIndex = 3;
            this.txtStoreName.Text = "";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(320, 203);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAddress.MaxLength = 40;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(223, 32);
            this.txtAddress.TabIndex = 4;
            this.txtAddress.Text = "";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(320, 237);
            this.txtCity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCity.MaxLength = 20;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(223, 32);
            this.txtCity.TabIndex = 5;
            this.txtCity.Text = "";
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(320, 272);
            this.txtState.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtState.MaxLength = 2;
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(223, 32);
            this.txtState.TabIndex = 6;
            this.txtState.Text = "";
            // 
            // lblStoreName
            // 
            this.lblStoreName.AutoSize = true;
            this.lblStoreName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoreName.Location = new System.Drawing.Point(193, 180);
            this.lblStoreName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStoreName.Name = "lblStoreName";
            this.lblStoreName.Size = new System.Drawing.Size(88, 18);
            this.lblStoreName.TabIndex = 8;
            this.lblStoreName.Text = "Store Name";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(219, 215);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(62, 18);
            this.lblAddress.TabIndex = 9;
            this.lblAddress.Text = "Address";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(247, 250);
            this.lblCity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(33, 18);
            this.lblCity.TabIndex = 10;
            this.lblCity.Text = "City";
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(320, 307);
            this.txtZip.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(227, 22);
            this.txtZip.TabIndex = 12;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(242, 284);
            this.lblState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(42, 18);
            this.lblState.TabIndex = 13;
            this.lblState.Text = "State";
            // 
            // lblZip
            // 
            this.lblZip.AutoSize = true;
            this.lblZip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZip.Location = new System.Drawing.Point(213, 308);
            this.lblZip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblZip.Name = "lblZip";
            this.lblZip.Size = new System.Drawing.Size(68, 18);
            this.lblZip.TabIndex = 14;
            this.lblZip.Text = "Zip Code";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(159, 404);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(161, 50);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(381, 404);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(161, 50);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmStores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 514);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblZip);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.txtZip);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblStoreName);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtStoreName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmStores";
            this.Text = "Stores Info";
            this.Load += new System.EventHandler(this.frmStores_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtStoreName;
        private System.Windows.Forms.RichTextBox txtAddress;
        private System.Windows.Forms.RichTextBox txtCity;
        private System.Windows.Forms.RichTextBox txtState;
        private System.Windows.Forms.Label lblStoreName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.MaskedTextBox txtZip;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblZip;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}