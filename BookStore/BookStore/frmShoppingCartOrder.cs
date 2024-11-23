using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp;

namespace BookStore
{
    public partial class frmShoppingCartOrder : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\oscar\\Downloads\\BookStore.MDF;Integrated Security=True;Connect Timeout=30";
        private decimal Subtotal = 0;
        private decimal Total = 0;
        private decimal Tax = 0;

        public frmShoppingCartOrder()
        {
            InitializeComponent();
        }

        private void frmShoppingCartOrder_Load(object sender, EventArgs e)
        {
            dataGridViewShoppingCart.Columns.Add("title_id", "Title_ID");
            dataGridViewShoppingCart.Columns.Add("title", "Title");
            dataGridViewShoppingCart.Columns.Add("price", "Price");
            dataGridViewShoppingCart.Columns.Add("qty", "Quantity");
            dataGridViewShoppingCart.Columns.Add("subtotal", "Subtotal");
        }

        private void LoadTitles(string title)
        {
            string query = "SELECT * FROM titles WHERE title LIKE @Title";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Title", "%" + title + "%");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            FillTable(dataGridViewTitle, dataTable);
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

        private void buttonAddToCart_Click(object sender, EventArgs e)
        {
            if (dataGridViewTitle.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewTitle.SelectedRows[0];

                if (int.TryParse(textBoxQTY.Text, out int qty) && qty > 0)
                {
                    string title = selectedRow.Cells["title"].Value.ToString();
                    string id = selectedRow.Cells["title_id"].Value.ToString();
                    decimal price = Convert.ToDecimal(selectedRow.Cells["price"].Value);

                    AddItemToCart(id, title, price, qty);
                }
                else
                {
                    MessageBox.Show("Please enter a valid quantity (positive integer).", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a title to add to the shopping cart.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddItemToCart(string id, string title, decimal price, int qty)
        {
            decimal itemSubtotal = price * qty;
            Subtotal += itemSubtotal;

            Tax = Subtotal * 0.07m;
            Total = Subtotal + Tax;

            dataGridViewShoppingCart.Rows.Add(id, title, price, qty, itemSubtotal);

            labelSubtotal.Text = $"Subtotal: {Subtotal:C}";
            labelTax.Text = $"Tax: {Tax:C}";
            labelTotal.Text = $"Total: {Total:C}";
        }

        private void buttonRemoveFromCart_Click(object sender, EventArgs e)
        {
            if (dataGridViewShoppingCart.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewShoppingCart.SelectedRows[0];

                decimal price = Convert.ToDecimal(selectedRow.Cells["price"].Value);
                int qty = Convert.ToInt32(selectedRow.Cells["qty"].Value);
                decimal itemSubtotal = Convert.ToDecimal(selectedRow.Cells["subtotal"].Value);

                dataGridViewShoppingCart.Rows.Remove(selectedRow);

                Subtotal -= itemSubtotal;
                Tax = Subtotal * 0.08m;
                Total = Subtotal + Tax;

                labelSubtotal.Text = $"Subtotal: {Subtotal:C}";
                labelTax.Text = $"Tax: {Tax:C}";
                labelTotal.Text = $"Total: {Total:C}";
            }
            else
            {
                MessageBox.Show("Please select an item to remove from the shopping cart.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnSubmitOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewShoppingCart.Rows.Count > 0) {
                frmOrderSummary orderSummaryForm = new frmOrderSummary(dataGridViewShoppingCart.Rows, Total);
                orderSummaryForm.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Add some products to the cart", "The Cart is Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void buttonCancelOrder_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            LoadTitles(textBoxTitle.Text);
        }
    }
}
