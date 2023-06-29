using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SublimeDiceUI
{

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

    public static class CryptoSafeRNG
    {
        private static readonly char[] charsFullAlphanumeric = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        private static readonly char[] charsLowercaseAlphanumeric = "abcdefghijklmnopqrstuvwxyz1234567890".ToCharArray();
        private static readonly char[] charsUppercaseAlphanumeric = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        private static readonly char[] charsLowercaseHexadecimal = "abcdef1234567890".ToCharArray();
        private static readonly char[] charsUppercaseHexadecimal = "ABCDEF1234567890".ToCharArray();

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
    }
}
