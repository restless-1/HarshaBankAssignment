namespace HarshaBank.Events
{
    /// <summary>
    /// Contract for publishing system events.
    /// </summary>
    internal interface IPublisher
    {
        /// <summary>
        /// Requests input from the user.
        /// </summary>
        /// <typeparam name="TResult">
        /// The container class for the input fields the user needs to provide.
        /// </typeparam>
        /// <param name="sender">
        /// The object from which the event originated.
        /// </param>
        /// <param name="data">
        /// Context data.
        /// </param>
        /// <returns>
        /// The requested user data.
        /// </returns>
        /// <exception cref="Exception">
        /// The requested user data could not be provided.
        /// </exception>
        public TResult? RequestUserInput<TResult>(object sender, object? data = null);
    }
}
