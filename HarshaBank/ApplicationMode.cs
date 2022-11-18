namespace HarshaBank
{
    /// <summary>
    /// Indicates the current application mode.
    /// </summary>
    internal enum ApplicationMode
    {
        /// <summary>
        /// Application is starting.
        /// </summary>
        Startup,

        /// <summary>
        /// User login.
        /// </summary>
        Login,

        /// <summary>
        /// Main application menu.
        /// </summary>
        MainMenu,

        /// <summary>
        /// Customers submenu.
        /// </summary>
        CustomersMenu,

        /// <summary>
        /// Add a new customer.
        /// </summary>
        AddCustomer,

        /// <summary>
        /// Update an existing customer.
        /// </summary>
        UpdateCustomer,

        /// <summary>
        /// Delete an existing customer.
        /// </summary>
        DeleteCustomer,

        /// <summary>
        /// Search for customers based on a search term.
        /// </summary>
        SearchCustomers,

        /// <summary>
        /// View all active customers.
        /// </summary>
        ViewCustomers,

        /// <summary>
        /// Accounts submenu.
        /// </summary>
        AccountsMenu,

        /// <summary>
        /// Add a new account.
        /// </summary>
        AddAccount,

        /// <summary>
        /// Update an existing account.
        /// </summary>
        UpdateAccount,

        /// <summary>
        /// Delete an existing account.
        /// </summary>
        DeleteAccount,

        /// <summary>
        /// View all active accounts.
        /// </summary>
        ViewAccounts,

        /// <summary>
        /// Transfer funds from one account to another.
        /// </summary>
        FundsTransfer,

        /// <summary>
        /// Report of all fund transfers within a specified date range.
        /// </summary>
        FundsTransferStatement,

        /// <summary>
        /// Report of all account transactions within a specified date range.
        /// </summary>
        AccountStatement,

        /// <summary>
        /// Application configuration.
        /// </summary>
        Configuration,

        /// <summary>
        /// Application is preparing to exit.
        /// </summary>
        Exit,

        /// <summary>
        /// Application is terminating.
        /// </summary>
        Terminate
    }
}
