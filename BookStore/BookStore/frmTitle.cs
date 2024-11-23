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
        //public string connectionString = "Data Source=(LocalDB)MSSQLLocalDB;AttachDbFilename=C:\\Users\\carlo\\Downloads\\BookStore.MDF;Integrated Security=True;Connect Timeout=30";
        //private int? bookId = null;
        public frmTitle()
        {
            InitializeComponent();
        }
        public bool ValidateInputs()
        {
            string errorMessage = "";
            bool isValid = true;

            // Validate txtTitle (Required)
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                errorMessage += "Title is required.\n";
                isValid = false;
            }

            // Validate txtType (Required)
            if (string.IsNullOrWhiteSpace(txtType.Text))
            {
                errorMessage += "Type is required.\n";
                isValid = false;
            }

            // Validate txtPrice (Numeric)
            if (!decimal.TryParse(txtPrice.Text, out _) || decimal.Parse(txtPrice.Text) < 0)
            {
                errorMessage += "Price must be a valid positive number.\n";
                isValid = false;
            }

            // Validate txtAdvance (Numeric)
            if (!decimal.TryParse(txtAdvance.Text, out _) || decimal.Parse(txtAdvance.Text) < 0)
            {
                errorMessage += "Advance must be a valid positive number.\n";
                isValid = false;
            }

            // Validate txtRoyalty (Numeric)
            if (!decimal.TryParse(txtRoyalty.Text, out _) || decimal.Parse(txtRoyalty.Text) < 0)
            {
                errorMessage += "Royalty must be a valid positive number.\n";
                isValid = false;
            }

            // Validate txtYtdsales (Numeric)
            if (!decimal.TryParse(txtYTDSales.Text, out _) || decimal.Parse(txtYTDSales.Text) < 0)
            {
                errorMessage += "Year-to-date sales must be a valid positive number.\n";
                isValid = false;
            }

            // Validate txtPubdate (Not in the future)
            if (txtPubDate.Value > DateTime.Now)
            {
                errorMessage += "Publication date cannot be in the future.\n";
                isValid = false;
            }

            // Display error messages, if any
            if (!isValid)
            {
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;

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
            txtPubDate.Value = DateTime.Now;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearInputs();
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputs()) // Validate all inputs
            {
                MessageBox.Show("Inputs are valid. Proceeding with save operation.");
                ClearInputs();
                // Save data logic here
            }


            //string query = bookId == null
            //? "INSERT INTO titles (title, type, price, advance, royalty, ytd_Sales, notes, pubdate) VALUES (@title, @type, @price, @advance, @royalty, @ytd_ales, @notes, @pubdate)"
            //"UPDATE titles SET title = @title, type = @type, price = @price, advance = @advance, royalty = @royalty, ytd_Sales = @ytd_Sales, notes = @Notes, pubdate = @pubdate WHERE titles_id = @BookId";

            // using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //SqlCommand cmd = new SqlCommand(query, conn);
            // cmd.Parameters.AddWithValue("@title", txtTitle.Text);
            //cmd.Parameters.AddWithValue("@type", txtType.Text);
            // cmd.Parameters.AddWithValue("@price", decimal.Parse(txtPrice.Text));
            //cmd.Parameters.AddWithValue("@advance", decimal.Parse(txtAdvance.Text));
            // cmd.Parameters.AddWithValue("@royalty", decimal.Parse(txtRoyalty.Text));
            //cmd.Parameters.AddWithValue("@ytd_sales", int.Parse(txtYTDSales.Text));
            // cmd.Parameters.AddWithValue("@notes", txtNotes.Text);
            // cmd.Parameters.AddWithValue("@pubdate", txtPubDate.Value); 


            // if (bookId != null)
            //{
            // cmd.Parameters.AddWithValue("@BookId", bookId);
            //}

            // conn.Open();
            //cmd.ExecuteNonQuery();
            //conn.Close();
            // }

            // this.Close();
        }

        private void frmTitle_Load(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        //public frmTitle(int bookId) : this()
        //{
        //this.bookId = bookId;
        // LoadBookData(bookId);
        // }

        // private void LoadBookData(int bookId)
        // {
        //using (SqlConnection conn = new SqlConnection(connectionString))
        //{
        //SqlCommand cmd = new SqlCommand("SELECT * FROM titles WHERE title_id = @BookId", conn);
        //cmd.Parameters.AddWithValue("@BookId", bookId);
        //conn.Open();

        //SqlDataReader reader = cmd.ExecuteReader();
        //if (reader.Read())
        //{
        //txtTitle.Text = reader["title"].ToString();
        // txtType.Text = reader["type"].ToString();
        // txtPrice.Text = reader["price"].ToString();
        // txtAdvance.Text = reader["advance"].ToString();
        //txtRoyalty.Text = reader["royalty"].ToString();
        //txtYTDSales.Text = reader["ytd_sales"].ToString();
        // txtNotes.Text = reader["notes"].ToString();
        //txtPubDate.Value = Convert.ToDateTime(reader["pubdate"]);
        // }
        //conn.Close();
        //}
        //}
    }
}
    

