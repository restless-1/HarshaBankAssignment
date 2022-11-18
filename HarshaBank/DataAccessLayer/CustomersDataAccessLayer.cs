using HarshaBank.Entities;
using HarshaBank.Exceptions;

namespace HarshaBank.DataAccessLayer
{
    /// <summary>
    /// Concrete implementation of <see cref="ICustomersDataAccessLayer"/> that operates against
    /// a <see cref="DataStore"/> instance.
    /// </summary>
    internal class CustomersDataAccessLayer : ICustomersDataAccessLayer
    {
        private readonly IDataStore _dataStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersDataAccessLayer"/> class.
        /// </summary>
        /// <param name="dataStore">
        /// Data store containing application data.
        /// </param>
        public CustomersDataAccessLayer(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        /// <inheritdoc />
        public Customer GetCustomer(Guid id)
        {
            Customer? customer = _dataStore.Customers.FirstOrDefault(c => c.CustomerId == id && c.IsActive)?.Clone();
            if (customer == null)
            {
                throw new CustomerNotFoundException($"No customer was found with the ID {id}");
            }
            return customer;
        }

        /// <inheritdoc />
        public Customer GetCustomer(long code)
        {
            Customer? customer = _dataStore.Customers.FirstOrDefault(c => c.CustomerCode == code && c.IsActive)?.Clone();
            if (customer == null)
            {
                throw new CustomerNotFoundException($"No customer was found with the code {code}");
            }
            return customer;
        }

        /// <inheritdoc />
        public List<Customer> GetCustomers()
        {
            // Return a deep clone of the customer list
            return _dataStore.Customers.Where(c => c.IsActive)
                                       .OrderBy(c => c.CustomerName)
                                       .Select(c => c.Clone())
                                       .ToList();
        }

        /// <inheritdoc />
        public List<Customer> FindCustomers(string searchTerm)
        {
            return _dataStore.Customers.Where(
                                            c => c.IsActive &&
                                                 (c.CustomerName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                                  c.Address.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                                  c.Landmark.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                                  c.City.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                                  c.Country.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                                  c.Mobile.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                                        )
                                       .OrderBy(c => c.CustomerName)
                                       .Select(c => c.Clone())
                                       .ToList();
        }

        /// <inheritdoc />
        public Customer AddCustomer(Customer customer)
        {
            Customer savedCustomer = customer.Clone();

            //generate new Guid
            savedCustomer.CustomerId = Guid.NewGuid();

            // BROUGHT THIS OVER FROM THE BUSINESS LAYER
            // Given the current use case, I can't think of a good reason to assign it outside of the data layer.
            savedCustomer.CustomerCode = _dataStore.NextCustomerCode;
            _dataStore.NextCustomerCode++;

            savedCustomer.IsActive = true;

            //add customer
            _dataStore.Customers.Add(savedCustomer);

            return savedCustomer.Clone();
        }

        /// <inheritdoc />
        public void UpdateCustomer(Customer customer)
        {
            Customer? existingCustomer = _dataStore.Customers.Find(c => c.CustomerId == customer.CustomerId && c.IsActive);
            if (existingCustomer == null)
            {
                throw new CustomerNotFoundException($"No customer was found with the ID {customer.CustomerId}");
            }

            // NOTE: I removed the code to update customer code based on the following:
            //       1) We do not allow the caller to set customer code on creation so why
            //          would we let them update it?
            //       2) The documentation for customer code says: "Auto-generated code number of the
            //          customer" - that doesn't sound like something that should be updated.
            existingCustomer.CustomerName = customer.CustomerName;
            existingCustomer.Address = customer.Address;
            existingCustomer.Landmark = customer.Landmark;
            existingCustomer.City = customer.City;
            existingCustomer.Country = customer.Country;
            existingCustomer.Mobile = customer.Mobile;
        }

        /// <inheritdoc />
        public bool DeleteCustomer(Guid customerId)
        {
            // Because this is a bank, they probably would never want to hard-delete information.
            // Doing so would create risk of spoofing attacks.

            Customer? customer = _dataStore.Customers.FirstOrDefault(c => c.CustomerId == customerId && c.IsActive);
            if (customer == null)
            {
                return false;
            }

            if (_dataStore.Accounts.Any(a => a.CustomerId == customerId && a.IsActive))
            {
                throw new CustomerHasActiveAccountsException(
                    "Cannot delete customer with active accounts - delete accounts first");
            }

            customer.IsActive = false;
            return true;
        }
    }
}
