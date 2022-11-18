using HarshaBank.Entities;

namespace HarshaBank.Presentation.Views.Application.Customers
{
    /// <summary>
    /// View contract for <see cref="HarshaBank.Presentation.Presenters.Application.Customers.AddCustomerPresenter"/>.
    /// </summary>
    internal interface IAddCustomerView
    {
        /// <summary>
        /// Displays the view title.
        /// </summary>
        void DisplayTitle();

        /// <summary>
        /// Inputs customer data.
        /// </summary>
        /// <returns>
        /// Customer data or null if the user cancelled the add.
        /// </returns>
        Customer? InputCustomer();

        /// <summary>
        /// Displays a message that the operation was cancelled.
        /// </summary>
        void DisplayOperationCancelled();

        /// <summary>
        /// Displays a message that the customer was successfully added.
        /// </summary>
        /// <param name="customerCode">
        /// The code assigned to the added customer.
        /// </param>
        void DisplayCustomerAdded(long? customerCode);
    }
}
