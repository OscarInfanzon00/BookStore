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
    public partial class frmPublisherInfo : Form {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "BookStore.mdf;Integrated Security=True;Connect Timeout=30";
        private string objectID;

        public frmPublisherInfo () {
            InitializeComponent();
        }

        public frmPublisherInfo(string objectID)
        {
            this.objectID = objectID;
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
    }
}
