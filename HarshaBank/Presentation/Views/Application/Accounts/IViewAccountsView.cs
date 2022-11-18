using HarshaBank.Entities;

namespace HarshaBank.Presentation.Views.Application.Accounts
{
    /// <summary>
    /// View contract for <see cref="HarshaBank.Presentation.Presenters.Application.Accounts.ViewAccountsPresenter"/>.
    /// </summary>
    internal interface IViewAccountsView
    {
        /// <summary>
        /// Displays the view title.
        /// </summary>
        void DisplayTitle();

        /// <summary>
        /// Displays all active accounts.
        /// </summary>
        /// <param name="accounts">
        /// Accounts to be displayed.
        /// </param>
        void DisplayAccounts(IReadOnlyList<AccountListItem> accounts);

        /// <summary>
        /// Displays a message that there are no active accounts.
        /// </summary>
        void DisplayNoAccountsFound();
    }
}
