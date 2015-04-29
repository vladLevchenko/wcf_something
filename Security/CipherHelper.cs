using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CR = System.Security.Cryptography;

namespace Security
{
    class CipherHelper
    {
        public static string Encrypt(string password,string salt)
        {
            var saltedPassword = salt + password;
            var saltedBytes = Encoding.Default.GetBytes(saltedPassword);
            var algorithm = new CR.SHA512Managed();
            var hashBytes = algorithm.ComputeHash(saltedBytes);
            return Convert.ToBase64String(hashBytes);
        }

    }
}
