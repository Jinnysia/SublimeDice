﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.Http.Headers;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SublimeDiceUI
{
    public class Connection
    {
        public User LoggedInUser { get; private set; }
        public SaveData SavedData { get; private set; }

        public bool IsLoggedIn { get; private set; }

        public DateTime CachedFaucetWaitTimer { get; private set; }

        private string _connectionDomain;
        private bool _isSecure;

        private const string URL_Login = "login.php";
        private const string URL_Register = "register.php";
        private const string URL_Logout = "logout.php";
        private const string URL_Faucet = "faucet.php";
        private const string URL_Roll = "roll.php";

        public Connection(SaveData savedData)
        {
            IsLoggedIn = false;
            _connectionDomain = "localhost";
            _isSecure = false;
            SavedData = savedData;
        }

        public Connection(string domain, bool secure, SaveData savedData)
        {
            IsLoggedIn = false;
            // Check domain
            // Using this regex:
            // ^(((?!-))(xn--|_)?[a-z0-9-]{0,61}[a-z0-9]{1,1}\.)*(xn--)?([a-z0-9][a-z0-9\-]{0,60}|[a-z0-9-]{1,30}\.[a-z]{2,})$
            // This allows domains, disallowing last slash
            // If domain is not localhost and there exists no periods, throw an exception as well

            if (!domain.Contains(".") && domain != "localhost")
            {
                throw new ArgumentException("Non-localhost domain does not have a TLD.");
            }

            if (domain == "localhost")
            {
                _connectionDomain = "localhost";
                _isSecure = false;
            }
            else
            {
                //                ^(((?!-))(xn--|_)?[a-z0-9-]{0,61}[a-z0-9]{1,1}\.)*(xn--)?([a-z0-9][a-z0-9\-]{0,60}|[a-z0-9-]{1,30}\.[a-z]{2,})$
                string pattern = "^(((?!-))(xn--|_)?[a-z0-9-]{0,61}[a-z0-9]{1,1}\\.)*(xn--)?([a-z0-9][a-z0-9\\-]{0,60}|[a-z0-9-]{1,30}\\.[a-z]{2,})$";

                if (!Regex.IsMatch(domain, pattern))
                {
                    throw new ArgumentException("Domain string could not be validated.");
                }

                _connectionDomain = domain;
                _isSecure = secure;
            }

            SavedData = savedData;
        }

        private string CreateFullURL(string path)
        {
            return "http" + (_isSecure ? "s" : "") + "://" + _connectionDomain + "/" + path;
        }

        private async Task<string> SendPOSTRequest(string path, Dictionary<string, string> post)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "SublimeDiceClient/" + Program.Version);
                client.DefaultRequestHeaders.Add("Connection", "keep-alive");

                // Encode all values in body in base64
                Dictionary<string, string> encryptedPost = new Dictionary<string, string>();
                foreach (KeyValuePair<string, string> kvp in post)
                {
                    encryptedPost[kvp.Key] = Convert.ToBase64String(Encoding.UTF8.GetBytes(kvp.Value));
                }

                FormUrlEncodedContent content = new FormUrlEncodedContent(encryptedPost);
                try
                {

                    HttpResponseMessage response = await client.PostAsync(CreateFullURL(path), content);
                    string responseText = await response.Content.ReadAsStringAsync();
                    return responseText;
                }
                catch (HttpRequestException e)
                {
                    return ServerResponseHandler.GenerateConnectionErrorJSONString(e);
                }
            }
        }

        public string ResolveClientSeed(string username)
        {
            string clientSeed = "";
            if (SavedData.ClientSeedFileExists())
            {
                clientSeed = SavedData.GetClientSeedFromFile(username);
                if (string.IsNullOrWhiteSpace(clientSeed))
                {
                    clientSeed = SavedData.GenerateNewClientSeed(username);
                    SavedData.UpdateClientSeedToFile(clientSeed);
                }
            }
            else
            {
                clientSeed = SavedData.GenerateNewClientSeed(username);
                SavedData.UpdateClientSeedToFile(clientSeed);
            }

            return clientSeed;
        }

        public void UpdateClientSeed(string newClientSeed)
        {
            SavedData.UpdateClientSeedToFile(newClientSeed);
        }

        public async Task<Tuple<string, int>> Login(string username, AuthenticationType authType, string authString, bool retain)
        {
            if (IsLoggedIn)
            {
                throw new InvalidOperationException("Cannot login if the user is already logged in.");
            }

            int faucetWait = 0;

            Dictionary<string, string> body = new Dictionary<string, string>();
            body.Add("username", username);
            if (authType == AuthenticationType.Password)
            {
                body.Add("password", authString);
            }
            else
            {
                body.Add("session_token", authString);
            }

            if (retain)
            {
                body.Add("retain", "session");
            }

            string response = await SendPOSTRequest(URL_Login, body);
            // Parse additional data
            using (JsonDocument doc = JsonDocument.Parse(response))
            {
                JsonElement root = doc.RootElement;

                // First check status and see if it's OK
                if (root.GetProperty("status").ToString() == "OK")
                {
                    // Initialize User
                    JsonElement data = root.GetProperty("data");
                    uint id = uint.Parse(data.GetProperty("id").ToString());
                    string name = data.GetProperty("username").ToString();
                    ulong balance = ulong.Parse(data.GetProperty("sd_balance").ToString());
                    ulong nonce = ulong.Parse(data.GetProperty("sd_current_nonce").ToString());
                    string serverSeedHash = data.GetProperty("sd_current_server_seed_hash").ToString();
                    JsonElement sessionToken;

                    string clientSeed = ResolveClientSeed(name);
                    User user;
                    // User user = new User(id, name, balance, clientSeed, serverSeedHash, nonce, authType, authString);
                    if (data.TryGetProperty("session_token", out sessionToken))
                    {
                        user = new User(id, name, balance, clientSeed, serverSeedHash, nonce, AuthenticationType.SessionToken, sessionToken.ToString());
                        SavedData.UpdateSessionToken(sessionToken.ToString());
                    }
                    else
                    {
                        user = new User(id, name, balance, clientSeed, serverSeedHash, nonce, AuthenticationType.Password, authString);
                        SavedData.UpdateSessionToken();
                    }

                    JsonElement secondsRemaining;
                    if (data.TryGetProperty("faucet_timer", out secondsRemaining))
                    {
                        int.TryParse(secondsRemaining.ToString(), out faucetWait);
                    }

                    IsLoggedIn = true;
                    LoggedInUser = user;
                }
            }

            if (faucetWait == 0)
            {
                CachedFaucetWaitTimer = DateTime.Now.AddSeconds(-1);
            }
            else
            {
                // Determine correct time from current time
                CachedFaucetWaitTimer = DateTime.Now.AddSeconds(faucetWait).AddSeconds(1);
            }
            return new Tuple<string, int>(response, faucetWait);
        }

        public async Task<string> Register(string username, string password, bool retain)
        {
            if (IsLoggedIn)
            {
                throw new InvalidOperationException("Cannot register if the user is already logged in.");
            }

            Dictionary<string, string> body = new Dictionary<string, string>();
            body.Add("username", username);
            body.Add("password", password);

            if (retain)
            {
                body.Add("retain", "session");
            }

            string response = await SendPOSTRequest(URL_Register, body);

            // Parse additional data
            using (JsonDocument doc = JsonDocument.Parse(response))
            {
                JsonElement root = doc.RootElement;

                // First check status and see if it's OK
                if (root.GetProperty("status").ToString() == "OK")
                {
                    // Initialize User
                    JsonElement data = root.GetProperty("data");
                    uint id = uint.Parse(data.GetProperty("id").ToString());
                    string name = data.GetProperty("username").ToString();
                    ulong balance = ulong.Parse(data.GetProperty("sd_balance").ToString());
                    ulong nonce = ulong.Parse(data.GetProperty("sd_current_nonce").ToString());
                    string serverSeedHash = data.GetProperty("sd_current_server_seed_hash").ToString();
                    JsonElement sessionToken;

                    string clientSeed = ResolveClientSeed(name);
                    User user;
                    if (data.TryGetProperty("session_token", out sessionToken))
                    {
                        user = new User(id, name, balance, clientSeed, serverSeedHash, nonce, AuthenticationType.SessionToken, sessionToken.ToString());
                        SavedData.UpdateSessionToken(sessionToken.ToString());
                    }
                    else
                    {
                        user = new User(id, name, balance, clientSeed, serverSeedHash, nonce, AuthenticationType.Password, password);
                        SavedData.UpdateSessionToken();
                    }

                    IsLoggedIn = true;
                    LoggedInUser = user;
                }
            }

            return response;
        }

        public async Task<Tuple<string, int>> FaucetRequest(string username, AuthenticationType authType, string authString)
        {
            if (!IsLoggedIn)
            {
                throw new InvalidOperationException("Cannot acquire faucet if the user is not logged in.");
            }

            int faucetWait = 0;

            Dictionary<string, string> body = new Dictionary<string, string>();
            body.Add("username", username);
            if (authType == AuthenticationType.Password)
            {
                body.Add("password", authString);
            }
            else
            {
                body.Add("session_token", authString);
            }

            string response = await SendPOSTRequest(URL_Faucet, body);
            // Parse additional data
            using (JsonDocument doc = JsonDocument.Parse(response))
            {
                JsonElement root = doc.RootElement;

                // First check status and see if it's OK
                if (root.GetProperty("status").ToString() == "OK")
                {
                    // Get seconds remaining
                    JsonElement secondsRemaining = root.GetProperty("seconds_remaining");
                    int.TryParse(secondsRemaining.ToString(), out faucetWait);

                    JsonElement data = root.GetProperty("data");
                    ulong balance = ulong.Parse(data.GetProperty("sd_balance").ToString());

                    // Update balance
                    LoggedInUser.UpdateBalance(balance);
                }
            }

            return new Tuple<string, int>(response, faucetWait);
        }

        public async Task<string> Logout(string username, string sessionToken)
        {
            if (!IsLoggedIn)
            {
                throw new InvalidOperationException("Cannot logout if the user is not logged in.");
            }

            Dictionary<string, string> body = new Dictionary<string, string>();
            body.Add("username", username);
            body.Add("session_token", sessionToken);

            string response = await SendPOSTRequest(URL_Logout, body);

            // Parse additional data
            using (JsonDocument doc = JsonDocument.Parse(response))
            {
                JsonElement root = doc.RootElement;

                // First check status and see if it's OK
                if (root.GetProperty("status").ToString() == "OK")
                {
                    // Logout and set user to null
                    LoggedInUser = null;
                    IsLoggedIn = false;

                    // Update saved session token
                    SavedData.UpdateSessionToken();
                }
                else
                {
                    SavedData.UpdateSessionToken();
                }
            }

            return response;
        }

        public async Task<Tuple<string, Roll>> RollDice(string username, AuthenticationType authType, string authString, string clientSeed, ulong currentNonce, ulong betAmount, ushort betBoundary, bool isRollOver)
        {
            if (!IsLoggedIn)
            {
                throw new InvalidOperationException("Cannot execute if the user is not logged in.");
            }

            Roll roll = null;

            Dictionary<string, string> body = new Dictionary<string, string>();
            body.Add("username", username);
            if (authType == AuthenticationType.Password)
            {
                body.Add("password", authString);
            }
            else
            {
                body.Add("session_token", authString);
            }

            body.Add("client_seed", clientSeed);
            body.Add("bet_amount", betAmount + "");
            body.Add("bet_boundary", betBoundary + "");
            body.Add("roll_over", isRollOver ? "1" : "0");

            string response = await SendPOSTRequest(URL_Roll, body);
            // Parse additional data
            using (JsonDocument doc = JsonDocument.Parse(response))
            {
                JsonElement root = doc.RootElement;

                // First check status and see if it's OK
                if (root.GetProperty("status").ToString() == "OK")
                {
                    ushort rolledNumber = 0;
                    JsonElement rolled = root.GetProperty("rolled");
                    ushort.TryParse(rolled.ToString(), out rolledNumber);

                    JsonElement data = root.GetProperty("data");
                    ulong userId = ulong.Parse(data.GetProperty("id").ToString());
                    ulong balance = ulong.Parse(data.GetProperty("sd_balance").ToString());
                    ulong newNonce = ulong.Parse(data.GetProperty("sd_current_nonce").ToString());
                    string serverSeedHash = data.GetProperty("sd_current_server_seed_hash").ToString();

                    roll = new Roll(userId, clientSeed, serverSeedHash, currentNonce, betBoundary, isRollOver);

                    roll.SetRolledNumber(rolledNumber);

                    // Update balance
                    LoggedInUser.UpdateBalance(balance);

                    // Update nonce
                    LoggedInUser.UpdateNonce(newNonce);
                }
            }

            return new Tuple<string, Roll>(response, roll);
        }
    }
}
