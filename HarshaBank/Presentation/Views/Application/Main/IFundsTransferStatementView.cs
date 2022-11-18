using HarshaBank.Entities;

namespace HarshaBank.Presentation.Views.Application.Main
{
    /// <summary>
    /// View contract for <see cref="HarshaBank.Presentation.Presenters.Application.Main.FundsTransferStatementPresenter"/>.
    /// </summary>
    internal interface IFundsTransferStatementView
    {
        /// <summary>
        /// Displays the view title.
        /// </summary>
        void DisplayTitle();

        /// <summary>
        /// Inputs the start date from the user.
        /// </summary>
        /// <param name="defaultStartDate">
        /// The default start date to use if the user presses enter.
        /// </param>
        /// <returns>
        /// The start date or null if the user cancelled the funds transfer statement.
        /// </returns>
        DateTime? InputStartDate(DateTime defaultStartDate);

        /// <summary>
        /// Inputs the end date from the user.
        /// </summary>
        /// <param name="defaultEndDate">
        /// The default end date to use if the user presses enter.
        /// </param>
        /// <returns>
        /// The end date or null if the user cancelled the funds transfer statement.
        /// </returns>
        DateTime? InputEndDate(DateTime defaultEndDate);

        /// <summary>
        /// Displays the funds transfer statement.
        /// </summary>
        /// <param name="startDate">
        /// Start date of the statement.
        /// </param>
        /// <param name="endDate">
        /// End date of the statement.
        /// </param>
        /// <param name="transactions">
        /// The transactions to report.
        /// </param>
        void DisplayStatement(DateTime startDate, DateTime endDate, List<Transaction> transactions);

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
