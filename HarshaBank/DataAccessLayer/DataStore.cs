using HarshaBank.Entities;
using System.Text.Json;

namespace HarshaBank.DataAccessLayer
{
    /// <summary>
    /// Concrete implementation of <see cref="IDataStore"/> that persists to a file.
    /// </summary>
    internal class DataStore : IDataStore
    {
        private readonly IDataStoreSettings _settings;

        /// <inheritdoc />
        public DataStore(IDataStoreSettings settings)
        {
            _settings = settings;
            Customers = new List<Customer>();
            Accounts = new List<Account>();
            Transactions = new List<Transaction>();
        }

        /// <inheritdoc />
        public long NextCustomerCode { get; set; }

        /// <inheritdoc />
        public List<Customer> Customers { get; }

        /// <inheritdoc />
        public long NextAccountCode { get; set; }

        /// <inheritdoc />
        public List<Account> Accounts { get; }

        /// <inheritdoc />
        public List<Transaction> Transactions { get; }

        /// <inheritdoc />
        public void Load()
        {
            // Initialize to the defaults
            Customers.Clear();
            Accounts.Clear();
            Transactions.Clear();
            NextCustomerCode = _settings.BaseCustomerCode;
            NextAccountCode = _settings.BaseAccountCode;

            string? dataFilePath = _settings.DataFilePath;
            if (!string.IsNullOrWhiteSpace(dataFilePath))
            {
                // Load the data from file (if possible)
                try
                {
                    using (FileStream fileStream = new(dataFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        ApplicationData? applicationData = JsonSerializer.Deserialize<ApplicationData>(fileStream);
                        if (applicationData != null)
                        {
                            NextCustomerCode = applicationData.NextCustomerCode;
                            NextAccountCode = applicationData.NextAccountCode;
                            Customers.AddRange(applicationData.Customers);
                            Accounts.AddRange(applicationData.Accounts);
                            Transactions.AddRange(applicationData.Transactions);
                        }
                    }
                }
                catch (FileNotFoundException)
                {
                    // There is no file, so just go with the defaults
                }
            }
        }

        /// <inheritdoc />
        public void Save()
        {
            string? dataFilePath = _settings.DataFilePath;
            if (!string.IsNullOrWhiteSpace(dataFilePath))
            {
                using (FileStream fileStream = new(dataFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    ApplicationData applicationData = new()
                    {
                        NextCustomerCode = NextCustomerCode,
                        NextAccountCode = NextAccountCode,
                        Customers = Customers,
                        Accounts = Accounts,
                        Transactions = Transactions
                    };
                    // Since this is an example application, write the file in human-readable format
                    JsonSerializer.Serialize(fileStream, applicationData, new JsonSerializerOptions { WriteIndented = true });
                }
            }
        }

        // Internal class used to load and save data in JSON format
        private class ApplicationData
        {
            public long NextCustomerCode { get; init; }
            public List<Customer> Customers { get; init; } = new();
            public long NextAccountCode { get; init; }
            public List<Account> Accounts { get; init; } = new();
            public List<Transaction> Transactions { get; init; } = new();
        }
    }
}
