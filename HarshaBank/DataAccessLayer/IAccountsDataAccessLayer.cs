using HarshaBank.Entities;

namespace HarshaBank.DataAccessLayer
{
    /// <summary>
    /// Contract for reading and writing account data.
    /// </summary>
    internal interface IAccountsDataAccessLayer
    {
        /// <summary>
        /// Returns the account with the specified ID.
        /// </summary>
        /// <param name="id">
        /// ID to look for.
        /// </param>
        /// <returns>
        /// The requested account.
        /// </returns>
        /// <exception cref="AccountNotFoundException">
        /// Account does not exist or is not active.
        /// </exception>
        Account GetAccount(Guid id);

        /// <summary>
        /// Returns the account with the specified code.
        /// </summary>
        /// <param name="code">
        /// Code to look for.
        /// </param>
        /// <returns>
        /// The requested account
        /// </returns>
        /// <exception cref="AccountNotFoundException">
        /// Account does not exist or is not active.
        /// </exception>
        Account GetAccount(long code);

        /// <summary>
        /// Returns all active accounts for the specified customer.
        /// </summary>
        /// <param name="customerId">
        /// ID of the customer to return accounts for.
        /// </param>
        /// <returns>
        /// All active accounts for the specified customer.
        /// </returns>
        /// <exception cref="CustomerNotFoundException">
        /// Customer does not exist or is not active.
        /// </exception>
        List<Account> GetAccountsForCustomer(Guid customerId);

        /// <summary>
        /// Returns all active accounts.
        /// </summary>
        /// <returns>
        /// All active accounts.
        /// </returns>
        List<Account> GetAccounts();

        /// <summary>
        /// Returns accounts that match the specified search term.
        /// All user-assigned fields will be searched for <paramref name="searchTerm"/>.
        /// </summary>
        /// <param name="searchTerm">
        /// Search term to look for.
        /// </param>
        /// <returns>
        /// The matching accounts.
        /// </returns>
        List<Account> FindAccounts(string searchTerm);

        /// <summary>
        /// Adds a new account.
        /// </summary>
        /// <param name="account">
        /// Account to add.
        /// </param>
        /// <returns>
        /// The added account (including auto-generated fields).
        /// </returns>
        Account AddAccount(Account account);

        /// <summary>
        /// Updates an existing account.
        /// </summary>
        /// <param name="account">
        /// Account to update.
        /// </param>
        /// <exception cref="AccountNotFoundException">
        /// Account does not exist or is not active.
        /// </exception>
        void UpdateAccount(Account account);

        /// <summary>
        /// Deletes an existing account.
        /// </summary>
        /// <param name="accountID">
        /// ID of the account to delete.
        /// </param>
        /// <returns>
        /// true if the account was deleted; false if the account did not exist to begin with.
        /// </returns>
        /// <exception cref="AccountHasNonZeroBalanceException">
        /// Account has a non-zero balance
        /// </exception>
        bool DeleteAccount(Guid accountID);

        /// <summary>
        /// Transfers funds from one account to another.
        /// </summary>
        /// <param name="sourceAccountId">
        /// ID of the account from which funds will be subtracted.
        /// </param>
        /// <param name="destinationAccountId">
        /// ID of the account to which funds will be added.
        /// </param>
        /// <param name="amount">
        /// The amount to transfer.
        /// </param>
        /// <param name="description">
        /// Description of the transfer.
        /// </param>
        /// <returns>
        /// The details of the transfer (including auto-generated fields).
        /// </returns>
        /// <exception cref="InsufficientFundsException">
        /// Source account does not have enough funds to cover the transfer.
        /// </exception>
        Transaction Transfer(Guid sourceAccountId, Guid destinationAccountId, decimal amount, string description);

        /// <summary>
        /// Gets the transactions that fall within the specified start and end dates.
        /// </summary>
        /// <param name="startDate">
        /// The starting cutoff date for the query (inclusive).
        /// </param>
        /// <param name="endDate">
        /// The ending cutoff date for the query (inclusive).
        /// </param>
        /// <returns>
        /// The matching transactions.
        /// </returns>
        List<Transaction> GetTransactions(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Gets the transactions for the specified account that fall within the specified start and
        /// end dates.
        /// </summary>
        /// <param name="startDate">
        /// The starting cutoff date for the query (inclusive).
        /// </param>
        /// <param name="endDate">
        /// The ending cutoff date for the query (inclusive).
        /// </param>
        /// <param name="accountCode">
        /// Code of the account to query.
        /// </param>
        /// <returns>
        /// The matching transactions.
        /// </returns>
        List<Transaction> GetTransactions(DateTime startDate, DateTime endDate, long accountCode);
    }
}
