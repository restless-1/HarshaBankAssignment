using HarshaBank.Entities;

namespace HarshaBank.DataAccessLayer
{
    /// <summary>
    /// Contract for authorizing users.
    /// </summary>
    internal interface IAuthorizer
    {
        /// <summary>
        /// Returns whether the specified credentials are authorized to access the application.
        /// </summary>
        /// <param name="credentials">
        /// Credentials to be authorized.
        /// </param>
        /// <returns>
        /// true if the credentials are authorized to access the application; false otherwise.
        /// </returns>
        bool Authorize(Credentials credentials);
    }
}
