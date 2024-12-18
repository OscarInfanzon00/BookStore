﻿namespace BookStore
{
    partial class frmDiscounts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiscounts));
            this.lblType = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.lblLowQTY = new System.Windows.Forms.Label();
            this.txtLowQTY = new System.Windows.Forms.TextBox();
            this.lblHighQTY = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtHighQTY = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxStoreID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(268, 113);
            this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(63, 25);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Type:";
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Initial Customer",
            "Volume Discount",
            "Customer Discount"});
            this.comboBoxType.Location = new System.Drawing.Point(367, 117);
            this.comboBoxType.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(227, 24);
            this.comboBoxType.TabIndex = 1;
            // 
            // lblLowQTY
            // 
            this.lblLowQTY.AutoSize = true;
            this.lblLowQTY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowQTY.Location = new System.Drawing.Point(230, 177);
            this.lblLowQTY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLowQTY.Name = "lblLowQTY";
            this.lblLowQTY.Size = new System.Drawing.Size(101, 25);
            this.lblLowQTY.TabIndex = 2;
            this.lblLowQTY.Text = "Low QTY:";
            // 
            // txtLowQTY
            // 
            this.txtLowQTY.Location = new System.Drawing.Point(367, 181);
            this.txtLowQTY.Margin = new System.Windows.Forms.Padding(4);
            this.txtLowQTY.MaxLength = 100;
            this.txtLowQTY.Name = "txtLowQTY";
            this.txtLowQTY.Size = new System.Drawing.Size(227, 22);
            this.txtLowQTY.TabIndex = 3;
            // 
            // lblHighQTY
            // 
            this.lblHighQTY.AutoSize = true;
            this.lblHighQTY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighQTY.Location = new System.Drawing.Point(226, 211);
            this.lblHighQTY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHighQTY.Name = "lblHighQTY";
            this.lblHighQTY.Size = new System.Drawing.Size(105, 25);
            this.lblHighQTY.TabIndex = 4;
            this.lblHighQTY.Text = "High QTY:";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(237, 241);
            this.lblDiscount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(94, 25);
            this.lblDiscount.TabIndex = 5;
            this.lblDiscount.Text = "Discount:";
            // 
            // txtHighQTY
            // 
            this.txtHighQTY.Location = new System.Drawing.Point(367, 211);
            this.txtHighQTY.Margin = new System.Windows.Forms.Padding(4);
            this.txtHighQTY.MaxLength = 100;
            this.txtHighQTY.Name = "txtHighQTY";
            this.txtHighQTY.Size = new System.Drawing.Size(227, 22);
            this.txtHighQTY.TabIndex = 6;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(367, 241);
            this.txtDiscount.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiscount.MaxLength = 100;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(227, 22);
            this.txtDiscount.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(200, 433);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(141, 57);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(533, 433);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(141, 57);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btn_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(367, 433);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(141, 57);
            this.buttonClear.TabIndex = 10;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(242, 145);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Store ID:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtBoxStoreID
            // 
            this.txtBoxStoreID.Location = new System.Drawing.Point(367, 149);
            this.txtBoxStoreID.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxStoreID.MaxLength = 100;
            this.txtBoxStoreID.Name = "txtBoxStoreID";
            this.txtBoxStoreID.Size = new System.Drawing.Size(227, 22);
            this.txtBoxStoreID.TabIndex = 12;
            // 
            // frmDiscounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 514);
            this.Controls.Add(this.txtBoxStoreID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.txtHighQTY);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblHighQTY);
            this.Controls.Add(this.txtLowQTY);
            this.Controls.Add(this.lblLowQTY);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.lblType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDiscounts";
            this.Text = "Discounts Info";
            this.Load += new System.EventHandler(this.frmDiscounts_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label lblLowQTY;
        private System.Windows.Forms.TextBox txtLowQTY;
        private System.Windows.Forms.Label lblHighQTY;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.TextBox txtHighQTY;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxStoreID;
    }
}