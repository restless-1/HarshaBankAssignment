using HarshaBank.Entities;
using HarshaBank.Presentation.Controls;
using HarshaBank.Presentation.Views.Formatting;

namespace HarshaBank.Presentation.Views.Application.Accounts
{
    /// <summary>
    /// View implementation for <see cref="HarshaBank.Presentation.Presenters.Application.Accounts.DeleteAccountPresenter"/>.
    /// </summary>
    internal class DeleteAccountView : IDeleteAccountView
    {
        /// <inheritdoc />
        public void DisplayTitle()
        {
            Dialog.Title(TitleType.Mode, ResourceManager.GetText("DeleteAccount_Title"));
        }

        /// <inheritdoc />
        public bool Confirm(Account account)
        {
            string? input = Dialog.Prompt(ResourceManager.GetText("DeleteAccount_Prompts_Confirm", account.AccountCode, account.AccountName));
            return "yes".Equals(input, StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc />
        public void DisplayAccountDeleted()
        {
            Dialog.Notify(ResourceManager.GetText("DeleteAccount_Notifications_Deleted"));
        }

        /// <inheritdoc />
        public void DisplayOperationCancelled()
        {
            Dialog.Notify(ResourceManager.GetText("DeleteAccount_Notifications_Cancelled"));
        }

        /// <inheritdoc />
        public void DisplayAccountNotFound()
        {
            Dialog.Error(ResourceManager.GetText("DeleteAccount_Errors_NotFound"));
        }

        /// <inheritdoc />
        public void DisplayNonZeroBalanceError()
        {
            Dialog.Error(ResourceManager.GetText("DeleteAccount_Errors_NonZeroBalance"));
        }
    }
}
