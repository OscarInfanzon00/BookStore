using BookStore;
using BookStore.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class frmOrderSummary : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "BookStore.mdf;Integrated Security=True;Connect Timeout=30";
        private List<Sales> salesList = new List<Sales>();
        private Form parentForm;

        public frmOrderSummary(DataGridViewRowCollection cartData, decimal total, List<Sales> salesList, Form parent, string discountName, string storeID)
        {
            InitializeComponent();
            InitializeDatabaseConnection();

            decimal totalSavings = 0; 

            this.salesList = salesList;

            Discounts discount = LoadDiscountData(discountName, storeID);

            if (discount != null)
            {
                foreach (DataGridViewRow row in cartData)
                {
                    if (row.Cells["title"].Value != null)
                    {
                        decimal itemTotal = Convert.ToDecimal(row.Cells["subtotal"].Value);
                        decimal itemDiscount = 0;

                        if (discount.Discounttype == "Volume Discount")
                        {
                            if (itemTotal >= discount.Lowqty && itemTotal <= discount.Highqty)
                            {
                                itemDiscount = itemTotal * (discount.Discount / 100); 
                            }
                        }
                        else if (discount.Discounttype == "Customer Discount" || discount.Discounttype == "Initial Customer")
                        {
                            itemDiscount = discount.Discount; 
                        }

                        totalSavings += itemDiscount;

                        tableOrderItems.Rows.Add(
                            row.Cells["title_id"].Value.ToString(),
                            row.Cells["title"].Value.ToString(),
                            row.Cells["price"].Value.ToString(),
                            row.Cells["qty"].Value.ToString(),
                            row.Cells["subtotal"].Value.ToString(),
                            itemDiscount > 0 ? $"{itemDiscount:F2}" : "No Discount"  
                        );
                    }
                }
            }

            decimal finalTotal = total - totalSavings;

            tableOrderItems.Rows.Add("Savings", "", "", "", "", $"-${totalSavings:F2}");

            lblTotalPrice.Text = $"Total Price: ${finalTotal:F2}";

            this.parentForm = parent;
        }

        private Discounts LoadDiscountData(string discountName, string storeID)
        {
            Discounts discount = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))  
                {
                    conn.Open();
                    string query = "SELECT * FROM discounts WHERE discounttype = @Type AND stor_id = @StoreID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = discountName;
                        cmd.Parameters.Add("@StoreID", SqlDbType.NVarChar).Value = storeID;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                discount = new Discounts(reader["discounttype"]?.ToString(), reader["stor_id"]?.ToString(), Convert.ToInt16(reader["lowqty"]), Convert.ToInt16(reader["highqty"]), Convert.ToDecimal(reader["discount"]));
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading discount: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return discount;
        }


        private void InitializeDatabaseConnection()
        {

        }

        private string storeSalesinDatabase()
        {
            string generatedOrderNumber = string.Empty;

            for (int i = 0; i < salesList.Count; i++)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string orderNumberQuery = "SELECT NEXT VALUE FOR dbo.OrderNumberSeq";

                        using (SqlCommand command = new SqlCommand(orderNumberQuery, connection))
                        {
                            object result = command.ExecuteScalar();
                            if (result != null)
                            {
                                generatedOrderNumber = result.ToString().PadLeft(4, '0');
                            }
                            else
                            {
                                throw new Exception("Failed to generate order number.");
                            }
                        }

                        string insertSaleQuery = @"
                    INSERT INTO dbo.sales (stor_id, ord_num, ord_date, qty, payterms, title_id)
                    VALUES (@stor_id, @ord_num, @ord_date, @qty, @payterms, @title_id)";

                        using (SqlCommand command = new SqlCommand(insertSaleQuery, connection))
                        {
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
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return generatedOrderNumber;
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                storeSalesinDatabase();
                parentForm.Close();
                this.Close();
            }
        }

        private bool ValidateForm()
        {
            if (tableOrderItems.Rows.Count == 0)
            {
                MessageBox.Show("No items in the order!");
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOrderSummary_Load(object sender, EventArgs e)
        {

        }
    }
}
