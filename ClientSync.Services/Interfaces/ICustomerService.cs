﻿using ClientSync.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientSync.Services.Interfaces
{
    /// <summary>
    /// Interface to interact with customer data from the database.
    /// </summary>
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
        /// Add a new customers in bulk.
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        Task AddCustomersAsync(IEnumerable<Customer> customers);

        /// <summary>
        /// Update a customer.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        Task UpdateCustomerAsync(Customer customer);

        /// <summary>
        /// Update a customers in bulk.
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        Task UpdateCustomersAsync(IEnumerable<Customer> customers);

        /// <summary>
        /// Delete a customer.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteCustomerAsync(int id);

        /// <summary>
        /// Delete a customer in bulk.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task DeleteCustomerAsync(IEnumerable<int> ids);
    }
}
