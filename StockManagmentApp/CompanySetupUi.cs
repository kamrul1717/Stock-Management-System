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
using StockManagmentApp.Models;

namespace StockManagmentApp
{
    public partial class CompanySetupUi : Form
    {
        Company company = new Company();
        

        private DataTable dataTable;
        public CompanySetupUi()
        {
            InitializeComponent();
            dataTable = company.ShowAllCompany();
            companyShowDataGridView.DataSource = dataTable;
        }
        

        private void CompanySaveButton_Click(object sender, EventArgs e)
        {
            company.Name = companyNameTextBox.Text;


            if (company.Exists())
            {
                MessageBox.Show("Company already exists!");
                return;
            }
            if (company.Name == "")
            {
                MessageBox.Show("Please input a company name.");
            }
            else
            {
                bool isSaved = company.Save();
                if (isSaved)
                {
                    MessageBox.Show("Saved");
                }
                else
                {
                    MessageBox.Show("Not Saved.");
                }

                dataTable = company.ShowAllCompany();
                companyShowDataGridView.DataSource = dataTable;


            }

        }

        

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockManagementAppFrontPageUi stockManagementAppFrontPageUi = new StockManagementAppFrontPageUi();
            stockManagementAppFrontPageUi.Show();
        }
    }
}
