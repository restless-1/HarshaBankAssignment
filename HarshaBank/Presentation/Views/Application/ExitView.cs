using HarshaBank.Presentation.Controls;
using HarshaBank.Presentation.Views.Formatting;

namespace HarshaBank.Presentation.Views.Application
{
    /// <summary>
    /// View implementation for <see cref="HarshaBank.Presentation.Presenters.Application.ExitPresenter"/>.
    /// </summary>
    internal class ExitView : IExitView
    {
        /// <inheritdoc />
        public void DisplayExitMessage()
        {
            Dialog.Notify(ResourceManager.GetText("Exit_Notifications_Exit"));
        }

        /// <inheritdoc />
        public void DisplaySaveError(Exception exception)
        {
            Dialog.Error(ResourceManager.GetText("Exit_Errors_Save", exception));
        }
    }
}
