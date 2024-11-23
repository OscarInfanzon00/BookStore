using System;
using System.Collections;
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
    public partial class frmMainMenu : Form
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\oscar\\Downloads\\BookStore.MDF;Integrated Security=True;Connect Timeout=30";

        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM employee", connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            DataRow firstRow = dataTable.Rows[0];

                            var employeeName = firstRow["fname"].ToString();
                            var employeeMiddleName = firstRow["minit"].ToString();
                            var employeeLastName = firstRow["lname"].ToString();
                            var employeeLvl = firstRow["job_lvl"].ToString();
                            var employeeHiringDate = firstRow["hire_date"].ToString();

                            labelUsername.Text = "Username: " + employeeName + " " + employeeMiddleName + ". " + employeeLastName;
                            labelLvl.Text = "Job level: " + employeeLvl;
                            labelUserHiringDate.Text = employeeHiringDate.ToString();
                        }
                        else
                        {
                            MessageBox.Show("No data found in the table.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadDataInTable(object sender, EventArgs e)
        {
            int type = comboBoxTable.SelectedIndex;

            string query = string.Empty;

            switch (type)
            {
                case 0:
                    query = "SELECT * FROM authors";
                    break;
                case 1:
                    query = "SELECT * FROM publishers";
                    break;
                case 2:
                    query = "SELECT * FROM titles";
                    break;
                case 3:
                    query = "SELECT * FROM stores";
                    break;
                case 4:
                    query = "SELECT * FROM employee";
                    break;
                case 5:
                    query = "SELECT * FROM discounts";
                    break;
                default:
                    MessageBox.Show("Invalid type selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        FillTable(dataGridViewTable, dataTable);
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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainMenu));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publisherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.titleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxUser = new System.Windows.Forms.GroupBox();
            this.labelUserHiringDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelLvl = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.dataGridViewTable = new System.Windows.Forms.DataGridView();
            this.comboBoxTable = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonNewOrder = new System.Windows.Forms.Button();
            this.buttonReports = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.groupBoxUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.addToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1307, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDBToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openDBToolStripMenuItem
            // 
            this.openDBToolStripMenuItem.Name = "openDBToolStripMenuItem";
            this.openDBToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.openDBToolStripMenuItem.Text = "Open DB";
            this.openDBToolStripMenuItem.Click += new System.EventHandler(this.openDBToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.authorToolStripMenuItem,
            this.publisherToolStripMenuItem,
            this.titleToolStripMenuItem,
            this.storesToolStripMenuItem,
            this.employeeToolStripMenuItem,
            this.discountToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // authorToolStripMenuItem
            // 
            this.authorToolStripMenuItem.Name = "authorToolStripMenuItem";
            this.authorToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.authorToolStripMenuItem.Text = "Author";
            // 
            // publisherToolStripMenuItem
            // 
            this.publisherToolStripMenuItem.Name = "publisherToolStripMenuItem";
            this.publisherToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.publisherToolStripMenuItem.Text = "Publisher";
            // 
            // titleToolStripMenuItem
            // 
            this.titleToolStripMenuItem.Name = "titleToolStripMenuItem";
            this.titleToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.titleToolStripMenuItem.Text = "Title";
            // 
            // storesToolStripMenuItem
            // 
            this.storesToolStripMenuItem.Name = "storesToolStripMenuItem";
            this.storesToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.storesToolStripMenuItem.Text = "Stores";
            // 
            // employeeToolStripMenuItem
            // 
            this.employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            this.employeeToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.employeeToolStripMenuItem.Text = "Employee";
            // 
            // discountToolStripMenuItem
            // 
            this.discountToolStripMenuItem.Name = "discountToolStripMenuItem";
            this.discountToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.discountToolStripMenuItem.Text = "Discount";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // groupBoxUser
            // 
            this.groupBoxUser.Controls.Add(this.labelUserHiringDate);
            this.groupBoxUser.Controls.Add(this.label3);
            this.groupBoxUser.Controls.Add(this.labelLvl);
            this.groupBoxUser.Controls.Add(this.labelUsername);
            this.groupBoxUser.Location = new System.Drawing.Point(868, 55);
            this.groupBoxUser.Name = "groupBoxUser";
            this.groupBoxUser.Size = new System.Drawing.Size(412, 165);
            this.groupBoxUser.TabIndex = 1;
            this.groupBoxUser.TabStop = false;
            this.groupBoxUser.Text = "User Logged In";
            // 
            // labelUserHiringDate
            // 
            this.labelUserHiringDate.AutoSize = true;
            this.labelUserHiringDate.Location = new System.Drawing.Point(17, 126);
            this.labelUserHiringDate.Name = "labelUserHiringDate";
            this.labelUserHiringDate.Size = new System.Drawing.Size(71, 16);
            this.labelUserHiringDate.TabIndex = 3;
            this.labelUserHiringDate.Text = "00/00/0000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Working with us since:";
            // 
            // labelLvl
            // 
            this.labelLvl.AutoSize = true;
            this.labelLvl.Location = new System.Drawing.Point(17, 63);
            this.labelLvl.Name = "labelLvl";
            this.labelLvl.Size = new System.Drawing.Size(27, 16);
            this.labelLvl.TabIndex = 1;
            this.labelLvl.Text = "Lvl:";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(17, 33);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(76, 16);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "User Name";
            // 
            // dataGridViewTable
            // 
            this.dataGridViewTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridViewTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridViewTable.Location = new System.Drawing.Point(27, 256);
            this.dataGridViewTable.Name = "dataGridViewTable";
            this.dataGridViewTable.RowHeadersWidth = 51;
            this.dataGridViewTable.RowTemplate.Height = 24;
            this.dataGridViewTable.Size = new System.Drawing.Size(1253, 433);
            this.dataGridViewTable.TabIndex = 2;
            // 
            // comboBoxTable
            // 
            this.comboBoxTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTable.FormattingEnabled = true;
            this.comboBoxTable.Items.AddRange(new object[] {
            "Author",
            "Publisher",
            "Title",
            "Stores",
            "Employee",
            "Discount"});
            this.comboBoxTable.Location = new System.Drawing.Point(27, 211);
            this.comboBoxTable.Name = "comboBoxTable";
            this.comboBoxTable.Size = new System.Drawing.Size(173, 24);
            this.comboBoxTable.TabIndex = 3;
            this.comboBoxTable.SelectedIndexChanged += new System.EventHandler(this.LoadDataInTable);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Select a table";
            // 
            // buttonNewOrder
            // 
            this.buttonNewOrder.Location = new System.Drawing.Point(434, 712);
            this.buttonNewOrder.Name = "buttonNewOrder";
            this.buttonNewOrder.Size = new System.Drawing.Size(209, 52);
            this.buttonNewOrder.TabIndex = 5;
            this.buttonNewOrder.Text = "New Order";
            this.buttonNewOrder.UseVisualStyleBackColor = true;
            // 
            // buttonReports
            // 
            this.buttonReports.Location = new System.Drawing.Point(703, 712);
            this.buttonReports.Name = "buttonReports";
            this.buttonReports.Size = new System.Drawing.Size(209, 52);
            this.buttonReports.TabIndex = 6;
            this.buttonReports.Text = "Reports";
            this.buttonReports.UseVisualStyleBackColor = true;
            this.buttonReports.Click += new System.EventHandler(this.buttonReports_Click);
            // 
            // MainMenu
            // 
            this.ClientSize = new System.Drawing.Size(1307, 788);
            this.Controls.Add(this.buttonReports);
            this.Controls.Add(this.buttonNewOrder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxTable);
            this.Controls.Add(this.dataGridViewTable);
            this.Controls.Add(this.groupBoxUser);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.MainMenu_Load_1);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBoxUser.ResumeLayout(false);
            this.groupBoxUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void openDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMenu_Load(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonReports_Click(object sender, EventArgs e)
        {
            frmSalesReport salesReport = new frmSalesReport();
            salesReport.Show();
        }

        private void MainMenu_Load_1(object sender, EventArgs e)
        {

        }
    }
}
