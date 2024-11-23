using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Returning to the Main Menu");

            this.Close();
        }
    }
}
