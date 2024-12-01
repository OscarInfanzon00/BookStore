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
    public partial class frmSalesReport : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "BookStore.mdf;Integrated Security=True;Connect Timeout=30";

        public frmSalesReport()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SalesReport_Load(object sender, EventArgs e)
        {

        }

        public void LoadDataInTable(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerFrom.Value.Date;
            DateTime endDate = dateTimePickerTo.Value.Date;

            string query = "SELECT * FROM sales WHERE ord_date BETWEEN @StartDate AND @EndDate";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            FillTable(dataGridViewTable, dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FillTable(DataGridView dataGridView, DataTable dataTable)
        {
            if (dataGridView == null || dataTable == null)
            {
                throw new ArgumentNullException("DataGridView and DataTable cannot be null.");
            }

            dataGridView.DataSource = null;

            dataGridView.DataSource = dataTable;

            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void buttonGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    DateTime startDate = dateTimePickerFrom.Value.Date;
                    DateTime endDate = dateTimePickerTo.Value.Date;

                    string query = @"
                SELECT 
                    s.ord_num,
                    s.ord_date,
                    s.qty,
                    t.title,
                    t.price,
                    (s.qty * t.price) AS subtotal
                FROM sales s
                INNER JOIN titles t ON s.title_id = t.title_id
                WHERE s.ord_date BETWEEN @StartDate AND @EndDate";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable saleDetails = new DataTable();
                            adapter.Fill(saleDetails);

                            // Calculate totals
                            decimal subtotal = saleDetails.AsEnumerable().Sum(row => row.Field<decimal>("subtotal"));
                            decimal tax = subtotal * 0.07M; // Assuming 7% tax
                            decimal total = subtotal + tax;

                            frmReportWindow reportWindow = new frmReportWindow(saleDetails, subtotal, tax, total);
                            reportWindow.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
