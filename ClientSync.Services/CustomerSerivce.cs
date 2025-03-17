namespace ClientSync.Services
{
    using ClientSync.Common;
    using ClientSync.Repository.Interfaces;
    using ClientSync.Repository.Models;
    using ClientSync.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation of Customer Service.
    /// </summary>
    internal class CustomerService : ICustomerService
    {
        #region Fields

        private readonly ICustomerRepository _customerRepository; 

        const int m_saltLength = 16;

        private const string ClassName = nameof(CustomerService);

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="customerRepository"></param>
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        #endregion

        #region Implement ICustomerService

        /// <inheritdoc/>
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        /// <inheritdoc/>
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        /// <inheritdoc/>
        public async Task AddCustomerAsync(Customer customer)
        {
            customer.LastUpdateDate = DateTime.UtcNow;
            await _customerRepository.AddAsync(customer);
        }

        /// <inheritdoc/>
        public async Task AddCustomersAsync(IEnumerable<Customer> customers)
        {
            Logger.Info(ClassName, $"Entered, IsNull:{customers is null}, RecordToAdd: {customers.Count()}");

            if (customers != null & customers.Any())
            {
                // Loop through each customer and add them to the database.
                foreach (var customer in customers)
                {
                    await AddCustomerAsync(customer);
                }
            }
            Logger.Info(ClassName, "Exited");
        }

        /// <inheritdoc/>
        public async Task UpdateCustomerAsync(Customer customer)
        {
            customer.LastUpdateDate = DateTime.UtcNow;
            await _customerRepository.UpdateAsync(customer);
        }

        /// <inheritdoc/>
        public async Task UpdateCustomersAsync(IEnumerable<Customer> customers)
        {
            Logger.Info(ClassName, $"Entered, IsNull:{customers is null}, RecordToUpdate: {customers.Count()}");

            if (customers != null & customers.Any())
            {
                // Loop through each customer and add them to the database.
                foreach (var customer in customers)
                {
                    await UpdateCustomerAsync(customer);
                }
            }
            Logger.Info(ClassName, "Exited");
        }

        /// <inheritdoc/>
        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }

        /// <inheritdoc/>
        public async Task DeleteCustomerAsync(IEnumerable<int> ids)
        {
            Logger.Info(ClassName, $"Entered, IsNull:{ids is null}, RecordToUpdate: {ids.Count()}");

            if (ids != null & ids.Any())
            {
                // Loop through each customer and add them to the database.
                foreach (var id in ids)
                {
                    await DeleteCustomerAsync(id);
                }
            }
            Logger.Info(ClassName, "Exited");
        }

        /// <inheritdoc/>
        public void SetCustomerPassword(Customer customer, string password = "password")
        {
            customer.Salt = GenerateSalt(m_saltLength);
            customer.Password = ComputeSAH1Hash($"{password}{customer.Salt}");
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Generates a random salt.
        /// </summary>
        /// <returns></returns>
        protected string GenerateSalt(int length)
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
        protected string ComputeSAH1Hash(string plainText)
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
