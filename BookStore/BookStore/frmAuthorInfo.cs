using System;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using BookStore.BusinessLogic;

namespace BookStore
{
    public partial class frmAuthorInfo : Form {
        public AuthorBusinessLogic authorBusinessLogic = new AuthorBusinessLogic();
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
                using (SqlConnection conn = new SqlConnection(authorBusinessLogic.authorDataAccess.connectionString))
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
                authorBusinessLogic.authorDataAccess.SaveOrUpdateEntity(objectID, txtFirstName, txtLastName, txtPhoneNumber, txtAddress, txtCity, cmbBoxState, txtZip, rbYes);
                ClearForm();
                this.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
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

            if (txtLastName.Text.Length > 40)
            {
                errorMessage.AppendLine("Last name exceeds the 40 characters, please fix.");
            }

            if (txtFirstName.Text.Length > 20)
            {
                errorMessage.AppendLine("First name exceeds the 20 characters, please fix.");
            }

            if (txtAddress.Text.Length > 40)
            {
                errorMessage.AppendLine("Address exceeds the 40 characters, please fix.");
            }

            if (txtCity.Text.Length > 20)
            {
                errorMessage.AppendLine("City exceeds the 20 characters, please fix.");
            }

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
