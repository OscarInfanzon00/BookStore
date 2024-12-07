using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

namespace BookStore.Data
{
    public class StoresDataAccess
    {
        public string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "BookStore.mdf;Integrated Security=True;Connect Timeout=30";

        public string GenerateRandomStoreID()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] idChars = new char[4];

            for (int i = 0; i < 4; i++)
            {
                idChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(idChars);
        }

        public void SaveOrUpdateEntity(string objectID, RichTextBox txtStoreName, RichTextBox txtAddress, RichTextBox txtCity, ComboBox comboBoxState, MaskedTextBox txtZip)
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
                        query = "UPDATE stores SET stor_name = @StoreName, stor_address = @Address, city = @City, state = @State, zip = @Zip WHERE stor_id = @Id";
                    }
                    else
                    {
                        // Insert new record
                        query = "INSERT INTO stores (stor_id, stor_name, stor_address, city, state, zip) VALUES (@ID, @StoreName, @Address, @City, @State, @Zip)";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // For Update, provide the ID
                        if (!string.IsNullOrWhiteSpace(objectID))
                        {
                            cmd.Parameters.AddWithValue("@Id", objectID);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ID", GenerateRandomStoreID());
                        }

                        cmd.Parameters.AddWithValue("@StoreName", txtStoreName.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@City", txtCity.Text);
                        cmd.Parameters.AddWithValue("@State", comboBoxState.SelectedItem?.ToString());
                        cmd.Parameters.AddWithValue("@Zip", txtZip.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
