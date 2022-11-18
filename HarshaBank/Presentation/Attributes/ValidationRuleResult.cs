namespace HarshaBank.Presentation.Attributes
{
    /// <summary>
    /// Represents the outcome of a validation operation performed
    /// against user input.
    /// </summary>
    internal record ValidationRuleResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationRuleResult"/> struct.
        /// </summary>
        public ValidationRuleResult()
        {
        }

        /// <summary>
        /// Gets or sets whether the value is valid.
        /// </summary>
        public bool IsValid { get; set; } = true;

        /// <summary>
        /// Gets or sets the message stating why the value is invalid.
        /// 
        /// This should be set to an empty string if the value is valid.
        /// </summary>
        public string Message { get; set; } = "";

        /// <summary>
        /// Gets or sets whether validation rule evaluation should
        /// be terminated if <see cref="IsValid"/> is false.
        /// </summary>
        public bool IsTerminal { get; set; } = false;
    }
}
