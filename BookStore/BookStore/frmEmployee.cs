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
    public partial class frmEmployee : Form
    {

        string FirstName;
        string MiddleName;
        string LastName;

        public frmEmployee()
        {
            InitializeComponent();
        }

        private void CheckValues()
        {
          // Bellow 3 lines pull values of text boxes and puts them into strings

          FirstName = txtFirstName.Text;
          MiddleName = txtMiddleName.Text;
          LastName = txtLastName.Text;


         // checks if any of the three name entries contain a string 
          bool FisNumber = FirstName.Any(char.IsDigit);
          bool MisNumber = MiddleName.Any(char.IsDigit);
          bool LisNumber = LastName.Any(char.IsDigit);

            // checks if any of the above tests returned true or if any of the name text boxes are blank


            if (FisNumber == true || txtFirstName.Text == "")
            {
                MessageBox.Show("Enter a valid Name into the First Name Text Box");
            }
            else
            {
                MessageBox.Show("Passed Test1");
            }
            
            if (MisNumber == true || txtMiddleName.Text == "")
            {
                MessageBox.Show("Enter a valid Name into the Middle Name Text Box");
            }
            else
            {
                MessageBox.Show("Passed Test2");
            }

            if (LisNumber == true || txtLastName.Text == "")
            {
                MessageBox.Show("Enter a valid Name into the Last Name Text Box");
            }
            else
            {
                MessageBox.Show("Passed Test3");
            }

        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CheckValues();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {

        }
    }
}
