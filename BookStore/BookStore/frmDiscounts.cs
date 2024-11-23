using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class frmDiscounts : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "BookStore.mdf;Integrated Security=True;Connect Timeout=30";
        public frmDiscounts()
        {
            InitializeComponent();
        }

        public void ClearDiscountsInputs()
        {
            comboBoxType.SelectedIndex = -1;
            txtDiscount.Text = "";
            txtHighQTY.Text = "";
            txtLowQTY.Text = "";
        }

        public bool ValidateDiscountsInputs()
        {
            string errorMessage = "";
            bool isValid = true;

            // Validate comboBoxType (Required)
            if (comboBoxType.SelectedIndex==-1)
            {
                errorMessage += "Select a Discount Type.\n";
                isValid = false;
            }

            // Validate txtDiscount (Required)
            if (string.IsNullOrWhiteSpace(txtDiscount.Text))
            {
                errorMessage += "Discount is required.\n";
                isValid = false;
            }

            // Validate txtHighQTY (Required)
            if (string.IsNullOrWhiteSpace(txtHighQTY.Text))
            {
                errorMessage += "High QTY is required.\n";
                isValid = false;
            }

            // Validate txtLowQTY (Required)
            if (string.IsNullOrWhiteSpace(txtLowQTY.Text))
            {
                errorMessage += "Low QTY is required.\n";
                isValid = false;
            }

            // Display error messages, if any
            if (!isValid)
            {
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateDiscountsInputs())
            {
                MessageBox.Show("Inputs are valid. Proceeding with save operation.");
                ClearDiscountsInputs();
                // Add logic to save store data here
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            ClearDiscountsInputs();
            this.Close();
        }

        private void frmDiscounts_Load(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearDiscountsInputs();
        }
    }
}
