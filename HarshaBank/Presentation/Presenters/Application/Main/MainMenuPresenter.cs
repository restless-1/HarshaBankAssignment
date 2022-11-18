using HarshaBank.Presentation.Views.Application;
using HarshaBank.Presentation.Views.Application.Main;

namespace HarshaBank.Presentation.Presenters.Application.Main
{
    /// <summary>
    /// Workflow for the main application menu.
    /// </summary>
    internal class MainMenuPresenter : IApplicationModePresenter
    {
        private readonly IMenuView<MainMenuAction> _view;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenuPresenter"/> class.
        /// </summary>
        /// <param name="view">
        /// View used to interact with the user.
        /// </param>
        public MainMenuPresenter(IMenuView<MainMenuAction> view)
        {
            _view = view;
        }

        /// <inheritdoc />
        public ApplicationMode Mode => ApplicationMode.MainMenu;

        /// <inheritdoc />
        public ApplicationMode Enter()
        {
            MainMenuAction action = _view.InputSelection();

            return action switch
            {
                MainMenuAction.Exit => ApplicationMode.Exit,
                MainMenuAction.Customers => ApplicationMode.CustomersMenu,
                MainMenuAction.Accounts => ApplicationMode.AccountsMenu,
                MainMenuAction.FundsTransfer => ApplicationMode.FundsTransfer,
                MainMenuAction.FundsTransferStatement => ApplicationMode.FundsTransferStatement,
                MainMenuAction.AccountStatement => ApplicationMode.AccountStatement,
                MainMenuAction.Configuration => ApplicationMode.Configuration,
                _ => throw new InvalidOperationException($"Unsupported main menu action: {action}")
            };
        }
    }
}
