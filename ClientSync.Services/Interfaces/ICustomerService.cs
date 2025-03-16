using ClientSync.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientSync.Services.Interfaces
{

    public interface ICustomerService
    {
        /// <summary>
        /// Fetch all customers.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Customer>> GetAllCustomersAsync();

        /// <summary>
        /// Fetch a customer by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Customer> GetCustomerByIdAsync(int id);

        /// <summary>
        /// Add a new customer.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        Task AddCustomerAsync(Customer customer);

        /// <summary>
        /// Update a customer.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        Task UpdateCustomerAsync(Customer customer);

        /// <summary>
        /// Delete a customer.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteCustomerAsync(int id);

        /// <summary>
        /// Set the password for a customer.
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="password"></param>
        void SetCustomerPassword(Customer customer, string password);
    }
}
