using Microsoft.Data.SqlClient;
using System;
using System.Text;
using System.Windows.Forms;

namespace BookStore {
    public partial class frmPublisherInfo : Form {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "BookStore.mdf;Integrated Security=True;Connect Timeout=30";
        private string objectID;

        public frmPublisherInfo () {
            InitializeComponent();
        }

        public frmPublisherInfo (string objectID) {
            this.objectID = objectID;
            InitializeComponent();
        }

        private void btnSave_Click (object sender, EventArgs e) {
            if (!ValidateEntries())
                return;

            try {
                string insert =
                "INSERT INTO Publishers (pub_name, city, state, country) " +
                "VALUES (@Name, @City, @State, @Country)";

                using SqlConnection connection = new(connectionString);
                using SqlCommand command = new SqlCommand(insert, connection);

                command.Parameters.AddWithValue("@Name", txtName.Text);
                command.Parameters.AddWithValue("@City", txtCity.Text);
                command.Parameters.AddWithValue("@State", cboState.Text);
                command.Parameters.AddWithValue("@Country", cboCountry.Text);

                connection.Open();
                command.ExecuteNonQuery();
                btnCancel_Click(sender, e);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show("Inputs are valid. Proceeding with save operation.");
            ClearForm();
        }

        private void btnCancel_Click (object sender, EventArgs e) {
            this.Close();
        }

        private bool ValidateEntries () {
            StringBuilder errorMessage = new StringBuilder();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtName.Text)) {
                errorMessage.AppendLine("Name is required.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtCity.Text)) {
                errorMessage.AppendLine("City is required.");
                isValid = false;
            }

            if (cboState.SelectedIndex == -1) {
                errorMessage.AppendLine("State is required.");
                isValid = false;
            }

            if (cboCountry.SelectedIndex == -1) {
                errorMessage.AppendLine("Country is required.");
                isValid = false;
            }

            if (!isValid) {
                errorMessage.AppendLine("Please fix listed entries and resubmit.");
                MessageBox.Show(errorMessage.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }


        private void ClearForm () {
            txtName.Text = string.Empty;
            txtCity.Text = string.Empty;
            cboCountry.SelectedIndex = -1;
            cboState.SelectedIndex = -1;
        }

        private void btnClear_Click (object sender, EventArgs e) {
            ClearForm();
        }

        private void frmPublisherInfo_Load (object sender, EventArgs e) {

        }
    }
}
