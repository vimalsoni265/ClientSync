using ClientSync.Repository.Interfaces;
using ClientSync.Repository.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ClientSync.Repository
{
    /// <summary>
    /// Implement <see cref="ICustomerRepository"/> <inheritdoc cref="ICustomerRepository"/>
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        #region Fields & Constants

        private readonly string _connectionString;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="connectionString"></param>
        protected CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Constructor with connection factory
        /// </summary>
        /// <param name="connectionFactory"></param>
        public CustomerRepository(Func<IDbConnection> connectionFactory)
            : this(connectionFactory().ConnectionString)
        {
            Console.WriteLine("CustomerRepository created with connection factory");
        }

        #endregion

        #region Implement ICustomerRepository

        /// <inheritdoc/>
        public async Task AddAsync(Customer customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(
                    "INSERT INTO Customers (FirstName, LastName, Age, Location, LastPurchaseDate, LastUpdateDate, Password, Salt) " +
                    "VALUES (@FirstName, @LastName, @Age, @Location, @LastPurchaseDate, @LastUpdateDate, @Password, @Salt)", connection))
                {
                    AddCustomerParameters(command, customer);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("DELETE FROM Customers WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        /// <inheritdoc/>
        public Task<IEnumerable<Customer>> Find(Expression<Func<Customer, bool>> predicate)
        {
            // do nothing for now.
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var customers = new List<Customer>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SELECT * FROM Customers", connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        customers.Add(MapCustomer(reader));
                    }
                }
            }
            return customers;
        }

        /// <inheritdoc/>
        public async Task<Customer> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SELECT * FROM Customers WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return MapCustomer(reader);
                        }
                    }
                }
            }
            return null;
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(Customer customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(
                    "UPDATE Customers SET FirstName = @FirstName, LastName = @LastName, Age = @Age, Location = @Location, " +
                    "LastPurchaseDate = @LastPurchaseDate, LastUpdateDate = @LastUpdateDate, Password = @Password, Salt = @Salt WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", customer.Id);
                    AddCustomerParameters(command, customer);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Maps the customer data from the database to the customer object.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Customer MapCustomer(SqlDataReader reader)
        {
            var customer = new Customer
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                Age = reader.GetInt32(reader.GetOrdinal("Age")),
                Location = reader.GetString(reader.GetOrdinal("Location")),
                LastPurchaseDate = reader.IsDBNull(reader.GetOrdinal("LastPurchaseDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("LastPurchaseDate")),
                LastUpdateDate = reader.IsDBNull(reader.GetOrdinal("LastUpdateDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("LastUpdateDate")),
                Password = reader.IsDBNull(reader.GetOrdinal("Password")) ? null : reader.GetString(reader.GetOrdinal("Password")),
                Salt = reader.IsDBNull(reader.GetOrdinal("Salt")) ? null : reader.GetString(reader.GetOrdinal("Salt")),
            };

            // Convert to local time.
            customer.LastPurchaseDate = customer.LastPurchaseDate?.ToLocalTime();
            customer.LastUpdateDate = customer.LastUpdateDate?.ToLocalTime();


            return customer;
        }

        /// <summary>
        /// Adds the customer parameters to the command.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="customer"></param>
        private static void AddCustomerParameters(SqlCommand command, Customer customer)
        {
            command.Parameters.AddWithValue("@FirstName", customer.FirstName);
            command.Parameters.AddWithValue("@LastName", customer.LastName);
            command.Parameters.AddWithValue("@Age", customer.Age);
            command.Parameters.AddWithValue("@Location", customer.Location);
            command.Parameters.AddWithValue("@LastPurchaseDate", customer.LastPurchaseDate ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@LastUpdateDate", customer.LastUpdateDate ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Password", customer.Password ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Salt", customer.Salt ?? (object)DBNull.Value);
        }

        #endregion
    }
}
