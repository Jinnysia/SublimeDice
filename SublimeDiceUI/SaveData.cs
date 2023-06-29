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

        public string GenerateNewClientSeed(User user)
        {
            return user.Username + ":" + CryptoSafeRNG.GetCryptographicallySecureRandomString(32, Charset.HexadecimalLowercase);
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

        public string GetClientSeed(User user)
        {
            string clientSeed = null;
            try
            {
                string text = File.ReadAllText(Filepath_ClientSeed);
                if (!string.IsNullOrWhiteSpace(text))
                {
                    clientSeed = text;
                }
            }
            catch (Exception e)
            {
                /*
                ServerResponseHandler.DisplayMessageBox(ServerResponseHandler.GenerateGenericErrorJSONString(e));
                // WARN: Maybe consider making this throw?
                */
                clientSeed = GenerateNewClientSeed(user);
            }

            UpdateClientSeed(clientSeed);
            return clientSeed;
        }

        public bool UpdateClientSeed(string newClientSeed = "")
        {
            try
            {
                CreateAppDataDirectoryIfNotExists();
                File.WriteAllText(Filepath_ClientSeed, newClientSeed);
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
