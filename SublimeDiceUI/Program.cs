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

        public static string Version => FormatProgramVersion(typeof(Program).Assembly.GetName().Version);

        private static string FormatProgramVersion(Version v)
        {
            if (v == null)
            {
                throw new ArgumentNullException(nameof(v));
            }

            if (v.Build == 0 && v.Revision == 0)
            {
                return $"v{v.Major}.{v.Minor}";
            }
            else if (v.Revision == 0)
            {
                return $"v{v.Major}.{v.Minor}.{v.Build}";
            }
            return $"v{v.Major}.{v.Minor}.{v.Build}.{v.Revision}";
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Connection connection = new Connection();

            // Application.Run(new LoginForm(connection));

            // Generate app data folder if it doesn't exist
            // TODO: Save client seed locally
            if (!Directory.Exists(appDataFolder))
            {
                Directory.CreateDirectory(appDataFolder);
            }

            // Check if session token exists and is valid
            if (File.Exists(sessionTokenFilePath))
            {

            }

            // Application.Run(new LoginForm());
        }
    }
}
