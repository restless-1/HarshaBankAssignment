using HarshaBank;
using HarshaBank.Configuration;
using HarshaBank.DataAccessLayer;
using HarshaBank.Events;
using HarshaBank.Presentation.Presenters.Application;
using HarshaBank.Presentation.Presenters.Application.Accounts;
using HarshaBank.Presentation.Presenters.Application.Customers;
using HarshaBank.Presentation.Presenters.Application.Main;
using HarshaBank.Presentation.Presenters.Input;
using HarshaBank.Presentation.Views.Application;
using HarshaBank.Presentation.Views.Application.Accounts;
using HarshaBank.Presentation.Views.Application.Customers;
using HarshaBank.Presentation.Views.Application.Main;
using HarshaBank.Presentation.Views.Input;

// Everything is in one project for simplicity and speed of compilation.  In most production
// scenarios, this would be split into 3 projects: one for front-end code (presentation logic),
// one for back-end code (business logic and data layer), and one for code shared by the other
// two projects.

// ASSUMPTIONS:
// * The Presenter First pattern will be implemented (at least my best guess at it)
// * There is no security aside from the initial login - anyone can modify anyone's data
// * This a closed ecosystem (no transfers from or to an external entity)
// * The UI should look more-or-less the same as the original
// * The user experience may be modified insofar as it remains similar enough to the original
//   to tell what was changed
// * Existing implementation may be changed insofar as it remains at least similar to the original
// * NO input cleanup will be performed
// * SOME arbitrary input validation will be performed
// * Redundant input validation at each layer will not be implemented (redundant input validation
//   would be critical in a real system)
// * No safeguards will be put in place to prevent concurrent access to resources
// * No transactions will be put in place to ensure multi-step processes are rolled back if any
//   step fails
// * Distinct records at the data layers will not be enforced
// * No logging will be added
// * Error checking/handling will be minimal
// * While attempts will be made to keep the architecture testable, no automated tests will be
//   implemented
// * While I probably won't update this project, feedback is welcome - I am always looking to improve

// Wire everything up
Settings settings = new Settings();
IDataStore dataStore = new DataStore(settings);
ICustomersDataAccessLayer customersDataLayer = new CustomersDataAccessLayer(dataStore);
IAccountsDataAccessLayer accountsDataLayer = new AccountsDataAccessLayer(dataStore);
EventBus eventBus = new EventBus();

// Instantiate the application
Application application = new Application(
    eventBus,
    new StartupPresenter(new StartupView(), dataStore),
    new LoginPresenter(new LoginView(), new Authorizer()),
    new MainMenuPresenter(new MainMenuView()),
    new FundsTransferPresenter(new FundsTransferView(), eventBus, accountsDataLayer),
    new FundsTransferStatementPresenter(new FundsTransferStatementView(), accountsDataLayer),
    new AccountStatementPresenter(new AccountStatementView(), eventBus, accountsDataLayer),
    new CustomersMenuPresenter(new CustomersMenuView()),
    new AddCustomerPresenter(new AddCustomerView(), customersDataLayer),
    new DeleteCustomerPresenter(new DeleteCustomerView(), eventBus, customersDataLayer),
    new UpdateCustomerPresenter(new UpdateCustomerView(), eventBus, customersDataLayer),
    new SearchCustomersPresenter(new SearchCustomersView(), customersDataLayer),
    new ViewCustomersPresenter(new ViewCustomersView(), customersDataLayer),
    new AccountsMenuPresenter(new AccountsMenuView()),
    new AddAccountPresenter(new AddAccountView(), eventBus, accountsDataLayer),
    new DeleteAccountPresenter(new DeleteAccountView(), eventBus, accountsDataLayer),
    new UpdateAccountPresenter(new UpdateAccountView(), eventBus, accountsDataLayer),
    new ViewAccountsPresenter(new ViewAccountsView(), customersDataLayer, accountsDataLayer),
    new ConfigurationPresenter(new ConfigurationView(), settings, dataStore),
    new ExitPresenter(new ExitView(), dataStore),
    // Input presenters
    new SelectCustomerPresenter(new SelectCustomerView(), customersDataLayer),
    new SelectAccountPresenter(new SelectAccountView(), eventBus, accountsDataLayer)
);

// Start the application
application.Execute();
