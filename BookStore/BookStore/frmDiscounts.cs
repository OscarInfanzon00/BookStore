﻿using BookStore.BusinessLogic;
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
using System.Xml.Linq;

namespace BookStore
{
    public partial class frmDiscounts : Form
    {
        public DiscountsBusinessLogic discountsBusinessLogic = new DiscountsBusinessLogic();
        private string objectID;
        private string storeID;

        public frmDiscounts()
        {
            InitializeComponent();
        }

        public frmDiscounts(string objectID, string storeID)
        {
            this.objectID = objectID;
            this.storeID = storeID;
            InitializeComponent();
            LoadEntityData(objectID, storeID);
        }

        public void ClearDiscountsInputs()
        {
            comboBoxType.SelectedIndex = -1;
            txtDiscount.Text = "";
            txtHighQTY.Text = "";
            txtLowQTY.Text = "";
            txtBoxStoreID.Text = "";
        }

        public bool ValidateDiscountsInputs()
        {
            StringBuilder errorMessage = new StringBuilder();
            bool isValid = true;

            if (comboBoxType.SelectedIndex == -1)
            {
                errorMessage.AppendLine("Select a Discount Type.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtDiscount.Text))
            {
                errorMessage.AppendLine("Discount is required.");
                isValid = false;
            }
            else if (!discountsBusinessLogic.IsNumeric(txtDiscount.Text))
            {
                errorMessage.AppendLine("Discount must be a valid number.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtHighQTY.Text))
            {
                errorMessage.AppendLine("High QTY is required.");
                isValid = false;
            }
            else if (!discountsBusinessLogic.IsNumeric(txtHighQTY.Text))
            {
                errorMessage.AppendLine("High QTY must be a valid number.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtLowQTY.Text))
            {
                errorMessage.AppendLine("Low QTY is required.");
                isValid = false;
            }
            else if (!discountsBusinessLogic.IsNumeric(txtLowQTY.Text))
            {
                errorMessage.AppendLine("Low QTY must be a valid number.");
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show(errorMessage.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateDiscountsInputs())
            {
                SaveOrUpdateEntity();
            }
        }

        private void LoadEntityData(string type, string storeID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(discountsBusinessLogic.discountsDataAccess.connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM discounts WHERE discounttype = @Type";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = type;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                comboBoxType.SelectedItem = reader["discounttype"]?.ToString() ?? string.Empty;
                                txtLowQTY.Text = reader["lowqty"]?.ToString() ?? string.Empty;
                                txtHighQTY.Text = reader["highqty"]?.ToString() ?? string.Empty;
                                txtDiscount.Text = reader["discount"]?.ToString() ?? string.Empty;
                                txtBoxStoreID.Text = reader["stor_id"]?.ToString() ?? string.Empty;
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                discountsBusinessLogic.discountsDataAccess.SaveOrUpdateEntity(objectID, comboBoxType, txtLowQTY,txtHighQTY,txtDiscount,txtBoxStoreID);
                ClearDiscountsInputs();
                this.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            ClearDiscountsInputs();
            this.Close();
        }

        private void frmDiscounts_Load(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearDiscountsInputs();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
