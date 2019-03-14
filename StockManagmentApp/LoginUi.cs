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
    public partial class LoginUi : Form
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["ProjectDbContext"].ToString();
        public LoginUi()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            bool isSuccess = CheckLogin(usernameTextBox.Text, passwordTextBox.Text);
            if (isSuccess)
            {
                this.Hide();
                StockManagementAppFrontPageUi stockManagementAppFrontPageUi = new StockManagementAppFrontPageUi();
                stockManagementAppFrontPageUi.Show();
            }
            else
            {
                MessageBox.Show("Username and Password doesn't match!");
            }
        }


        public bool CheckLogin(string userName, string password)
        {
            bool isSuccess = false;
            int i = 0;
            try
            {

                SqlConnection sqlConnection = new SqlConnection(connectionString);

                string query = @"SELECT * FROM users WHERE username='"+userName+"' AND password='"+password+"'";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    isSuccess = false;
                }
                else
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

    }
}
