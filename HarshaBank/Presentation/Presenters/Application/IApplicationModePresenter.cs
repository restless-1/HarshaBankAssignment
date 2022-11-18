namespace HarshaBank.Presentation.Presenters.Application
{
    /// <summary>
    /// Contract for presenters responsible for handling a specific <see cref="ApplicationMode"/>.
    /// </summary>
    internal interface IApplicationModePresenter : IPresenter
    {
        /// <summary>
        /// The <see cref="ApplicationMode"/> the presenter is designed to handle.
        /// </summary>
        ApplicationMode Mode { get; }

        /// <summary>
        /// Executes the presenter.
        /// </summary>
        /// <returns>
        /// The <see cref="ApplicationMode"/> the application should move to next.
        /// </returns>
        ApplicationMode Enter();
    }
}
