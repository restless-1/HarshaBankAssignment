using HarshaBank.DataAccessLayer;
using HarshaBank.Entities;
using HarshaBank.Presentation.Views.Application.Customers;

namespace HarshaBank.Presentation.Presenters.Application.Customers
{
    /// <summary>
    /// Workflow for searching for customers with a search term.
    /// </summary>
    internal class SearchCustomersPresenter : IApplicationModePresenter
    {
        private readonly ISearchCustomersView _view;
        private readonly ICustomersDataAccessLayer _dataLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchCustomersPresenter"/> class.
        /// </summary>
        /// <param name="view">
        /// View used to interact with the user.
        /// </param>
        /// <param name="dataLayer">
        /// Data layer used to access customer data.
        /// </param>
        public SearchCustomersPresenter(ISearchCustomersView view, ICustomersDataAccessLayer dataLayer)
        {
            _view = view;
            _dataLayer = dataLayer;
        }

        /// <inheritdoc />
        public ApplicationMode Mode => ApplicationMode.SearchCustomers;

        /// <inheritdoc />
        public ApplicationMode Enter()
        {
            _view.DisplayTitle();

            // Input the search term
            string? searchTerm = _view.InputSearchTerm();
            if (string.IsNullOrEmpty(searchTerm))
            {
                _view.DisplayOperationCancelled();
                return ApplicationMode.CustomersMenu;
            }

            // Search for and display matching customers
            List<Customer> customers = _dataLayer.FindCustomers(searchTerm);
            if (customers.Count == 0)
            {
                _view.DisplayNoCustomersFound();
            }
            else
            {
                _view.DisplayCustomers(customers);
            }

            return ApplicationMode.CustomersMenu;
        }
    }
}

