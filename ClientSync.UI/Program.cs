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
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;


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
                LogError(nameof(FileNotFoundException), ex);
                MessageBox.Show($"Missing File: {ex.FileName}\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                LogError(nameof(Exception), ex);
            }

        }

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


        static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            LogError("Unhandled Exception", e.ExceptionObject as Exception);
        }

        static void ThreadExceptionHandler(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            LogError("Thread Exception", e.Exception);
        }

        static void LogError(string errorType, Exception ex)
        {
            if (ex != null)
            {
                string message = $"{errorType}: {ex.Message}\nStackTrace:\n{ex.StackTrace}";
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                File.WriteAllText("error_log.txt", message);
            }
        }

        // P/Invoke to kernel32.dll to allocate a new console window for the app (if not already running from one)
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}
