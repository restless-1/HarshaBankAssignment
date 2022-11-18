using HarshaBank.DataAccessLayer;
using HarshaBank.Entities;
using HarshaBank.Events;
using HarshaBank.Presentation.Views.Application.Accounts;

namespace HarshaBank.Presentation.Presenters.Application.Accounts
{
    /// <summary>
    /// Workflow for adding a new account.
    /// </summary>
    internal class AddAccountPresenter : IApplicationModePresenter
    {
        private readonly IAddAccountView _view;
        private readonly IPublisher _publisher;
        private readonly IAccountsDataAccessLayer _dataLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddAccountPresenter"/> class.
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
        public AddAccountPresenter(IAddAccountView view,
                                   IPublisher publisher,
                                   IAccountsDataAccessLayer dataLayer)
        {
            _view = view;
            _publisher = publisher;
            _dataLayer = dataLayer;
        }

        /// <inheritdoc />
        public ApplicationMode Mode => ApplicationMode.AddAccount;

        /// <inheritdoc />
        public ApplicationMode Enter()
        {
            _view.DisplayTitle();

            // Input the customer the account will be created for
            Customer? customer = _publisher.RequestUserInput<Customer>(this);
            if (customer == null)
            {
                _view.DisplayOperationCancelled();
                return ApplicationMode.AccountsMenu;
            }

            // Input the account details
            Account? account = _view.InputAccount();
            if (account == null)
            {
                _view.DisplayOperationCancelled();
                return ApplicationMode.AccountsMenu;
            }

            // Save the account
            account.CustomerId = customer.CustomerId;
            Account savedAccount = _dataLayer.AddAccount(account);
            _view.DisplayAccountAdded(savedAccount.AccountCode);
            return ApplicationMode.AccountsMenu;
        }
    }
}
