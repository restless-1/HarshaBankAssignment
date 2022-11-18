using HarshaBank.Entities;

namespace HarshaBank.Presentation.Views.Application.Accounts
{
    /// <summary>
    /// View contract for <see cref="HarshaBank.Presentation.Presenters.Application.Accounts.UpdateAccountPresenter"/>.
    /// </summary>
    internal interface IUpdateAccountView
    {
        /// <summary>
        /// Displays the view title.
        /// </summary>
        void DisplayTitle();

        /// <summary>
        /// Inputs account data.
        /// </summary>
        /// <param name="account">
        /// The current account data.
        /// </param>
        /// <returns>
        /// The edited account data or null if the user cancelled the edit.
        /// </returns>
        Account? EditAccount(Account account);

        /// <summary>
        /// Displays a message that the account was successfully edited.
        /// </summary>
        void DisplayAccountUpdated();

        /// <summary>
        /// Displays a message that the operation was cancelled.
        /// </summary>
        void DisplayOperationCancelled();

        /// <summary>
        /// Displays a message that the account was not found.
        /// </summary>
        void DisplayAccountNotFound();
    }
}
