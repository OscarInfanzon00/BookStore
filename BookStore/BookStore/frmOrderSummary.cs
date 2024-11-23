using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class frmOrderSummary : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "BookStore.mdf;Integrated Security=True;Connect Timeout=30";
        private decimal total;

        public frmOrderSummary(DataGridViewRowCollection cartData, decimal total)
        {
            InitializeComponent();
            InitializeDatabaseConnection();

            foreach (DataGridViewRow row in cartData)
            {
                if (row.Cells["title"].Value != null) 
                {
                    tableOrderItems.Rows.Add(
                        row.Cells["title_id"].Value.ToString(),
                        row.Cells["title"].Value.ToString(),
                        row.Cells["price"].Value.ToString(),
                        row.Cells["qty"].Value.ToString(),
                        row.Cells["subtotal"].Value.ToString()
                    );
                }
            }

            lblTotalPrice.Text = $"Total Price: ${total:F2}";
            lblOrderNumber.Text = "Order Number: JHBDJS12";
        }

        private void InitializeDatabaseConnection()
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                SaveOrder();
                MessageBox.Show("Order Confirmed!");
                this.Close();
            }
        }

        private bool ValidateForm()
        {
            if (tableOrderItems.Rows.Count == 0)
            {
                MessageBox.Show("No items in the order!");
                return false;
            }

            return true;
        }

        private void SaveOrder()
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOrderSummary_Load(object sender, EventArgs e)
        {

        }
    }
}
