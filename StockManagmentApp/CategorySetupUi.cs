using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagmentApp.Models;

namespace StockManagmentApp
{
    public partial class CategorySetupUi : Form
    {
        Category category = new Category();
        private DataTable dataTable;
        private int updateRowIndex ;
        public CategorySetupUi()
        {
            InitializeComponent();
            UpdateButton.Hide();
            dataTable= category.ShowAllCategory();
            categoryShowDataGridView.DataSource = dataTable;
        }

        

        private void CategorySaveButton_Click(object sender, EventArgs e)
        {
            category.Name = categoryNameTextBox.Text;


            if (category.Exists())
            {
                MessageBox.Show("Category already exists!");
                return;
            }
            if (category.Name == "")
            {
                MessageBox.Show("Please input a category name.");
            }
            else
            {
                bool isSaved = category.Save();
                if (isSaved)
                {
                    MessageBox.Show("Saved");
                }
                else
                {
                    MessageBox.Show("Not Saved.");
                }

                dataTable = category.ShowAllCategory();
                categoryShowDataGridView.DataSource = dataTable;
                categoryNameTextBox.Text = "";

            }

        }


        private void categoryShowDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            updateRowIndex = e.RowIndex;
            DataGridViewRow row = categoryShowDataGridView.Rows[updateRowIndex];
            categoryNameTextBox.Text = row.Cells[1].Value.ToString();
  
            CategorySaveButton.Hide();
            UpdateButton.Show();
        }

        private void CategoryUpdateButton_Click(object sender, EventArgs e)
        {

            try
            {
                DataGridViewRow row = categoryShowDataGridView.Rows[updateRowIndex];
                 category.Id = (int)row.Cells[0].Value;
                 category.Name = categoryNameTextBox.Text;


                if (category.Exists())
                {
                    MessageBox.Show("Already Exist");
                    

                }
                else
                {
                    if (category.Update())
                    {
                        MessageBox.Show("updated");
                    }
                    else
                    {
                        MessageBox.Show("Not updated");

                    }

                    UpdateButton.Hide();

                    
                }


                dataTable = category.ShowAllCategory();

                categoryShowDataGridView.DataSource = dataTable;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            categoryNameTextBox.Text = "";
            UpdateButton.Hide();
            CategorySaveButton.Show();
        }


        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockManagementAppFrontPageUi stockManagementAppFrontPageUi = new StockManagementAppFrontPageUi();
            stockManagementAppFrontPageUi.Show();
        }
    }
}
