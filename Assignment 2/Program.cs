using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// App name: Sharp Auto Form
/// Author's name: Navleen Kaur Gill
/// Student ID: 200334989
/// App Creation Date: February 12, 2016
/// App Description: This app determines the total amount due for the purchase of a vehicle based on accessories and options selected
/// and a trade-in value (if any).
/// 
/// </summary>

namespace Assignment_2
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
            Application.Run(new SharpAutoForm());
        }
    }
}
