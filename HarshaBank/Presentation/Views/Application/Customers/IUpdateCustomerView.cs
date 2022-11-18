using HarshaBank.Entities;

namespace HarshaBank.Presentation.Views.Application.Customers
{
    /// <summary>
    /// View contract for <see cref="HarshaBank.Presentation.Presenters.Application.Customers.UpdateCustomerPresenter"/>.
    /// </summary>
    internal interface IUpdateCustomerView
    {
        /// <summary>
        /// Displays the view title.
        /// </summary>
        void DisplayTitle();

        /// <summary>
        /// Inputs customer data.
        /// </summary>
        /// <param name="customer">
        /// The current customer data.
        /// </param>
        /// <returns>
        /// The edited customer data or null if the user cancelled the edit.
        /// </returns>
        Customer? EditCustomer(Customer customer);

        /// <summary>
        /// Displays a message that the customer was successfully updated.
        /// </summary>
        void DisplayCustomerUpdated();

        /// <summary>
        /// Displays a message that the operation was cancelled.
        /// </summary>
        void DisplayOperationCancelled();

        /// <summary>
        /// Displays a message that the customer was not found.
        /// </summary>
        void DisplayCustomerNotFound();
    }
}
