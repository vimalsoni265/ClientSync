namespace ClientSync.Repository.Interfaces
{
    using ClientSync.Repository.Models;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using System;

    /// <summary>
    /// Interface to interact with customer data from the database.
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer>
    {

        /// <summary>
        /// Finds requested record based on a predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<Customer>> Find(Expression<Func<Customer, bool>> predicate);
    }
}
