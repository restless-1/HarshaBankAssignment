using HarshaBank.DataAccessLayer;
using HarshaBank.Entities;
using HarshaBank.Presentation.Views.Application.Customers;

namespace HarshaBank.Presentation.Presenters.Application.Customers
{
    /// <summary>
    /// Workflow for adding a new customer.
    /// </summary>
    internal class AddCustomerPresenter : IApplicationModePresenter
    {
        private readonly IAddCustomerView _view;
        private readonly ICustomersDataAccessLayer _dataLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddCustomerPresenter"/> class.
        /// </summary>
        /// <param name="view">
        /// View used to interact with the user.
        /// </param>
        /// <param name="dataLayer">
        /// Data layer used to access customer data.
        /// </param>
        public AddCustomerPresenter(IAddCustomerView view, ICustomersDataAccessLayer dataLayer)
        {
            _view = view;
            _dataLayer = dataLayer;
        }

        /// <inheritdoc />
        public ApplicationMode Mode => ApplicationMode.AddCustomer;

        /// <inheritdoc />
        public ApplicationMode Enter()
        {
            _view.DisplayTitle();

            // Input the customer data
            Customer? customer = _view.InputCustomer();
            if (customer == null)
            {
                _view.DisplayOperationCancelled();
                return ApplicationMode.CustomersMenu;
            }

            // Save the customer
            Customer savedCustomer = _dataLayer.AddCustomer(customer);
            _view.DisplayCustomerAdded(savedCustomer?.CustomerCode);
            return ApplicationMode.CustomersMenu;
        }
    }
}
