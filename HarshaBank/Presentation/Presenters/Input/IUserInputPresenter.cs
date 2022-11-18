namespace HarshaBank.Presentation.Presenters.Input
{
    /// <summary>
    /// Contract for presenters that handle user input requests.
    /// </summary>
    internal interface IUserInputPresenter : IPresenter
    {
        /// <summary>
        /// The contract type the presenter can retrieve user input for.
        /// </summary>
        Type Type { get; }

        /// <summary>
        /// Collects user input.
        /// </summary>
        /// <param name="data">
        /// Context data.
        /// </param>
        /// <returns>
        /// An instance of <see cref="IUserInputPresenter.Type"/> containing the data
        /// input by the user.
        /// </returns>
        object? Execute(object? data = null);
    }
}
