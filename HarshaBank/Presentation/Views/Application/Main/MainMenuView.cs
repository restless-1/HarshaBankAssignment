using HarshaBank.Presentation.Controls;
using HarshaBank.Presentation.Views.Formatting;

namespace HarshaBank.Presentation.Views.Application.Main
{
    /// <summary>
    /// View implementation for <see cref="HarshaBank.Presentation.Presenters.Application.Main.MainMenuPresenter"/>.
    /// </summary>
    internal class MainMenuView : IMenuView<MainMenuAction>
    {
        private readonly MenuControl<MainMenuAction> _menuControl;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenuView"/> class.
        /// </summary>
        public MainMenuView()
        {
            _menuControl = new MenuControl<MainMenuAction>(
                new MenuItem<MainMenuAction>[]
                {
                    new MenuItem<MainMenuAction> {
                        Id = 1,
                        Name = ResourceManager.GetText("MainMenu_Items_Customers"),
                        Action = MainMenuAction.Customers
                    },
                    new MenuItem<MainMenuAction>
                    {
                        Id = 2,
                        Name = ResourceManager.GetText("MainMenu_Items_Accounts"),
                        Action = MainMenuAction.Accounts
                    },
                    new MenuItem<MainMenuAction>
                    {
                        Id = 3,
                        Name = ResourceManager.GetText("MainMenu_Items_FundsTransfer"),
                        Action = MainMenuAction.FundsTransfer
                    },
                    new MenuItem<MainMenuAction>
                    {
                        Id = 4,
                        Name = ResourceManager.GetText("MainMenu_Items_FundsTransferStatement"),
                        Action = MainMenuAction.FundsTransferStatement
                    },
                    new MenuItem<MainMenuAction>
                    {
                        Id = 5,
                        Name = ResourceManager.GetText("MainMenu_Items_AccountStatement"),
                        Action = MainMenuAction.AccountStatement
                    },
                    new MenuItem<MainMenuAction>
                    {
                        Id = 6,
                        Name = ResourceManager.GetText("MainMenu_Items_Configuration"),
                        Action = MainMenuAction.Configuration
                    },
                    new MenuItem<MainMenuAction>
                    {
                        Id = 0,
                        Name = ResourceManager.GetText("MainMenu_Items_Exit"),
                        Action = MainMenuAction.Exit
                    }
                },
                ResourceManager.GetText("MainMenu_Title")
            );
        }

        /// <inheritdoc />
        public MainMenuAction InputSelection()
        {
            return _menuControl.InputSelection();
        }
    }
}
