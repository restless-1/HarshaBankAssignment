using HarshaBank.DataAccessLayer;
using HarshaBank.Entities;
using HarshaBank.Presentation.Views.Application;

namespace HarshaBank.Presentation.Presenters.Application
{
    /// <summary>
    /// Workflow for user login.
    /// </summary>
    internal class LoginPresenter : IApplicationModePresenter
    {
        private readonly ILoginView _view;
        private readonly IAuthorizer _authorizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPresenter"/> class
        /// </summary>
        /// <param name="view">
        /// View used to interact with the user.
        /// </param>
        /// <param name="authorizer">
        /// Authorizer instance used to authenticate the user.
        /// </param>
        public LoginPresenter(ILoginView view, IAuthorizer authorizer)
        {
            _view = view;
            _authorizer = authorizer;
        }

        /// <inheritdoc />
        public ApplicationMode Mode => ApplicationMode.Login;

        /// <inheritdoc />
        public ApplicationMode Enter()
        {
            Credentials credentials = _view.InputCredentials();
            if (_authorizer.Authorize(credentials))
            {
                return ApplicationMode.MainMenu;
            }

            _view.DisplayPasswordRejectedMessage();
            return ApplicationMode.Exit;
        }
    }
}
