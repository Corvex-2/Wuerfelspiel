using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AE_Wuefelspiel
{
    /// <summary>
    /// Eine cryptographisch sicherere Random Klasse, zum minimieren von duplikaten.
    /// </summary>
    public static class CRandom
    {
        public static float Random(float min, float max)
        {
            byte[] data = new byte[/*128*/1024];
            using (RNGCryptoServiceProvider c = new RNGCryptoServiceProvider())
            {
                c.GetNonZeroBytes(data);
            }
            return (float)(new Random(BitConverter.ToInt32(data, 0)).NextDouble() * ((double)max - (double)min) + (double)min);
        }
        public static double Random(double min, double max)
        {
            byte[] data = new byte[/*128*/256];
            using (RNGCryptoServiceProvider c = new RNGCryptoServiceProvider())
            {
                c.GetNonZeroBytes(data);
            }
            return new Random(BitConverter.ToInt32(data, 0) + Guid.NewGuid().GetHashCode()).NextDouble() * (max - min) + min;
        }
        public static int Random(int min, int max)
        {
            byte[] data = new byte[/*128*/1024];
            using (RNGCryptoServiceProvider c = new RNGCryptoServiceProvider())
            {
                c.GetNonZeroBytes(data);
            }
            return new Random(BitConverter.ToInt32(data, 0) + Guid.NewGuid().GetHashCode()).Next(min, max);
        }
        public static uint Random(uint min, uint max)
        {
            byte[] data = new byte[/*128*/1024];
            using (RNGCryptoServiceProvider c = new RNGCryptoServiceProvider())
            {
                c.GetNonZeroBytes(data);
            }
            return (uint)Math.Abs(new Random(BitConverter.ToInt32(data, 0) + Guid.NewGuid().GetHashCode()).Next((int)min, (int)max));
        }
        public static byte Random(byte min, byte max)
        {
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider c = new RNGCryptoServiceProvider())
            {
                c.GetNonZeroBytes(data);
            }
            return data[0];
        }
        public static byte[] Random(byte min, byte max, int size)
        {
            byte[] data = new byte[size];
            using (RNGCryptoServiceProvider c = new RNGCryptoServiceProvider())
            {
                c.GetNonZeroBytes(data);
            }
            return data;
        }
        public static string RandomString(int size)
        {
            char[] chars = ("ABCDEFGHIJKLMNOPQRSTUVWXYZ" + "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower() + "1234567890").ToArray();
            byte[] data = new byte[size];
            using (RNGCryptoServiceProvider c = new RNGCryptoServiceProvider())
            {
                c.GetNonZeroBytes(data);
            }
            StringBuilder res = new StringBuilder(size);
            foreach (byte b in data)
            {
                res.Append(chars[b % (chars.Length)]);
            }
            return res.ToString();
        }
        public static string RandomString(int size, bool NoNumbers)
        {
            string cchars = ("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower()) + ((NoNumbers) ? "" : "1234567890");
            char[] chars = cchars.ToArray();
            byte[] data = new byte[size];
            using (RNGCryptoServiceProvider c = new RNGCryptoServiceProvider())
            {
                c.GetNonZeroBytes(data);
            }
            StringBuilder res = new StringBuilder(size);
            foreach (byte b in data)
            {
                res.Append(chars[b % (chars.Length)]);
            }
            return res.ToString();
        }
        public static string RandomString(int size, bool NoNumbers, bool NoUppercase)
        {
            string cchars = ("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower()) + ((NoNumbers) ? "" : "1234567890") + ((NoUppercase) ? "" : "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            char[] chars = cchars.ToArray();
            byte[] data = new byte[size];
            using (RNGCryptoServiceProvider c = new RNGCryptoServiceProvider())
            {
                c.GetNonZeroBytes(data);
            }
            StringBuilder res = new StringBuilder(size);
            foreach (byte b in data)
            {
                res.Append(chars[b % (chars.Length)]);
            }
            return res.ToString();
        }
        public static string RandomHexString(int size)
        {
            char[] chars = "ABCDEF1234567890".ToArray();
            byte[] data = new byte[size];
            using (RNGCryptoServiceProvider c = new RNGCryptoServiceProvider())
            {
                c.GetNonZeroBytes(data);
            }
            StringBuilder res = new StringBuilder(size);
            foreach (byte b in data)
            {
                res.Append(chars[b % (chars.Length)]);
            }
            return res.ToString();
        }
    }
}
