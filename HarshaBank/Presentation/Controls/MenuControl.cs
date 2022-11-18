using HarshaBank.Presentation.Views.Application;
using HarshaBank.Presentation.Views.Formatting;

namespace HarshaBank.Presentation.Controls
{
    /// <summary>
    /// Displays a list of menu items to the user and inputs their menu selection.
    /// </summary>
    /// <typeparam name="TAction">
    /// The type of value to be returned when the user makes a menu selection.
    /// </typeparam>
    internal class MenuControl<TAction> : IMenuView<TAction> where TAction : Enum
    {
        private readonly IReadOnlyList<MenuItem<TAction>> _items;
        private readonly string? _title;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuControl"/> class.
        /// </summary>
        /// <param name="items">
        /// Menu item definitions.
        /// </param>
        /// <param name="title">
        /// Title text to display with the menu.
        /// Defaults to no title.
        /// </param>
        public MenuControl(IReadOnlyList<MenuItem<TAction>> items, string? title = null)
        {
            _items = items;
            _title = string.IsNullOrEmpty(title) ? null : title;
        }

        /// <summary>
        /// Displays the menu an inputs the users selection.
        /// </summary>
        /// <returns>
        /// A <typeparamref name="TAction"/> value representing the user's menu selection.
        /// </returns>
        public TAction InputSelection()
        {
            while (true)
            {
                if (_title != null)
                {
                    Dialog.Title(TitleType.Menu, _title);
                }

                foreach (MenuItem<TAction> item in _items)
                {
                    Console.WriteLine($"{item.Id}. {item.Name}");
                }

                string? input = Dialog.Prompt(ResourceManager.GetText("MenuControl_Prompts_Choice"), prohibitCancel: true);

                if (int.TryParse(input, out int id))
                {
                    MenuItem<TAction>? selectedItem = _items.Where(x => x.Id == id).FirstOrDefault();
                    if (selectedItem != null)
                    {
                        return selectedItem.Action;
                    }
                }

                Dialog.Error(ResourceManager.GetText("MenuControl_Errors_InvalidChoice"));
            }
        }
    }
}
