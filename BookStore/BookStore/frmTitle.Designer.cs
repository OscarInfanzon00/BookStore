namespace BookStoreTitleStores
{
    partial class frmTitle
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.RichTextBox();
            this.txtType = new System.Windows.Forms.RichTextBox();
            this.txtPrice = new System.Windows.Forms.RichTextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblAdvance = new System.Windows.Forms.Label();
            this.lblRoyalty = new System.Windows.Forms.Label();
            this.lblYtdSales = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblPubDate = new System.Windows.Forms.Label();
            this.txtAdvance = new System.Windows.Forms.RichTextBox();
            this.txtRoyalty = new System.Windows.Forms.RichTextBox();
            this.txtYTDSales = new System.Windows.Forms.RichTextBox();
            this.txtNotes = new System.Windows.Forms.RichTextBox();
            this.txtPubDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(206, 490);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(161, 50);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(411, 490);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(161, 50);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(361, 106);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTitle.MaxLength = 80;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(223, 32);
            this.txtTitle.TabIndex = 2;
            this.txtTitle.Text = "";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(361, 140);
            this.txtType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtType.MaxLength = 12;
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(223, 35);
            this.txtType.TabIndex = 3;
            this.txtType.Text = "";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(361, 177);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPrice.MaxLength = 8;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(223, 35);
            this.txtPrice.TabIndex = 4;
            this.txtPrice.Text = "";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(261, 118);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(35, 18);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Title";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(257, 155);
            this.lblType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(40, 18);
            this.lblType.TabIndex = 6;
            this.lblType.Text = "Type";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(256, 192);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(42, 18);
            this.lblPrice.TabIndex = 7;
            this.lblPrice.Text = "Price";
            // 
            // lblAdvance
            // 
            this.lblAdvance.AutoSize = true;
            this.lblAdvance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdvance.Location = new System.Drawing.Point(232, 227);
            this.lblAdvance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAdvance.Name = "lblAdvance";
            this.lblAdvance.Size = new System.Drawing.Size(64, 18);
            this.lblAdvance.TabIndex = 8;
            this.lblAdvance.Text = "Advance";
            // 
            // lblRoyalty
            // 
            this.lblRoyalty.AutoSize = true;
            this.lblRoyalty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoyalty.Location = new System.Drawing.Point(241, 257);
            this.lblRoyalty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRoyalty.Name = "lblRoyalty";
            this.lblRoyalty.Size = new System.Drawing.Size(57, 18);
            this.lblRoyalty.TabIndex = 9;
            this.lblRoyalty.Text = "Royalty";
            // 
            // lblYtdSales
            // 
            this.lblYtdSales.AutoSize = true;
            this.lblYtdSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYtdSales.Location = new System.Drawing.Point(216, 293);
            this.lblYtdSales.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblYtdSales.Name = "lblYtdSales";
            this.lblYtdSales.Size = new System.Drawing.Size(78, 18);
            this.lblYtdSales.TabIndex = 10;
            this.lblYtdSales.Text = "YTD Sales";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.Location = new System.Drawing.Point(251, 328);
            this.lblNotes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(48, 18);
            this.lblNotes.TabIndex = 11;
            this.lblNotes.Text = "Notes";
            // 
            // lblPubDate
            // 
            this.lblPubDate.AutoSize = true;
            this.lblPubDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPubDate.Location = new System.Drawing.Point(227, 415);
            this.lblPubDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPubDate.Name = "lblPubDate";
            this.lblPubDate.Size = new System.Drawing.Size(69, 18);
            this.lblPubDate.TabIndex = 12;
            this.lblPubDate.Text = "Pub Date";
            // 
            // txtAdvance
            // 
            this.txtAdvance.Location = new System.Drawing.Point(361, 214);
            this.txtAdvance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAdvance.MaxLength = 8;
            this.txtAdvance.Name = "txtAdvance";
            this.txtAdvance.Size = new System.Drawing.Size(223, 35);
            this.txtAdvance.TabIndex = 13;
            this.txtAdvance.Text = "";
            // 
            // txtRoyalty
            // 
            this.txtRoyalty.Location = new System.Drawing.Point(361, 252);
            this.txtRoyalty.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRoyalty.MaxLength = 4;
            this.txtRoyalty.Name = "txtRoyalty";
            this.txtRoyalty.Size = new System.Drawing.Size(223, 35);
            this.txtRoyalty.TabIndex = 14;
            this.txtRoyalty.Text = "";
            // 
            // txtYTDSales
            // 
            this.txtYTDSales.Location = new System.Drawing.Point(361, 289);
            this.txtYTDSales.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtYTDSales.MaxLength = 4;
            this.txtYTDSales.Name = "txtYTDSales";
            this.txtYTDSales.Size = new System.Drawing.Size(223, 35);
            this.txtYTDSales.TabIndex = 15;
            this.txtYTDSales.Text = "";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(361, 328);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNotes.MaxLength = 200;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(223, 85);
            this.txtNotes.TabIndex = 16;
            this.txtNotes.Text = "";
            // 
            // txtPubDate
            // 
            this.txtPubDate.CustomFormat = "1/1/1950 12:00";
            this.txtPubDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtPubDate.Location = new System.Drawing.Point(361, 415);
            this.txtPubDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPubDate.MaxDate = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            this.txtPubDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.txtPubDate.Name = "txtPubDate";
            this.txtPubDate.Size = new System.Drawing.Size(223, 22);
            this.txtPubDate.TabIndex = 17;
            this.txtPubDate.Value = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            // 
            // frmTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 589);
            this.Controls.Add(this.txtPubDate);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtYTDSales);
            this.Controls.Add(this.txtRoyalty);
            this.Controls.Add(this.txtAdvance);
            this.Controls.Add(this.lblPubDate);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblYtdSales);
            this.Controls.Add(this.lblRoyalty);
            this.Controls.Add(this.lblAdvance);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmTitle";
            this.Text = "Title";
            this.Load += new System.EventHandler(this.frmTitle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RichTextBox txtTitle;
        private System.Windows.Forms.RichTextBox txtType;
        private System.Windows.Forms.RichTextBox txtPrice;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblAdvance;
        private System.Windows.Forms.Label lblRoyalty;
        private System.Windows.Forms.Label lblYtdSales;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblPubDate;
        private System.Windows.Forms.RichTextBox txtAdvance;
        private System.Windows.Forms.RichTextBox txtRoyalty;
        private System.Windows.Forms.RichTextBox txtYTDSales;
        private System.Windows.Forms.RichTextBox txtNotes;
        private System.Windows.Forms.DateTimePicker txtPubDate;
    }
}

