namespace HarshaBank.Presentation.Attributes
{
    /// <summary>
    /// Marks a property as requiring user input.
    /// </summary>
    internal class RequiredAttribute : ValidationRuleAttribute
    {
        private readonly string _message;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredAttribute"/> class.
        /// </summary>
        /// <param name="message">
        /// The message to be displayed if no value was provided for the property.
        /// </param>
        public RequiredAttribute(string? message = null)
        {
            _message = message ?? "You must provide a value for this field";
        }

        /// <inheritdoc />
        public override ValidationRuleResult Validate(object? value)
        {
            var result = new ValidationRuleResult();
            if (value == null || value is string text && text.Length == 0)
            {
                result.IsValid = false;
                result.Message = _message;
                result.IsTerminal = true;
            }
            return result;
        }
    }
}
