using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.Data
{
    public class EmployeeDataAccess
    {
        public string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "BookStore.mdf;Integrated Security=True;Connect Timeout=30";
        private static Random random = new Random();

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
            if (ForM == 0)
                empID.Append("F");
            else empID.Append("M");

            return empID.ToString();
        }

        private static char RandomChar()
        {
            return (char)random.Next('A', 'Z' + 1);
        }

        public int GetMinLevelForJob(int lvl)
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

        public void SaveOrUpdateEntity(string objectID, ComboBox comboBoxJob, TextBox txtFirstName, TextBox txtMiddleName, TextBox txtLastName, MaskedTextBox maskedTextBoxHiringDate)
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
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
