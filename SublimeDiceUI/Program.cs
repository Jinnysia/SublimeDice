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
            SaveData saveData = new SaveData();

            // TODO: LOGIN

            // TODO: Check if session token exists and is valid

            // Application.Run(new LoginForm(connection));

            // Application.Run(new LoginForm());

            // TODO: GET/SET CLIENT SEED

            // TODO: RUN GAME FORM

            // TODO: CLEAN UP / SAVE FILES
        }
    }
}
