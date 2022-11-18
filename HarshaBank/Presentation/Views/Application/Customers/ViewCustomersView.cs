using HarshaBank.Entities;
using HarshaBank.Presentation.Controls;
using HarshaBank.Presentation.Views.Formatting;

namespace HarshaBank.Presentation.Views.Application.Customers
{
    /// <summary>
    /// View implementation for <see cref="HarshaBank.Presentation.Presenters.Application.Customers.ViewCustomersPresenter"/>.
    /// </summary>
    internal class ViewCustomersView : IViewCustomersView
    {
        private readonly SelectControl<Customer> _listControl;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewCustomersView"/> class.
        /// </summary>
        public ViewCustomersView()
        {
            _listControl = new SelectControl<Customer>(
                new SelectOptions()
                {
                    Title = ResourceManager.GetText("ViewCustomers_Title"),
                    PageSize = 2,
                    DisableSelection = true
                }
            );
        }

        /// <inheritdoc />
        public void DisplayTitle()
        {
            Dialog.Title(TitleType.Mode, ResourceManager.GetText("ViewCustomers_Title"));
        }

        /// <inheritdoc />
        public void DisplayNoCustomersFound()
        {
            Dialog.Notify(ResourceManager.GetText("ViewCustomers_Notifications_NoMatches"));
        }

        /// <inheritdoc />
        public void DisplayCustomers(IReadOnlyList<Customer> customers)
        {
            _listControl.Display(customers);
        }
    }
}
