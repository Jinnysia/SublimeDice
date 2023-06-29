using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SublimeDiceUI
{
    public enum AuthenticationType
    {
        Password,
        SessionToken
    }

    public class User
    {
        public static int UsernameLengthMin => 5;
        public static int UsernameLengthMax => 30;
        public static int PasswordLengthMin => 6;

        public Tuple<AuthenticationType, string> AuthenticationMethod { get; private set; }

        public uint ID { get; private set; }
        public string Username { get; private set; }
        public ulong Balance { get; private set; }

        public string ClientSeed { get; private set; }
        public string ServerSeedHash { get; private set; }
        public ulong Nonce { get; private set; }

        public User(uint id, string username, ulong balance, string clientSeed, string serverSeedHash, ulong nonce, AuthenticationType authType, string authString)
        {
            ID = id;
            Username = username;
            Balance = balance;
            ClientSeed = clientSeed;
            ServerSeedHash = serverSeedHash;
            Nonce = nonce;
            AuthenticationMethod = new Tuple<AuthenticationType, string>(authType, authString);
        }

        public static bool IsValidUsernameForRegistration(string username)
        {
            if (username.Length < UsernameLengthMin || username.Length > UsernameLengthMax)
                return false;
            string pattern = @"^[A-Za-z0-9]{5,30}$";
            return Regex.IsMatch(username, pattern);
        }
    }
}
