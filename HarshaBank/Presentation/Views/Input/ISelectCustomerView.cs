using HarshaBank.Entities;

namespace HarshaBank.Presentation.Views.Input
{
    /// <summary>
    /// View contract for <see cref="HarshaBank.Presentation.Presenters.Input.SelectCustomerPresenter"/>.
    /// </summary>
    internal interface ISelectCustomerView
    {
        /// <summary>
        /// Inputs a search term from the user.
        /// </summary>
        /// <returns>
        /// The search term or null if the user cancels the search.
        /// </returns>
        string? InputSearchTerm();

        /// <summary>
        /// Inputs a customer selection from the user.
        /// </summary>
        /// <param name="customers">
        /// The candidate customers.
        /// </param>
        /// <returns>
        /// The selected customer or null if the user cancels customer selection.
        /// </returns>
        Customer? InputSelection(IReadOnlyList<Customer> customers);

        /// <summary>
        /// Displays a message that a customer has been selected.
        /// </summary>
        /// <param name="customer">
        /// The selected customer.
        /// </param>
        void DisplayCustomerSelected(Customer customer);

        /// <summary>
        /// Displays a message that the customer was not found.
        /// </summary>
        void DisplayCustomerNotFound();

        /// <summary>
        /// Displays a message that no customers were found for the search term.
        /// </summary>
        void DisplayNoMatchingCustomersFound();
    }
}
