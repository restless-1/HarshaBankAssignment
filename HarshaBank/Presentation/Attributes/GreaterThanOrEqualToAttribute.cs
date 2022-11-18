namespace HarshaBank.Presentation.Attributes
{
    /// <summary>
    /// Verifies that the property value is greater than or equal to a specified minimum value.
    /// </summary>
    internal class GreaterThanOrEqualToAttribute : ValidationRuleAttribute
    {
        private readonly long _minimumValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="GreaterThanOrEqualToAttribute"/> class.
        /// </summary>
        /// <param name="minimumValue">
        /// The minimum value for the property.
        /// </param>
        public GreaterThanOrEqualToAttribute(long minimumValue)
        {
            // Decimal is sadly not a valid attribute parameter type - we're stuck with the distant runner up
            _minimumValue = minimumValue;
        }

        /// <inheritdoc />
        public override ValidationRuleResult Validate(object? value)
        {
            ValidationRuleResult result = new();
            long? longValue = value as long?;
            if (longValue != null && longValue < _minimumValue)
            {
                result.IsValid = false;
                result.Message = $"Must be equal to or greater than {_minimumValue}";
            }
            return result;
        }
    }
}
