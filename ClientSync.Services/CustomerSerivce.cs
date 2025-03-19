namespace ClientSync.Services
{
    using ClientSync.Common;
    using ClientSync.Repository.Interfaces;
    using ClientSync.Repository.Models;
    using ClientSync.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation of Customer Service.
    /// </summary>
    internal class CustomerService : ICustomerService
    {
        #region Fields

        private readonly ICustomerRepository _customerRepository; 
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

            if (customers != null && customers.Any())
            {
                // Loop through each customer and add them to the database.
                foreach (var customer in customers)
                {
                    await AddCustomerAsync(customer);
                }
            }
            Logger.Info(ClassName, Logger.Exited);
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

            if (customers != null && customers.Any())
            {
                // Loop through each customer and add them to the database.
                foreach (var customer in customers)
                {
                    await UpdateCustomerAsync(customer);
                }
            }
            Logger.Info(ClassName, Logger.Exited);
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

            if (ids != null && ids.Any())
            {
                // Loop through each customer and add them to the database.
                foreach (var id in ids)
                {
                    await DeleteCustomerAsync(id);
                }
            }
            Logger.Info(ClassName, Logger.Exited);
        }

        #endregion
    }
}
