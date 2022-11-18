using HarshaBank.Entities;
using HarshaBank.Presentation.Controls;
using HarshaBank.Presentation.Views.Formatting;

namespace HarshaBank.Presentation.Views.Application
{
    /// <summary>
    /// View implementation for <see cref="HarshaBank.Presentation.Presenters.Application.LoginPresenter"/>.
    /// </summary>
    internal class LoginView : ILoginView
    {
        /// <inheritdoc />
        public Credentials InputCredentials()
        {
            Dialog.Title(TitleType.Login, ResourceManager.GetText("Login_Title"));
            string? userName = Dialog.Prompt(ResourceManager.GetText("Login_Prompts_UserName"), prohibitCancel: true);
            string? password = null;
            if (!string.IsNullOrEmpty(userName))
            {
                password = Dialog.Prompt(ResourceManager.GetText("Login_Prompts_Password"), prohibitCancel: true);
            }

            return new()
            {
                UserName = userName,
                Password = password
            };
        }

        /// <inheritdoc />
        public void DisplayPasswordRejectedMessage()
        {
            Dialog.Notify(ResourceManager.GetText("Login_Notifications_CredentialsRejected"));
        }
    }
}
