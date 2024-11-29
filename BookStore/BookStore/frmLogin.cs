using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class frmLogin : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "BookStore.mdf;Integrated Security=True;Connect Timeout=30";
        public frmLogin()
        {
            InitializeComponent();

            txtEnterID.Text = "PTC11962M";
            richTextBoxLastName.Text = "Cramer";
            login();
        }

        private void login()
        {

            string empId = txtEnterID.Text.Trim();
            string lastName = richTextBoxLastName.Text.Trim();

            if (string.IsNullOrEmpty(empId) || string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var employeeDetails = GetEmployeeDetails(empId, lastName);

            if (employeeDetails != null)
            {
                frmMainMenu mainMenu = new frmMainMenu(
                    employeeDetails.Item1,
                    employeeDetails.Item2,
                    employeeDetails.Item3,
                    employeeDetails.Item4,
                    employeeDetails.Item5
                );

                mainMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid employee ID or last name.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private Tuple<string, string, string, string, DateTime> GetEmployeeDetails(string empId, string lastName)
        {
            string query = "SELECT fname, minit, lname, job_lvl, hire_date FROM employee WHERE emp_id = @empId AND lname = @lastName";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@empId", empId);
                        command.Parameters.AddWithValue("@lastName", lastName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string employeeName = reader["fname"].ToString();
                                string employeeMiddleName = reader["minit"].ToString();
                                string employeeLastName = reader["lname"].ToString();
                                string employeeLvl = reader["job_lvl"].ToString();
                                DateTime employeeHiringDate = Convert.ToDateTime(reader["hire_date"]);

                                return Tuple.Create(employeeName, employeeMiddleName, employeeLastName, employeeLvl, employeeHiringDate);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving employee details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null; 
        }

        private void txtType_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
