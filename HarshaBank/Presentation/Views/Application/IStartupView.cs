namespace HarshaBank.Presentation.Views.Application
{
    /// <summary>
    /// View contract for <see cref="HarshaBank.Presentation.Presenters.Application.StartupPresenter"/>.
    /// </summary>
    internal interface IStartupView
    {
        /// <summary>
        /// Displays the main application title.
        /// </summary>
        void DisplayApplicationTitle();

        /// <summary>
        /// Displays that an error was encountered loading application data.
        /// </summary>
        /// <param name="exception">
        /// Error details.
        /// </param>
        void DisplayLoadError(Exception exception);
    }
}
