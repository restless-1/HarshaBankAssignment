using HarshaBank.Entities;
using HarshaBank.Presentation.Controls;
using HarshaBank.Presentation.Views.Formatting;

namespace HarshaBank.Presentation.Views.Application.Customers
{
    /// <summary>
    /// View implementation for <see cref="HarshaBank.Presentation.Presenters.Application.Customers.UpdateCustomerPresenter"/>.
    /// </summary>
    internal class UpdateCustomerView : IUpdateCustomerView
    {
        private readonly FormControl<Customer> _editControl;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCustomerView"/> class.
        /// </summary>
        public UpdateCustomerView()
        {
            _editControl = new FormControl<Customer>();
        }

        /// <inheritdoc />
        public void DisplayTitle()
        {
            Dialog.Title(TitleType.Mode, ResourceManager.GetText("UpdateCustomer_Title"));
        }

        /// <inheritdoc />
        public Customer? EditCustomer(Customer customer)
        {
            return _editControl.InputData(customer);
        }

        /// <inheritdoc />
        public void DisplayCustomerUpdated()
        {
            Dialog.Notify(ResourceManager.GetText("UpdateCustomer_Notifications_Updated"));
        }

        /// <inheritdoc />
        public void DisplayOperationCancelled()
        {
            Dialog.Notify(ResourceManager.GetText("UpdateCustomer_Notifications_Cancelled"));
        }

        /// <inheritdoc />
        public void DisplayCustomerNotFound()
        {
            Dialog.Error(ResourceManager.GetText("UpdateCustomer_Errors_NotFound"));
        }
    }
}
