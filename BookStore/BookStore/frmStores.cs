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
                MessageBox.Show("Inputs are valid. Proceeding with save operation.");
                ClearStoreInputs();
            }
           

            //string query = storesId == null
            //? "INSERT INTO stores  (stor_name,stor_address,city,state,zip) VALUES (@stor_name, @stor_address, @city, @state, @zip)"
            //: "UPDATE stores SET stor_name = @stor_name, stor_address = @stor_address, city = @city, state = @state, zip = @zip WHERE stor_id = @StoreId";

            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            // SqlCommand cmd = new SqlCommand(query, conn);
            // cmd.Parameters.AddWithValue("@stor_name", txtStoreName.Text);
            // cmd.Parameters.AddWithValue("@stor_address", txtAddress.Text);
            //cmd.Parameters.AddWithValue("@city", txtCity.Text);
            //cmd.Parameters.AddWithValue("@state", txtState.Text);
            //cmd.Parameters.AddWithValue("@zip", decimal.Parse(txtZip.Text));



            //if (storesId != null)
            // {
            // cmd.Parameters.AddWithValue("@StoreId", storesId);
            //}

            // conn.Open();
            //cmd.ExecuteNonQuery();
            //conn.Close();
            //}

            // this.Close();
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

        //public frmStores(int storesId) : this()
        // {
        // this.storesId = storesId;
        //LoadData(storesId);
        //}
        //private void LoadData(int storesId)
        //{
        //using (SqlConnection conn = new SqlConnection(connectionString))
        //{
        // SqlCommand cmd = new SqlCommand("SELECT * FROM stores  WHERE stor_id = @StoreId", conn);
        // cmd.Parameters.AddWithValue("@StoreId", storesId);
        //conn.Open();

        //SqlDataReader reader = cmd.ExecuteReader();
        //if (reader.Read())
        // {
        //txtStoreName.Text = reader["stor_name"].ToString();
        // txtAddress.Text = reader["stor_address"].ToString();
        // txtCity.Text = reader["city"].ToString();
        //txtState.Text = reader["state"].ToString();
        // txtZip.Text = reader["zip"].ToString();

        //}
        // conn.Close();
        // }
        //}
    }
}
