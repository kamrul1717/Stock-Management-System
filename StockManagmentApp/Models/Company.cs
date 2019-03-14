using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagmentApp.Models
{
    class Company
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["ProjectDbContext"].ToString();
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Save()
        {
            bool isSuccess = false;

            try
            {

                SqlConnection sqlConnection = new SqlConnection(connectionString);

                string query = @"INSERT INTO Company(Name)VALUES('" + Name + "')";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();


                int isExecuted = sqlCommand.ExecuteNonQuery();



                if (isExecuted > 0)
                {

                    isSuccess = true;
                }

                sqlConnection.Close();

            }

            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

            return isSuccess;
        }

        public bool Exists()
        {
            bool isExists = false;

            try
            {

                SqlConnection sqlConnection = new SqlConnection(connectionString);

                string query = @"SELECT *FROM Company WHERE Name = '" + Name + "';";
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);



                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                string data = "";
                if (sqlDataReader.Read())
                {
                    data = sqlDataReader["Id"].ToString();
                }

                if (!string.IsNullOrEmpty(data))
                {
                    isExists = true;
                }

                sqlConnection.Close();


            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

            return isExists;
        }

        public DataTable ShowAllCompany()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = @"Select * from Company;";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;

        }
    }
}
