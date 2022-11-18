using HarshaBank.Extensions;
using HarshaBank.Presentation.Attributes;
using HarshaBank.Presentation.Views.Formatting;
using System.Reflection;

namespace HarshaBank.Presentation.Controls
{
    /// <summary>
    /// Displays a collection of items in a paged view and optionally allows the
    /// user to select an item.
    /// </summary>
    /// <typeparam name="TItem">
    /// The type of item to be displayed.
    /// </typeparam>
    internal class SelectControl<TItem> where TItem : class
    {
        // Since the interface relies on numeric input, we have to enforce a maximum
        // page size to reserve room for command options.
        private const int MaximumPageSize = 5;

        private readonly string? _title;
        private readonly string _displayGroup;
        private readonly int _pageSize;
        private readonly bool _disableSelection;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectControl"/> class.
        /// </summary>
        /// <param name="options">
        /// Options to be applied when the select control is displayed.
        /// </param>
        /// <exception cref="ArgumentException">
        /// If <see cref="SelectOptions.PageSize"/> is less than zero or greater than 5.
        /// </exception>
        public SelectControl(SelectOptions? options)
        {
            options ??= new SelectOptions();
            if (options.PageSize < 1 || options.PageSize > MaximumPageSize)
            {
                throw new ArgumentException($"PageSize must be in the range 1 - {MaximumPageSize}", nameof(options));
            }

            _title = string.IsNullOrEmpty(options?.Title) ? null : options.Title;
            _pageSize = options?.PageSize ?? MaximumPageSize;
            string defaultDisplayGroup = options?.DisableSelection == true ? "List" : "Select";
            _displayGroup = string.IsNullOrEmpty(options?.DisplayGroup) ? defaultDisplayGroup : options.DisplayGroup;
            _disableSelection = options?.DisableSelection ?? false;
        }

        /// <summary>
        /// Displays the specified items and takes user input.
        /// </summary>
        /// <param name="items">
        /// The items which the user may select from.
        /// </param>
        /// <returns>
        /// The selected item or null if the user cancels the selection.
        /// </returns>
        public TItem? Display(IReadOnlyList<TItem> items)
        {
            int currentPage = 0;
            int lastPage = items.Count / _pageSize + (items.Count % _pageSize == 0 ? 0 : 1) - 1;
            PropertyInfo[] properties = typeof(TItem).GetProperties(BindingFlags.Instance | BindingFlags.Public);

            while (true)
            {
                // Display the current page of data
                RenderPage(items, properties, currentPage, lastPage);

                // Process user input
                string? input = Dialog.Prompt(ResourceManager.GetText("SelectControl_Prompts_Choice"), prohibitCancel: true);
                if (int.TryParse(input, out int choice))
                {
                    if (choice == 8)
                    {
                        if (currentPage > 0)
                        {
                            currentPage--;
                            continue;
                        }
                    }
                    else if (choice == 9)
                    {
                        if (currentPage < lastPage)
                        {
                            currentPage++;
                            continue;
                        }
                    }
                    else if (choice == 0)
                    {
                        return null;
                    }
                    else if (choice <= _pageSize && !_disableSelection)
                    {
                        int index = (currentPage * _pageSize) + (choice - 1);
                        if (index >= 0 && index < items.Count)
                        {
                            return items[index];
                        }
                    }
                }
                Dialog.Error(ResourceManager.GetText("SelectControl_Errors_InvalidChoice"));
            }
        }

        /// <summary>
        /// Displays a page of items.
        /// </summary>
        /// <param name="items">
        /// All items.
        /// </param>
        /// <param name="properties">
        /// Item properties.
        /// </param>
        /// <param name="currentPage">
        /// Index of the current page (zero-based).
        /// </param>
        /// <param name="lastPage">
        /// Index of the last page (zero-based).
        /// </param>
        private void RenderPage(IReadOnlyList<TItem> items,
                                PropertyInfo[] properties,
                                int currentPage,
                                int lastPage)
        {
            Console.WriteLine(
                ResourceManager.GetText(
                    "SelectControl_Headers_Page",
                    (_title == null ? "" : $"{_title} - "),
                    currentPage + 1,
                    lastPage + 1
                )
            );
            for (int displayItemIndex = 0; displayItemIndex < _pageSize; displayItemIndex++)
            {
                int itemIndex = currentPage * _pageSize + displayItemIndex;
                if (itemIndex >= items.Count)
                {
                    break;
                }

                RenderItem(items[itemIndex], displayItemIndex, properties);
            }
            RenderPageOptions(currentPage, lastPage);
        }

        /// <summary>
        /// Displays an individual item.
        /// </summary>
        /// <param name="item">
        /// Item to be displayed.
        /// </param>
        /// <param name="displayItemIndex">
        /// Index of the item relative to the page (zero-based).
        /// </param>
        /// <param name="properties">
        /// Item properties.
        /// </param>
        private void RenderItem(TItem item, int displayItemIndex, PropertyInfo[] properties)
        {
            if (!_disableSelection)
            {
                Console.WriteLine($"{displayItemIndex + 1}.");
            }
            foreach (PropertyInfo property in properties)
            {
                if (!property.CanRead || ShouldExclude(property))
                {
                    continue;
                }

                if (property.PropertyType.IsAssignableFrom(typeof(decimal)))
                {
                    Console.WriteLine($"{property.GetLabel()}:  {property.GetValue(item):F2}");
                }
                else
                {
                    Console.WriteLine($"{property.GetLabel()}:  {property.GetValue(item)}");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Returns whether the property should be excluded from the output.
        /// </summary>
        /// <param name="property">
        /// The property to be evaluated.
        /// </param>
        /// <returns>
        /// true if the property should be EXCLUDED; false if the property should be INCLUDED.
        /// </returns>
        private bool ShouldExclude(PropertyInfo property)
        {
            return !property.CanRead || property.GetCustomAttribute<DisplayGroupAttribute>()?.IsInGroup(_displayGroup) != true;
        }

        /// <summary>
        /// Displays the control items for the current page.
        /// </summary>
        /// <param name="currentPage">
        /// Index of the current page (zero-based).
        /// </param>
        /// <param name="lastPage">
        /// Index of the last page (zero-based).
        /// </param>
        private void RenderPageOptions(int currentPage, int lastPage)
        {
            if (currentPage > 0)
            {
                Console.WriteLine($"8. {ResourceManager.GetText("SelectControl_Menu_PreviousPage")}");
            }
            if (currentPage < lastPage)
            {
                Console.WriteLine($"9. {ResourceManager.GetText("SelectControl_Menu_NextPage")}");
            }
            Console.WriteLine($"0. {ResourceManager.GetText("SelectControl_Menu_Exit")}");
        }
    }
}
