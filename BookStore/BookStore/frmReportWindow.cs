using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class frmReportWindow : Form
    {
        public frmReportWindow()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public frmReportWindow(DataTable saleDetails, decimal subtotal, decimal tax, decimal total)
        {
            InitializeComponent();

            dataGridViewOrder.DataSource = saleDetails;

            lblSubtotal.Text = $"Subtotal: ${subtotal:F2}";
            lblTax.Text = $"Tax: ${tax:F2}";
            lblTotal.Text = $"Total: ${total:F2}";
        }

        private void lblSubtotal_Click(object sender, EventArgs e)
        {

        }

        private void lblTax_Click(object sender, EventArgs e)
        {

        }
    }
}
