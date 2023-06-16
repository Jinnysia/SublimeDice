using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SublimeDiceUI
{
    internal static class Program
    {
        static string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        static string appDataFolder = Path.Combine(localAppData, "Sublime Dice");
        static string sessionTokenFilePath = Path.Combine(appDataFolder, "session_token.txt");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Generate app data folder if it doesn't exist
            if (!Directory.Exists(appDataFolder))
            {
                Directory.CreateDirectory(appDataFolder);
            }

            // Check if session token exists and is valid
            if (File.Exists(sessionTokenFilePath))
            {

            }

            Application.Run(new LoginForm());
        }
    }
}
