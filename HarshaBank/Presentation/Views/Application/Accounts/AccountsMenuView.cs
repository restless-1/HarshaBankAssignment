using HarshaBank.Presentation.Controls;
using HarshaBank.Presentation.Views.Formatting;

namespace HarshaBank.Presentation.Views.Application.Accounts
{
    /// <summary>
    /// View implementation for <see cref="HarshaBank.Presentation.Presenters.Application.Accounts.AccountsMenuPresenter"/>.
    /// </summary>
    internal class AccountsMenuView : IMenuView<AccountsMenuAction>
    {
        private readonly MenuControl<AccountsMenuAction> _menuControl;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsMenuView"/> class.
        /// </summary>
        public AccountsMenuView()
        {
            _menuControl = new MenuControl<AccountsMenuAction>(
                                new MenuItem<AccountsMenuAction>[]
                {
                    new MenuItem<AccountsMenuAction>
                    {
                        Id = 1,
                        Name = ResourceManager.GetText("AccountsMenu_Items_AddAccount"),
                        Action = AccountsMenuAction.AddAccount
                    },
                    new MenuItem<AccountsMenuAction>
                    {
                        Id = 2,
                        Name = ResourceManager.GetText("AccountsMenu_Items_DeleteAccount"),
                        Action = AccountsMenuAction.DeleteAccount
                    },
                    new MenuItem<AccountsMenuAction>
                    {
                        Id = 3,
                        Name = ResourceManager.GetText("AccountsMenu_Items_UpdateAccount"),
                        Action = AccountsMenuAction.UpdateAccount
                    },
                    new MenuItem<AccountsMenuAction>
                    {
                        Id = 4,
                        Name = ResourceManager.GetText("AccountsMenu_Items_ViewAccounts"),
                        Action = AccountsMenuAction.ViewAccounts
                    },
                    new MenuItem<AccountsMenuAction>
                    {
                        Id = 0,
                        Name = ResourceManager.GetText("AccountsMenu_Items_Exit"),
                        Action = AccountsMenuAction.Exit
                    }
                },
                ResourceManager.GetText("AccountsMenu_Title")
            );
        }

        /// <inheritdoc />
        public AccountsMenuAction InputSelection()
        {
            return _menuControl.InputSelection();
        }
    }
}
