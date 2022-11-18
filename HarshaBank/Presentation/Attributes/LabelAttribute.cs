namespace HarshaBank.Presentation.Attributes
{
    /// <summary>
    /// Sets the UI label that will be displayed for a property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    internal class LabelAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LabelAttribute"/> class.
        /// </summary>
        /// <param name="label">
        /// The label to be displayed for the property.
        /// </param>
        public LabelAttribute(string label)
        {
            Label = label;
        }

        /// <summary>
        /// Gets the UI label to be displayed for the property.
        /// </summary>
        public string Label
        {
            get;

            init;
        }
    }
}
