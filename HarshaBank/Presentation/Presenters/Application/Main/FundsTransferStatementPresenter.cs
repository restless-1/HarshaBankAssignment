using HarshaBank.DataAccessLayer;
using HarshaBank.Entities;
using HarshaBank.Presentation.Views.Application.Main;

namespace HarshaBank.Presentation.Presenters.Application.Main
{
    /// <summary>
    /// Workflow for displaying a funds transfer statement.
    /// </summary>
    internal class FundsTransferStatementPresenter : IApplicationModePresenter
    {
        private readonly IFundsTransferStatementView _view;
        private readonly IAccountsDataAccessLayer _dataLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="FundsTransferStatementPresenter"/> class.
        /// </summary>
        /// <param name="view">
        /// View used to interact with the user.
        /// </param>
        /// <param name="dataLayer">
        /// Data layer used to access stored data.
        /// </param>
        public FundsTransferStatementPresenter(IFundsTransferStatementView view, IAccountsDataAccessLayer dataLayer)
        {
            _view = view;
            _dataLayer = dataLayer;
        }

        /// <inheritdoc />
        public ApplicationMode Mode => ApplicationMode.FundsTransferStatement;

        /// <inheritdoc />
        public ApplicationMode Enter()
        {
            _view.DisplayTitle();

            // Input the start date (default to the first of the current month)
            DateTime currentDate = DateTime.Now;
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
            List<Transaction> transactions = _dataLayer.GetTransactions(startDate.Value, endDate.Value);
            _view.DisplayStatement(startDate.Value, endDate.Value, transactions);
            return ApplicationMode.MainMenu;
        }
    }
}
