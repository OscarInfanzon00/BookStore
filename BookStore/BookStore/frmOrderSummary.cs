using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class frmOrderSummary : Form
    {
        private SqlConnection connection;

        public frmOrderSummary()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            LoadOrderDetails();
        }

        private void InitializeDatabaseConnection()
        {

            string connectionString = "Data Source=YOUR_SERVER;Initial Catalog=BookStore;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        private void LoadOrderDetails()
        {
            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("sp_GetSalesByDateRange", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@StartDate", DateTime.Now.AddMonths(-1));
                cmd.Parameters.AddWithValue("@EndDate", DateTime.Now);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable salesData = new DataTable();
                adapter.Fill(salesData);

                foreach (DataRow row in salesData.Rows)
                {
                    dgvOrderItems.Rows.Add(
                        row["Title"].ToString(),
                        row["Qty"].ToString(),
                        $"${row["Price"]}",
                        $"${Convert.ToDecimal(row["Qty"]) * Convert.ToDecimal(row["Price"])}",
                        $"{row["Discount"]}%"
                    );
                }

                CalculateOrderSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order details: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void CalculateOrderSummary()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvOrderItems.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["Subtotal"].Value.ToString().Replace("$", ""));
                }
            }

            lblTotalPrice.Text = $"Total Price: ${total}";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                SaveOrder();
                MessageBox.Show("Order Confirmed!");
                this.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvOrderItems.Rows.Clear();
            lblTotalPrice.Text = "Total Price: $0.00";
        }

        private bool ValidateForm()
        {
            if (dgvOrderItems.Rows.Count == 0)
            {
                MessageBox.Show("No items in the order!");
                return false;
            }

            return true;
        }

        private void SaveOrder()
        {
            try
            {
                connection.Open();

                foreach (DataGridViewRow row in dgvOrderItems.Rows)
                {
                    if (row.IsNewRow) continue;

                    SqlCommand cmd = new SqlCommand("sp_UpdateSales", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@Title", row.Cells["ItemName"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Qty", Convert.ToInt32(row.Cells["Quantity"].Value));
                    cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(row.Cells["Price"].Value.ToString().Replace("$", "")));
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving order: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Navigating to Edit Order Screen...");

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to cancel the order?",
                "Cancel Order", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
