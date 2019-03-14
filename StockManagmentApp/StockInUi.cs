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

namespace StockManagmentApp
{
    public partial class StockInUi : Form
    {
        public StockInUi()
        {
            InitializeComponent();
            CompanyComboBox.DataSource = CompanyComboBoxLoad();
            CompanyComboBox.SelectedIndex = -1;
        }
        private static string connectionString = ConfigurationManager.ConnectionStrings["ProjectDbContext"].ToString();
        private SqlConnection sqlConnection;
        private int previousQuantity;

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int companyId = Convert.ToInt32(CompanyComboBox.SelectedValue);
                int itemId = Convert.ToInt32(ItemComboBox.SelectedValue);
                int stockIn = Convert.ToInt32(stockInTextBox.Text);

                bool isUpdate = UpdateAvailableQuantity(companyId, itemId, stockIn);
                if (isUpdate)
                {
                    MessageBox.Show("Saved");
                    stockInTextBox.Text = "";
                    int companyId1 = Convert.ToInt32(CompanyComboBox.SelectedValue);
                    int itemId1 = Convert.ToInt32(ItemComboBox.SelectedValue);
                    SetReorderLevelAndAvailableQuantity(companyId1, itemId1); 
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }


        }

        private bool UpdateAvailableQuantity(int companyId, int itemId, int stockIn)
        {
            bool chk = false;
            sqlConnection = new SqlConnection(connectionString);
            stockIn = previousQuantity + stockIn;
            string query = @"Update Item Set AvailableQuantity = "+stockIn+" where Company = "+companyId+" and Id ="+itemId;
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            int isUpdate = sqlCommand.ExecuteNonQuery();
            if (isUpdate > 0)
            {
                chk = true;           
            }
            return chk;
        }
        private DataTable CompanyComboBoxLoad()
        {
            sqlConnection = new SqlConnection(connectionString);
            string query = @"Select * from Company;";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }
        private DataTable ItemComboBoxLoad(int companyId)
        {
            sqlConnection = new SqlConnection(connectionString);
            string query = @"Select Id,ItemName from Item where Company = "+companyId+";";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }

        private void SetReorderLevelAndAvailableQuantity(int companyId,int itemId)
        {
            sqlConnection = new SqlConnection(connectionString);
            string query = @"select ReorderLevel,AvailableQuantity from Item where Company = " + companyId + " and Id = " + itemId;
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            string data = "";
            if (sqlDataReader.Read())
            {
                data = sqlDataReader["ReorderLevel"].ToString();
                reorderLevelTextBox.Text = data;
                data = sqlDataReader["AvailableQuantity"].ToString();
                previousQuantity = Convert.ToInt32(data);
                availableQuantityTextBox.Text = data;
            }
            sqlConnection.Close();
            
        }

        private void CompanyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int companyId = Convert.ToInt32(CompanyComboBox.SelectedValue);
            ItemComboBox.DataSource = ItemComboBoxLoad(companyId);
            ItemComboBox.SelectedIndex = -1;
        }

        private void ItemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int companyId = Convert.ToInt32(CompanyComboBox.SelectedValue);
            int itemId = Convert.ToInt32(ItemComboBox.SelectedValue);
            if (CompanyComboBox.SelectedIndex == -1 || ItemComboBox.SelectedIndex == -1)
            {
                availableQuantityTextBox.Text = "";
                reorderLevelTextBox.Text = "";

            }
            else
            {
                SetReorderLevelAndAvailableQuantity(companyId, itemId);
                
            }
                    

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockManagementAppFrontPageUi frontPageUi = new StockManagementAppFrontPageUi();
            frontPageUi.Show();
        }
    }
}
