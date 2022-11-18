using HarshaBank.Entities;
using HarshaBank.Presentation.Controls;
using HarshaBank.Presentation.Views.Formatting;

namespace HarshaBank.Presentation.Views.Application.Customers
{
    /// <summary>
    /// View implementation for <see cref="HarshaBank.Presentation.Presenters.Application.Customers.SearchCustomersPresenter"/>.
    /// </summary>
    internal class SearchCustomersView : ISearchCustomersView
    {
        private readonly SelectControl<Customer> _listControl;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchCustomersView"/> class.
        /// </summary>
        public SearchCustomersView()
        {
            _listControl = new SelectControl<Customer>(
                new SelectOptions()
                {
                    Title = ResourceManager.GetText("SearchCustomers_Title"),
                    PageSize = 2,
                    DisableSelection = true
                }
            );
        }

        /// <inheritdoc />
        public void DisplayTitle()
        {
            Dialog.Title(TitleType.Mode, ResourceManager.GetText("SearchCustomers_Title"));
        }

        /// <inheritdoc />
        public string? InputSearchTerm()
        {
            return Dialog.Prompt(ResourceManager.GetText("SearchCustomers_Prompts_SearchTerm"));
        }

        /// <inheritdoc />
        public void DisplayCustomers(IReadOnlyList<Customer> customers)
        {
            _listControl.Display(customers);
        }

        /// <inheritdoc />
        public void DisplayOperationCancelled()
        {
            Dialog.Notify(ResourceManager.GetText("SearchCustomers_Notifications_Cancelled"));
        }

        /// <inheritdoc />
        public void DisplayNoCustomersFound()
        {
            Dialog.Notify(ResourceManager.GetText("SearchCustomers_Notifications_NoMatches"));
        }
    }
}
