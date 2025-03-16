using ClientSync.Services.Interfaces;
using System;
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

        #region Private Methods

        /// <summary>
        /// Load customer data when the form is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MainWindow_Load(object sender, EventArgs e)
        {
            try
            {
                var customers = await _customerService.GetAllCustomersAsync();
                dgCustomers.DataSource = new BindingSource { DataSource = customers };
                tsp_lbl_recordCountVal.Text = $"{customers.Count()} |";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 

        #endregion
    }
}
