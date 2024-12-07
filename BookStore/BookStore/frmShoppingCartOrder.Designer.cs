namespace BookStore
{
    partial class frmShoppingCartOrder
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShoppingCartOrder));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.dataGridViewTitle = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxQTY = new System.Windows.Forms.TextBox();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxStoreID = new System.Windows.Forms.TextBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.dataGridViewShoppingCart = new System.Windows.Forms.DataGridView();
            this.buttonCancelOrder = new System.Windows.Forms.Button();
            this.buttonSubmitOrder = new System.Windows.Forms.Button();
            this.labelSubtotal = new System.Windows.Forms.Label();
            this.labelTax = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.buttonFind = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxPayment = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxDiscount = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTitle)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShoppingCart)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(621, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(375, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter Title";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(467, 90);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(420, 22);
            this.textBoxTitle.TabIndex = 2;
            // 
            // dataGridViewTitle
            // 
            this.dataGridViewTitle.AllowUserToAddRows = false;
            this.dataGridViewTitle.AllowUserToDeleteRows = false;
            this.dataGridViewTitle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTitle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewTitle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTitle.Location = new System.Drawing.Point(51, 131);
            this.dataGridViewTitle.Name = "dataGridViewTitle";
            this.dataGridViewTitle.ReadOnly = true;
            this.dataGridViewTitle.RowHeadersWidth = 51;
            this.dataGridViewTitle.RowTemplate.Height = 24;
            this.dataGridViewTitle.Size = new System.Drawing.Size(1214, 165);
            this.dataGridViewTitle.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(497, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "QTY";
            // 
            // textBoxQTY
            // 
            this.textBoxQTY.Location = new System.Drawing.Point(545, 322);
            this.textBoxQTY.Name = "textBoxQTY";
            this.textBoxQTY.Size = new System.Drawing.Size(100, 22);
            this.textBoxQTY.TabIndex = 5;
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.Location = new System.Drawing.Point(670, 312);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(141, 57);
            this.buttonAddProduct.TabIndex = 6;
            this.buttonAddProduct.Text = "Add Product";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddToCart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxStoreID);
            this.groupBox1.Controls.Add(this.buttonRemove);
            this.groupBox1.Controls.Add(this.dataGridViewShoppingCart);
            this.groupBox1.Location = new System.Drawing.Point(51, 394);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1214, 272);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shopping Cart";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Store ID";
            // 
            // textBoxStoreID
            // 
            this.textBoxStoreID.Location = new System.Drawing.Point(95, 218);
            this.textBoxStoreID.Name = "textBoxStoreID";
            this.textBoxStoreID.Size = new System.Drawing.Size(149, 22);
            this.textBoxStoreID.TabIndex = 22;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(538, 199);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(141, 57);
            this.buttonRemove.TabIndex = 1;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemoveFromCart_Click);
            // 
            // dataGridViewShoppingCart
            // 
            this.dataGridViewShoppingCart.AllowUserToAddRows = false;
            this.dataGridViewShoppingCart.AllowUserToDeleteRows = false;
            this.dataGridViewShoppingCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewShoppingCart.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewShoppingCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShoppingCart.Location = new System.Drawing.Point(22, 32);
            this.dataGridViewShoppingCart.Name = "dataGridViewShoppingCart";
            this.dataGridViewShoppingCart.ReadOnly = true;
            this.dataGridViewShoppingCart.RowHeadersWidth = 51;
            this.dataGridViewShoppingCart.RowTemplate.Height = 24;
            this.dataGridViewShoppingCart.Size = new System.Drawing.Size(1170, 150);
            this.dataGridViewShoppingCart.TabIndex = 0;
            // 
            // buttonCancelOrder
            // 
            this.buttonCancelOrder.Location = new System.Drawing.Point(51, 717);
            this.buttonCancelOrder.Name = "buttonCancelOrder";
            this.buttonCancelOrder.Size = new System.Drawing.Size(141, 57);
            this.buttonCancelOrder.TabIndex = 8;
            this.buttonCancelOrder.Text = "Cancel order";
            this.buttonCancelOrder.UseVisualStyleBackColor = true;
            this.buttonCancelOrder.Click += new System.EventHandler(this.buttonCancelOrder_Click);
            // 
            // buttonSubmitOrder
            // 
            this.buttonSubmitOrder.Location = new System.Drawing.Point(218, 717);
            this.buttonSubmitOrder.Name = "buttonSubmitOrder";
            this.buttonSubmitOrder.Size = new System.Drawing.Size(141, 57);
            this.buttonSubmitOrder.TabIndex = 9;
            this.buttonSubmitOrder.Text = "Submit order";
            this.buttonSubmitOrder.UseVisualStyleBackColor = true;
            this.buttonSubmitOrder.Click += new System.EventHandler(this.btnSubmitOrder_Click);
            // 
            // labelSubtotal
            // 
            this.labelSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtotal.Location = new System.Drawing.Point(983, 685);
            this.labelSubtotal.Name = "labelSubtotal";
            this.labelSubtotal.Size = new System.Drawing.Size(282, 23);
            this.labelSubtotal.TabIndex = 10;
            this.labelSubtotal.Text = "Subtotal:";
            this.labelSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTax
            // 
            this.labelTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTax.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.labelTax.Location = new System.Drawing.Point(987, 717);
            this.labelTax.Name = "labelTax";
            this.labelTax.Size = new System.Drawing.Size(275, 23);
            this.labelTax.TabIndex = 11;
            this.labelTax.Text = "Tax:";
            this.labelTax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTotal
            // 
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.Location = new System.Drawing.Point(991, 751);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(271, 23);
            this.labelTotal.TabIndex = 12;
            this.labelTotal.Text = "Total:";
            this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonFind
            // 
            this.buttonFind.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonFind.Location = new System.Drawing.Point(893, 82);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(60, 39);
            this.buttonFind.TabIndex = 13;
            this.buttonFind.TabStop = false;
            this.buttonFind.Text = "Find";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(518, 688);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Payment Terms";
            // 
            // comboBoxPayment
            // 
            this.comboBoxPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPayment.FormattingEnabled = true;
            this.comboBoxPayment.Items.AddRange(new object[] {
            "ON invoice",
            "Net 60",
            "Net 30"});
            this.comboBoxPayment.Location = new System.Drawing.Point(652, 688);
            this.comboBoxPayment.Name = "comboBoxPayment";
            this.comboBoxPayment.Size = new System.Drawing.Size(212, 24);
            this.comboBoxPayment.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(518, 717);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Add a Discount";
            // 
            // comboBoxDiscount
            // 
            this.comboBoxDiscount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDiscount.FormattingEnabled = true;
            this.comboBoxDiscount.Items.AddRange(new object[] {
            "Initial Customer",
            "Volume Discount",
            "Customer Discount"});
            this.comboBoxDiscount.Location = new System.Drawing.Point(652, 716);
            this.comboBoxDiscount.Name = "comboBoxDiscount";
            this.comboBoxDiscount.Size = new System.Drawing.Size(212, 24);
            this.comboBoxDiscount.TabIndex = 20;
            // 
            // frmShoppingCartOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 796);
            this.Controls.Add(this.comboBoxDiscount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxPayment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.labelTax);
            this.Controls.Add(this.labelSubtotal);
            this.Controls.Add(this.buttonSubmitOrder);
            this.Controls.Add(this.buttonCancelOrder);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonAddProduct);
            this.Controls.Add(this.textBoxQTY);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewTitle);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmShoppingCartOrder";
            this.Text = "Shopping Cart Order";
            this.Load += new System.EventHandler(this.frmShoppingCartOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTitle)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShoppingCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.DataGridView dataGridViewTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxQTY;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.DataGridView dataGridViewShoppingCart;
        private System.Windows.Forms.Button buttonCancelOrder;
        private System.Windows.Forms.Button buttonSubmitOrder;
        private System.Windows.Forms.Label labelSubtotal;
        private System.Windows.Forms.Label labelTax;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxPayment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxDiscount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxStoreID;
    }
}