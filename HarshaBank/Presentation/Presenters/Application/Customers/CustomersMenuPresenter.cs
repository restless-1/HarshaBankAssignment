using HarshaBank.Presentation.Views.Application;
using HarshaBank.Presentation.Views.Application.Customers;

namespace HarshaBank.Presentation.Presenters.Application.Customers
{
    /// <summary>
    /// Workflow for the customers application submenu.
    /// </summary>
    internal class CustomersMenuPresenter : IApplicationModePresenter
    {
        private readonly IMenuView<CustomersMenuAction> _view;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersMenuPresenter"/> class.
        /// </summary>
        /// <param name="view">
        /// View used to interact with the user.
        /// </param>
        public CustomersMenuPresenter(IMenuView<CustomersMenuAction> view)
        {
            _view = view;
        }

        /// <inheritdoc />
        public ApplicationMode Mode => ApplicationMode.CustomersMenu;

        /// <inheritdoc />
        public ApplicationMode Enter()
        {
            CustomersMenuAction action = _view.InputSelection();

            return action switch
            {
                CustomersMenuAction.Exit => ApplicationMode.MainMenu,
                CustomersMenuAction.AddCustomer => ApplicationMode.AddCustomer,
                CustomersMenuAction.DeleteCustomer => ApplicationMode.DeleteCustomer,
                CustomersMenuAction.UpdateCustomer => ApplicationMode.UpdateCustomer,
                CustomersMenuAction.SearchCustomers => ApplicationMode.SearchCustomers,
                CustomersMenuAction.ViewCustomers => ApplicationMode.ViewCustomers,
                _ => throw new InvalidOperationException($"Unsupported customers menu action: {Enum.GetName(action)}")
            };
        }
    }
}
