using HarshaBank.Entities;

namespace HarshaBank.DataAccessLayer
{
    /// <summary>
    /// Contract for reading and writing customer data.
    /// </summary>
    public interface ICustomersDataAccessLayer
    {
        /// <summary>
        /// Returns the customer with the specified ID.
        /// </summary>
        /// <param name="id">
        /// ID to look for.
        /// </param>
        /// <returns>
        /// The specified customer.
        /// </returns>
        /// <exception cref="CustomerNotFoundException">
        /// Requested customer does not exist or is not active.
        /// </exception>
        Customer GetCustomer(Guid id);

        /// <summary>
        /// Returns the customer with the specified code.
        /// </summary>
        /// <param name="code">
        /// Code to look for.
        /// </param>
        /// <returns>
        /// The specified customer.
        /// </returns>
        /// <exception cref="CustomerNotFoundException">
        /// Requested customer does not exist or is not active.
        /// </exception>
        Customer GetCustomer(long code);

        /// <summary>
        /// Returns all active customers.
        /// </summary>
        /// <returns>
        /// All active customers.
        /// </returns>
        List<Customer> GetCustomers();

        /// <summary>
        /// Returns customers that match the specified search term.
        /// All user-assigned fields will be searched for <paramref name="searchTerm"/>.
        /// </summary>
        /// <param name="searchTerm">
        /// Search term to look for.
        /// </param>
        /// <returns>
        /// The matching customers.
        /// </returns>
        List<Customer> FindCustomers(string searchTerm);

        // NOTE: GetCustomersByCondition was removed as it breaks encapsulation, forcing the
        //       consumer to have deep knowledge of the underlying data schema.

        /// <summary>
        /// Adds a new customer.
        /// </summary>
        /// <param name="customer">
        /// Customer to add.
        /// </param>
        /// <returns>
        /// The added customer (including auto-generated fields).
        /// </returns>
        Customer AddCustomer(Customer customer);

        /// <summary>
        /// Updates an existing customer
        /// </summary>
        /// <param name="customer">
        /// Customer to update.
        /// </param>
        /// <exception cref="CustomerNotFoundException">
        /// Customer does not exist.
        /// </exception>
        void UpdateCustomer(Customer customer);

        /// <summary>
        /// Deletes an existing customer.
        /// </summary>
        /// <param name="customerID">
        /// ID of the customer to delete.
        /// </param>
        /// <returns>
        /// true if the customer was deleted; false if the customer did not exist to begin with.
        /// </returns>
        /// <exception cref="CustomerHasActiveAccountsException">
        /// Customer has active accounts.
        /// </exception>
        bool DeleteCustomer(Guid customerID);
    }
}

