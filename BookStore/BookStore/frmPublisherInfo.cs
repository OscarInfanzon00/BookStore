using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore {
    public partial class frmPublisherInfo : Form {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "BookStore.mdf;Integrated Security=True;Connect Timeout=30";
        private string objectID;

        public frmPublisherInfo () {
            InitializeComponent();
        }

        public frmPublisherInfo(string objectID)
        {
            this.objectID = objectID;
            InitializeComponent();
            LoadEntityData(objectID);
        }

        private void btnSave_Click (object sender, EventArgs e) {
            if (!ValidateEntries())
                return;

            MessageBox.Show("Inputs are valid. Proceeding with save operation.");
            ClearForm();
        }

        private void btnCancel_Click (object sender, EventArgs e) {
            this.Close();
        }

        private bool ValidateEntries()
        {
            StringBuilder errorMessage = new StringBuilder();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorMessage.AppendLine("Name is required.");
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

            if (comboBoxCountry.SelectedIndex == -1)
            {
                errorMessage.AppendLine("Country is required.");
                isValid = false;
            }

            if (!isValid)
            {
                errorMessage.AppendLine("Please fix listed entries and resubmit.");
                MessageBox.Show(errorMessage.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }


        private void ClearForm () {
            txtName.Text = string.Empty;
            txtCity.Text = string.Empty;
            comboBoxCountry.SelectedIndex = -1;
            comboBoxState.SelectedIndex = -1;
        }

        private void btnClear_Click (object sender, EventArgs e) {
            ClearForm();
        }

        private void frmPublisherInfo_Load(object sender, EventArgs e)
        {

        }

        private void LoadEntityData(string id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM publishers WHERE pub_id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtName.Text = reader["pub_name"].ToString();
                                txtCity.Text = reader["city"].ToString();
                                comboBoxState.SelectedItem = reader["state"].ToString();
                                comboBoxCountry.Items.Add(reader["country"].ToString());
                                comboBoxCountry.SelectedItem = reader["country"].ToString();
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
                        query = "UPDATE publishers SET pub_name = @PubName, city = @City, state = @State, country = @Country WHERE pub_id = @Id";
                    }
                    else
                    {
                        // Insert new record
                        query = "INSERT INTO publishers (pub_name, city, state, country) VALUES (@PubName, @City, @State, @Country)";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(objectID))
                        {
                            cmd.Parameters.AddWithValue("@Id", objectID);
                        }

                        cmd.Parameters.AddWithValue("@PubName", txtName.Text);
                        cmd.Parameters.AddWithValue("@City", txtCity.Text);
                        cmd.Parameters.AddWithValue("@State", comboBoxState.SelectedItem?.ToString());
                        cmd.Parameters.AddWithValue("@Country", comboBoxCountry.SelectedItem?.ToString());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if(ValidateEntries())
                SaveOrUpdateEntity();

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
