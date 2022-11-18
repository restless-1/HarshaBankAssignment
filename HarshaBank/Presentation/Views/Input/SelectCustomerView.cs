using HarshaBank.Entities;
using HarshaBank.Presentation.Controls;
using HarshaBank.Presentation.Views.Formatting;

namespace HarshaBank.Presentation.Views.Input
{
    /// <summary>
    /// View implementation for <see cref="HarshaBank.Presentation.Presenters.Input.SelectCustomerPresenter"/>.
    /// </summary>
    internal class SelectCustomerView : ISelectCustomerView
    {
        private readonly SelectControl<Customer> _selectControl;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectAccountView"/> class.
        /// </summary>
        public SelectCustomerView()
        {
            _selectControl = new SelectControl<Customer>(
                new SelectOptions()
                {
                    Title = ResourceManager.GetText("SelectCustomer_Title"),
                    PageSize = 2
                }
            );
        }

        /// <inheritdoc />
        public string? InputSearchTerm()
        {
            return Dialog.Prompt(ResourceManager.GetText("SelectCustomer_Prompts_SearchTerm"));
        }

        /// <inheritdoc />
        public Customer? InputSelection(IReadOnlyList<Customer> customers)
        {
            return _selectControl.Display(customers);
        }

        /// <inheritdoc />
        public void DisplayCustomerSelected(Customer customer)
        {
            Dialog.Notify(ResourceManager.GetText("SelectCustomer_Notifications_Selected", customer.CustomerCode, customer.CustomerName));
        }

        /// <inheritdoc />
        public void DisplayCustomerNotFound()
        {
            Dialog.Notify(ResourceManager.GetText("SelectCustomer_Errors_NotFound"));
        }

        /// <inheritdoc />
        public void DisplayNoMatchingCustomersFound()
        {
            Dialog.Notify(ResourceManager.GetText("SelectCustomer_Notifications_NoMatches"));
        }
    }
}
