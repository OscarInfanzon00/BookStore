using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BookStore
{
    public partial class frmDiscounts : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "BookStore.mdf;Integrated Security=True;Connect Timeout=30";
        private string objectID;
        private string storeID;

        public frmDiscounts()
        {
            InitializeComponent();
        }

        public frmDiscounts(string objectID, string storeID)
        {
            this.objectID = objectID;
            this.storeID = storeID;
            InitializeComponent();
            LoadEntityData(objectID, storeID);
        }

        public void ClearDiscountsInputs()
        {
            comboBoxType.SelectedIndex = -1;
            txtDiscount.Text = "";
            txtHighQTY.Text = "";
            txtLowQTY.Text = "";
            txtBoxStoreID.Text = "";
        }

        public bool ValidateDiscountsInputs()
        {
            StringBuilder errorMessage = new StringBuilder();
            bool isValid = true;

            if (comboBoxType.SelectedIndex == -1)
            {
                errorMessage.AppendLine("Select a Discount Type.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtDiscount.Text))
            {
                errorMessage.AppendLine("Discount is required.");
                isValid = false;
            }
            else if (!IsNumeric(txtDiscount.Text))
            {
                errorMessage.AppendLine("Discount must be a valid number.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtHighQTY.Text))
            {
                errorMessage.AppendLine("High QTY is required.");
                isValid = false;
            }
            else if (!IsNumeric(txtHighQTY.Text))
            {
                errorMessage.AppendLine("High QTY must be a valid number.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtLowQTY.Text))
            {
                errorMessage.AppendLine("Low QTY is required.");
                isValid = false;
            }
            else if (!IsNumeric(txtLowQTY.Text))
            {
                errorMessage.AppendLine("Low QTY must be a valid number.");
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show(errorMessage.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }

        private bool IsNumeric(string input)
        {
            return decimal.TryParse(input, out _);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateDiscountsInputs())
            {
                SaveOrUpdateEntity();
            }
        }

        private void LoadEntityData(string type, string storeID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM discounts WHERE discounttype = @Type";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = type;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                comboBoxType.SelectedItem = reader["discounttype"]?.ToString() ?? string.Empty;
                                txtLowQTY.Text = reader["lowqty"]?.ToString() ?? string.Empty;
                                txtHighQTY.Text = reader["highqty"]?.ToString() ?? string.Empty;
                                txtDiscount.Text = reader["discount"]?.ToString() ?? string.Empty;
                                txtBoxStoreID.Text = reader["stor_id"]?.ToString() ?? string.Empty;
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
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveOrUpdateEntity()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query;
                    if (!string.IsNullOrWhiteSpace(objectID))
                    {
                        // Update existing record
                        query = "UPDATE discounts SET discounttype = @Type, stor_id = @StoreID, lowqty = @LowQty, highqty = @HighQty, discount = @Discount WHERE discounttype = @Type";
                    }
                    else
                    {
                        // Insert new record
                        query = "INSERT INTO discounts (discounttype, lowqty, highqty, discount, stor_id) VALUES (@Type, @LowQty, @HighQty, @Discount, @StoreID)";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Type", comboBoxType.SelectedItem?.ToString() ?? string.Empty);

                        if (!int.TryParse(txtLowQTY.Text, out int lowQTY))
                        {
                            MessageBox.Show("Invalid Low Qty value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        cmd.Parameters.AddWithValue("@LowQty", lowQTY);

                        if (!int.TryParse(txtHighQTY.Text, out int highQTY))
                        {
                            MessageBox.Show("Invalid High Qty value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        cmd.Parameters.AddWithValue("@HighQty", highQTY);

                        decimal discount;
                        if (!decimal.TryParse(txtDiscount.Text, out discount) || discount < -99.99m || discount > 99.99m)
                        {
                            MessageBox.Show("Discount must be a numeric value between -99.99 and 99.99.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        cmd.Parameters.Add("@Discount", SqlDbType.Decimal).Value = Math.Round(discount, 2);

                        string storeId = txtBoxStoreID.Text.PadRight(4).Substring(0, 4);
                        cmd.Parameters.AddWithValue("@StoreID", storeId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearDiscountsInputs();
                        this.Close();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Error saving data: {sqlEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btn_Click(object sender, EventArgs e)
        {
            ClearDiscountsInputs();
            this.Close();
        }

        private void frmDiscounts_Load(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearDiscountsInputs();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
