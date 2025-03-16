namespace ClientSync.Core
{
    using ClientSync.Core.Interface;
    using System;

    /// <summary>
    /// Implementation of <see cref="IPasswordHelper"/> to hash the password.
    /// </summary>
    internal class PasswordHelper : IPasswordHelper
    {
        public string ComputeHash(string password, string salt)
        {
            // Create a new instance of the SHA1CryptoServiceProvider.
            using (var sha1 = System.Security.Cryptography.SHA1.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(password + salt);
                byte[] hashBytes = sha1.ComputeHash(inputBytes);

                // Convert the byte array to a base64 string.
                return Convert.ToBase64String(hashBytes);
            }
        }
        public string GenerateSalt()
        {
            // Create a byte array of length 16.
            byte[] saltBytes = new byte[16];

            // Create a new instance of the RNGCryptoServiceProvider.
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }

            // Return the salt.
            return Convert.ToBase64String(saltBytes);
        }
    }
}
