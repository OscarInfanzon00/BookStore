using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.Data
{
    public class DiscountsDataAccess
    {
        public string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "BookStore.mdf;Integrated Security=True;Connect Timeout=30";

        public void SaveOrUpdateEntity(string objectID, ComboBox comboBoxType, TextBox txtLowQTY, TextBox txtHighQTY, TextBox txtDiscount, TextBox txtBoxStoreID)
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
    }
}
