using HarshaBank.Entities;

namespace HarshaBank.Presentation.Views.Application.Main
{
    /// <summary>
    /// View contract for <see cref="HarshaBank.Presentation.Presenters.Application.Main.AccountStatementPresenter"/>.
    /// </summary>
    internal interface IAccountStatementView
    {
        /// <summary>
        /// Displays the view title.
        /// </summary>
        void DisplayTitle();

        /// <summary>
        /// Inputs the start date from the user.
        /// </summary>
        /// <param name="defaultStartDate">
        /// The default start date if the user presses enter.
        /// </param>
        /// <returns>
        /// The start date or null if the user cancelled the account statement.
        /// </returns>
        DateTime? InputStartDate(DateTime defaultStartDate);

        /// <summary>
        /// Inputs the end date from the user.
        /// </summary>
        /// <param name="defaultEndDate">
        /// The default end date if the user presses enter.
        /// </param>
        /// <returns>
        /// The end date or null if the user cancelled the account statement.
        /// </returns>
        DateTime? InputEndDate(DateTime defaultEndDate);

        /// <summary>
        /// Displays the account statement.
        /// </summary>
        /// <param name="account">
        /// The account being reported on.
        /// </param>
        /// <param name="startDate">
        /// The start date for the statement.
        /// </param>
        /// <param name="endDate">
        /// The end date for the statement.
        /// </param>
        /// <param name="transactions">
        /// The transactions to be reported.
        /// </param>
        void DisplayReport(Account account, DateTime startDate, DateTime endDate, IReadOnlyList<Transaction> transactions);

        /// <summary>
        /// Displays a message that the operation was cancelled.
        /// </summary>
        void DisplayOperationCancelled();

        /// <summary>
        /// Displays a message that the statement cannot be created because the end date is before
        /// the start date.
        /// </summary>
        void DisplayEndDateBeforeStartDate();
    }
}
