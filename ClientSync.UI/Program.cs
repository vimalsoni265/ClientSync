using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;
using System.Configuration;
using ClientSync.Repository;
using ClientSync.Repository.Interfaces;
using ClientSync.Services;
using ClientSync.Services.Interfaces;
using System.Data;


namespace ClientSync.UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Set up DI container
            var serviceProvider = ConfigureServices();

            // Start the app with DI
            Application.Run(serviceProvider.GetRequiredService<MainWindow>());
        }

        /// <summary>
        /// Configure services for DI.
        /// </summary>
        /// <returns></returns>
        private static ServiceProvider ConfigureServices()
        {
            // Read connection string from App.config
            string connectionString = ConfigurationManager.ConnectionStrings["sqlConnection"].ConnectionString;
            if(string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("Connection string is missing! Check the config.");
            }

            var services = new ServiceCollection();

            // Register IDbConnection factory to ensure fresh connection per request with correct lifetime
            services.AddScoped<Func<IDbConnection>>(sp => () => new SqlConnection(connectionString));

            // Register Repositories and Services
            services.AddScoped<ICustomerRepository, CustomerRepository>(); 
            services.AddScoped<ICustomerService, CustomerService>();

            // Register Form for DI
            services.AddTransient<MainWindow>(); 

            return services.BuildServiceProvider();
        }
    }
}
