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
    public partial class ItemSetupUi : Form
    {
        
        Item item = new Item();
        
        public ItemSetupUi()
        {
            InitializeComponent();
            reOrderLevelTextBox.Text = "0";
            categoryComboBox.DataSource = item.CategoryComboBoxLoad();
            companyComboBox.DataSource = item.CompanyComboBoxLoad();
            itemDataGridView.DataSource = item.ItemLoad();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            item.Category = Convert.ToInt16(categoryComboBox.SelectedValue);
            item.Company = Convert.ToInt16(companyComboBox.SelectedValue);
            item.ItemName = itemNameTextBox.Text;
            item.ReorderLevel = Convert.ToInt32(reOrderLevelTextBox.Text);

            try
            {
                if (item.Exists())
                {
                    MessageBox.Show("Item already exists!");
                    return;
                }
                if (item.ItemName == "")
                {
                    MessageBox.Show("Please input a item name.");
                }
                else
                {
                    bool isSaved = item.Save();
                    if (isSaved)
                    {
                        MessageBox.Show("Saved");
                    }
                    else
                    {
                        MessageBox.Show("Not Saved.");
                    }

                    
                    itemDataGridView.DataSource = item.ItemLoad() ;

                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
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
