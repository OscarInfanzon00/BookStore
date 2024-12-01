using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStoreTitleStores
{
    public partial class frmStores : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "BookStore.mdf;Integrated Security=True;Connect Timeout=30";
        private string objectID;

        public frmStores()
        {
            InitializeComponent();
        }

        public frmStores(string objectID)
        {
            this.objectID = objectID;
            InitializeComponent();
            LoadEntityData(objectID);
        }

        public bool ValidateStoreInputs()
        {
            StringBuilder errorMessage = new StringBuilder();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtStoreName.Text))
            {
                errorMessage.AppendLine("Store Name is required.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                errorMessage.AppendLine("Address is required.");
                isValid = false;
            }

            if (txtStoreName.Text.Length > 40)
            {
                errorMessage.AppendLine("Store Name exceeds the 40 characters, please fix.");
                isValid = false;
            }

            if (txtAddress.Text.Length > 40)
            {
                errorMessage.AppendLine("Address exceeds the 40 characters, please fix.");
                isValid = false;
            }

            if (txtCity.Text.Length > 20)
            {
                errorMessage.AppendLine("City exceeds the 20 characters, please fix.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtCity.Text))
            {
                errorMessage.AppendLine("City is required.");
                isValid = false;
            }

            if (comboBoxState.SelectedIndex == -1)
            {
                errorMessage.AppendLine("State is required.");
                isValid = false;
            }

            if (!IsValidZipCode(txtZip.Text))
            {
                errorMessage.AppendLine("ZIP code must be a valid 5-digit or 9-digit code (e.g., 12345 or 12345-6789).");
                isValid = false;
            }

            if (!isValid)
            {
                errorMessage.AppendLine("Please fix the listed entries and resubmit.");
                MessageBox.Show(errorMessage.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }

        private bool IsValidZipCode(string zipCode)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(zipCode, @"^\d{5}(-\d{4})?$");
        }

        private void LoadEntityData(string id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM stores WHERE stor_id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtStoreName.Text = reader["stor_name"].ToString();
                                txtAddress.Text = reader["stor_address"].ToString();
                                txtCity.Text = reader["city"].ToString();
                                comboBoxState.SelectedItem = reader["state"].ToString();
                                txtZip.Text = reader["zip"].ToString();
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

        private string GenerateRandomStoreID()
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
                        ClearStoreInputs();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void ClearStoreInputs()
        {
            txtStoreName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            comboBoxState.SelectedIndex = -1;
            txtZip.Text = "";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateStoreInputs())
            {
                SaveOrUpdateEntity();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearStoreInputs ();
            this.Close();
        }

        private void frmStores_Load(object sender, EventArgs e)
        {
       
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearStoreInputs();
        }

        
    }
}


