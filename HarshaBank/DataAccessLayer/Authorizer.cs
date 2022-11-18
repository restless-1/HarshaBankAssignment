using HarshaBank.Entities;

namespace HarshaBank.DataAccessLayer
{
    /// <summary>
    /// Authorizes the client credentials against a fixed set of credentials.
    /// </summary>
    internal class Authorizer : IAuthorizer
    {
        /// <inheritdoc />
        public bool Authorize(Credentials credentials)
        {
            // Stubbed-in authorization logic (matches functionality of Harsha's original code)
            return (credentials.UserName == "system" && credentials.Password == "manager");
        }
    }
}

