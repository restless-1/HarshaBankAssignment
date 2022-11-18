using HarshaBank.DataAccessLayer;
using HarshaBank.Entities;
using HarshaBank.Events;
using HarshaBank.Exceptions;
using HarshaBank.Presentation.Views.Application.Accounts;

namespace HarshaBank.Presentation.Presenters.Application.Accounts
{
    /// <summary>
    /// Workflow for deleting an existing account.
    /// </summary>
    internal class DeleteAccountPresenter : IApplicationModePresenter
    {
        private readonly IDeleteAccountView _view;
        private readonly IPublisher _publisher;
        private readonly IAccountsDataAccessLayer _dataLayer;

        /// <summary>
        /// Initialize a new instance of the <see cref="DeleteAccountPresenter"/> class.
        /// </summary>
        /// <param name="view">
        /// View used to interact with the user.
        /// </param>
        /// <param name="publisher">
        /// Publisher used to request a customer selection.
        /// </param>
        /// <param name="dataLayer">
        /// Data layer used to access account data.
        /// </param>
        public DeleteAccountPresenter(IDeleteAccountView view,
                                      IPublisher publisher,
                                      IAccountsDataAccessLayer dataLayer)
        {
            _view = view;
            _publisher = publisher;
            _dataLayer = dataLayer;
        }

        /// <inheritdoc />
        public ApplicationMode Mode => ApplicationMode.DeleteAccount;

        /// <inheritdoc />
        public ApplicationMode Enter()
        {
            _view.DisplayTitle();

            // Get the account to be deleted
            Account? account = _publisher.RequestUserInput<Account>(this);
            if (account == null || !_view.Confirm(account))
            {
                _view.DisplayOperationCancelled();
                return ApplicationMode.AccountsMenu;
            }

            // Delete the account
            try
            {
                if (_dataLayer.DeleteAccount(account.AccountId))
                {
                    _view.DisplayAccountDeleted();
                }
                else
                {
                    _view.DisplayAccountNotFound();
                }
            }
            catch (AccountHasNonZeroBalanceException)
            {
                _view.DisplayNonZeroBalanceError();
            }

            return ApplicationMode.AccountsMenu;
        }
    }
}
