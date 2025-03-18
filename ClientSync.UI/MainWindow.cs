using ClientSync.Common;
using ClientSync.Repository.Models;
using ClientSync.Services.Interfaces;
using ClientSync.UI.UserControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
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
            }
            finally
            {
                // Update Grid
                await LoadCustomerData();

                // Disable the button to prevent multiple clicks.
                (sender as Button).Enabled = true;
                Logger.Info(ClassName, "Exited");
            }
        }

        /// <summary>
        /// Handle <see cref="btn_exportJson"/> button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExportJson_Click(object sender, EventArgs e)
        {
            Logger.Info(ClassName, $"Entered");
            try
            {
                // Disable the button to prevent multiple clicks.
                (sender as Button).Enabled = false;

                string inputName = string.Empty;

                // Show prompt to get the user's first name.
                using (var promptInput = new PromptInputBox("Enter first name of user", typeof(string)))
                {
                    if (DialogResult.OK == promptInput.ShowDialog())
                    {
                        inputName = promptInput.Value.Trim();
                        Logger.Info(ClassName, $"input from prompt dialog: {inputName}");
                    }
                }

                // Determine if the input is empty or not.
                if (string.IsNullOrEmpty(inputName))
                {
                    MessageBox.Show("First name cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dgCustomers.DataSource is BindingSource source &&
                    source.DataSource is List<Customer> customers &&
                    customers.Any())
                {
                    // Get all customers, filter by first name (ignore case)
                    var filteredRecord = customers.Where(c => c.FirstName.Equals(inputName, StringComparison.OrdinalIgnoreCase));
                    if (!filteredRecord.Any())
                    {
                        MessageBox.Show("No matching customers found!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Prompt for file location.
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "JSON files (*.json)|*.json";
                        saveFileDialog.Title = "Save JSON File";
                        saveFileDialog.FileName = $"Customers_{inputName}.json";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Serialize to JSON.
                            string json = JsonSerializer.Serialize(filteredRecord, new JsonSerializerOptions { WriteIndented = true });

                            // Write to file.
                            File.WriteAllText(saveFileDialog.FileName, json);
                            MessageBox.Show($"Customer data exported successfully at Location: {saveFileDialog.FileName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
            finally
            {
                (sender as Button).Enabled = true;
                Logger.Info(ClassName, "Exited");
            }
        }

        /// <summary>
        /// Handle <see cref="btn_searchByAge"/> button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_searchByAge_Click(object sender, EventArgs e)
        {
            Logger.Info(ClassName, $"Entered");
            try
            {
                // Disable the button to prevent multiple clicks.
                (sender as Button).Enabled = false;

                string inputValue = string.Empty;

                // Show prompt to get the user's first name.
                using (var promptInput = new PromptInputBox("Enter maximum age", typeof(int)))
                {
                    if (DialogResult.OK == promptInput.ShowDialog())
                    {
                        inputValue = promptInput.Value.Trim();
                    }
                }

                // Determine if the input is empty or not.
                if (string.IsNullOrEmpty(inputValue) || !int.TryParse(inputValue, out int maxAge))
                {
                    MessageBox.Show("Invalid age entered!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dgCustomers.DataSource is BindingSource source &&
                    source.DataSource is List<Customer> customers &&
                    customers.Any())
                {
                    // Get all customers, filter by age using LINQ.
                    var filteredRecord = customers.Where(c => c.Age <= maxAge).ToList();
                    if (!filteredRecord.Any())
                    {
                        MessageBox.Show("No matching customers found!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Display the filtered list in DataGridView
                    BindCustomerData(filteredRecord);
                    source.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
            finally
            {
                (sender as Button).Enabled = true;
                Logger.Info(ClassName, "Exited");
            }
        }

        /// <summary>
        /// Handle <see cref="btn_resetGrid"/> button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Btn_resetGrid_Click(object sender, EventArgs e) => await LoadCustomerData();

        /// <summary>
        /// Handled <see cref="dgCustomers"/> dataGridView CellContent Click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private async void DgCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Logger.Info(ClassName, $"Entered, Clicked Cell of row:{e.RowIndex}, col:{e.ColumnIndex}");

            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == dgCustomers.Columns["SetPassword"].Index)
                {
                    Customer customer = dgCustomers.Rows[e.RowIndex].DataBoundItem as Customer;
                    if (customer != null)
                    {
                        customer.SetPassword("Password");

                        // Update in DB (Async)
                        await _customerService.UpdateCustomerAsync(customer);

                        dgCustomers.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
            finally
            {
                Logger.Info(ClassName, "Exited");
            }
        }

        /// <summary>
        /// Triggered when the form is closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Unsubscribe event to avoid resource .
            dgCustomers.CellContentClick -= DgCustomers_CellContentClick;
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
                // Unsubscribe event to avoid multiple bindings
                dgCustomers.CellContentClick -= DgCustomers_CellContentClick;

                // Bind the data to the grid.
                BindingSource bindingSource = new BindingSource
                {
                    DataSource = customers
                };

                dgCustomers.DataSource = bindingSource;

                // Make some columns readonly.
                dgCustomers.Columns["LastPurchaseDate"].ReadOnly = true;
                dgCustomers.Columns["LastUpdateDate"].ReadOnly = true;
                dgCustomers.Columns["Password"].ReadOnly = true;
                dgCustomers.Columns["Salt"].ReadOnly = true;

                // Add SetPassword button to each record.
                if (dgCustomers.Columns["SetPassword"] == null) // Avoid duplicate columns
                {
                    DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn
                    {
                        Name = "SetPassword",
                        HeaderText = "Set Password",
                        Text = "Set Password",
                        UseColumnTextForButtonValue = true
                    };
                    dgCustomers.Columns.Add(btnColumn);
                }

                // Subscribe to the event to perform specific action on cell click.
                dgCustomers.CellContentClick += DgCustomers_CellContentClick;
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
                    lbl_recordVal.Text = customers.Count().ToString();
                    Logger.Info(ClassName, $"{customers.Count()} records fetched successfully.");
                }
                else
                    Logger.Info(ClassName, "No records found.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
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
            }
            finally
            {
                Logger.Info(ClassName, "Exited");
            }
            return customers;
        }

        #endregion

        /// <summary>
        /// Handle key down event to prevent copy/paste.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGCustomers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.Equals(Keys.C) || e.KeyCode.Equals(Keys.V))
            {
                // TODO: filter Cell here, and only prevent password and salt. 
                // that part is not given in requirement though.

                // Prevent copy/paste
                e.SuppressKeyPress = true;
            }
        }
    }
}
