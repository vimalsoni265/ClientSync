namespace ClientSync.Services
{
    using ClientSync.Repository.Interfaces;
    using ClientSync.Repository.Models;
    using ClientSync.Services.Interfaces;
    using System;
    using System.Collections.Generic;
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
        public async Task UpdateCustomerAsync(Customer customer)
        {
            customer.LastUpdateDate = DateTime.UtcNow;
            await _customerRepository.UpdateAsync(customer);
        }

        /// <inheritdoc/>
        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }

        /// <inheritdoc/>
        public void SetCustomerPassword(Customer customer, string password)
        {
            customer.Salt = GenerateSalt(m_saltLength);
            customer.Password = ComputeHash($"{password}{customer.Salt}");
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Generates a random salt.
        /// </summary>
        /// <returns></returns>
        private string GenerateSalt(int length)
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
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        private string ComputeHash(string input)
        {
            using (var sha1 = SHA1.Create())
            {
                var hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        } 
        #endregion
    }
}
