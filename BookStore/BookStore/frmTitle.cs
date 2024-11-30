using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStoreTitleStores
{
    public partial class frmTitle : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "BookStore.mdf;Integrated Security=True;Connect Timeout=30";
        private string objectID;

        public frmTitle()
        {
            InitializeComponent();
        }

        public frmTitle(string objectID)
        {
            this.objectID = objectID;
            InitializeComponent();
        }

        public bool ValidateInputs()
        {
            StringBuilder errorMessage = new StringBuilder();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                errorMessage.AppendLine("Title is required.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtType.Text))
            {
                errorMessage.AppendLine("Type is required.");
                isValid = false;
            }

            isValid &= ValidateNumericField(txtPrice.Text, "Price", errorMessage);
            isValid &= ValidateNumericField(txtAdvance.Text, "Advance", errorMessage);
            isValid &= ValidateNumericField(txtRoyalty.Text, "Royalty", errorMessage);
            isValid &= ValidateNumericField(txtYTDSales.Text, "Year-to-date sales"  , errorMessage);

            if (txtPubDate.Value.Date > DateTime.Today)
            {
                errorMessage.AppendLine("Publication date cannot be in the future.");
                isValid = false;
            }

            if (comboBoxPubInfo.SelectedIndex == -1)
            {
                errorMessage.AppendLine("Publication Info is missing.");
                isValid = false;
            }

            if (!isValid)
            {
                errorMessage.AppendLine("Please fix the listed entries and resubmit.");
                MessageBox.Show(errorMessage.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }

        private bool ValidateNumericField(string inputText, string fieldName, StringBuilder errorMessage)
        {
            if (string.IsNullOrWhiteSpace(inputText) || !decimal.TryParse(inputText, out decimal result) || result < 0)
            {
                errorMessage.AppendLine($"{fieldName} must be a valid positive number.");
                return false;
            }
            return true;
        }

        public void ClearInputs()
        {
            txtTitle.Text = "";
            txtType.Text = "";
            txtPrice.Text = "";
            txtAdvance.Text = "";
            txtRoyalty.Text = "";
            txtYTDSales.Text = "";
            txtNotes.Text = "";
            comboBoxPubInfo.SelectedIndex = -1;
            txtPubDate.Value = DateTime.Now;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearInputs();
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputs()) 
            { 
        
                MessageBox.Show("Inputs are valid. Proceeding with save operation.");
                ClearInputs();
                this.Close();
            }


            
        }

        private void frmTitle_Load(object sender, EventArgs e)
        {

     
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

       

        
        
    }
}
    

