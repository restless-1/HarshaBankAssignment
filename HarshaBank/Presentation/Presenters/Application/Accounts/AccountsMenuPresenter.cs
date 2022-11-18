using HarshaBank.Presentation.Views.Application;
using HarshaBank.Presentation.Views.Application.Accounts;

namespace HarshaBank.Presentation.Presenters.Application.Accounts
{
    /// <summary>
    /// Workflow for the accounts application submenu.
    /// </summary>
    internal class AccountsMenuPresenter : IApplicationModePresenter
    {
        private readonly IMenuView<AccountsMenuAction> _view;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsMenuPresenter"/> class.
        /// </summary>
        /// <param name="view">
        /// View used to interact with the user.
        /// </param>
        public AccountsMenuPresenter(IMenuView<AccountsMenuAction> view)
        {
            _view = view;
        }

        /// <inheritdoc />
        public ApplicationMode Mode => ApplicationMode.AccountsMenu;

        /// <inheritdoc />
        public ApplicationMode Enter()
        {
            AccountsMenuAction action = _view.InputSelection();

            return action switch
            {
                AccountsMenuAction.Exit => ApplicationMode.MainMenu,
                AccountsMenuAction.AddAccount => ApplicationMode.AddAccount,
                AccountsMenuAction.DeleteAccount => ApplicationMode.DeleteAccount,
                AccountsMenuAction.UpdateAccount => ApplicationMode.UpdateAccount,
                AccountsMenuAction.ViewAccounts => ApplicationMode.ViewAccounts,
                _ => throw new InvalidOperationException($"Unsupported accounts menu action: {Enum.GetName(action)}")
            };
        }
    }
}
