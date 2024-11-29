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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BookStore {
    public partial class frmAuthorInfo : Form {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "BookStore.mdf;Integrated Security=True;Connect Timeout=30";
        private string objectID;

        public frmAuthorInfo () {
            InitializeComponent();
        }

        public frmAuthorInfo(string objectID)
        {
            this.objectID = objectID;
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

        private bool ValidateEntries()
        {
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

            if (comboBoxState.SelectedIndex == -1)
                errorMessage.AppendLine("State is required.");

            string zipCode = txtZip.Text.Replace("-", "").Trim();
            if (string.IsNullOrEmpty(zipCode) || (zipCode.Length != 5 && zipCode.Length != 9))
                errorMessage.AppendLine("ZIP code is missing or does not have the required 5 or 9 digits.");

            if (errorMessage.Length > 0)
            {
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
            comboBoxState.SelectedIndex = -1;
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
