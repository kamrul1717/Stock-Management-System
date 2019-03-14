using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagmentApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginUi());
            //Application.Run(new StockManagementAppFrontPageUi());
            //Application.Run(new CategorySetupUi());
            //Application.Run(new CompanySetupUi());
            //Application.Run(new ItemSetupUi());
            //Application.Run(new StockInUi());
            //Application.Run(new StockOutUi());
            //Application.Run(new ViewSalesBetweenTwoDatesUi());
        }

    }
}
