namespace WindowsFormsApp
{
    partial class frmOrderSummary
    {
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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderSummary));
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.lblCustomerDetails = new System.Windows.Forms.Label();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.SuspendLayout();

            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblOrderNumber.Location = new System.Drawing.Point(20, 20);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(116, 17);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "Order Number:";
      
            this.lblCustomerDetails.AutoSize = true;
            this.lblCustomerDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblCustomerDetails.Location = new System.Drawing.Point(20, 50);
            this.lblCustomerDetails.Name = "lblCustomerDetails";
            this.lblCustomerDetails.Size = new System.Drawing.Size(136, 17);
            this.lblCustomerDetails.TabIndex = 1;
            this.lblCustomerDetails.Text = "Customer Details:";

            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemName,
            this.Quantity,
            this.Price,
            this.Subtotal,
            this.Discount});
            this.dgvOrderItems.Location = new System.Drawing.Point(20, 80);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.Size = new System.Drawing.Size(600, 167);
            this.dgvOrderItems.TabIndex = 2;

            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.Width = 200;

            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";

            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";

            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.Name = "Subtotal";

            this.Discount.HeaderText = "Discount";
            this.Discount.Name = "Discount";

            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalPrice.Location = new System.Drawing.Point(20, 250);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(99, 20);
            this.lblTotalPrice.TabIndex = 3;
            this.lblTotalPrice.Text = "Total Price:";

            this.btnConfirm.Location = new System.Drawing.Point(20, 300);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 30);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "Confirm Order";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);

            this.btnClear.Location = new System.Drawing.Point(140, 300);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 30);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            this.btnEdit.Location = new System.Drawing.Point(260, 300);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 30);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Edit Order";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnCancel.Location = new System.Drawing.Point(380, 300);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel Order";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 360);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.dgvOrderItems);
            this.Controls.Add(this.lblCustomerDetails);
            this.Controls.Add(this.lblOrderNumber);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrderSummary";
            this.Text = "Order Summary";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label lblCustomerDetails;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
    }
}
