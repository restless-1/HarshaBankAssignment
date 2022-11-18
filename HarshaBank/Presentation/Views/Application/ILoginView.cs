using HarshaBank.Entities;

namespace HarshaBank.Presentation.Views.Application
{
    /// <summary>
    /// View contract for <see cref="HarshaBank.Presentation.Presenters.Application.LoginPresenter"/>.
    /// </summary>
    internal interface ILoginView
    {
        /// <summary>
        /// Inputs user credentials.
        /// </summary>
        /// <returns>
        /// User's credentials.
        /// </returns>
        Credentials InputCredentials();

        /// <summary>
        /// Displays a message that the user's credentials are not authorized to access
        /// the system.
        /// </summary>
        void DisplayPasswordRejectedMessage();
    }
}
