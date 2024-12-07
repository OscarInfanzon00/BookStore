using BookStore.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace BookStore
{
    public partial class frmEmployee : Form
    {
        public EmployeeBusinessLogic employeeBusinessLogic = new EmployeeBusinessLogic();
        private string objectID;

        public frmEmployee()
        {
            InitializeComponent();
            loadJob_IdList();
        }

        public frmEmployee(string objectID)
        {
            this.objectID = objectID;
            InitializeComponent();
            loadJob_IdList();
            LoadEntityData(objectID);
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

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errorMessage.AppendLine("Employee Last Name is required.");
                isValid = false;
            }

            if (txtFirstName.Text.Length > 20)
            {
                errorMessage.AppendLine("First name exceeds the 20 characters, please fix.");
                isValid = false;
            }

            if (txtLastName.Text.Length > 30)
            {
                errorMessage.AppendLine("Last name exceeds the 30 characters, please fix.");
                isValid = false;
            }

            if (txtMiddleName.Text.Length>1)
            {
                errorMessage.AppendLine("Only add the initial of the Middle name.");
                isValid = false;
            }

            if (comboBoxJob.SelectedIndex == -1)
            {
                errorMessage.AppendLine("Job level is required.");
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadJob_IdList()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(employeeBusinessLogic.employeeDataAccess.connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM jobs";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBoxJob.Items.Add(reader["job_id"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEntityData(string id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(employeeBusinessLogic.employeeDataAccess.connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM employee WHERE emp_id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtFirstName.Text = reader["fname"].ToString();
                                txtMiddleName.Text = reader["minit"].ToString();
                                txtLastName.Text = reader["lname"].ToString();
                                comboBoxJob.SelectedItem = reader["job_id"].ToString();
                                DateTime hireDate = Convert.ToDateTime(reader["hire_date"]);
                                maskedTextBoxHiringDate.Text = hireDate.ToString("MM-dd-yyyy");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private int GetMinLevelForJob(int lvl)
        {
            return employeeBusinessLogic.employeeDataAccess.GetMinLevelForJob(lvl);
        }


        private void SaveOrUpdateEntity()
        {
            try
            {
                employeeBusinessLogic.employeeDataAccess.SaveOrUpdateEntity(objectID,comboBoxJob,txtFirstName,txtMiddleName,txtLastName,maskedTextBoxHiringDate);
                ClearEmployeeInputs();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateEmployeeInputs())
            {
                SaveOrUpdateEntity();
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
