using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore {
    public partial class frmAuthorInfo : Form {
        private string connectionString;
        public frmAuthorInfo () {
            InitializeComponent();
        }

        private void btnSave_Click (object sender, EventArgs e) {
            if (!ValidateEntries())
                return;


            //TODO: Update State to cbo instead of txt, Handle ID key.
            //try {
            //    string insert =
            //    "INSERT INTO Authors (Au_id, Au_lName, Au_fName, Phone, Address, City, State, Zip, Contract) " +
            //    "VALUES (@Id, @LastName, @FirstName, @Phone, @Address, @City, @State, @Zip, @Contract)";

            //    using SqlConnection connection = new(connectionString);
            //    using SqlCommand command = new SqlCommand(insert, connection);

            //    command.Parameters.AddWithValue("@LastName", txtLastName.Text);
            //    command.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            //    command.Parameters.AddWithValue("@Phone", txtPhoneNumber.Text);
            //    command.Parameters.AddWithValue("@Address", txtAddress.Text);
            //    command.Parameters.AddWithValue("@City", txtCity.Text);
            //    command.Parameters.AddWithValue("@State", txtState.Text);
            //    command.Parameters.AddWithValue("@Zip", txtZip.Text);
            //    if (rbYes.Checked)
            //        command.Parameters.AddWithValue("@Contract", "Yes");
            //    else
            //        command.Parameters.AddWithValue("@Contract", "No");

            //    connection.Open();
            //    command.ExecuteNonQuery();
            //    btnCancel_Click(sender, e);
            //}
            //catch (Exception ex) {
            //    MessageBox.Show(ex.Message);
            //}

            MessageBox.Show("Inputs are valid. Proceeding with save operation.");
            ClearForm();
        }

        private void btnCancel_Click (object sender, EventArgs e) {
            this.Close();
        }

        private bool ValidateEntries () {
            string errorMessage = "";
            string zipCode = txtZip.Text.Replace("-", "").Trim();

            if (string.IsNullOrEmpty(txtFirstName.Text))
                errorMessage += "First Name is required. \n";
            if (string.IsNullOrEmpty(txtLastName.Text))
                errorMessage += "Last Name is required. \n";
            if (string.IsNullOrEmpty(txtPhoneNumber.Text.Trim()) || !txtPhoneNumber.MaskFull)
                errorMessage += "Phone number is missing or is not the required 14 digit length. \n";
            if (string.IsNullOrEmpty(txtAddress.Text))
                errorMessage += "Address is required. \n";
            if (string.IsNullOrEmpty(txtCity.Text))
                errorMessage += "City is required. \n";
            if (string.IsNullOrEmpty(txtState.Text))
                errorMessage += "State is required. \n";
            if (string.IsNullOrEmpty(zipCode) || (zipCode.Length != 5 && zipCode.Length != 9))
                errorMessage += "ZIP code is missing or is not the required 5/9 digit length. \n";

            if (errorMessage != "") {
                errorMessage += "Please fix listed entries and resubmit.";
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            txtState.Text = string.Empty;
            txtZip.Text = string.Empty;
        }

        private void frmAuthorInfo_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
