using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Numerics;
using ExtendedNumerics;
using System.Security.Policy;

namespace SublimeDicePrototype
{
    public static class LocalCrypto
    {

        private static readonly char[] charsFullAlphanumeric = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        private static readonly char[] charsLowercaseAlphanumeric = "abcdefghijklmnopqrstuvwxyz1234567890".ToCharArray();
        private static readonly char[] charsUppercaseAlphanumeric = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        private static readonly char[] charsLowercaseHexadecimal = "abcdef1234567890".ToCharArray();
        private static readonly char[] charsUppercaseHexadecimal = "ABCDEF1234567890".ToCharArray();

        /// <summary>
        /// Determines the set of <see langword="char"/>s to be used in several string generation methods.
        /// </summary>
        public enum Charset
        {
            /// <summary>
            /// Indicates all alphanumeric characters, including uppercase and lowercase letters, equivalent to [a-zA-Z0-9].
            /// </summary>
            All,
            /// <summary>
            /// Indicates lowercase letters and numbers, equivalent to [a-z0-9].
            /// </summary>
            AlphanumericLowercase,
            /// <summary>
            /// Indicates uppercase letters and numbers, equivalent to [A-Z0-9].
            /// </summary>
            AlphanumericUppercase,
            /// <summary>
            /// Indicates hexadecimal digits with lowercase letters, equivalent to [a-f0-9].
            /// </summary>
            HexadecimalLowercase,
            /// <summary>
            /// Indicates hexadecimal digits with uppercase letters, equivalent to [A-F0-9].
            /// </summary>
            HexadecimalUppercase
        }

        public static string GetCryptographicallySecureRandomString(int size, Charset set)
        {
            char[] charset;
            switch (set)
            {
                case Charset.AlphanumericLowercase:
                    charset = charsLowercaseAlphanumeric;
                    break;
                case Charset.AlphanumericUppercase:
                    charset = charsUppercaseAlphanumeric;
                    break;
                case Charset.HexadecimalLowercase:
                    charset = charsLowercaseHexadecimal;
                    break;
                case Charset.HexadecimalUppercase:
                    charset = charsUppercaseHexadecimal;
                    break;
                default:
                    charset = charsFullAlphanumeric;
                    break;
            }

            byte[] data = new byte[4 * size];
            using (RandomNumberGenerator crypto = RandomNumberGenerator.Create())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            for (int i = 0; i < size; i++)
            {
                uint rnd = BitConverter.ToUInt32(data, i * 4);
                long idx = rnd % charset.Length;

                result.Append(charset[idx]);
            }

            return result.ToString();
        }

