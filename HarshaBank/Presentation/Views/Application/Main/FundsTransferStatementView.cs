using HarshaBank.Entities;
using HarshaBank.Presentation.Controls;
using HarshaBank.Presentation.Views.Formatting;

namespace HarshaBank.Presentation.Views.Application.Main
{
    /// <summary>
    /// View implementation for <see cref="HarshaBank.Presentation.Presenters.Application.Main.FundsTransferStatementPresenter"/>.
    /// </summary>
    internal class FundsTransferStatementView : IFundsTransferStatementView
    {
        private const int MaximumNameLength = 40;
        private readonly string _truncationIndicator = ResourceManager.GetText("FundsTransferStatement_Statement_TruncationIndicator");

        /// <inheritdoc />
        public void DisplayTitle()
        {
            Dialog.Title(TitleType.Mode, ResourceManager.GetText("FundsTransferStatement_Title"));
        }

        /// <inheritdoc />
        public DateTime? InputStartDate(DateTime defaultStartDate)
        {
            return Dialog.PromptForDate(ResourceManager.GetText("FundsTransferStatement_Prompts_StartDate", defaultStartDate), defaultStartDate);
        }

        /// <inheritdoc />
        public DateTime? InputEndDate(DateTime defaultEndDate)
        {
            return Dialog.PromptForDate(ResourceManager.GetText("FundsTransferStatement_Prompts_EndDate", defaultEndDate), defaultEndDate);
        }

        /// <inheritdoc />
        public void DisplayStatement(DateTime startDate, DateTime endDate, List<Transaction> transactions)
        {
            Console.WriteLine(ResourceManager.GetText("FundsTransferStatement_Statement_Title", startDate, endDate));

            if (transactions.Count == 0)
            {
                Console.WriteLine(ResourceManager.GetText("FundsTransferStatement_Statement_NoMatches"));
                return;
            }

            Console.WriteLine(ResourceManager.GetText("FundsTransferStatement_Statement_Header"));
            foreach (Transaction transaction in transactions)
            {
                Console.WriteLine(
                    ResourceManager.GetText(
                        "FundsTransferStatement_Statement_Item",
                        transaction.Timestamp,
                        FormatEntity(transaction.Source.Customer),
                        FormatEntity(transaction.Destination.Customer),
                        transaction.Amount,
                        FormatEntity(transaction.Source.Account),
                        FormatEntity(transaction.Destination.Account)
                    )
                );
            }
            Console.WriteLine();
        }

        /// <inheritdoc />
        public void DisplayOperationCancelled()
        {
            Dialog.Notify(ResourceManager.GetText("FundsTransferStatement_Notifications_Cancelled"));
        }

        /// <inheritdoc />
        public void DisplayEndDateBeforeStartDate()
        {
            Dialog.Error(ResourceManager.GetText("FundsTransferStatement_Errors_EndDateBeforeStartDate"));
        }

        /// <summary>
        /// Formats entity data into a human-readable format.
        /// </summary>
        /// <param name="entity">
        /// Entity to be formatted.
        /// </param>
        /// <returns>
        /// A text respresentation of the entity.
        /// </returns>
        private string FormatEntity(TransactionActorEntity entity)
        {
            string result = ResourceManager.GetText("FundsTransferStatement_Statement_Item_Actor", entity.Code,entity.Name);
            if (result.Length <= MaximumNameLength)
            {
                return result.PadRight(MaximumNameLength);
            }

            return $"{result.Substring(0, MaximumNameLength - _truncationIndicator.Length)}{_truncationIndicator}";
        }
    }
}
