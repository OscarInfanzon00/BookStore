using BookStore.Business;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.Data
{
    public class TitleDataAccess
    {
        public string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "BookStore.mdf;Integrated Security=True;Connect Timeout=30";

        public ComboBox loadPub_IdList(ComboBox comboBoxPubInfo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM titles";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBoxPubInfo.Items.Add(reader["pub_id"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return comboBoxPubInfo;
        }

        public string GenerateRandomTitleID()
        {
            Random random = new Random();
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digits = "0123456789";

            char[] prefixChars = new char[2];
            for (int i = 0; i < 2; i++)
            {
                prefixChars[i] = letters[random.Next(letters.Length)];
            }

            string numberPart = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                numberPart += digits[random.Next(digits.Length)];
            }

            return new string(prefixChars) + numberPart;
        }

        public void SaveOrUpdateEntity(string objectID, RichTextBox txtTitle, RichTextBox txtType, RichTextBox txtPrice, 
            RichTextBox txtAdvance, RichTextBox txtRoyalty, RichTextBox txtYTDSales, RichTextBox txtNotes, DateTimePicker txtPubDate, ComboBox comboBoxPubInfo)
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
                        query = "UPDATE titles SET title = @Title, type = @Type, price = @Price, advance = @Advance, royalty = @Royalty, ytd_Sales = @Ytd_sales, notes = @Notes, pubdate = @Pubdate, pub_id = @PubInfo WHERE title_id = @Id";
                    }
                    else
                    {
                        // Insert new record
                        query = "INSERT INTO titles (title_id, title, type, price, advance, royalty, ytd_Sales, Notes, pubdate, pub_id) VALUES (@ID, @Title, @Type, @Price, @Advance, @Royalty, @Ytd_sales, @Notes, @PubDate, @PubInfo)";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(objectID))
                        {
                            cmd.Parameters.AddWithValue("@Id", objectID);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ID", GenerateRandomTitleID());
                        }

                        cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                        cmd.Parameters.AddWithValue("@Type", txtType.Text);
                        cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text));
                        cmd.Parameters.AddWithValue("@Advance", decimal.Parse(txtAdvance.Text));
                        cmd.Parameters.AddWithValue("@Royalty", int.Parse(txtRoyalty.Text));
                        cmd.Parameters.AddWithValue("@Ytd_Sales", int.Parse(txtYTDSales.Text));
                        cmd.Parameters.AddWithValue("@Notes", txtNotes.Text);
                        cmd.Parameters.AddWithValue("@PubDate", txtPubDate.Value);
                        cmd.Parameters.AddWithValue("@PubInfo", comboBoxPubInfo.SelectedItem.ToString());

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
