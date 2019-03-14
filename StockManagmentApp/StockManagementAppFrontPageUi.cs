using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagmentApp
{
    public partial class StockManagementAppFrontPageUi : Form
    {
        public StockManagementAppFrontPageUi()
        {
            InitializeComponent();
        }

        private void CategorySetupButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            CategorySetupUi categorySetupUi = new CategorySetupUi();
            categorySetupUi.Show();
        }

        private void CompanySetupButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            CompanySetupUi companySetupUi = new CompanySetupUi();
            companySetupUi.Show();

        }

        private void ItemSetupButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemSetupUi itemSetupUi = new ItemSetupUi();
            itemSetupUi.Show();
        }

        private void StockInButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockInUi stockInUi = new StockInUi();
            stockInUi.Show();

        }

        private void StockOutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockOutUi stockOutUi = new StockOutUi();
            stockOutUi.Show();
        }

        private void ViewSalesButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewSalesBetweenTwoDatesUi viewSalesBetweenTwoDatesUi = new ViewSalesBetweenTwoDatesUi();
            viewSalesBetweenTwoDatesUi.Show( );
        }

        private void SearchViewSummaryButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SearchandViewItemUi searchAndViewItemUi = new SearchandViewItemUi();
            searchAndViewItemUi.Show();
        }

        
    }
}
