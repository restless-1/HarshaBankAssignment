using HarshaBank.Entities;

namespace HarshaBank.Presentation.Views.Application.Customers
{
    /// <summary>
    /// View contract for <see cref="HarshaBank.Presentation.Presenters.Application.Customers.DeleteCustomerPresenter"/>.
    /// </summary>
    internal interface IDeleteCustomerView
    {
        /// <summary>
        /// Displays the view title.
        /// </summary>
        void DisplayTitle();

        /// <summary>
        /// Prompts the user for delete confirmation.
        /// </summary>
        /// <param name="customer">
        /// Customer to be deleted.
        /// </param>
        /// <returns>
        /// true if the user confirmed the delete; false otherwise.
        /// </returns>
        bool Confirm(Customer customer);

        /// <summary>
        /// Displays a message that the customer was successfully deleted.
        /// </summary>
        void DisplayCustomerDeleted();

        /// <summary>
        /// Displays a message that the operation was cancelled.
        /// </summary>
        void DisplayOperationCancelled();

        /// <summary>
        /// Displays a message that the customer was not found.
        /// </summary>
        void DisplayCustomerNotFound();

        /// <summary>
        /// Displays a message that the customer cannot be deleted because they
        /// have active associated accounts.
        /// </summary>
        void DisplayActiveAccountsError();
    }
}