        public static string GenerateHashOfString(string input)
        {
            using (SHA256Managed sha256 = new SHA256Managed())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public static string GenerateHMACHashedString(string input, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            using (HMACSHA256 hmacsha256 = new HMACSHA256(keyBytes))
            {
                byte[] bytes = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }

    public class KeyPair
    {
        public string PlayerSeed { get; }
        public string ServerSeedHash { get; }
        private string ServerSeed { get; }

        public bool Expired { get; private set; }

        public KeyPair(string playerSeed)
        {
            PlayerSeed = playerSeed;
            Expired = false;
            
            // Generate random string for server seed
            ServerSeed = LocalCrypto.GetCryptographicallySecureRandomString(64, LocalCrypto.Charset.HexadecimalLowercase);
            ServerSeedHash = LocalCrypto.GenerateHashOfString(ServerSeed);
        }

        public string GetServerSeed()
        {
            if (!Expired)
            {
                Expired = true;
            }
            return this.ServerSeed;
        }
    }

    public class Player
    {
        public string Name { get; }
        public KeyPair Keys { get; private set; }

    }

    public class Bet
    {
        public ulong ID { get; }

        public string Name { get; }

        public DateTime Timestamp { get; }

        public ushort Boundary { get; }

        private ushort UnderBoundary { get; }

        public bool IsRollOver { get; }

        public decimal Multiplier => GetMultiplier(this.UnderBoundary);

        public decimal WinChance => UnderBoundary * 1.0m / 100.0m;

        public string ClientSeed { get; }
        public string ServerSeed { get; }
        public string ServerSeedHash { get; }
        public ulong Nonce { get; }

        public ushort RolledNumber { get; }
        public bool Won => RolledNumber < UnderBoundary;

        public Bet(ulong id, string name, ushort rawBoundary, bool isRollOver, string clientSeed, string serverSeed, ulong nonce)
        {
            if (rawBoundary < 200 || rawBoundary > 9800)
            {
                throw new ArgumentException("Raw boundary (" + rawBoundary + ") was outside of the expected range of [200, 9800].");
            }

            ID = id;
            Name = name;
            Timestamp = DateTime.UtcNow;
            IsRollOver = isRollOver;
            if (!isRollOver)
            {
                Boundary = rawBoundary;
                UnderBoundary = rawBoundary;
            }
            else
            {
                Boundary = (ushort)(9999 - rawBoundary);
                UnderBoundary = rawBoundary;
            }

            ClientSeed = clientSeed;
            ServerSeed = serverSeed;
            ServerSeedHash = LocalCrypto.GenerateHashOfString(serverSeed);

            Nonce = nonce;

            RolledNumber = Roll(clientSeed, nonce, serverSeed);
        }

        private static ushort Roll(string clientSeed, ulong nonce, string serverSeed)
        {
            int min = 0;
            int max = 9999;
            string hash = LocalCrypto.GenerateHMACHashedString(clientSeed + ":" + nonce, serverSeed);
            BigInteger decHash = ConvertToBase10(hash);
            BigDecimal dividend = new BigDecimal(decHash, BigInteger.One); // hashInDec
            BigDecimal divisor = BigDecimal.Pow(new BigDecimal(16), new BigInteger(hash.Length));
            BigDecimal scaled = BigDecimal.Divide(dividend, divisor);
            decimal scaledDecimal = (decimal)scaled;
            decimal result = 0.0m + min + scaledDecimal * (max - min);
            return (ushort)result;
        }

        public static ushort VerifyRoll(string clientSeed, ulong nonce, string serverSeed)
        {
            return Roll(clientSeed, nonce, serverSeed);
        }

        private static BigInteger ConvertToBase10(string hexValue)
        {
            // Must prepend a 0 so that the MSB is recognized as positive
            // The value will be recognized as negative if the first digit is 8-F, because the MSB will then be 1
            return BigInteger.Parse("0" + hexValue, NumberStyles.AllowHexSpecifier);
        }

        private static int RollNumber(string hash, int min = 0, int max = 9999)
        {
            BigInteger decHash = ConvertToBase10(hash);
            BigDecimal dividend = new BigDecimal(decHash, BigInteger.One); // hashInDec
            BigDecimal divisor = BigDecimal.Pow(new BigDecimal(16), new BigInteger(hash.Length));
            BigDecimal scaled = BigDecimal.Divide(dividend, divisor);
            decimal scaledDecimal = (decimal)scaled;
            decimal result = 0.0m + min + scaledDecimal * (max - min);
            return (int)result;
        }

        private static decimal GetMultiplier(ushort underBoundary)
        {
            // 9900x^(-1)
            double calc = (double)(9900.0m) * Math.Pow(underBoundary, -1);
            return (decimal)calc;
        }

        public static string GetDecimalRoll(ushort rawRoll)
        {
            if (rawRoll > 9999)
            {
                throw new ArgumentException("Roll was greater than 9999.");
            }

            string result = rawRoll.ToString();

            if (rawRoll < 10)
            {
                // Single digit
                result = "0.0" + result;
            }
            else if (rawRoll < 100)
            {
                // Double digit
                result = "0." + result;
            }
            else if (rawRoll < 1000)
            {
                // Triple digits
                result = result.Insert(1, ".");
            }
            else
            {
                result = result.Insert(2, ".");
            }

            return result;
        }
    }

    internal class Program
    {
        private static string HashString(string input)
        {
            using (SHA256Managed sha256 = new SHA256Managed())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        private static string HMACHashString(string input, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            using (HMACSHA256 hmacsha256 = new HMACSHA256(keyBytes))
            {
                byte[] bytes = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        private static BigInteger ConvertToBase10(string hexValue)
        {
            // Must prepend a 0 so that the MSB is recognized as positive
            // The value will be recognized as negative if the first digit is 8-F, because the MSB will then be 1
            return BigInteger.Parse("0" + hexValue, NumberStyles.AllowHexSpecifier);
        }

        private static int RollNumber(string hash, int min = 0, int max = 9999)
        {
            BigInteger decHash = ConvertToBase10(hash);
            BigDecimal dividend = new BigDecimal(decHash, BigInteger.One); // hashInDec
            BigDecimal divisor = BigDecimal.Pow(new BigDecimal(16), new BigInteger(hash.Length));
            BigDecimal scaled = BigDecimal.Divide(dividend, divisor);
            decimal scaledDecimal = (decimal)scaled;
            decimal result = 0.0m + min + scaledDecimal * (max - min);
            return (int)result;
        }

        static void Main(string[] args)
        {
            string clientSeed = "0cc175b9c0f1b6a831c399e269772662";
            string serverSeed = "7b50df1869c23ef7c7978a3cf6dc4b72f1a06823364b01339f23ce8e49b2017c"; // "Username-DateTime"
            string serverSeedHash = "ca4b18ce24adf2c55fe117297d423956af764852490d862c3c4f260257279f3d";
            ulong nonce = 1;
            ulong totalRolls = 0;

            ConsoleColor defaultColor = Console.ForegroundColor;

            ConsoleKeyInfo cki;
            do
            {
                Console.WriteLine("Client seed:          " + clientSeed);
                Console.WriteLine("Server seed (hashed): " + serverSeedHash);
                Console.WriteLine("Current nonce:        " + nonce);
                ushort bounds = 0;
                /*
                Console.Write("Input boundary:     > ");
                while (!ushort.TryParse(Console.ReadLine(), out bounds) || (bounds < 200 || bounds > 9800))
                {
                    Console.Write("Invalid boundary... > ");
                }
                */
                bounds = 4950;

                Bet b = new Bet(totalRolls + nonce, "You", bounds, false, clientSeed, serverSeed, nonce);
                Console.Write("Roll:                 " + Bet.GetDecimalRoll(b.RolledNumber) + " (" + b.RolledNumber + ") ");

                if (b.Won)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Win!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Loss...");
                }

                Console.ForegroundColor = defaultColor;
                Console.Write("Verifying roll...     ");
                ushort verifyResult = Bet.VerifyRoll(clientSeed, nonce, serverSeed);
                Console.Write(Bet.GetDecimalRoll(verifyResult) + " (" + verifyResult + ") ");
                if (verifyResult == b.RolledNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Verified!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Could not verify!!!");
                }
                Console.ForegroundColor = defaultColor;

                Console.WriteLine("Incrementing nonce.");
                nonce++;

                Console.Write("Press Q to quit, any other key to continue... > ");

                cki = Console.ReadKey();
                Console.WriteLine();
            } while (cki.Key != ConsoleKey.Q);
            Console.WriteLine("Done. Press any key to exit");
            Console.ReadKey(true);
            Console.WriteLine("Bye");
        }
    }
}
