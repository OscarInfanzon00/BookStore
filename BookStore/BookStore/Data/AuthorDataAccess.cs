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
    public class AuthorDataAccess
    {
        public string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "BookStore.mdf;Integrated Security=True;Connect Timeout=30";

        private string GenerateAuId()
        {
            Random random = new Random();
            string part1 = random.Next(100, 1000).ToString();
            string part2 = random.Next(10, 100).ToString();
            string part3 = random.Next(1000, 10000).ToString();

            return $"{part1}-{part2}-{part3}";
        }

        public void SaveOrUpdateEntity(string objectID, TextBox txtFirstName, TextBox txtLastName, MaskedTextBox txtPhoneNumber, TextBox txtAddress, TextBox txtCity,
            ComboBox cmbBoxState, MaskedTextBox txtZip, RadioButton rbYes)
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
                        query = "UPDATE authors SET au_fname = @FirstName, au_lname = @LastName, phone = @Phone, address = @Address, city = @City, state = @State, zip = @Zip, contract = @Contract WHERE au_id = @Id";
                    }
                    else
                    {
                        // Insert new record
                        query = "INSERT INTO authors (au_id, au_fname, au_lname, phone, address, city, state, zip, contract) VALUES (@ID, @FirstName, @LastName, @Phone, @Address, @City, @State, @Zip, @Contract)";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(objectID))
                        {
                            cmd.Parameters.AddWithValue("@Id", objectID);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ID", GenerateAuId());
                        }


                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);

                        // Process phone number to store only digits
                        string phone = txtPhoneNumber.Text;
                        string processedPhone = new string(phone.Where(char.IsDigit).ToArray());
                        cmd.Parameters.AddWithValue("@Phone", processedPhone);

                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@City", txtCity.Text);
                        cmd.Parameters.AddWithValue("@State", cmbBoxState.SelectedItem?.ToString() ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Zip", txtZip.Text);

                        // Contract field as boolean, assuming radio buttons rbYes and rbNo are used for selection
                        string contract = rbYes.Checked ? "True" : "False";
                        cmd.Parameters.AddWithValue("@Contract", contract);

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
