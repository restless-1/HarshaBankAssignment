namespace HarshaBank.Presentation.Controls
{
    /// <summary>
    /// Represents an individual item in a menu.
    /// </summary>
    /// <typeparam name="TAction">
    /// The type used to represent the user's menu choice.
    /// </typeparam>
    internal class MenuItem<TAction> where TAction : Enum
    {
        /// <summary>
        /// Gets or sets the ID of the menu item.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Gets or sets the name of the menu item.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Gets or sets the value that will be returned if the menu item is selected.
        /// </summary>
        public TAction Action { get; init; }
    }
}
