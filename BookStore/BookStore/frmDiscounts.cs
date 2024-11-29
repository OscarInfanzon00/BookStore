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
        private string objectID;

        public frmDiscounts()
        {
            InitializeComponent();
        }

        public frmDiscounts(string objectID)
        {
            this.objectID = objectID;
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
            StringBuilder errorMessage = new StringBuilder();
            bool isValid = true;

            if (comboBoxType.SelectedIndex == -1)
            {
                errorMessage.AppendLine("Select a Discount Type.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtDiscount.Text))
            {
                errorMessage.AppendLine("Discount is required.");
                isValid = false;
            }
            else if (!IsNumeric(txtDiscount.Text))
            {
                errorMessage.AppendLine("Discount must be a valid number.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtHighQTY.Text))
            {
                errorMessage.AppendLine("High QTY is required.");
                isValid = false;
            }
            else if (!IsNumeric(txtHighQTY.Text))
            {
                errorMessage.AppendLine("High QTY must be a valid number.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtLowQTY.Text))
            {
                errorMessage.AppendLine("Low QTY is required.");
                isValid = false;
            }
            else if (!IsNumeric(txtLowQTY.Text))
            {
                errorMessage.AppendLine("Low QTY must be a valid number.");
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show(errorMessage.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }

        private bool IsNumeric(string input)
        {
            return decimal.TryParse(input, out _);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateDiscountsInputs())
            {
                MessageBox.Show("Inputs are valid. Proceeding with save operation.");
                ClearDiscountsInputs();
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
