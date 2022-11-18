using HarshaBank.Presentation.Controls;
using HarshaBank.Presentation.Views.Formatting;

namespace HarshaBank.Presentation.Views.Application.Customers
{
    /// <summary>
    /// View implementation for <see cref="HarshaBank.Presentation.Presenters.Application.Customers.CustomersMenuPresenter"/>.
    /// </summary>
    internal class CustomersMenuView : IMenuView<CustomersMenuAction>
    {
        private readonly MenuControl<CustomersMenuAction> _menuControl;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersMenuView"/> class.
        /// </summary>
        public CustomersMenuView()
        {
            _menuControl = new MenuControl<CustomersMenuAction>(
                new MenuItem<CustomersMenuAction>[]
                {
                    new MenuItem<CustomersMenuAction>
                    {
                        Id = 1,
                        Name = ResourceManager.GetText("CustomersMenu_Items_AddCustomer"),
                        Action = CustomersMenuAction.AddCustomer
                    },
                    new MenuItem<CustomersMenuAction>
                    {
                        Id = 2,
                        Name = ResourceManager.GetText("CustomersMenu_Items_DeleteCustomer"),
                        Action = CustomersMenuAction.DeleteCustomer
                    },
                    new MenuItem<CustomersMenuAction>
                    {
                        Id = 3,
                        Name = ResourceManager.GetText("CustomersMenu_Items_UpdateCustomer"),
                        Action = CustomersMenuAction.UpdateCustomer
                    },
                    new MenuItem<CustomersMenuAction>
                    {
                        Id = 4,
                        Name = ResourceManager.GetText("CustomersMenu_Items_SearchCustomers"),
                        Action = CustomersMenuAction.SearchCustomers
                    },
                    new MenuItem<CustomersMenuAction>
                    {
                        Id = 5,
                        Name = ResourceManager.GetText("CustomersMenu_Items_ViewCustomers"),
                        Action = CustomersMenuAction.ViewCustomers
                    },
                    new MenuItem<CustomersMenuAction>
                    {
                        Id = 0,
                        Name = ResourceManager.GetText("CustomersMenu_Items_Exit"),
                        Action = CustomersMenuAction.Exit
                    }
                },
                ResourceManager.GetText("CustomersMenu_Title")
            );
        }

        /// <inheritdoc />
        public CustomersMenuAction InputSelection()
        {
            return _menuControl.InputSelection();
        }
    }
}
