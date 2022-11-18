using HarshaBank.Entities;

namespace HarshaBank.Presentation.Views.Application.Accounts
{
    /// <summary>
    /// View contract for <see cref="HarshaBank.Presentation.Presenters.Application.Accounts.AddAccountPresenter"/>.
    /// </summary>
    internal interface IAddAccountView
    {
        /// <summary>
        /// Displays the view title.
        /// </summary>
        void DisplayTitle();

        /// <summary>
        /// Inputs account data.
        /// </summary>
        /// <returns>
        /// Account data or null if the user cancelled the operation.
        /// </returns>
        Account? InputAccount();

        /// <summary>
        /// Displays a message that the operation was cancelled.
        /// </summary>
        void DisplayOperationCancelled();

        /// <summary>
        /// Displays a message that the account was added.
        /// </summary>
        /// <param name="accountCode">
        /// Code of the added account.
        /// </param>
        void DisplayAccountAdded(long? accountCode);
    }
}
