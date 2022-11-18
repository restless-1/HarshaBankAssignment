using HarshaBank.DataAccessLayer;
using HarshaBank.Entities;
using HarshaBank.Events;
using HarshaBank.Exceptions;
using HarshaBank.Presentation.Views.Application.Customers;

namespace HarshaBank.Presentation.Presenters.Application.Customers
{
    /// <summary>
    /// Workflow for updating an existing customer.
    /// </summary>
    internal class UpdateCustomerPresenter : IApplicationModePresenter
    {
        private readonly IUpdateCustomerView _view;
        private readonly IPublisher _publisher;
        private readonly ICustomersDataAccessLayer _dataLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCustomerPresenter"/> class.
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
        public UpdateCustomerPresenter(IUpdateCustomerView view,
                                       IPublisher publisher,
                                       ICustomersDataAccessLayer dataLayer)
        {
            _view = view;
            _publisher = publisher;
            _dataLayer = dataLayer;
        }

        /// <inheritdoc />
        public ApplicationMode Mode => ApplicationMode.UpdateCustomer;

        /// <inheritdoc />
        public ApplicationMode Enter()
        {
            _view.DisplayTitle();

            // Select the customer to update
            Customer? customer = _publisher.RequestUserInput<Customer>(this);
            if (customer == null)
            {
                _view.DisplayOperationCancelled();
                return ApplicationMode.CustomersMenu;
            }

            // Input updated customer data
            Customer? edititCustomer = _view.EditCustomer(customer);
            if (edititCustomer == null)
            {
                _view.DisplayOperationCancelled();
                return ApplicationMode.CustomersMenu;
            }

            // Save the customer
            try
            {
                _dataLayer.UpdateCustomer(edititCustomer);
                _view.DisplayCustomerUpdated();
            }
            catch (CustomerNotFoundException)
            {
                _view.DisplayCustomerNotFound();
            }

            return ApplicationMode.CustomersMenu;
        }
    }
}
