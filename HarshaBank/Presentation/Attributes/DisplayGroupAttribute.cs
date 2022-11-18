namespace HarshaBank.Presentation.Attributes
{
    /// <summary>
    /// Attribute which tells the UI which display groups the property should
    /// appear in.
    /// Properties without this decorator will be omitted from the UI.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    internal class DisplayGroupAttribute : Attribute
    {
        private readonly ISet<string> _displayGroups;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayGroupAttribute"/> class.
        /// </summary>
        /// <param name="displayGroups">
        /// The UI display groups the property should be represented in.  Use "*" for all
        /// display groups.
        /// </param>
        public DisplayGroupAttribute(params string[] displayGroups)
        {
            _displayGroups =
                new HashSet<string>(displayGroups ?? new string[0], StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Returns whether the property is a member of the specified group.
        /// </summary>
        /// <param name="group">
        /// The group to check.
        /// </param>
        /// <returns>
        /// true if the property is a member of the group; false otherwise.
        /// </returns>
        public bool IsInGroup(string? group)
        {
            return string.IsNullOrEmpty(group) ||
                   _displayGroups.Contains(group) ||
                   _displayGroups.Contains("*");
        }
    }
}
