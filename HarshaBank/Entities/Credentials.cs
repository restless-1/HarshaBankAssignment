namespace HarshaBank.Entities
{
    /// <summary>
    /// Container class for user credentials.
    /// </summary>
    internal struct Credentials
    {
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string? Password { get; set; }
    }
}
