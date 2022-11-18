using HarshaBank.Entities;

namespace HarshaBank.Presentation.Views.Application.Customers
{
    /// <summary>
    /// View contract for <see cref="HarshaBank.Presentation.Presenters.Application.Customers.ViewCustomersPresenter"/>.
    /// </summary>
    internal interface IViewCustomersView
    {
        /// <summary>
        /// Displays the view title.
        /// </summary>
        void DisplayTitle();

        /// <summary>
        /// Displays the customers.
        /// </summary>
        /// <param name="customers">
        /// The customers to be displayed.
        /// </param>
        void DisplayCustomers(IReadOnlyList<Customer> customers);

        /// <summary>
        /// Displays a message that no active customers exist.
        /// </summary>
        void DisplayNoCustomersFound();
    }
}
