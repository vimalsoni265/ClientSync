using ClientSync.Common;
using ClientSync.Repository;
using ClientSync.Repository.Interfaces;
using ClientSync.Services;
using ClientSync.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;


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
            try
            {
                Logger.Info(nameof(Program), "Application started.");

                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
                Application.ThreadException += ThreadExceptionHandler;

                // Allocates a new console window for the app (if not already running from one)
                OpenTerminal();

                // Set up DI container
                var serviceProvider = ConfigureServices();
                if (serviceProvider.GetService<ICustomerRepository>() != null)
                {
                    Console.WriteLine("SQL Server Database connection is successful...");
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Start the app with DI
                Application.Run(serviceProvider.GetRequiredService<MainWindow>());

            }
            catch (FileNotFoundException ex)
            {
                Logger.Error(ex);
                throw;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        #region Private Methods

        /// <summary>
        /// Open Terminal and print welcome message with version.
        /// </summary>
        private static void OpenTerminal()
        {
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                AllocConsole();
            }

            // Print Welcome Message and Version
            Console.WriteLine("Welcome to ClientSync!");
            Console.WriteLine($"Version: {Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "Unknown"}");
        }

        /// <summary>
        /// Configure services for DI.
        /// </summary>
        /// <returns></returns>
        private static ServiceProvider ConfigureServices()
        {
            // Read connection string from App.config
            string connectionString = ConfigurationManager.ConnectionStrings["sqlConnection"].ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
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

        #endregion

        #region Event Handlers

        /// <summary>
        /// Handles unhandled exceptions.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Logger.Error(e.ExceptionObject as Exception);
        }

        /// <summary>
        /// Handles thread exceptions.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ThreadExceptionHandler(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Logger.Error(e.Exception);
        }

        #endregion 

        // P/Invoke to kernel32.dll to allocate a new console window for the app (if not already running from one)
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();
    }
}
