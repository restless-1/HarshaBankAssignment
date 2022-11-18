using HarshaBank.Entities;
using HarshaBank.Presentation.Controls;
using HarshaBank.Presentation.Views.Formatting;

namespace HarshaBank.Presentation.Views.Application.Accounts
{
    /// <summary>
    /// View implementation for <see cref="HarshaBank.Presentation.Presenters.Application.Accounts.AddAccountPresenter"/>.
    /// </summary>
    internal class AddAccountView : IAddAccountView
    {
        private readonly FormControl<Account> _inputAccountControl;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddAccountView"/> class.
        /// </summary>
        public AddAccountView()
        {
            _inputAccountControl = new FormControl<Account>();
        }

        /// <inheritdoc />
        public void DisplayTitle()
        {
            Dialog.Title(TitleType.Mode, ResourceManager.GetText("AddAccount_Title"));
        }

        /// <inheritdoc />
        public Account? InputAccount()
        {
            return _inputAccountControl.InputData();
        }

        /// <inheritdoc />
        public void DisplayOperationCancelled()
        {
            Dialog.Notify(ResourceManager.GetText("AddAccount_Notifications_Cancelled"));
        }

        /// <inheritdoc />
        public void DisplayAccountAdded(long? accountCode)
        {
            Dialog.Notify(ResourceManager.GetText("AddAccount_Notifications_Added", accountCode ?? -1));
        }
    }
}
