namespace HarshaBank.Events
{
    /// <summary>
    /// Provides a publisher-subscriber mechanism for allowing application components
    /// to communicate with each other.
    /// </summary>
    internal class EventBus : IEventBus, IPublisher
    {
        /// <inheritdoc />
        public event EventHandler<UserInputEventArgs>? UserInputRequired;

        /// <inheritdoc />
        public TResult? RequestUserInput<TResult>(object sender, object? data = null)
        {
            UserInputEventArgs userInputEventArgs = new(typeof(TResult), data);
            UserInputRequired?.Invoke(sender, userInputEventArgs);
            return (TResult)userInputEventArgs.Value;
        }
    }
}
