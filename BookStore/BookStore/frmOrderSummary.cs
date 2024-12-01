using BookStore;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp {
    public partial class frmOrderSummary : Form {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "BookStore.mdf;Integrated Security=True;Connect Timeout=30";
        private List<Sales> salesList = new List<Sales>();
        private Form parentForm;

        public frmOrderSummary (DataGridViewRowCollection cartData, decimal total, List<Sales> salesList, Form parent) {
            InitializeComponent();
            InitializeDatabaseConnection();

            foreach (DataGridViewRow row in cartData) {
                if (row.Cells["title"].Value != null) {
                    tableOrderItems.Rows.Add(
                        row.Cells["title_id"].Value.ToString(),
                        row.Cells["title"].Value.ToString(),
                        row.Cells["price"].Value.ToString(),
                        row.Cells["qty"].Value.ToString(),
                        row.Cells["subtotal"].Value.ToString()
                    );
                }
            }

            lblTotalPrice.Text = $"Total Price: ${total:F2}";
            lblOrderNumber.Text = "Order Number: JHBDJS12";
            this.salesList = salesList;
            this.parentForm = parent;
        }

        private void InitializeDatabaseConnection () {

        }

        private string storeSalesinDatabase () {
            string generatedOrderNumber = string.Empty;

            for (int i = 0; i < salesList.Count; i++) {
                try {
                    using (SqlConnection connection = new SqlConnection(connectionString)) {
                        connection.Open();

                        string orderNumberQuery = "SELECT NEXT VALUE FOR dbo.OrderNumberSeq";

                        using (SqlCommand command = new SqlCommand(orderNumberQuery, connection)) {
                            object result = command.ExecuteScalar();
                            if (result != null) {
                                generatedOrderNumber = result.ToString().PadLeft(4, '0');
                            }
                            else {
                                throw new Exception("Failed to generate order number.");
                            }
                        }

                        string insertSaleQuery = @"
                    INSERT INTO dbo.sales (stor_id, ord_num, ord_date, qty, payterms, title_id)
                    VALUES (@stor_id, @ord_num, @ord_date, @qty, @payterms, @title_id)";

                        using (SqlCommand command = new SqlCommand(insertSaleQuery, connection)) {
                            command.Parameters.AddWithValue("@stor_id", salesList[i].StorId);
                            command.Parameters.AddWithValue("@ord_num", generatedOrderNumber);
                            command.Parameters.AddWithValue("@ord_date", salesList[i].OrdDate);
                            command.Parameters.AddWithValue("@qty", salesList[i].Qty);
                            command.Parameters.AddWithValue("@payterms", salesList[i].Payterms);
                            command.Parameters.AddWithValue("@title_id", salesList[i].TitleId);

                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show($"Sale inserted successfully with Order Number: {generatedOrderNumber}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return generatedOrderNumber;
        }


        private void btnConfirm_Click (object sender, EventArgs e) {
            if (ValidateForm()) {
                storeSalesinDatabase();
                parentForm.Close();
                this.Close();
            }
        }

        private bool ValidateForm () {
            if (tableOrderItems.Rows.Count == 0) {
                MessageBox.Show("No items in the order!");
                return false;
            }

            return true;
        }

        private void btnCancel_Click (object sender, EventArgs e) {
            this.Close();
        }

        private void frmOrderSummary_Load (object sender, EventArgs e) {

        }
    }
}
