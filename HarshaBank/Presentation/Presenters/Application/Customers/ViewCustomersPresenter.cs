using HarshaBank.DataAccessLayer;
using HarshaBank.Entities;
using HarshaBank.Presentation.Views.Application.Customers;

namespace HarshaBank.Presentation.Presenters.Application.Customers
{
    /// <summary>
    /// Workflow for viewing all active customers.
    /// </summary>
    internal class ViewCustomersPresenter : IApplicationModePresenter
    {
        private readonly IViewCustomersView _view;
        private readonly ICustomersDataAccessLayer _dataLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewCustomersPresenter"/> class.
        /// </summary>
        /// <param name="view">
        /// View used to interact with the user.
        /// </param>
        /// <param name="dataLayer">
        /// Data layer used to access customer data.
        /// </param>
        public ViewCustomersPresenter(IViewCustomersView view, ICustomersDataAccessLayer dataLayer)
        {
            _view = view;
            _dataLayer = dataLayer;
        }

        /// <inheritdoc />
        public ApplicationMode Mode => ApplicationMode.ViewCustomers;

        /// <inheritdoc />
        public ApplicationMode Enter()
        {
            _view.DisplayTitle();

            List<Customer> customers = _dataLayer.GetCustomers();
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
