using HarshaBank.Entities;
using HarshaBank.Presentation.Controls;
using HarshaBank.Presentation.Views.Formatting;

namespace HarshaBank.Presentation.Views.Application.Accounts
{
    /// <summary>
    /// View implementation for <see cref="HarshaBank.Presentation.Presenters.Application.Accounts.ViewAccountsPresenter"/>.
    /// </summary>
    internal class ViewAccountsView : IViewAccountsView
    {
        private readonly SelectControl<AccountListItem> _listControl;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewAccountsView"/> class.
        /// </summary>
        public ViewAccountsView()
        {
            _listControl = new SelectControl<AccountListItem>(
                new SelectOptions()
                {
                    Title = ResourceManager.GetText("ViewAccounts_Title"),
                    PageSize = 2,
                    DisableSelection = true
                }
            );
        }

        /// <inheritdoc />
        public void DisplayTitle()
        {
            Dialog.Title(TitleType.Mode, ResourceManager.GetText("ViewAccounts_Title"));
        }

        /// <inheritdoc />
        public void DisplayNoAccountsFound()
        {
            Dialog.Notify(ResourceManager.GetText("ViewAccounts_Notifications_NoMatches"));
        }

        /// <inheritdoc />
        public void DisplayAccounts(IReadOnlyList<AccountListItem> accounts)
        {
            _listControl.Display(accounts);
        }
    }
}
