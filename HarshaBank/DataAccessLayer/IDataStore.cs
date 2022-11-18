using HarshaBank.Entities;

// In a real application this wouldn't exist.  Data would be saved and
// retrieved in real-time from a database or API.

namespace HarshaBank.DataAccessLayer
{
    /// <summary>
    /// Central location for application data so it's easier to persist.
    /// </summary>
    internal interface IDataStore
    {
        /// <summary>
        /// Gets or sets the next customer code to be assigned.
        /// </summary>
        long NextCustomerCode { get; set; }

        /// <summary>
        /// Gets the list of all existing customers.
        /// </summary>
        List<Customer> Customers { get; }

        /// <summary>
        /// Gets or sets the next account code to be assigned.
        /// </summary>
        long NextAccountCode { get; set; }

        /// <summary>
        /// Gets the list of all existing accounts.
        /// </summary>
        List<Account> Accounts { get; }

        /// <summary>
        /// Gets the list of all existing transactions.
        /// </summary>
        List<Transaction> Transactions { get; }

        /// <summary>
        /// Loads application data from the file specified in the settings passed to the constructor.
        /// </summary>
        /// <exception cref="Exception">
        /// An error was encountered loading application data.
        /// </exception>
        void Load();

        /// <summary>
        /// Saves application data to the file specified in the settings passed to the constructor.
        /// </summary>
        /// <exception cref="Exception">
        /// An error was encountered saving application data.
        /// </exception>
        void Save();
    }
}