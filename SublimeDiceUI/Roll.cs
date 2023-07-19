using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeDiceUI
{
    public class Roll
    {
        public ulong UserId { get; private set; }

        public string ClientSeed { get; private set; }
        public string ServerSeedRaw { get; private set; } // Only available after keypair has been rotated
        public string ServerSeedHash { get; private set; }
        public ulong Nonce { get; private set; }
        public ushort Boundary { get; private set; }
        private ushort RawBoundary { get; }
        public bool IsRollOver { get; private set; }
        public double Multiplier => (100 - 1) * Math.Pow(this.RawBoundary * 1.0 / 100, -1);
        public ushort RolledNumber { get; private set; }
        public string RolledNumberString => GetRolledNumberStringFromRawResult(this.RolledNumber);
        public bool Win { get; private set; }

        public Roll(ulong userId, string clientSeed, string serverSeedHash, ulong nonce, ushort boundary, bool isRollOver)
        {
            this.UserId = userId;
            this.ClientSeed = clientSeed;
            this.ServerSeedHash = serverSeedHash;
            this.ServerSeedRaw = "";
            this.Nonce = nonce;
            this.Boundary = boundary;
            this.IsRollOver = isRollOver;
            this.RawBoundary = isRollOver ? (ushort)(9999 - boundary) : boundary;
        }

        public void SetRolledNumber(ushort result)
        {
            this.RolledNumber = result;
            this.Win = this.RolledNumber < RawBoundary;
        }

        private string GetRolledNumberStringFromRawResult(ushort rawRolledNumber)
        {
            if (rawRolledNumber < 10)
            {
                // Single digit
                return "00.0" + rawRolledNumber;
            }
            if (rawRolledNumber < 100)
            {
                // Double digits
                return "00." + rawRolledNumber;
            }

            // Three or four digits
            return rawRolledNumber.ToString().Insert(rawRolledNumber < 1000 ? 1 : 2, ".");
        }
    }
}
