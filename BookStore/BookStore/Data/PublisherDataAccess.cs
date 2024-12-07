using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BookStore.Data
{
    public class PublisherDataAccess
    {
        public string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "BookStore.mdf;Integrated Security=True;Connect Timeout=30";

        private string GenerateRandomPublisherID()
        {
            Random random = new Random();

            string[] predefinedIDs = { "1756", "1622", "0877", "0736", "1389" };

            string pubID;
            if (random.NextDouble() > 0.5)
            {
                pubID = predefinedIDs[random.Next(predefinedIDs.Length)];
            }
            else
            {
                pubID = "99" + random.Next(10, 100).ToString("D2");
            }

            return pubID;
        }

        public void SaveOrUpdateEntity(string objectID, TextBox txtName, TextBox txtCity, ComboBox comboBoxState, ComboBox comboBoxCountry)
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
                        query = "UPDATE publishers SET pub_name = @PubName, city = @City, state = @State, country = @Country WHERE pub_id = @Id";
                    }
                    else
                    {
                        // Insert new record
                        query = "INSERT INTO publishers (pub_id, pub_name, city, state, country) VALUES (@ID, @PubName, @City, @State, @Country)";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(objectID))
                        {
                            cmd.Parameters.AddWithValue("@Id", objectID);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ID", GenerateRandomPublisherID());
                        }

                        cmd.Parameters.AddWithValue("@PubName", txtName.Text);
                        cmd.Parameters.AddWithValue("@City", txtCity.Text);
                        cmd.Parameters.AddWithValue("@State", comboBoxState.SelectedItem?.ToString());
                        cmd.Parameters.AddWithValue("@Country", comboBoxCountry.SelectedItem?.ToString());

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
