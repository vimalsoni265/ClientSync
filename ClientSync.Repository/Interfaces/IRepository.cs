using ClientSync.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientSync.Repository.Interfaces
{
    /// <summary>
    /// Interface to Communicate with Database
    /// </summary>
    /// <typeparam name="T">The Repository Model class for which Database operations to be carried out</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Gets all request records from the database.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Gets a requested record by id from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Customer> GetByIdAsync(int id);

        /// <summary>
        /// Adds a requested record to the database.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        Task AddAsync(T customer);

        /// <summary>
        /// Updates a requested record in the database.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        Task UpdateAsync(T customer);

        /// <summary>
        /// Deletes a requested record from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);

    }
}
