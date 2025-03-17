using System;
using System.Windows.Forms;

namespace ClientSync.UI.UserControls
{
    /// <summary>
    /// UserControl to get user's first name on prompt.
    /// </summary>
    public partial class PromptInputBox : Form
    {
        #region Properties

        /// <summary>
        /// Get or set the entered user name
        /// </summary>
        public string Value { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PromptInputBox(string promptTitle, Type dataType)
        {
            InitializeComponent();

            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;
            lbl_title.Text = promptTitle;
            base.DialogResult = DialogResult.No;

            if (dataType == typeof(int))
            {
                txt_inputValue.KeyPress += new KeyPressEventHandler(txt_inputValue_KeyPress);
            }
            else
            {
                txt_inputValue.KeyPress -= new KeyPressEventHandler(txt_inputValue_KeyPress);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Handled the ok button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOk_Click(object sender, System.EventArgs e)
        {
            // Set the value to the entered value
            Value = txt_inputValue.Text;

            // Remove the event handler
            txt_inputValue.KeyPress -= new KeyPressEventHandler(txt_inputValue_KeyPress);

            // Set the dialog result to OK
            base.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handled the cancel button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Cancel_Click(object sender, System.EventArgs e)
        {
            // Set the value to empty
            Value = string.Empty;

            // Remove the event handler
            txt_inputValue.KeyPress -= new KeyPressEventHandler(txt_inputValue_KeyPress);

            // Set the dialog result to Cancel
            base.DialogResult = DialogResult.Cancel;
        } 

        #endregion

        #region Event Handler

        /// <summary>
        /// Handled the key press event for the input text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_inputValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        #endregion
    }
}
