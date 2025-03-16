using ClientSync.Core;
using ClientSync.Core.Interface;
using System;

namespace ClientSync.Repository.Models
{
    /// <summary>
    /// Represents a customer
    /// </summary>
    public partial class Customer
    {
        private readonly IPasswordHelper _passwordHelper;

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
        /// Sets the password for the customer.
        /// </summary>
        /// <param name="password"></param>
        public void SetPassword(string password)
        {
            Salt = _passwordHelper.GenerateSalt();
            Password = _passwordHelper.ComputeHash(password, Salt);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        #endregion
    }
}
