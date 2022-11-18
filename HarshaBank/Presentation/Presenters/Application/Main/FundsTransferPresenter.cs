using HarshaBank.DataAccessLayer;
using HarshaBank.Entities;
using HarshaBank.Events;
using HarshaBank.Exceptions;
using HarshaBank.Presentation.Views.Application.Main;

namespace HarshaBank.Presentation.Presenters.Application.Main
{
    /// <summary>
    /// Workflow for transferring funds from one account to another.
    /// </summary>
    internal class FundsTransferPresenter : IApplicationModePresenter
    {
        private readonly IFundsTransferView _view;
        private readonly IPublisher _publisher;
        private readonly IAccountsDataAccessLayer _dataLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="FundsTransferPresenter"/> class.
        /// </summary>
        /// <param name="view">
        /// View used to interact with the user.
        /// </param>
        /// <param name="publisher">
        /// Publisher used to request an account selection.
        /// </param>
        /// <param name="dataLayer">
        /// Data layer used to access stored data.
        /// </param>
        public FundsTransferPresenter(IFundsTransferView view,
                                      IPublisher publisher,
                                      IAccountsDataAccessLayer dataLayer)
        {
            _view = view;
            _publisher = publisher;
            _dataLayer = dataLayer;
        }

        /// <inheritdoc />
        public ApplicationMode Mode => ApplicationMode.FundsTransfer;

        /// <inheritdoc />
        public ApplicationMode Enter()
        {
            _view.DisplayTitle();

            // Get the account funds will be transferred from
            _view.DisplaySourceAccountLabel();
            Account? sourceAccount = _publisher.RequestUserInput<Account>(this);
            if (sourceAccount == null)
            {
                _view.DisplayOperationCancelled();
                return ApplicationMode.MainMenu;
            }

            // Get the account the funds will be transferred to
            _view.DisplayDestinationAccountLabel();
            Account? destinationAccount = _publisher.RequestUserInput<Account>(this);
            if (destinationAccount == null)
            {
                _view.DisplayOperationCancelled();
                return ApplicationMode.MainMenu;
            }
            else if (destinationAccount.AccountId == sourceAccount.AccountId)
            {
                _view.DisplaySourceAndDestinationAccountsAreTheSame();
                return ApplicationMode.MainMenu;
            }

            // Get how many funds to transfer
            decimal amount = _view.InputAmount(sourceAccount.Balance);
            if (amount == 0)
            {
                _view.DisplayOperationCancelled();
                return ApplicationMode.MainMenu;
            }

            // Get a description to help the user remember what the transfer was for
            string description = _view.InputDescription() ?? "";

            // Confirm that the user is sure they want to make the transfer
            if (!_view.Confirm(amount))
            {
                _view.DisplayOperationCancelled();
                return ApplicationMode.MainMenu;
            }

            // Transfer the funds
            try
            {
                Transaction transaction = _dataLayer.Transfer(sourceAccount.AccountId, destinationAccount.AccountId, amount, description);
                _view.DisplayFundsTransferred(transaction);
            }
            catch (InsufficientFundsException)
            {
                _view.DisplayInsufficientFunds();
            }

            return ApplicationMode.MainMenu;
        }
    }
}
