using HarshaBank.Entities;

namespace HarshaBank.Presentation.Views.Application.Customers
{
    /// <summary>
    /// View contract for <see cref="HarshaBank.Presentation.Presenters.Application.Customers.SearchCustomersPresenter"/>.
    /// </summary>
    internal interface ISearchCustomersView
    {
        /// <summary>
        /// Displays the view title.
        /// </summary>
        void DisplayTitle();

        /// <summary>
        ///  Inputs a search term from the user.
        /// </summary>
        /// <returns>
        /// The search term or null if the user cancelled the search.
        /// </returns>
        string? InputSearchTerm();

        /// <summary>
        /// Displays the search results.
        /// </summary>
        /// <param name="customers">
        /// The customers to be displayed.
        /// </param>
        void DisplayCustomers(IReadOnlyList<Customer> customers);

        /// <summary>
        /// Displays a message that the operation was cancelled.
        /// </summary>
        void DisplayOperationCancelled();

        /// <summary>
        /// Displays a message that no matching customers were found.
        /// </summary>
        void DisplayNoCustomersFound();
    }
}
