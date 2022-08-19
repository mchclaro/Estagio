using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils
{
    public static class Crypto
    {
        public static string CryptoToMd5(string input)
        {
            byte[] hash = MD5.Create().ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte num in hash)
                stringBuilder.Append(num.ToString("x2"));
            return stringBuilder.ToString();
        }
        
        public static string CryptoToBCrypt(string input)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt(15);
            var hash = BCrypt.Net.BCrypt.HashPassword(input, salt);

            return hash;
        }
    }
}