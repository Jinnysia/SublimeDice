using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SublimeDiceUI
{
    public class SaveData
    {
        private static string directoryLocalAppData => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private static string Directory_AppDataFolder => Path.Combine(directoryLocalAppData, "Sublime Dice");
        public static string Filepath_SessionToken => Path.Combine(Directory_AppDataFolder, "session_token.txt");
        public static string Filepath_ClientSeed => Path.Combine(Directory_AppDataFolder, "client_seed.txt");

        public string CurrentClientSeed { get; set; }

        public SaveData()
        {
            CreateAppDataDirectoryIfNotExists();
        }

        private void CreateAppDataDirectoryIfNotExists()
        {
            if (!Directory.Exists(Directory_AppDataFolder))
            {
                Directory.CreateDirectory(Directory_AppDataFolder);
            }
        }

        public bool SessionTokenFileExists()
        {
            return File.Exists(Filepath_SessionToken);
        }

        public bool ClientSeedFileExists()
        {
            return File.Exists(Filepath_ClientSeed);
        }

        public string GenerateNewClientSeed(string username)
        {
            return username + ":" + CryptoSafeRNG.GetCryptographicallySecureRandomString(32, Charset.HexadecimalLowercase);
        }

        public bool GetSessionToken(out string sessionToken)
        {
            sessionToken = null;
            if (SessionTokenFileExists())
            {
                try
                {
                    string text = File.ReadAllText(Filepath_SessionToken);
                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        sessionToken = text;
                        return true;
                    }
                }
                catch (Exception e)
                {
                    ServerResponseHandler.DisplayMessageBox(ServerResponseHandler.GenerateGenericErrorJSONString(e));
                    // WARN: Maybe consider making this throw?
                }
            }

            return false;
        }

        public string GetUsernameFromSessionToken(string sessionToken)
        {
            string result = "";
            if (string.IsNullOrWhiteSpace(sessionToken))
            {
                result = "";
            }
            else if (sessionToken.Split('|').Length < 2)
            {
                result = "";
            }
            else
            {
                result = Encoding.UTF8.GetString(Convert.FromBase64String(sessionToken.Split('|')[0]));
            }

            return result;
        }

        public bool UpdateSessionToken(string newSessionToken = "")
        {
            try
            {
                CreateAppDataDirectoryIfNotExists();
                File.WriteAllText(Filepath_SessionToken, newSessionToken);
                return true;
            }
            catch (Exception e)
            {
                ServerResponseHandler.DisplayMessageBox(ServerResponseHandler.GenerateGenericErrorJSONString(e));
                // WARN: Maybe consider making this throw?
            }

            return false;
        }

        public string GetClientSeedFromFile(string username)
        {
            string clientSeed = null;
            try
            {
                string text = File.ReadAllText(Filepath_ClientSeed);
                if (!string.IsNullOrWhiteSpace(text))
                {
                    clientSeed = text;
                    CurrentClientSeed = text;
                }
            }
            catch (Exception e)
            {
                /*
                ServerResponseHandler.DisplayMessageBox(ServerResponseHandler.GenerateGenericErrorJSONString(e));
                // WARN: Maybe consider making this throw?
                */
                clientSeed = GenerateNewClientSeed(username);
            }

            UpdateClientSeedToFile(clientSeed);
            return clientSeed;
        }

        public bool UpdateClientSeedToFile(string newClientSeed = "")
        {
            try
            {
                CreateAppDataDirectoryIfNotExists();
                if (newClientSeed.Length == 0)
                {
                    throw new Exception("Client seed cannot be blank.");
                }
                File.WriteAllText(Filepath_ClientSeed, newClientSeed);
                CurrentClientSeed = newClientSeed;
                return true;
            }
            catch (Exception e)
            {
                ServerResponseHandler.DisplayMessageBox(ServerResponseHandler.GenerateGenericErrorJSONString(e));
                // WARN: Maybe consider making this throw?
            }

            return false;
        }
    }
}
