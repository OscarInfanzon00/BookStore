using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStoreTitleStores
{
    public partial class frmTitle : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "BookStore.mdf;Integrated Security=True;Connect Timeout=30";
        private string objectID;

        public frmTitle()
        {
            InitializeComponent();
            loadPub_IdList();
        }

        public frmTitle(string objectID)
        {
            this.objectID = objectID;
            InitializeComponent();
            loadPub_IdList();
            LoadEntityData(objectID);
        }

        private void loadPub_IdList()
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
        }

        public bool ValidateInputs()
        {
            StringBuilder errorMessage = new StringBuilder();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                errorMessage.AppendLine("Title is required.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtType.Text))
            {
                errorMessage.AppendLine("Type is required.");
                isValid = false;
            }

            isValid &= ValidateNumericField(txtPrice.Text, "Price", errorMessage);
            isValid &= ValidateNumericField(txtAdvance.Text, "Advance", errorMessage);
            isValid &= ValidateNumericField(txtRoyalty.Text, "Royalty", errorMessage);
            isValid &= ValidateNumericField(txtYTDSales.Text, "Year-to-date sales", errorMessage);

            if (txtPubDate.Value.Date > DateTime.Today)
            {
                errorMessage.AppendLine("Publication date cannot be in the future.");
                isValid = false;
            }

            if (comboBoxPubInfo.SelectedIndex == -1)
            {
                errorMessage.AppendLine("Publication Info is missing.");
                isValid = false;
            }

            if (!isValid)
            {
                errorMessage.AppendLine("Please fix the listed entries and resubmit.");
                MessageBox.Show(errorMessage.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }

        private bool ValidateNumericField(string inputText, string fieldName, StringBuilder errorMessage)
        {
            if (string.IsNullOrWhiteSpace(inputText) || !decimal.TryParse(inputText, out decimal result) || result < 0)
            {
                errorMessage.AppendLine($"{fieldName} must be a valid positive number.");
                return false;
            }
            return true;
        }

        public void ClearInputs()
        {
            txtTitle.Text = "";
            txtType.Text = "";
            txtPrice.Text = "";
            txtAdvance.Text = "";
            txtRoyalty.Text = "";
            txtYTDSales.Text = "";
            txtNotes.Text = "";
            comboBoxPubInfo.SelectedIndex = -1;
            txtPubDate.Value = DateTime.Now;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearInputs();
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                SaveOrUpdateEntity();
                ClearInputs();
                this.Close();
            }
        }

        private void frmTitle_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(objectID))
            {
                LoadEntityData(objectID);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void LoadEntityData(string id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM titles WHERE title_id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtTitle.Text = reader["title"].ToString();
                                txtType.Text = reader["type"].ToString();
                                txtPrice.Text = reader["price"].ToString();
                                txtAdvance.Text = reader["advance"].ToString();
                                txtRoyalty.Text = reader["royalty"].ToString();
                                txtYTDSales.Text = reader["ytd_Sales"].ToString();
                                txtNotes.Text = reader["notes"].ToString();
                                txtPubDate.Value = Convert.ToDateTime(reader["pubdate"]);
                                comboBoxPubInfo.SelectedItem = reader["pub_id"].ToString();
                            }
                        }
                    }
                }
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
                        query = "UPDATE titles SET title = @Title, type = @Type, price = @Price, advance = @Advance, royalty = @Royalty, ytd_Sales = @Ytd_sales, notes = @Notes, pubdate = @Pubdate, pub_id = @PubInfo WHERE title_id = @Id";
                    }
                    else
                    {
                        // Insert new record
                        query = "INSERT INTO titles (title, type, price, advance, royalty, ytd_Sales, Notes, pubdate, pub_id) VALUES (@Title, @Type, @Price, @Advance, @Royalty, @YTDSales, @Notes, @PubDate, @PubInfo)";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", objectID);
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
