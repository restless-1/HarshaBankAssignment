using HarshaBank.Presentation.Controls;
using HarshaBank.Presentation.Views.Formatting;

namespace HarshaBank.Presentation.Views.Application
{
    /// <summary>
    /// View implementation for <see cref="HarshaBank.Presentation.Presenters.Application.StartupPresenter"/>.
    /// </summary>
    internal class StartupView : IStartupView
    {
        /// <inheritdoc />
        public void DisplayApplicationTitle()
        {
            Dialog.Title(TitleType.Application, ResourceManager.GetText("Startup_Title"));
        }

        /// <inheritdoc />
        public void DisplayLoadError(Exception exception)
        {
            Dialog.Error(ResourceManager.GetText("Startup_Errors_Load", exception));
        }
    }
}
