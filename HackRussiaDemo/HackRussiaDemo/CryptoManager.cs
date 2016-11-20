using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security.Cryptography;
using System.IO;
using System.Text;
using HackRussiaDemo.Properties;

namespace HackRussiaDemo
{
    public static class CryptoManager
    {
        public static string encodeData(string input)
        {
            var rc2CSP = new RC2CryptoServiceProvider();

            byte[] key = Encoding.Default.GetBytes(Settings.Default.authKey);
            byte[] IV = Encoding.Default.GetBytes(Settings.Default.authIV);

            var encryptor = rc2CSP.CreateEncryptor(key, IV);

            var msEncrypt = new MemoryStream();
            var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

            csEncrypt.Write(Encoding.Default.GetBytes(input), 0, Encoding.Default.GetBytes(input).Length);
            csEncrypt.FlushFinalBlock();

            return Encoding.Default.GetString(msEncrypt.ToArray());
        }

        public static string decrypt(string encrypted)
        {
            var rc2CSP = new RC2CryptoServiceProvider();

            byte[] key = Encoding.Default.GetBytes(Settings.Default.authKey);
            byte[] IV = Encoding.Default.GetBytes(Settings.Default.authIV);

            var decryptor = rc2CSP.CreateDecryptor(key, IV);

            var msDecrypt = new MemoryStream(Encoding.Default.GetBytes(encrypted));
            var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);

            StringBuilder result = new StringBuilder();

            int b = 0;

            do
            {
                b = csDecrypt.ReadByte();

                if (b != -1)
                {
                    result.Append((char)b);
                }

            } while (b != -1);

            return result.ToString();

        }
    }
}