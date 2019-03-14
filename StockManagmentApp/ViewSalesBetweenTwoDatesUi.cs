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
    public partial class ViewSalesBetweenTwoDatesUi : Form
    {
        public ViewSalesBetweenTwoDatesUi()
        {
            InitializeComponent();
        }
        private static string connectionString = ConfigurationManager.ConnectionStrings["ProjectDbContext"].ToString();
        private SqlConnection sqlConnection;

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string fromDate = fromDateTimePicker.Value.ToString("yyyy/MM/dd");
            string toDate = toDateTimePicker.Value.ToString("yyyy/MM/dd");
            sqlConnection = new SqlConnection(connectionString);
            string query = @"select ItemName,CompanyName,SUM(Quantity) as Quantity 
                             from 
                                (SELECT Date,ItemName,CompanyName,Quantity, StockOutType FROM SalesView 
                                    where StockOutType = 'Sell' and Date >= '"+fromDate+"' and Date <= '"+toDate+"') as t GROUP BY ItemName,CompanyName";

            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query,sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            showSalesDataGridView.DataSource = dataTable;

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockManagementAppFrontPageUi frontPageUi = new StockManagementAppFrontPageUi();
            frontPageUi.Show();
        }

        private void pdfButton_Click(object sender, EventArgs e)
        {
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(showSalesDataGridView.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 30;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            //Adding Header row
            foreach (DataGridViewColumn column in showSalesDataGridView.Columns)
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
            int row = showSalesDataGridView.Rows.Count;
            int cell2 = showSalesDataGridView.Rows[1].Cells.Count;
            for (int i = 0; i < row - 1; i++)
            {
                for (int j = 0; j < cell2; j++)
                {
                    if (showSalesDataGridView.Rows[i].Cells[j].Value == null)
                    {
                        //return directly
                        //return;
                        //or set a value for the empty data
                        showSalesDataGridView.Rows[i].Cells[j].Value = "null";
                    }
                    pdfTable.AddCell(showSalesDataGridView.Rows[i].Cells[j].Value.ToString());
                }
            }

            //Exporting to PDF
            string folderPath = @"E:\SalesReport\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            using (FileStream stream = new FileStream(folderPath + "DataGridViewExport.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);

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
