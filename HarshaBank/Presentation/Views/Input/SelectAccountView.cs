using HarshaBank.Entities;
using HarshaBank.Presentation.Controls;
using HarshaBank.Presentation.Views.Formatting;

namespace HarshaBank.Presentation.Views.Input
{
    /// <summary>
    /// View implementation for <see cref="HarshaBank.Presentation.Presenters.Input.SelectAccountPresenter"/>.
    /// </summary>
    internal class SelectAccountView : ISelectAccountView
    {
        private readonly SelectControl<Account> _selectControl;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectAccountView"/> class.
        /// </summary>
        public SelectAccountView()
        {
            _selectControl = new SelectControl<Account>(
                new SelectOptions()
                {
                    Title = ResourceManager.GetText("SelectAccount_Title"),
                    PageSize = 2
                }
            );
        }

        /// <inheritdoc />
        public string? InputSearchTerm()
        {
            return Dialog.Prompt(ResourceManager.GetText("SelectAccount_Prompts_SearchTerm"));
        }

        /// <inheritdoc />
        public Account? InputSelection(IReadOnlyList<Account> accounts)
        {
            return _selectControl.Display(accounts);
        }

        /// <inheritdoc />
        public void DisplayAccountSelected(Account account)
        {
            Dialog.Notify(ResourceManager.GetText("SelectAccount_Notifications_Selected", account.AccountCode, account.AccountName));
        }

        /// <inheritdoc />
        public void DisplayAccountNotFound()
        {
            Dialog.Error(ResourceManager.GetText("SelectAccount_Errors_NotFound"));
        }

        /// <inheritdoc />
        public void DisplayNoMatchingAccountsFound()
        {
            Dialog.Notify(ResourceManager.GetText("SelectAccount_Notifications_NoMatches"));
        }
    }
}
