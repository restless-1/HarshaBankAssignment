using HarshaBank.DataAccessLayer;
using HarshaBank.Entities;
using HarshaBank.Events;
using HarshaBank.Exceptions;
using HarshaBank.Presentation.Views.Application.Accounts;

namespace HarshaBank.Presentation.Presenters.Application.Accounts
{
    /// <summary>
    /// Workflow for updating an existing account.
    /// </summary>
    internal class UpdateAccountPresenter : IApplicationModePresenter
    {
        private readonly IUpdateAccountView _view;
        private readonly IPublisher _publisher;
        private readonly IAccountsDataAccessLayer _dataLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateAccountPresenter"/> class.
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
        public UpdateAccountPresenter(IUpdateAccountView view,
                                      IPublisher publisher,
                                      IAccountsDataAccessLayer dataLayer)
        {
            _view = view;
            _publisher = publisher;
            _dataLayer = dataLayer;
        }

        /// <inheritdoc />
        public ApplicationMode Mode => ApplicationMode.UpdateAccount;

        /// <inheritdoc />
        public ApplicationMode Enter()
        {
            _view.DisplayTitle();

            // Get the account to be updated
            Account? account = _publisher.RequestUserInput<Account>(this);
            if (account == null)
            {
                _view.DisplayOperationCancelled();
                return ApplicationMode.AccountsMenu;
            }

            // Get the updated account data
            Account? updatedAccount = _view.EditAccount(account);
            if (updatedAccount == null)
            {
                _view.DisplayOperationCancelled();
                return ApplicationMode.AccountsMenu;
            }

            // Save the updated account data
            try
            {
                _dataLayer.UpdateAccount(updatedAccount);
                _view.DisplayAccountUpdated();
            }
            catch (AccountNotFoundException)
            {
                _view.DisplayAccountNotFound();
            }
            return ApplicationMode.AccountsMenu;
        }
    }
}
