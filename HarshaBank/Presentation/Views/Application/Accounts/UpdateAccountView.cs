using HarshaBank.Entities;
using HarshaBank.Presentation.Controls;
using HarshaBank.Presentation.Views.Formatting;

namespace HarshaBank.Presentation.Views.Application.Accounts
{
    /// <summary>
    /// View implementation for <see cref="HarshaBank.Presentation.Presenters.Application.Accounts.UpdateAccountPresenter"/>.
    /// </summary>
    internal class UpdateAccountView : IUpdateAccountView
    {
        private readonly FormControl<Account> _editControl;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateAccountView"/> class.
        /// </summary>
        public UpdateAccountView()
        {
            _editControl = new FormControl<Account>();
        }

        /// <inheritdoc />
        public void DisplayTitle()
        {
            Dialog.Title(TitleType.Mode, ResourceManager.GetText("UpdateAccount_Title"));
        }

        /// <inheritdoc />
        public Account? EditAccount(Account account)
        {
            return _editControl.InputData(account);
        }

        /// <inheritdoc />
        public void DisplayAccountUpdated()
        {
            Dialog.Notify(ResourceManager.GetText("UpdateAccount_Notifications_Updated"));
        }

        /// <inheritdoc />
        public void DisplayOperationCancelled()
        {
            Dialog.Notify(ResourceManager.GetText("UpdateAccount_Notifications_Cancelled"));
        }

        /// <inheritdoc />
        public void DisplayAccountNotFound()
        {
            Dialog.Error(ResourceManager.GetText("UpdateAccount_Errors_NotFound"));
        }
    }
}
