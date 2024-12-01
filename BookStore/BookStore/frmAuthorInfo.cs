using System;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace BookStore
{
    public partial class frmAuthorInfo : Form {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "BookStore.mdf;Integrated Security=True;Connect Timeout=30";
        private string objectID;

        public frmAuthorInfo () {
            InitializeComponent();
        }

        public frmAuthorInfo (string objectID) {
            this.objectID = objectID;
            InitializeComponent();
            LoadEntityData(objectID);
        }

        private void btnSave_Click (object sender, EventArgs e) {
            if (!ValidateEntries())
                return;
        }

        private void btnCancel_Click (object sender, EventArgs e) {
            Close();
        }

        private void LoadEntityData(string id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM authors WHERE au_id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtFirstName.Text = reader["au_fname"].ToString();
                                txtLastName.Text = reader["au_lname"].ToString();
                                string phone = reader["phone"]?.ToString() ?? string.Empty;
                                string processedPhone = new string(phone.Where(char.IsDigit).ToArray()); // Extract only digits

                                txtPhoneNumber.Text = processedPhone;
                                txtAddress.Text = reader["address"].ToString();
                                txtCity.Text = reader["city"].ToString();
                                cmbBoxState.SelectedItem = reader["state"].ToString();
                                txtZip.Text = reader["zip"].ToString();
                                string inContract = reader["contract"].ToString();
                                if (inContract == "True")
                                    rbYes.Checked = true;
                                else
                                    rbNo.Checked = true;
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
                        query = "UPDATE authors SET au_fname = @FirstName, au_lname = @LastName, phone = @Phone, address = @Address, city = @City, state = @State, zip = @Zip, contract = @Contract WHERE au_id = @Id";
                    }
                    else
                    {
                        // Insert new record
                        query = "INSERT INTO authors (au_fname, au_lname, phone, address, city, state, zip, contract) VALUES (@FirstName, @LastName, @Phone, @Address, @City, @State, @Zip, @Contract)";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(objectID))
                        {
                            cmd.Parameters.AddWithValue("@Id", objectID);
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


        private bool ValidateEntries () {
            StringBuilder errorMessage = new StringBuilder();

            if (string.IsNullOrEmpty(txtFirstName.Text))
                errorMessage.AppendLine("First Name is required.");
            else if (txtFirstName.Text.Contains(" "))
                errorMessage.AppendLine("First Name should not contain spaces.");

            if (string.IsNullOrEmpty(txtLastName.Text))
                errorMessage.AppendLine("Last Name is required.");
            else if (txtLastName.Text.Contains(" "))
                errorMessage.AppendLine("Last Name should not contain spaces.");

            if (string.IsNullOrEmpty(txtPhoneNumber.Text.Trim()) || !txtPhoneNumber.MaskFull)
                errorMessage.AppendLine("Phone number is missing or does not have the required 14 digits.");

            if (string.IsNullOrEmpty(txtAddress.Text))
                errorMessage.AppendLine("Address is required.");

            if (string.IsNullOrEmpty(txtCity.Text))
                errorMessage.AppendLine("City is required.");

            if (cmbBoxState.SelectedIndex == -1)
                errorMessage.AppendLine("State is required.");

            string zipCode = txtZip.Text.Replace("-", "").Trim();
            if (string.IsNullOrEmpty(zipCode) || (zipCode.Length != 5 && zipCode.Length != 9))
                errorMessage.AppendLine("ZIP code is missing or does not have the required 5 or 9 digits.");

            if (errorMessage.Length > 0) {
                errorMessage.AppendLine("Please fix the listed entries and resubmit.");
                MessageBox.Show(errorMessage.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        private void ClearForm () {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtCity.Text = string.Empty;
            cmbBoxState.SelectedIndex = -1;
            txtZip.Text = string.Empty;
        }

        private void frmAuthorInfo_Load (object sender, EventArgs e) {

        }

        private void btnClear_Click_1 (object sender, EventArgs e) {
            ClearForm();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if(ValidateEntries())
                SaveOrUpdateEntity();

        }
    }
}
