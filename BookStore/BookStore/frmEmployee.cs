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
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "BookStore.mdf;Integrated Security=True;Connect Timeout=30";
        private string objectID;
        private static Random random = new Random();

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
                using (SqlConnection conn = new SqlConnection(connectionString))
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
                using (SqlConnection conn = new SqlConnection(connectionString))
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

        public static string GenerateRandomEmployeeID()
        {
            StringBuilder empID = new StringBuilder();

            empID.Append(RandomChar());  
            empID.Append(RandomChar());  
            empID.Append(RandomChar()); 

            for (int i = 0; i < 5; i++)
            {
                empID.Append(random.Next(0, 10)); 
            }

            int ForM = random.Next(0, 2);
            if(ForM==0)
                empID.Append("F"); 
            else empID.Append("M");

            return empID.ToString();
        }

        private static char RandomChar()
        {
            return (char)random.Next('A', 'Z' + 1);
        }

        private int GetMinLevelForJob(int lvl)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT min_lvl FROM jobs WHERE job_id = @Lvl";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Lvl", lvl);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show($"No job found for the level {lvl}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return -1; 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving min level: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; 
            }
        }


        private void SaveOrUpdateEntity()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query;
                    if (!string.IsNullOrWhiteSpace(objectID))
                    {
                        // Update existing record
                        query = "UPDATE employee SET fname = @FirstName, minit = @MiddleName, lname = @LastName, job_id = @JobId, hire_date = @HireDate WHERE emp_id = @Id";
                    }
                    else
                    {
                        // Insert new record
                        query = "INSERT INTO employee (emp_id, fname, minit, lname, job_id, job_lvl, hire_date) VALUES (@ID, @FirstName, @MiddleName, @LastName, @JobId, @JobLvl, @HireDate)";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(objectID))
                        {
                            cmd.Parameters.AddWithValue("@Id", objectID);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ID", GenerateRandomEmployeeID());
                        }

                        cmd.Parameters.AddWithValue("@JobLvl", GetMinLevelForJob(int.Parse(comboBoxJob.SelectedItem.ToString())));
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@JobId", comboBoxJob.SelectedItem?.ToString());
                        cmd.Parameters.AddWithValue("@HireDate", DateTime.Parse(maskedTextBoxHiringDate.Text));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearEmployeeInputs();
                        this.Close();
                    }
                }
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
