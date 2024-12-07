using BookStore.BusinessLogic;
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
        public PublisherBusinessLogic publisherBusinessLogic = new PublisherBusinessLogic();
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

            if (txtName.Text.Length > 40)
            {
                errorMessage.AppendLine("Publisher Name exceeds the 40 characters, please fix.");
                isValid = false;
            }

            if (txtCity.Text.Length > 20)
            {
                errorMessage.AppendLine("City exceeds the 20 characters, please fix.");
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
                using (SqlConnection conn = new SqlConnection(publisherBusinessLogic.publisherDataAccess.connectionString))
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
                publisherBusinessLogic.publisherDataAccess.SaveOrUpdateEntity(objectID, txtName, txtCity, comboBoxState, comboBoxCountry);
                ClearForm();
                this.Close();
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
