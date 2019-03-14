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
    public partial class StockOutUi : Form
    {
        public StockOutUi()
        {
            InitializeComponent();
            CompanyComboBox.DataSource = CompanyComboBoxLoad();
        }
        private static string connectionString = ConfigurationManager.ConnectionStrings["ProjectDbContext"].ToString();
        private SqlConnection sqlConnection;
        DataTable table = new DataTable();
        private int index;

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                string itemName = ItemComboBox.Text;
                int itemId = (int)ItemComboBox.SelectedValue;
                string companyName = CompanyComboBox.Text;
                int companyId = (int) CompanyComboBox.SelectedValue;   
                int quantity = Convert.ToInt32(stockOutQuantityTextBox.Text);

                table.Rows.Add(itemName, itemId, companyName, companyId, quantity);

                stockOutDataGridView.DataSource = table;
                this.stockOutDataGridView.Columns[1].Visible = false;
                this.stockOutDataGridView.Columns[3].Visible = false;
                stockOutQuantityTextBox.Clear();
                

            }
            catch (Exception exception)
            {
                MessageBox.Show("Fill all the data!");
            }

        }

        private void SellButton_Click(object sender, EventArgs e)
        {
            try
            {
                int tableRows = table.Rows.Count;
                if (tableRows == 0)
                {
                    MessageBox.Show("Please add data to gridView");
                }
                else
                {
                    string type = "Sell";
                    UpdateStockInAndStockOutTable(tableRows, type);
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);

            }
        }

        private void DamageButton_Click(object sender, EventArgs e)
        {
            try
            {
                int tableRows = table.Rows.Count;
                if (tableRows == 0)
                {
                    MessageBox.Show("Please add data to gridView");
                }
                else
                {
                    string type = "Damage";
                    UpdateStockInAndStockOutTable(tableRows, type);
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);

            }

        }

        private void LostButton_Click(object sender, EventArgs e)
        {
            try
            {
                int tableRows = table.Rows.Count;
                if (tableRows == 0)
                {
                    MessageBox.Show("Please add data to gridView");
                }
                else
                {
                    string type = "Lost";
                    UpdateStockInAndStockOutTable(tableRows, type);
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);

            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            table.Rows[index].Delete();
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
            string query = @"Select Id,ItemName from Item where Company = " + companyId + ";";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }

        private void SetReorderLevelAndAvailableQuantity(int companyId, int itemId)
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
                availableQuantityTextBox.Text = data;
            }
            sqlConnection.Close();

        }

        private void CompanyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int companyId = Convert.ToInt32(CompanyComboBox.SelectedValue);
            ItemComboBox.Text = "";
            reorderLevelTextBox.Text = "";
            availableQuantityTextBox.Text = "";
            ItemComboBox.DataSource = ItemComboBoxLoad(companyId);
        }

        private void ItemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int companyId = Convert.ToInt32(CompanyComboBox.SelectedValue);
            int itemId = Convert.ToInt32(ItemComboBox.SelectedValue);
            SetReorderLevelAndAvailableQuantity(companyId,itemId);
        }

        private void StockOut_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Item Name",typeof(string));
            table.Columns.Add("Item Id", typeof (int));
            table.Columns.Add("Company", typeof (string));
            table.Columns.Add("Company Id", typeof(int));
            table.Columns.Add("Quantity", typeof (int));

            stockOutDataGridView.DataSource = table;
            this.stockOutDataGridView.Columns[1].Visible = false;
            this.stockOutDataGridView.Columns[3].Visible = false;
        }

        

        private void UpdateStockInAndStockOutTable(int tableRows,string type)
        {
            int i;
            for (i = 0; i < tableRows;i++ )
            {
                int itemId = (int)table.Rows[i][1];
                int companyId = (int)table.Rows[i][3];
                int stockOutQuantity = (int)table.Rows[i][4];
                DateTime date = DateTime.Now;
                
                bool isUpdated = UpdateAvailableQuantity(companyId, itemId, stockOutQuantity);
                if (isUpdated)
                {
                    bool isSaved = InsertIntoStockOut(itemId, companyId, stockOutQuantity, type, date);
                }
                else
                {
                    string itemName = (string) table.Rows[i][0];
                    string companyName = (string) table.Rows[i][2];
                    string message = itemName + " item Under " + companyName + " company cant stock Out " +
                                     stockOutQuantity + " item";
                    MessageBox.Show(message);
                    break;
                }
                
            }
            if (i == tableRows)
            {
                MessageBox.Show("Success");
                ItemComboBox.Text = "";
                reorderLevelTextBox.Text = "";
                availableQuantityTextBox.Text = "";
                table.Clear();
            }
            else
            {
                MessageBox.Show("Not Success");
                ItemComboBox.Text = "";
                reorderLevelTextBox.Text = "";
                availableQuantityTextBox.Text = "";
                table.Clear();
                
            }
        }

        private bool InsertIntoStockOut(int itemId,int companyId,int stockOutQuantity,string type,DateTime date)
        {
            bool chk = false;
            try
            {
                string query = @"INSERT INTO StockOuts (ItemId,CompanyId,Quantity,StockOutType,Date) VALUES (" + itemId +
                               "," + companyId + "," + stockOutQuantity + ",'" + type + "','" + date + "');";
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query,sqlConnection);
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    chk = true;
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            return chk;
        }

        private bool UpdateAvailableQuantity(int companyId, int itemId, int stockOut)
        {
            bool chk = false;
            int previousQuantity = GetPreviousQuantity(companyId, itemId);
            sqlConnection = new SqlConnection(connectionString);
            stockOut = previousQuantity - stockOut;
            if (stockOut >= 0)
            {
                string query = @"Update Item Set AvailableQuantity = " + stockOut + " where Company = " + companyId +
                               " and Id =" + itemId;
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                int isUpdate = sqlCommand.ExecuteNonQuery();
                if (isUpdate > 0)
                {
                    chk = true;
                }
                
            }
            return chk;
        }



        private int GetPreviousQuantity(int companyId, int itemId)
        {
            int previousQuantity=0;
            sqlConnection = new SqlConnection(connectionString);
            string query = @"select AvailableQuantity from Item where Company = " + companyId + " and Id = " + itemId;
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            string data = "";
            if (sqlDataReader.Read())
            {
                data = sqlDataReader["AvailableQuantity"].ToString();
                previousQuantity = Convert.ToInt32(data);
                availableQuantityTextBox.Text = data;
            }
            sqlConnection.Close();
            return previousQuantity;

        }

        

        
        private void stockOutDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = stockOutDataGridView.SelectedCells[0].RowIndex;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockManagementAppFrontPageUi frontPageUi = new StockManagementAppFrontPageUi();
            frontPageUi.Show();
        }
        

    }
}
