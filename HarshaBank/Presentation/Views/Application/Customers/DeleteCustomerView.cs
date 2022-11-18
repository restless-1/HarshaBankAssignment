using HarshaBank.Entities;
using HarshaBank.Presentation.Controls;
using HarshaBank.Presentation.Views.Formatting;

namespace HarshaBank.Presentation.Views.Application.Customers
{
    /// <summary>
    /// View implementation for <see cref="HarshaBank.Presentation.Presenters.Application.Customers.DeleteCustomerPresenter"/>.
    /// </summary>
    internal class DeleteCustomerView : IDeleteCustomerView
    {
        /// <inheritdoc />
        public void DisplayTitle()
        {
            Dialog.Title(TitleType.Mode, ResourceManager.GetText("DeleteCustomer_Title"));
        }

        /// <inheritdoc />
        public bool Confirm(Customer customer)
        {
            string? input = Dialog.Prompt(ResourceManager.GetText("DeleteCustomer_Prompts_Confirm", customer.CustomerCode, customer.CustomerName));
            return "yes".Equals(input, StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc />
        public void DisplayCustomerDeleted()
        {
            Dialog.Notify(ResourceManager.GetText("DeleteCustomer_Notifications_Deleted"));
        }

        /// <inheritdoc />
        public void DisplayOperationCancelled()
        {
            Dialog.Notify(ResourceManager.GetText("DeleteCustomer_Notifications_Cancelled"));
        }

        /// <inheritdoc />
        public void DisplayCustomerNotFound()
        {
            Dialog.Error(ResourceManager.GetText("DeleteCustomer_Errors_NotFound"));
        }

        /// <inheritdoc />
        public void DisplayActiveAccountsError()
        {
            Dialog.Error(ResourceManager.GetText("DeleteCustomer_Errors_ActiveAccounts"));
        }
    }
}
