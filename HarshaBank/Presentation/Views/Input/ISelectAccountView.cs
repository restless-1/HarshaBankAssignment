using HarshaBank.Entities;

namespace HarshaBank.Presentation.Views.Input
{
    /// <summary>
    /// View contract for <see cref="HarshaBank.Presentation.Presenters.Input.SelectAccountPresenter"/>.
    /// </summary>
    internal interface ISelectAccountView
    {
        /// <summary>
        /// Inputs a search term from the user.
        /// </summary>
        /// <returns>
        /// The search term or null if the user cancels the search.
        /// </returns>
        string? InputSearchTerm();

        /// <summary>
        /// Inputs an account selection from the user.
        /// </summary>
        /// <param name="accounts">
        /// The candidate accounts.
        /// </param>
        /// <returns>
        /// The selected account or null if the user cancels account selection.
        /// </returns>
        Account? InputSelection(IReadOnlyList<Account> accounts);

        /// <summary>
        /// Displays a message that a account has been selected.
        /// </summary>
        /// <param name="account">
        /// The selected account.
        /// </param>
        void DisplayAccountSelected(Account account);

        /// <summary>
        /// Displays a message that the account was not found.
        /// </summary>
        void DisplayAccountNotFound();

        /// <summary>
        /// Displays a message that no accounts were found for the search term.
        /// </summary>
        void DisplayNoMatchingAccountsFound();
    }
}
