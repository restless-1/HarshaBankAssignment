using HarshaBank.Entities;

namespace HarshaBank.Presentation.Views.Application.Main
{
    /// <summary>
    /// View contract for <see cref="HarshaBank.Presentation.Presenters.Application.Main.FundsTransferPresenter"/>.
    /// </summary>
    internal interface IFundsTransferView
    {
        /// <summary>
        /// Displays the view title.
        /// </summary>
        void DisplayTitle();

        /// <summary>
        /// Displays the label to be displayed when the user needs to select the source account.
        /// </summary>
        void DisplaySourceAccountLabel();

        /// <summary>
        /// Displays the label to be displayed when the user needs to select the destination account.
        /// </summary>
        void DisplayDestinationAccountLabel();

        /// <summary>
        /// Inputs the transfer amount from the user.
        /// </summary>
        /// <param name="currentBalance">
        /// The current balance of the source account.
        /// </param>
        /// <returns>
        /// The amount of the transfer (0 to cancel the transfer).
        /// </returns>
        decimal InputAmount(decimal currentBalance);

        /// <summary>
        /// Inputs the transfer description.
        /// </summary>
        /// <returns>
        /// The transfer description or null if the user cancelled the transfer.
        /// </returns>
        string? InputDescription();

        /// <summary>
        /// Prompts the user for transfer confirmation.
        /// </summary>
        /// <param name="amount">
        /// Amount being transferred.
        /// </param>
        /// <returns>
        /// true if the user confirmed the transfer; false otherwise.
        /// </returns>
        bool Confirm(decimal amount);

        /// <summary>
        /// Displays a message that the funds were transferred.
        /// </summary>
        /// <param name="transaction">
        /// A transaction containing the transfer details.
        /// </param>
        void DisplayFundsTransferred(Transaction transaction);

        /// <summary>
        /// Displays a message that the operation was cancelled.
        /// </summary>
        void DisplayOperationCancelled();

        /// <summary>
        /// Displays a message that the source account has insufficient funds to
        /// complete the transfer.
        /// </summary>
        void DisplayInsufficientFunds();

        /// <summary>
        /// Displays a message that the transfer cannot be performed because the
        /// source and destination accounts are the same.
        /// </summary>
        void DisplaySourceAndDestinationAccountsAreTheSame();
    }
}
