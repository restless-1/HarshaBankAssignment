namespace HarshaBank.Presentation.Controls
{
    /// <summary>
    /// Options for the <see cref="SelectControl{TItem}"/> constructor.
    /// </summary>
    internal class SelectOptions
    {
        /// <summary>
        /// Gets or sets the title text.
        /// 
        /// Defaults to no title.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the display group indicating which properties will be displayed by the
        /// <see cref="SelectControl{TItem}"/>.
        /// 
        /// Default value depends on the value of <see cref="DisableSelection"/>.
        /// If <see cref="DisableSelection"/> is true, the default is "List".
        /// If <see cref="DisableSelection"/> is false, the default is "Select".
        /// </summary>
        public string? DisplayGroup { get; set; }

        /// <summary>
        /// Gets or sets the number of items to display per page.
        /// 
        /// Defaults to 5.
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// Gets or sets whether to allow the user to select an item.
        /// If set to true, the <see cref="SelectControl{TItem}"/> will behave like a list control.
        /// 
        /// Defaults to false.
        /// </summary>
        public bool? DisableSelection {  get; set; }
    }
}
