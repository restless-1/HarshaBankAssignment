namespace HarshaBank.Presentation.Views.Application
{
    /// <summary>
    /// View contract for <see cref="HarshaBank.Presentation.Presenters.Application.ExitPresenter"/>.
    /// </summary>
    internal interface IExitView
    {
        /// <summary>
        /// Displays a message indicating the application is exiting.
        /// </summary>
        void DisplayExitMessage();

        /// <summary>
        /// Displays an error message indicating application data could not be saved.
        /// </summary>
        /// <param name="exception">
        /// Error details.
        /// </param>
        void DisplaySaveError(Exception exception);
    }
}
