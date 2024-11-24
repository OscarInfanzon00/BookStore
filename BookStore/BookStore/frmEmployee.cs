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

namespace BookStore
{
    public partial class frmEmployee : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "BookStore.mdf;Integrated Security=True;Connect Timeout=30";

        string FirstName;
        string MiddleName;
        string LastName;

        public frmEmployee()
        {
            InitializeComponent();
        }

        public bool ValidateEmployeeInputs()
        {
            string errorMessage = "";
            bool isValid = true;

            // Validate txtFirstName (Required)
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errorMessage += "Employee Name is required.\n";
                isValid = false;
            }

            // Validate txtMiddleName (Required)
            if (string.IsNullOrWhiteSpace(txtMiddleName.Text))
            {
                errorMessage += "Employee Middle Name is required.\n";
                isValid = false;
            }

            // Validate txtLastName (Required)
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errorMessage += "Employee Last Name is required.\n";
                isValid = false;
            }

            // Validate txtJoblvl (Required)
            if (string.IsNullOrWhiteSpace(txtJoblvl.Text))
            {
                errorMessage += "A Job lvl is required.\n";
                isValid = false;
            }
            
            // Validate ComboBoxJob (Required)
            if (ComboBoxJob.SelectedIndex == -1)
            {
                errorMessage += "Select a Job.\n";
                isValid = false;
            }

            // Validate 
            if (!maskedTextBoxHiringDate.MaskCompleted)
            {
                errorMessage += "Add a Hiring Date.\n";
                isValid = false;
            }

            // Display error messages, if any
            if (!isValid)
            {
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }

        public void ClearEmployeeInputs()
        {
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            txtJoblvl.Text = "";
            maskedTextBoxHiringDate.Text = "";
            ComboBoxJob.SelectedIndex = -1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateEmployeeInputs())
            {
                MessageBox.Show("Inputs are valid. Proceeding with save operation.");
                ClearEmployeeInputs();
                // Add logic to save store data here
            }
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearEmployeeInputs();
        }
    }
}
