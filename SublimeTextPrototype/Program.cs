using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Numerics;
using ExtendedNumerics;

// using ExtendedNumerics;

namespace SublimeDicePrototype
{
    public class Bet
    {
        public ulong ID { get; }

        public string Name { get; }

        public ushort Boundary { get; }

        public static string DisplayRoll(ushort rawRoll)
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
            /*
            Console.Write("Enter text: ");
            string input = Console.ReadLine();
            string hashed = HashString(input);
            Console.WriteLine(hashed);
            */

            string hex = "78ed9330f00055f15765cb141088f316d507204a745ad4800fd719fcbfca071a";
            string hex2 = "78ed9330f00055f15765cb141088f316d507204a745ad4800fd719fcbfca071b";
            //Console.WriteLine(ConvertToBase10(hex).ToString());
            //Console.WriteLine(ConvertToBase10(hex2).ToString());

            // Console.WriteLine(ConvertToBase10("fa37dc90"));

            RollNumber(hex, 0, 9999);

            Console.WriteLine(Bet.DisplayRoll(2));
            Console.WriteLine(Bet.DisplayRoll(9));
            Console.WriteLine(Bet.DisplayRoll(10));
            Console.WriteLine(Bet.DisplayRoll(12));
            Console.WriteLine(Bet.DisplayRoll(80));
            Console.WriteLine(Bet.DisplayRoll(99));
            Console.WriteLine(Bet.DisplayRoll(100));
            Console.WriteLine(Bet.DisplayRoll(500));
            Console.WriteLine(Bet.DisplayRoll(990));
            Console.WriteLine(Bet.DisplayRoll(999));
            Console.WriteLine(Bet.DisplayRoll(1000));
            Console.WriteLine(Bet.DisplayRoll(1001));
            Console.WriteLine(Bet.DisplayRoll(7831));

            Console.ReadKey(true);
        }
    }
}
