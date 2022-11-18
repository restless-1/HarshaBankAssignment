namespace HarshaBank.Presentation.Attributes
{
    /// <summary>
    /// Base class for property validator attributes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    internal abstract class ValidationRuleAttribute : Attribute
    {
        /// <summary>
        /// Validates the specified value.
        /// </summary>
        /// <param name="value">
        /// The value to be validated.
        /// </param>
        /// <returns>
        /// Contains the result of the validation operation.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// <paramref name="value"/> is not an instance of <see cref="String"/>.
        /// </exception>
        public abstract ValidationRuleResult Validate(object? value);
    }
}
