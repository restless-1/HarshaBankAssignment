using HarshaBank.Entities;
using HarshaBank.Presentation.Controls;
using HarshaBank.Presentation.Views.Formatting;

namespace HarshaBank.Presentation.Views.Application.Customers
{
    /// <summary>
    /// View implementation for <see cref="HarshaBank.Presentation.Presenters.Application.Customers.AddCustomerPresenter"/>.
    /// </summary>
    internal class AddCustomerView : IAddCustomerView
    {
        private readonly FormControl<Customer> _inputCustomerControl;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddCustomerView"/> class.
        /// </summary>
        public AddCustomerView()
        {
            _inputCustomerControl = new FormControl<Customer>();
        }

        /// <inheritdoc />
        public void DisplayTitle()
        {
            Dialog.Title(TitleType.Mode, ResourceManager.GetText("AddCustomer_Title"));
        }

        /// <inheritdoc />
        public Customer? InputCustomer()
        {
            return _inputCustomerControl.InputData();
        }

        /// <inheritdoc />
        public void DisplayOperationCancelled()
        {
            Dialog.Notify(ResourceManager.GetText("AddCustomer_Notifications_Cancelled"));
        }

        /// <inheritdoc />
        public void DisplayCustomerAdded(long? customerCode)
        {
            Dialog.Notify(ResourceManager.GetText("AddCustomer_Notifications_Added", customerCode ?? -1));
        }
    }
}
