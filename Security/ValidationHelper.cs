using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
    public class ValidationHelper
    {
        public static UserPasswordHashed GetHashedCredentials(string password)
        {
            var generator = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var salt = new byte[6];
            generator.GetBytes(salt);
            var saltString = Encoding.Default.GetString(salt);
            var hashedPassword = CipherHelper.Encrypt(password, saltString);
            return new UserPasswordHashed { HashedPassword = hashedPassword, PasswordSalt = saltString };
        }
        public static bool ValidatePassword(string passwordToValidate, UserPasswordHashed dbPassword)
        {
            var hashToCheck = CipherHelper.Encrypt(passwordToValidate, dbPassword.PasswordSalt);
            return hashToCheck == dbPassword.HashedPassword;
        }
        
    }
}
