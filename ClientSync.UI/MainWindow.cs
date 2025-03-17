using ClientSync.Common;
using ClientSync.Repository.Models;
using ClientSync.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSync.UI
{
    /// <summary>
    /// Main window of the application.
    /// </summary>
    public partial class MainWindow : Form
    {
        #region Fields

        private readonly ICustomerService _customerService;

        private const string ClassName = nameof(MainWindow);

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class with the specified customer service.
        /// </summary>
        /// <param name="customerService">The customer service.</param>
        public MainWindow(ICustomerService customerService)
        {
            InitializeComponent();
            _customerService = customerService;
        }

        #endregion

        #region UI Events

        /// <summary>
        /// Load customer data when the form is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MainWindow_Load(object sender, EventArgs e) => await LoadCustomerData();

        /// <summary>
        /// Handle 'Update to UPPERCASE' button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_updateToUpper_Click(object sender, EventArgs e)
        {
            Logger.Info(ClassName, $"Entered, " +
                $"DataSource is BindingSource: {dgCustomers.DataSource is BindingSource} ");

            try
            {
                if (dgCustomers.DataSource is BindingSource source && 
                    source.DataSource is List<Customer> customers && 
                    customers.Any())
                {
                    (sender as Button).Enabled = false;
                    BindCustomerData(UpdateLastNameToUpperCase(customers));
                    source.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                (sender as Button).Enabled = true;
                Logger.Info(ClassName, "Exited");
            }
        }

        /// <summary>
        /// Handle Save changes click and save data asynchronously.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnSaveChanges_Click(object sender, EventArgs e)
        {
            Logger.Info(ClassName, $"Entered, " +
                $"DataSource is BindingSource: {dgCustomers.DataSource is BindingSource} ");

            try
            {
                if (dgCustomers.DataSource is BindingSource source &&
                    source.DataSource is List<Customer> customers &&
                    customers.Any())
                {
                    // Disable the button to prevent multiple clicks.
                    (sender as Button).Enabled = false;

                    // Push the updated data to the database.
                    await _customerService.UpdateCustomersAsync(customers);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Disable the button to prevent multiple clicks.
                (sender as Button).Enabled = true;
                Logger.Info(ClassName, "Exited");
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Add datasource as BindingSource.
        /// </summary>
        /// <param name="customers"></param>
        protected void BindCustomerData(IEnumerable<Customer> customers)
        {
            if (customers.Any())
            {
                // Bind the data to the grid.
                BindingSource bindingSource = new BindingSource
                {
                    DataSource = customers
                };
                dgCustomers.DataSource = bindingSource;
            }
        }

        /// <summary>
        /// Load customer data.
        /// </summary>
        /// <returns></returns>
        protected async Task LoadCustomerData()
        {
            Logger.Info(ClassName, "Entered");

            try
            {
                Logger.Info(ClassName, "Fetching all customers records.");

                // Fetch all customers.
                var customers = await _customerService.GetAllCustomersAsync();

                // Bind the data to the grid, if any.
                if (customers != null && customers.Any())
                {
                    BindCustomerData(customers);
                    tsp_lbl_recordCountVal.Text = customers.Count().ToString();
                    Logger.Info(ClassName, $"{customers.Count()} records fetched successfully.");
                }
                else
                    Logger.Info(ClassName, "No records found.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Logger.Info(ClassName, "Exited");
        }

        /// <summary>
        /// Update last name to UPPERCASE.
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        protected IEnumerable<Customer> UpdateLastNameToUpperCase(List<Customer> customers)
        {
            Logger.Info(ClassName, "Entered");

            try
            {
                if (customers != null && customers.Any())
                {
                    // Loop through each customer and update the last name to UPPERCASE.
                    customers.ForEach(customer =>
                    {
                        if (!string.IsNullOrEmpty(customer.LastName))
                            customer.LastName = customer.LastName.ToUpper();
                    });
                    Logger.Info(ClassName, "Records updated successfully.");
                }
                else
                    Logger.Info(ClassName, "No records found.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Logger.Info(ClassName, "Exited");
            }
            return customers;
        }

        /// <summary>
        /// Update first name to UPPERCASE.
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        protected IEnumerable<Customer> UpdateFirstNameToUpperCase(List<Customer> customers)
        {
            Logger.Info(ClassName, "Entered");

            try
            {
                if (customers != null && customers.Any())
                {
                    // Loop through each customer and update the last name to UPPERCASE.
                    customers.ForEach(customer =>
                    {
                        if (!string.IsNullOrEmpty(customer.FirstName))
                            customer.FirstName = customer.FirstName.ToUpper();
                    });
                    Logger.Info(ClassName, "Records updated successfully.");
                }
                else
                    Logger.Info(ClassName, "No records found.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Logger.Info(ClassName, "Exited");
            }
            return customers;
        }

        #endregion        
    }
}
