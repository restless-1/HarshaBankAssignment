using HarshaBank.Entities;

namespace HarshaBank.Presentation.Views.Application.Accounts
{
    /// <summary>
    /// View contract for <see cref="HarshaBank.Presentation.Presenters.Application.Accounts.DeleteAccountPresenter"/>.
    /// </summary>
    internal interface IDeleteAccountView
    {
        /// <summary>
        /// Displays the view title.
        /// </summary>
        void DisplayTitle();

        /// <summary>
        /// Prompts the user for delete confirmation.
        /// </summary>
        /// <param name="account">
        /// Account to be deleted.
        /// </param>
        /// <returns>
        /// true if the user confirmed the delete; false otherwise.
        /// </returns>
        bool Confirm(Account account);

        /// <summary>
        /// Displays a message that the account was successfully deleted.
        /// </summary>
        void DisplayAccountDeleted();

        /// <summary>
        /// Displays a message that the operation was cancelled.
        /// </summary>
        void DisplayOperationCancelled();

        /// <summary>
        /// Displays a message that the account was not found.
        /// </summary>
        void DisplayAccountNotFound();

        /// <summary>
        /// Displays a message that the account cannot be deleted because it has
        /// a non-zero balance.
        /// </summary>
        void DisplayNonZeroBalanceError();
    }
}
