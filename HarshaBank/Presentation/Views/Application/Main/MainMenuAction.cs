namespace HarshaBank.Presentation.Views.Application.Main
{
    /// <summary>
    /// Represents a user selection from the main menu.
    /// </summary>
    internal enum MainMenuAction
    {
        /// <summary>
        /// Exit the main menu.
        /// </summary>
        Exit,

        /// <summary>
        /// Navigate to the customers submenu.
        /// </summary>
        Customers,

        /// <summary>
        /// Navigate to the accounts submenu.
        /// </summary>
        Accounts,

        /// <summary>
        /// Transfer funds from one account to another.
        /// </summary>
        FundsTransfer,

        /// <summary>
        /// Display a funds-transfer statement.
        /// </summary>
        FundsTransferStatement,

        /// <summary>
        /// Display an account statement.
        /// </summary>
        AccountStatement,

        /// <summary>
        /// Edit application settings.
        /// </summary>
        Configuration
    }
}
