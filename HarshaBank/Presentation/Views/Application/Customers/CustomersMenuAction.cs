namespace HarshaBank.Presentation.Views.Application.Customers
{
    /// <summary>
    /// Represents a user selection from the customers submenu.
    /// </summary>
    internal enum CustomersMenuAction
    {
        /// <summary>
        /// Exit the customers submenu.
        /// </summary>
        Exit,

        /// <summary>
        /// Add a new customer.
        /// </summary>
        AddCustomer,

        /// <summary>
        /// Delete an existing customer.
        /// </summary>
        DeleteCustomer,

        /// <summary>
        /// Update an existing customer.
        /// </summary>
        UpdateCustomer,

        /// <summary>
        /// Search for customers.
        /// </summary>
        SearchCustomers,

        /// <summary>
        /// View all active customers.
        /// </summary>
        ViewCustomers
    }
}
