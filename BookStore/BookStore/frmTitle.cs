using BookStore.Business;
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
        public TitleBusinessLogic titleBusinessLogic = new TitleBusinessLogic();
        private string objectID;

        public frmTitle()
        {
            InitializeComponent();
            loadPub_IdList();
        }

        public frmTitle(string objectID)
        {
            this.objectID = objectID;
            InitializeComponent();
            loadPub_IdList();
            LoadEntityData(objectID);
        }

        private void loadPub_IdList()
        {
            comboBoxPubInfo = titleBusinessLogic.titleDataAccess.loadPub_IdList(comboBoxPubInfo);
        }

        public bool ValidateInputs()
        {
            StringBuilder errorMessage = new StringBuilder();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                errorMessage.AppendLine("Title is required.");
                isValid = false;
            }

            if (txtTitle.Text.Length>80)
            {
                errorMessage.AppendLine("Title exceeds the 80 characters, please fix.");
                isValid = false;
            }

            if (txtNotes.Text.Length > 200)
            {
                errorMessage.AppendLine("Notes exceeds the 200 characters, please fix.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtType.Text))
            {
                errorMessage.AppendLine("Type is required.");
                isValid = false;
            }

            isValid &= titleBusinessLogic.ValidateNumericField(txtPrice.Text, "Price", errorMessage);
            isValid &= titleBusinessLogic.ValidateNumericField(txtAdvance.Text, "Advance", errorMessage);
            isValid &= titleBusinessLogic.ValidateNumericField(txtRoyalty.Text, "Royalty", errorMessage);
            isValid &= titleBusinessLogic.ValidateNumericField(txtYTDSales.Text, "Year-to-date sales", errorMessage);

            if (txtPubDate.Value.Date > DateTime.Today)
            {
                errorMessage.AppendLine("Publication date cannot be in the future.");
                isValid = false;
            }

            if (comboBoxPubInfo.SelectedIndex == -1)
            {
                errorMessage.AppendLine("Publication Info is missing.");
                isValid = false;
            }

            if (!isValid)
            {
                errorMessage.AppendLine("Please fix the listed entries and resubmit.");
                MessageBox.Show(errorMessage.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            comboBoxPubInfo.SelectedIndex = -1;
            txtPubDate.Value = DateTime.Now;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearInputs();
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                SaveOrUpdateEntity();
            }
        }

        private void frmTitle_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(objectID))
            {
                LoadEntityData(objectID);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void LoadEntityData(string id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(titleBusinessLogic.titleDataAccess.connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM titles WHERE title_id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtTitle.Text = reader["title"].ToString();
                                txtType.Text = reader["type"].ToString();
                                txtPrice.Text = reader["price"].ToString();
                                txtAdvance.Text = reader["advance"].ToString();
                                txtRoyalty.Text = reader["royalty"].ToString();
                                txtYTDSales.Text = reader["ytd_Sales"].ToString();
                                txtNotes.Text = reader["notes"].ToString();
                                txtPubDate.Value = Convert.ToDateTime(reader["pubdate"]);
                                comboBoxPubInfo.SelectedItem = reader["pub_id"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveOrUpdateEntity()
        {
            try
            {
                titleBusinessLogic.titleDataAccess.SaveOrUpdateEntity(objectID, txtTitle, txtType, txtPrice, txtAdvance, txtRoyalty, txtYTDSales, txtNotes, txtPubDate, comboBoxPubInfo);
                ClearInputs();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
