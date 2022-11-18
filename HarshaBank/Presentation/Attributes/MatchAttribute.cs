using System.Text.RegularExpressions;

namespace HarshaBank.Presentation.Attributes
{
    /// <summary>
    /// Validates a string property value using a regular expression pattern.
    /// </summary>
    internal class MatchAttribute : ValidationRuleAttribute
    {
        private readonly Regex _expression;
        private readonly string _message;

        /// <summary>
        /// Initializes a new instance of the <see cref="MatchAttribute"/> class.
        /// </summary>
        /// <param name="pattern">
        /// The pattern the value must match to be considered valid.
        /// </param>
        /// <param name="message">
        /// The message to be applied if the value is found to be invalid.
        /// </param>
        public MatchAttribute(string pattern, string? message = null)
        {
            _expression = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled);
            _message = message ?? $"Must match the expression: /{pattern}/";
        }

        /// <inheritdoc />
        public override ValidationRuleResult Validate(object? value)
        {
            ValidationRuleResult result = new ValidationRuleResult();
            if (value is string)
            {
                if (!_expression.IsMatch((string)value))
                {
                    result.IsValid = false;
                    result.Message = _message;
                }
            }
            else if (value != null)
            {
                throw new InvalidOperationException(
                    $"{nameof(MatchAttribute)} cannot be applied to values of type {value.GetType().Name}");
            }
            return result;
        }
    }
}
