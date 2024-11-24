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

        public frmPublisherInfo () {
            InitializeComponent();
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

        private bool ValidateEntries () {
            string errorMessage = "";

            if (string.IsNullOrEmpty(txtName.Text))
                errorMessage += "Name is required. \n";
            if (string.IsNullOrEmpty(txtCity.Text))
                errorMessage += "City is required. \n";
            if (comboBoxState.SelectedIndex==-1)
                errorMessage += "State is required. \n";
            if (comboBoxCountry.SelectedIndex==-1)
                errorMessage += "Country is required. \n";

            if (errorMessage != "") {
                errorMessage += "Please fix listed entries and resubmit.";
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
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
