using HarshaBank.Entities;
using HarshaBank.Presentation.Controls;
using HarshaBank.Presentation.Views.Formatting;

namespace HarshaBank.Presentation.Views.Application.Main
{
    /// <summary>
    /// View implementation for <see cref="HarshaBank.Presentation.Presenters.Application.Main.FundsTransferPresenter"/>.
    /// </summary>
    internal class FundsTransferView : IFundsTransferView
    {
        /// <inheritdoc />
        public void DisplayTitle()
        {
            Dialog.Title(TitleType.Mode, ResourceManager.GetText("FundsTransfer_Title"));
        }

        /// <inheritdoc />
        public void DisplaySourceAccountLabel()
        {
            Console.WriteLine(ResourceManager.GetText("FundsTransfer_Prompts_SourceAccount"));
        }

        /// <inheritdoc />
        public void DisplayDestinationAccountLabel()
        {
            Console.WriteLine(ResourceManager.GetText("FundsTransfer_Prompts_DestinationAccount"));
        }

        /// <inheritdoc />
        public decimal InputAmount(decimal currentBalance)
        {
            while (true)
            {
                string? input = Dialog.Prompt(ResourceManager.GetText("FundsTransfer_Prompts_Amount", currentBalance));
                if (string.IsNullOrEmpty(input))
                {
                    return 0;
                }
                if (decimal.TryParse(input, out decimal amount) && amount >= 0 && amount == Math.Round(amount, 2))
                {
                    return amount;
                }
                Dialog.Error(ResourceManager.GetText("FundsTransfer_Errors_InvalidAmount"));
            }
        }

        /// <inheritdoc />
        public string? InputDescription()
        {
            return Dialog.Prompt(ResourceManager.GetText("FundsTransfer_Prompts_Description"));
        }

        /// <inheritdoc />
        public bool Confirm(decimal amount)
        {
            string? input = Dialog.Prompt(ResourceManager.GetText("FundsTransfer_Prompts_Confirm", amount));
            return "yes".Equals(input, StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc />
        public void DisplayFundsTransferred(Transaction transaction)
        {
            Dialog.Notify(
                ResourceManager.GetText(
                    "FundsTransfer_Notifications_Transferred",
                    transaction.Source.Customer.Code,
                    transaction.Source.Customer.Name,
                    transaction.Source.Account.Code,
                    transaction.Source.Account.Name,
                    transaction.Source.OldBalance,
                    transaction.Source.NewBalance,
                    transaction.Destination.Customer.Code,
                    transaction.Destination.Customer.Name,
                    transaction.Destination.Account.Code,
                    transaction.Destination.Account.Name,
                    transaction.Destination.OldBalance,
                    transaction.Destination.NewBalance
                )
            );
        }

        /// <inheritdoc />
        public void DisplayOperationCancelled()
        {
            Dialog.Notify(ResourceManager.GetText("FundsTransfer_Notifications_Cancelled"));
        }

        /// <inheritdoc />
        public void DisplayInsufficientFunds()
        {
            Dialog.Error(ResourceManager.GetText("FundsTransfer_Errors_InsufficientFunds"));
        }

        /// <inheritdoc />
        public void DisplaySourceAndDestinationAccountsAreTheSame()
        {
            Dialog.Error(ResourceManager.GetText("FundsTransfer_Errors_SourceAccountIsAlsoDestinationAccount"));
        }
    }
}
