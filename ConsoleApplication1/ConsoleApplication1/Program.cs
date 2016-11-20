using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string authKey = "text2";
            string authIV = "some other text";

            var input = Console.ReadLine();

            var rc2CSP = new RC2CryptoServiceProvider();

            byte[] key = Encoding.Default.GetBytes(authKey);
            byte[] IV = Encoding.Default.GetBytes(authIV);

            var encryptor = rc2CSP.CreateEncryptor(key, IV);

            var msEncrypt = new MemoryStream();
            var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

            csEncrypt.Write(Encoding.Default.GetBytes(input), 0, Encoding.Default.GetBytes(input).Length);
            csEncrypt.FlushFinalBlock();

            Console.WriteLine(Encoding.Default.GetString(msEncrypt.ToArray()));

            var encrypted = Encoding.Default.GetString(msEncrypt.ToArray());

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

            Console.WriteLine(result.ToString());

            Console.ReadLine();
        }
}
}
