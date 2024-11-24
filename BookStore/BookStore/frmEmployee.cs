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
            StringBuilder errorMessage = new StringBuilder();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errorMessage.AppendLine("Employee First Name is required.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtMiddleName.Text))
            {
                errorMessage.AppendLine("Employee Middle Name is required.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errorMessage.AppendLine("Employee Last Name is required.");
                isValid = false;
            }

            if (comboBoxJob.SelectedIndex == -1)
            {
                errorMessage.AppendLine("Job level is required.");
                isValid = false;
            }
            
            // Validate ComboBoxJob (Required)
            if (ComboBoxJob.SelectedIndex == -1)
            {
                errorMessage += "Select a Job.\n";
                isValid = false;
            }

            if (!maskedTextBoxHiringDate.MaskCompleted)
            {
                errorMessage.AppendLine("Hiring Date is required.");
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show(errorMessage.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }


        public void ClearEmployeeInputs()
        {
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            comboBoxJob.SelectedIndex = -1;
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
