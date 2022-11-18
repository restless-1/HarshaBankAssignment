using HarshaBank.DataAccessLayer;
using HarshaBank.Entities;
using HarshaBank.Events;
using HarshaBank.Presentation.Views.Application.Main;

namespace HarshaBank.Presentation.Presenters.Application.Main
{
    /// <summary>
    /// Workflow for displaying an account statement.
    /// </summary>
    internal class AccountStatementPresenter : IApplicationModePresenter
    {
        private readonly IAccountStatementView _view;
        private readonly IPublisher _publisher;
        private readonly IAccountsDataAccessLayer _dataLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountStatementPresenter"/> class.
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
        public AccountStatementPresenter(IAccountStatementView view,
                                         IPublisher publisher,
                                         IAccountsDataAccessLayer dataLayer)
        {
            _view = view;
            _publisher = publisher;
            _dataLayer = dataLayer;
        }

        /// <inheritdoc />
        public ApplicationMode Mode => ApplicationMode.AccountStatement;

        /// <inheritdoc />
        public ApplicationMode Enter()
        {
            _view.DisplayTitle();

            // Get the account to be reported on
            Account? account = _publisher.RequestUserInput<Account>(this);
            if (account == null)
            {
                _view.DisplayOperationCancelled();
                return ApplicationMode.MainMenu;
            }

            // Input the start date - default to the first of the current month
            DateTime currentDate= DateTime.Now;
            DateTime defaultStartDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            DateTime? startDate = _view.InputStartDate(defaultStartDate);
            if (startDate == null)
            {
                _view.DisplayOperationCancelled();
                return ApplicationMode.MainMenu;
            }

            // Input the end date
            DateTime? endDate = _view.InputEndDate(DateTime.Now);
            if (endDate == null)
            {
                _view.DisplayOperationCancelled();
                return ApplicationMode.MainMenu;
            }
            if (endDate < startDate)
            {
                _view.DisplayEndDateBeforeStartDate();
                return ApplicationMode.MainMenu;
            }

            // Retrieve the transactions and display the report
            List<Transaction> transactions = _dataLayer.GetTransactions(startDate.Value, endDate.Value, account.AccountCode);
            _view.DisplayReport(account, startDate.Value, endDate.Value, transactions);
            return ApplicationMode.MainMenu;
        }
    }
}
