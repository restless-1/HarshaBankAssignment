using HarshaBank.DataAccessLayer;
using HarshaBank.Entities;
using HarshaBank.Events;
using HarshaBank.Exceptions;
using HarshaBank.Presentation.Views.Application.Customers;

namespace HarshaBank.Presentation.Presenters.Application.Customers
{
    /// <summary>
    /// Workflow for deleting an existing customer.
    /// </summary>
    internal class DeleteCustomerPresenter : IApplicationModePresenter
    {
        private readonly IDeleteCustomerView _view;
        private readonly IPublisher _publisher;
        private readonly ICustomersDataAccessLayer _dataLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCustomerPresenter"/> class.
        /// </summary>
        /// <param name="view">
        /// View used to interact with the user.
        /// </param>
        /// <param name="publisher">
        /// Publisher used to request customer selection.
        /// </param>
        /// <param name="dataLayer">
        /// Data layer used to access customer data.
        /// </param>
        public DeleteCustomerPresenter(IDeleteCustomerView view,
                                       IPublisher publisher,
                                       ICustomersDataAccessLayer dataLayer)
        {
            _view = view;
            _publisher = publisher;
            _dataLayer = dataLayer;
        }

        /// <inheritdoc />
        public ApplicationMode Mode => ApplicationMode.DeleteCustomer;

        /// <inheritdoc />
        public ApplicationMode Enter()
        {
            _view.DisplayTitle();

            // Get the customer to be deleted
            Customer? customer = _publisher.RequestUserInput<Customer>(this);
            if (customer == null || !_view.Confirm(customer))
            {
                _view.DisplayOperationCancelled();
                return ApplicationMode.CustomersMenu;
            }

            // Delete the customer
            try
            {
                if (_dataLayer.DeleteCustomer(customer.CustomerId))
                {
                    _view.DisplayCustomerDeleted();
                }
                else
                {
                    _view.DisplayCustomerNotFound();
                }
            }
            catch (CustomerHasActiveAccountsException)
            {
                _view.DisplayActiveAccountsError();
            }

            return ApplicationMode.CustomersMenu;
        }
    }
}

