using HarshaBank.DataAccessLayer;
using HarshaBank.Entities;
using HarshaBank.Events;
using HarshaBank.Exceptions;
using HarshaBank.Presentation.Views.Input;
using System.Text.RegularExpressions;

namespace HarshaBank.Presentation.Presenters.Input
{
    /// <summary>
    /// Presenter which prompts the user to input or select an account.
    /// </summary>
    internal class SelectAccountPresenter : IUserInputPresenter
    {
        private static readonly Regex CustomerExpression = new Regex("(?<=(^\\s*c:\\s*)).*$", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        private readonly ISelectAccountView _view;
        private readonly IPublisher _publisher;
        private readonly IAccountsDataAccessLayer _dataLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectAccountPresenter"/> class.
        /// </summary>
        /// <param name="view">
        /// View used to interact with the user.
        /// </param>
        /// <param name="publisher">
        /// Publisher used to request a customer selection.
        /// </param>
        /// <param name="dataLayer">
        /// Data layer used to access stored data.
        /// </param>
        public SelectAccountPresenter(ISelectAccountView view,
                                      IPublisher publisher,
                                      IAccountsDataAccessLayer dataLayer)
        {
            _view = view;
            _publisher = publisher;
            _dataLayer = dataLayer;
        }

        /// <inheritdoc />
        public Type Type => typeof(Account);

        /// <inheritdoc />
        public object? Execute(object? data = null)
        {
            string? searchTerm = string.IsNullOrEmpty(data as string) ? _view.InputSearchTerm() : (string)data;
            if (string.IsNullOrEmpty(searchTerm))
            {
                return null;
            }

            Account? account = GetAccount(searchTerm);
            if (account != null)
            {
                _view.DisplayAccountSelected(account);
            }
            return account;
        }

        /// <summary>
        /// Gets the user's account selection.
        /// </summary>
        /// <param name="searchTerm">
        /// Search term entered by the user.
        /// </param>
        /// <returns>
        /// Account selected by the user or null if the user cancels account selection.
        /// </returns>
        private Account? GetAccount(string searchTerm)
        {
            Match match = CustomerExpression.Match(searchTerm);
            if (match.Success)
            {
                return GetAccountByCustomer(match.Value);
            }

            if (long.TryParse(searchTerm, out long code))
            {
                return GetAccountByCode(code);
            }

            return SelectAccountFromSearchResults(searchTerm);
        }

        /// <summary>
        /// Allows the user to select the account by customer.
        /// </summary>
        /// <param name="searchTerm">
        /// Search term entered by the user.
        /// </param>
        /// <returns>
        /// Account selected by the user or null if the user cancels account selection.
        /// </returns>
        private Account? GetAccountByCustomer(string searchTerm)
        {
            Customer? customer = _publisher.RequestUserInput<Customer>(this, searchTerm);
            if (customer == null)
            {
                return null;
            }

            List<Account> accounts = _dataLayer.GetAccountsForCustomer(customer.CustomerId);
            if (accounts.Count == 0)
            {
                _view.DisplayNoMatchingAccountsFound();
                return null;
            }

            return _view.InputSelection(accounts);
        }

        /// <summary>
        /// Retrieves a specific account by code.
        /// </summary>
        /// <param name="code">
        /// Code of the account to retrieve.
        /// </param>
        /// <returns>
        /// The specified account or null if the account does not exist.
        /// </returns>
        private Account? GetAccountByCode(long code)
        {
            try
            {
                return _dataLayer.GetAccount(code);
            }
            catch (AccountNotFoundException)
            {
                _view.DisplayAccountNotFound();
                return null;
            }
        }

        /// <summary>
        /// Allows the user to select an account from a list of search results.
        /// </summary>
        /// <param name="searchTerm">
        /// Search term entered by the user.
        /// </param>
        /// <returns>
        /// Account selected by the user or null if the user cancels account selection.
        /// </returns>
        private Account? SelectAccountFromSearchResults(string searchTerm)
        {
            List<Account> accounts = _dataLayer.FindAccounts(searchTerm);
            if (accounts.Count == 0)
            {
                _view.DisplayNoMatchingAccountsFound();
                return null;
            }

            return _view.InputSelection(accounts);
        }
    }
}
