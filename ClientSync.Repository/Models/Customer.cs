namespace ClientSync.Repository.Models
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Represents a customer
    /// </summary>
    public partial class Customer
    {
        private const int m_saltLength = 16;

        #region Properties

        /// <summary>
        /// Gets or sets the customer id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the customer first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the customer last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the customer email.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the customer email.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the last purchase date.
        /// </summary>
        public DateTime? LastPurchaseDate { get; set; }

        /// <summary>
        /// Gets or sets the last update date.
        /// </summary>
        public DateTime? LastUpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the password. 
        /// </summary>
        public string Password { get; set; } = null;

        /// <summary>
        /// Gets random generated salt.
        /// </summary>
        public string Salt { get; set; } = null;

        #endregion

        #region Public Methods

        /// <summary>
        /// Overrides the ToString method to current record data.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{base.ToString()}" +
                $"{nameof(FirstName)}:{FirstName}" +
                $"{nameof(LastName)}:{LastName}" +
                $"{nameof(Age)}:{Age}" +
                $"{nameof(Location)}:{Location}" +
                $"{nameof(LastPurchaseDate)}:{LastPurchaseDate}" +
                $"{nameof(LastUpdateDate)}:{LastUpdateDate}";
        }

        /// <summary>
        /// Sets the password for the customer.
        /// </summary>
        /// <param name="password"></param>
        public virtual void SetPassword(string password)
        {
            Salt = GenerateSalt(m_saltLength);
            Password = ComputeSAH1Hash(password + Salt);
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Generates a random salt.
        /// </summary>
        /// <returns></returns>
        protected virtual string GenerateSalt(int length)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var saltBytes = new byte[length];
                rng.GetBytes(saltBytes);
                return Convert.ToBase64String(saltBytes);
            }
        }

        /// <summary>
        /// Computes the hash of the password.
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        protected virtual string ComputeSAH1Hash(string plainText)
        {
            using (var sha1 = SHA1.Create())
            {
                var hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(plainText));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
        #endregion
    }
}
