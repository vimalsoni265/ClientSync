namespace ClientSync.Repository.Models
{
    using System;

    /// <summary>
    /// Represents a customer
    /// </summary>
    public partial class Customer
    {
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

        #endregion
    }
}
