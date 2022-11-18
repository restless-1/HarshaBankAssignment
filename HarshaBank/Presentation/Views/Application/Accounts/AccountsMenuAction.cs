namespace HarshaBank.Presentation.Views.Application.Accounts
{
    /// <summary>
    /// Represents a user selection from the accounts submenu.
    /// </summary>
    internal enum AccountsMenuAction
    {
        /// <summary>
        /// Exit the accounts submenu.
        /// </summary>
        Exit,

        /// <summary>
        /// Add a new account.
        /// </summary>
        AddAccount,

        /// <summary>
        /// Delete an existing account.
        /// </summary>
        DeleteAccount,

        /// <summary>
        /// Update an existing account.
        /// </summary>
        UpdateAccount,

        /// <summary>
        /// View all active accounts.
        /// </summary>
        ViewAccounts
    }
}
