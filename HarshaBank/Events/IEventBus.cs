namespace HarshaBank.Events
{
    /// <summary>
    /// Contract for subscribing to system events.
    /// </summary>
    internal interface IEventBus
    {
        /// <summary>
        /// Called when a component requires input from the user.
        /// </summary>
        event EventHandler<UserInputEventArgs>? UserInputRequired;
    }
}
