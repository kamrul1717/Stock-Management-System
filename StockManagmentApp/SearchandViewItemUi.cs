using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagmentApp.Models;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Configuration;

using iTextSharp.text;

using iTextSharp.text.pdf;

using iTextSharp.text.html;

using iTextSharp.text.html.simpleparser;

namespace StockManagmentApp
{
    public partial class SearchandViewItemUi : Form
    {
        Item item = new Item();
        Category category = new Category();
        Company company = new Company();
       
        public SearchandViewItemUi()
        {
            InitializeComponent();

            try
            {

                categoryComboBox.DataSource = CategoryCombo();
                categoryComboBox.SelectedIndex = -1;
                companyComboBox.DataSource = CompanyCombo();
                companyComboBox.SelectedIndex = -1;
               // showDataGridView.DataSource = GridViewLoad();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                //throw;
            }
        }

        private static string connectionString = ConfigurationManager.ConnectionStrings["ProjectDbContext"].ToString();
        private SqlConnection sqlConnection;
        DataTable table = new DataTable();

        private void searchButton_Click(object sender, EventArgs e)
        {
            search();
            categoryComboBox.SelectedIndex = -1;
            companyComboBox.SelectedIndex = -1;
        }

        private DataTable CategoryCombo()
        {
            DataTable dataTable = new DataTable();


            try
            {

                SqlConnection sqlConnection = new SqlConnection(connectionString);



                string query = @"SELECT * FROM Category ";


                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                sqlDataAdapter.Fill(dataTable);

                sqlConnection.Close();



            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }

            return dataTable;

        }

        private DataTable CompanyCombo()
        {
            //company.Name = companyComboBox.SelectedValue.ToString();
            DataTable dataTable = new DataTable();

            try
            {

                SqlConnection sqlConnection = new SqlConnection(connectionString);



                string query = @"SELECT * FROM Company";


                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                sqlDataAdapter.Fill(dataTable);

                sqlConnection.Close();



            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }

            return dataTable;

        }

        private DataTable GridViewLoad()
        {
            DataTable dataTable = new DataTable();

            try
            {

                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //4
                string query = @"SELECT *From ItemView ";

                //5
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                //6
                sqlConnection.Open();
                //7
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                sqlDataAdapter.Fill(dataTable);

                sqlConnection.Close();



            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }

            return dataTable;

        }

        private DataTable search()
        {

            // bool isSuccess = false;
            //category.Name = categoryComboBox.SelectedValue.ToString();
            // company.Name = companyComboBox.SelectedValue.ToString();
            DataTable dataTable = new DataTable();

            try
            {

                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string query = null;

                if (categoryComboBox.Text == "" || companyComboBox.Text == "")
                {
                    query = @"SELECT *FROM ItemView WHERE Category = '" + categoryComboBox.SelectedValue +
                                  "' OR Company = '" + companyComboBox.SelectedValue + "'  ;";

                }

                else if (categoryComboBox.Text != "" && companyComboBox.Text != "")
                {
                    query = @"SELECT *FROM ItemView WHERE Category = '" + categoryComboBox.SelectedValue +
                                  "' AND Company = '" + companyComboBox.SelectedValue + "'  ;";
                }
                //string query = @"SELECT *FROM ItemView WHERE Company = '" + company.Name + "';";
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    showDataGridView.DataSource = dataTable;
                }

                else
                {
                    showDataGridView.DataSource = null;
                }



                sqlConnection.Close();

                //  clear();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                //throw;
            }

            return dataTable;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockManagementAppFrontPageUi frontPageUi = new StockManagementAppFrontPageUi();
            frontPageUi.Show();
        }

        private void pdfButton_Click(object sender, EventArgs e)
        {
             //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(showDataGridView.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 30;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            //Adding Header row
            foreach (DataGridViewColumn column in showDataGridView.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
               
                cell.BackgroundColor = new iTextSharp.text.BaseColor(205, 92, 92);
               
                pdfTable.AddCell(cell);
              
            }

           

            //Adding DataRow
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    foreach (DataGridViewCell cell in row.Cells)
            //    {
            //        pdfTable.AddCell(cell.Value.ToString());
            //    }
            //}
            int row = showDataGridView.Rows.Count;
            int cell2 = showDataGridView.Rows[1].Cells.Count;
            for (int i = 0; i < row - 1; i++)
            {
                for (int j = 0; j < cell2; j++)
                {
                    if (showDataGridView.Rows[i].Cells[j].Value == null)
                    {
                        //return directly
                        //return;
                        //or set a value for the empty data
                        showDataGridView.Rows[i].Cells[j].Value = "null";
                    }
                    pdfTable.AddCell(showDataGridView.Rows[i].Cells[j].Value.ToString());
                }
            }

            //Exporting to PDF
            string folderPath = @"E:\SearchReport\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
           
            using (FileStream stream = new FileStream(folderPath + "DataGridViewExport.pdf", FileMode.Create))
            {
               
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
               // pdfDoc.AddHeader("Header", "Your Search Report");
               
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }
            MessageBox.Show("Done");

           

        
        
        }

        

    }
}
