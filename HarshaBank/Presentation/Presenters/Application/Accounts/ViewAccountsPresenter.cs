using HarshaBank.DataAccessLayer;
using HarshaBank.Entities;
using HarshaBank.Presentation.Views.Application.Accounts;

namespace HarshaBank.Presentation.Presenters.Application.Accounts
{
    /// <summary>
    /// Workflow for viewing active accounts.
    /// </summary>
    internal class ViewAccountsPresenter : IApplicationModePresenter
    {
        private readonly IViewAccountsView _view;
        private readonly ICustomersDataAccessLayer _customersDataLayer;
        private readonly IAccountsDataAccessLayer _accountsDataLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewAccountsPresenter"/> class.
        /// </summary>
        /// <param name="view">
        /// View used to interact with the user.
        /// </param>
        /// <param name="customersDataLayer">
        /// Data layer used to access customer data.
        /// </param>
        /// <param name="accountsDataLayer">
        /// Data layer used to access account data.
        /// </param>
        public ViewAccountsPresenter(IViewAccountsView view,
                                     ICustomersDataAccessLayer customersDataLayer,
                                     IAccountsDataAccessLayer accountsDataLayer)
        {
            _view = view;
            _customersDataLayer= customersDataLayer;
            _accountsDataLayer = accountsDataLayer;
        }

        /// <inheritdoc />
        public ApplicationMode Mode => ApplicationMode.ViewAccounts;

        /// <inheritdoc />
        public ApplicationMode Enter()
        {
            _view.DisplayTitle();

            List<AccountListItem> accounts = LoadListItems();
            if (accounts.Count == 0)
            {
                _view.DisplayNoAccountsFound();
            }
            else
            {
                _view.DisplayAccounts(accounts);
            }
            return ApplicationMode.AccountsMenu;
        }

        /// <summary>
        /// Loads the list items in a format which may be easily displayed in a
        /// <see cref="HarshaBank.Presentation.Controls.SelectControl{TItem}"/>.
        /// </summary>
        /// <returns>
        /// The account list items.
        /// </returns>
        private List<AccountListItem> LoadListItems()
        {
            // This approach would be unbearably slow and expensive in a real application where we were accessing
            //  a database, but it is sufficient here
            List<AccountListItem> listItems = new List<AccountListItem>();
            foreach (Customer customer in _customersDataLayer.GetCustomers())
            {
                foreach (Account account in _accountsDataLayer.GetAccountsForCustomer(customer.CustomerId))
                {
                    listItems.Add(
                        new()
                        {
                            Customer = $"{customer.CustomerCode} ({customer.CustomerName})",
                            Code = account.AccountCode,
                            Name = account.AccountName,
                            Balance = account.Balance
                        }
                    );
                }
            }
            return listItems;
        }
    }
}
