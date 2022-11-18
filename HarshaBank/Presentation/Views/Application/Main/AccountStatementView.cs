using HarshaBank.Entities;
using HarshaBank.Presentation.Controls;
using HarshaBank.Presentation.Views.Formatting;

namespace HarshaBank.Presentation.Views.Application.Main
{
    /// <summary>
    /// View implementation for <see cref="HarshaBank.Presentation.Presenters.Application.Main.AccountStatementPresenter"/>.
    /// </summary>
    internal class AccountStatementView : IAccountStatementView
    {
        private const int CurrencyWidth = 13;

        /// <inheritdoc />
        public void DisplayTitle()
        {
            Dialog.Title(TitleType.Mode, ResourceManager.GetText("AccountStatement_Title"));
        }

        /// <inheritdoc />
        public DateTime? InputStartDate(DateTime defaultStartDate)
        {
            return Dialog.PromptForDate(ResourceManager.GetText("AccountStatement_Prompts_StartDate", defaultStartDate), defaultStartDate);
        }

        /// <inheritdoc />
        public DateTime? InputEndDate(DateTime defaultEndDate)
        {
            return Dialog.PromptForDate(ResourceManager.GetText("AccountStatement_Prompts_EndDate", defaultEndDate), defaultEndDate);
        }

        /// <inheritdoc />
        public void DisplayReport(Account account,
                                  DateTime startDate,
                                  DateTime endDate,
                                  IReadOnlyList<Transaction> transactions)
        {
            Console.WriteLine(
                ResourceManager.GetText(
                    "AccountStatement_Statement_Title",
                    account.AccountCode,
                    account.AccountName,
                    startDate,
                    endDate
                )
            );

            if (transactions.Count == 0)
            {
                Console.WriteLine(ResourceManager.GetText("AccountStatement_Statement_NoMatches"));
                return;
            }

            Console.WriteLine(ResourceManager.GetText("AccountStatement_Statement_Header"));
            int numberOfTransactions = transactions.Count;
            for (int transactionIndex = 0; transactionIndex < numberOfTransactions; transactionIndex++)
            {
                Transaction transaction = transactions[transactionIndex];
                if (transactionIndex == 0)
                {
                    decimal startingBalance = transaction.Source.Account.Code == account.AccountCode ? transaction.Source.OldBalance : transaction.Destination.OldBalance;
                    Console.WriteLine(ResourceManager.GetText("AccountStatement_Statement_Item_StartingBalance", startingBalance));
                }
                Console.WriteLine(
                    ResourceManager.GetText(
                        "AccountStatement_Statement_Item",
                        transaction.Timestamp,
                        FormatCurrency(account.AccountCode == transaction.Source.Account.Code ? null : transaction.Amount),
                        FormatCurrency(account.AccountCode == transaction.Source.Account.Code ? transaction.Amount : null),
                        FormatCurrency(account.AccountCode == transaction.Source.Account.Code ? transaction.Source.NewBalance : transaction.Destination.NewBalance),
                        transaction.Description
                    )
                );
            }
            Console.WriteLine();
        }

        /// <inheritdoc />
        public void DisplayOperationCancelled()
        {
            Dialog.Notify(ResourceManager.GetText("AccountStatement_Notifications_Cancelled"));
        }

        /// <inheritdoc />
        public void DisplayEndDateBeforeStartDate()
        {
            Dialog.Error(ResourceManager.GetText("AccountStatement_Errors_EndDateBeforeStartDate"));
        }

        /// <summary>
        /// Formats a currency value as a string.
        /// Value will be displayed with two floating point digits and left-padded with spaces
        /// so it is right-aligned when displayed.
        /// </summary>
        /// <param name="value">
        /// The value to be formatted.
        /// </param>
        /// <returns>
        /// The formatted value.
        /// </returns>
        private static string FormatCurrency(decimal? value)
        {
            return (value == null ? "" : value.Value.ToString("F2")).PadLeft(CurrencyWidth);
        }
    }
}
