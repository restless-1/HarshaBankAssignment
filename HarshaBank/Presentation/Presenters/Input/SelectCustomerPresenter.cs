using HarshaBank.DataAccessLayer;
using HarshaBank.Entities;
using HarshaBank.Exceptions;
using HarshaBank.Presentation.Views.Input;

namespace HarshaBank.Presentation.Presenters.Input
{
    /// <summary>
    /// Presenter which prompts the user to input or select a customer.
    /// </summary>
    internal class SelectCustomerPresenter : IUserInputPresenter
    {
        private readonly ISelectCustomerView _view;
        private readonly ICustomersDataAccessLayer _dataLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectCustomerPresenter"/> class.
        /// </summary>
        /// <param name="view">
        /// View used to interact with the user.
        /// </param>
        /// <param name="dataLayer">
        /// Data layer used to access stored data.
        /// </param>
        public SelectCustomerPresenter(ISelectCustomerView view, ICustomersDataAccessLayer dataLayer)
        {
            _view = view;
            _dataLayer = dataLayer;
        }

        /// <inheritdoc />
        public Type Type => typeof(Customer);

        /// <inheritdoc />
        public object? Execute(object? data = null)
        {
            string? searchTerm = string.IsNullOrEmpty(data as string) ? _view.InputSearchTerm() : (string)data;
            if (string.IsNullOrEmpty(searchTerm))
            {
                return null;
            }

            Customer? customer = GetCustomer(searchTerm);
            if (customer != null)
            {
                _view.DisplayCustomerSelected(customer);
            }
            return customer;
        }

        /// <summary>
        /// Gets the user's customer selection.
        /// </summary>
        /// <param name="searchTerm">
        /// Search term entered by the user.
        /// </param>
        /// <returns>
        /// Customer selected by the user or null if the user cancels customer selection.
        /// </returns>
        private Customer? GetCustomer(string searchTerm)
        {
            if (long.TryParse(searchTerm, out long code))
            {
                return GetCustomerByCode(code);
            }

            return SelectCustomerFromSearchResults(searchTerm);
        }

        /// <summary>
        /// Retrieves a specific customer by code.
        /// </summary>
        /// <param name="code">
        /// Code of the customer to retrieve.
        /// </param>
        /// <returns>
        /// The specified customer or null if the customer does not exist.
        /// </returns>
        private Customer? GetCustomerByCode(long code)
        {
            try
            {
                return _dataLayer.GetCustomer(code);
            }
            catch (CustomerNotFoundException)
            {
                _view.DisplayCustomerNotFound();
                return null;
            }
        }

        /// <summary>
        /// Allows the user to select an customer from a list of search results.
        /// </summary>
        /// <param name="searchTerm">
        /// Search term entered by the user.
        /// </param>
        /// <returns>
        /// Customer selected by the user or null if the user cancels customer selection.
        /// </returns>
        private Customer? SelectCustomerFromSearchResults(string searchTerm)
        {
            List<Customer> customers = _dataLayer.FindCustomers(searchTerm);
            if (customers.Count == 0)
            {
                _view.DisplayNoMatchingCustomersFound();
                return null;
            }

            return _view.InputSelection(customers);
        }
    }
}
