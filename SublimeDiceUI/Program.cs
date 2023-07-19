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
            
            SaveData saveData = new SaveData();
            Connection connection = new Connection("sublimedice.com", true, saveData);

            if (saveData.SessionTokenFileExists())
            {
                string sessionToken = "";
                if (saveData.GetSessionToken(out sessionToken))
                {
                    string username = saveData.GetUsernameFromSessionToken(sessionToken);
                    if (!string.IsNullOrWhiteSpace(username))
                    {
                        Tuple<string, int> responseTuple = await connection.Login(username, AuthenticationType.SessionToken, sessionToken, true);
                        string response = responseTuple.Item1;
                        ResponseStatus responseStatus = ServerResponseHandler.DisplayMessageBox(response);
                        if (responseStatus == ResponseStatus.OK)
                        {
                            // Logged in!
                        }
                        else
                        {
                            // Session token expired or was invalid, remove it
                            saveData.UpdateSessionToken();
                        }
                    }
                }
                else
                {
                    // Session token file was invalid or unable to be read
                    saveData.UpdateSessionToken();
                }
            }

            if (!connection.IsLoggedIn)
            {
                Application.Run(new LoginForm(connection));
            }

            if (connection.IsLoggedIn)
            {
                // Get client seed
                if (saveData.ClientSeedFileExists())
                {
                    string clientSeed = saveData.GetClientSeedFromFile(connection.LoggedInUser.Username);
                    if (string.IsNullOrWhiteSpace(clientSeed))
                    {
                        saveData.UpdateClientSeedToFile(saveData.GenerateNewClientSeed(connection.LoggedInUser.Username));
                    }
                    else
                    {
                        
                    }
                }

                Application.Run(new GameForm(connection));
            }

            // TODO: CLEAN UP / SAVE FILES
        }
    }
}
