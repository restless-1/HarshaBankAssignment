using HarshaBank.Entities;
using HarshaBank.Exceptions;

namespace HarshaBank.DataAccessLayer
{
    /// <summary>
    /// Concrete implementation of <see cref="IAccountsDataAccessLayer"/> that operates against
    /// in a <see cref="DataStore"/> instance.
    /// </summary>
    internal class AccountsDataAccessLayer : IAccountsDataAccessLayer
    {
        private readonly IDataStore _dataStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsDataAccessLayer"/> class.
        /// </summary>
        /// <param name="dataStore">
        /// Data store containing application data.
        /// </param>
        public AccountsDataAccessLayer(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        /// <inheritdoc />
        public Account GetAccount(Guid id)
        {
            Account? account = _dataStore.Accounts.FirstOrDefault(a => a.AccountId == id && a.IsActive)?.Clone();
            if (account == null)
            {
                throw new AccountNotFoundException($"No account was found with the ID {id}");
            }
            return account;
        }

        /// <inheritdoc />
        public Account GetAccount(long code)
        {
            Account? account = _dataStore.Accounts.FirstOrDefault(a => a.AccountCode == code && a.IsActive)?.Clone();
            if (account == null)
            {
                throw new AccountNotFoundException($"No account was found with the code {code}");
            }
            return account;
        }

        /// <inheritdoc />
        public List<Account> GetAccountsForCustomer(Guid customerId)
        {
            if (!_dataStore.Customers.Any(c => c.CustomerId == customerId && c.IsActive))
            {
                throw new CustomerNotFoundException($"No customer was found with the ID {customerId}");
            }
            return _dataStore.Accounts.Where(a => a.CustomerId == customerId && a.IsActive)
                                      .Select(a => a.Clone())
                                      .OrderBy(a => a.AccountName)
                                      .ToList();
        }

        /// <inheritdoc />
        public List<Account> GetAccounts()
        {
            return _dataStore.Accounts.Where(a => a.IsActive)
                                      .OrderBy(a => a.CustomerId)
                                      .ThenBy(a => a.AccountName)
                                      .Select(a => a.Clone())
                                      .ToList();
        }

        public List<Account> FindAccounts(string searchTerm)
        {
            return _dataStore.Accounts.Where(a => a.IsActive && a.AccountName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                                      .OrderBy(a => a.AccountName)
                                      .Select(a => a.Clone())
                                      .ToList();
        }

        /// <inheritdoc />
        public Account AddAccount(Account account)
        {
            if (!_dataStore.Customers.Exists(c => c.CustomerId == account.CustomerId && c.IsActive))
            {
                throw new CustomerNotFoundException($"No customer was found with the ID {account.CustomerId}");
            }

            Account savedAccount = account.Clone();

            //generate new Guid
            savedAccount.AccountId = Guid.NewGuid();

            savedAccount.AccountCode = _dataStore.NextAccountCode;
            _dataStore.NextAccountCode++;

            savedAccount.IsActive = true;

            //add customer
            _dataStore.Accounts.Add(savedAccount);

            return savedAccount.Clone() ;
        }

        /// <inheritdoc />
        public void UpdateAccount(Account account)
        {
            Account? storedAccount = _dataStore.Accounts.Find(a => a.AccountId == account.AccountId && a.IsActive);

            if (storedAccount == null)
            {
                throw new AccountNotFoundException($"No account was found with the ID {account.AccountId}");
            }

            storedAccount.AccountName = account.AccountName;
            storedAccount.Balance = account.Balance;
            storedAccount.IsActive = account.IsActive;
        }

        /// <inheritdoc />
        public bool DeleteAccount(Guid accountId)
        {
            // Because this is a bank, they probably would never want to hard-delete information.
            // Doing so would create risk of spoofing attacks.

            Account? account = _dataStore.Accounts.FirstOrDefault(a => a.AccountId == accountId && a.IsActive);
            if (account == null)
            {
                return false;
            }

            if (account.Balance > 0)
            {
                throw new AccountHasNonZeroBalanceException("Cannot delete account with non-zero balance");
            }

            account.IsActive = false;
            return true;
        }

        /// <inheritdoc />
        public Transaction Transfer(Guid sourceAccountId,
                                    Guid destinationAccountId,
                                    decimal amount,
                                    string description)
        {
            Account? sourceAccount = _dataStore.Accounts.FirstOrDefault(a => a.AccountId == sourceAccountId && a.IsActive);
            if (sourceAccount == null)
            {
                throw new AccountNotFoundException($"No account was found with the ID {sourceAccountId}");
            }

            Account? destinationAccount = _dataStore.Accounts.FirstOrDefault(a => a.AccountId == destinationAccountId && a.IsActive);
            if (destinationAccount == null)
            {
                throw new AccountNotFoundException($"No account was found with the ID {destinationAccountId}");
            }

            if (amount > sourceAccount.Balance)
            {
                throw new InsufficientFundsException($"Insufficient funds (funds: {sourceAccount.Balance}; requested: {amount})");
            }

            Customer sourceCustomer = _dataStore.Customers.First(c => c.CustomerId == sourceAccount.CustomerId);
            Customer destinationCustomer = _dataStore.Customers.First(c => c.CustomerId == destinationAccount.CustomerId);

            Transaction transaction = new()
            {
                Timestamp = DateTime.UtcNow,
                Amount = amount,
                Description = description,
                Source = new()
                {
                    Customer = new()
                    {
                        Code = sourceCustomer.CustomerCode,
                        Name = sourceCustomer.CustomerName
                    },
                    Account = new()
                    {
                        Code = sourceAccount.AccountCode,
                        Name = sourceAccount.AccountName
                    },
                    OldBalance = sourceAccount.Balance,
                    NewBalance = sourceAccount.Balance - amount
                },
                Destination = new()
                {
                    Customer = new()
                    {
                        Code = destinationCustomer.CustomerCode,
                        Name = destinationCustomer.CustomerName
                    },
                    Account = new()
                    {
                        Code = destinationAccount.AccountCode,
                        Name = destinationAccount.AccountName
                    },
                    OldBalance = destinationAccount.Balance,
                    NewBalance = destinationAccount.Balance + amount
                },
            };

            sourceAccount.Balance = transaction.Source.NewBalance;
            destinationAccount.Balance = transaction.Destination.NewBalance;
            _dataStore.Transactions.Add(transaction);

            return transaction.Clone();
        }

        /// <inheritdoc />
        public List<Transaction> GetTransactions(DateTime startDate, DateTime endDate)
        {
            DateTime floor = startDate.ToUniversalTime().Date;
            DateTime ceiling = endDate.ToUniversalTime().Date;

            return _dataStore.Transactions.Where(t => t.Timestamp.Date >= startDate && t.Timestamp.Date <= endDate)
                                          .OrderBy(t => t.Timestamp)
                                          .Select(t => t.Clone())
                                          .ToList();
        }

        /// <inheritdoc />
        public List<Transaction> GetTransactions(DateTime startDate, DateTime endDate, long accountCode)
        {
            DateTime floor = startDate.ToUniversalTime().Date;
            DateTime ceiling = endDate.ToUniversalTime().Date;

            return _dataStore.Transactions.Where(t => (t.Source.Account.Code == accountCode || t.Destination.Account.Code == accountCode) && t.Timestamp.Date >= floor && t.Timestamp.Date <= ceiling)
                                          .OrderBy(t => t.Timestamp)
                                          .Select(t => t.Clone())
                                          .ToList();
        }
    }
}
