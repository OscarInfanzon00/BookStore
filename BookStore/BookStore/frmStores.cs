using BookStore.BusinessLogic;
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
        public StoresBusinessLogic storesBusinessLogic = new StoresBusinessLogic();
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

            if (!storesBusinessLogic.IsValidZipCode(txtZip.Text))
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



        private void LoadEntityData(string id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(storesBusinessLogic.storesDataAccess.connectionString))
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


        private void SaveOrUpdateEntity()
        {
            try
            {
                storesBusinessLogic.storesDataAccess.SaveOrUpdateEntity(objectID, txtStoreName, txtAddress, txtCity, comboBoxState, txtZip);
                 ClearStoreInputs();
                 this.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
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


