namespace HarshaBank.Events
{
    /// <summary>
    /// Event data for <see cref="IEventBus.UserInputRequired"/> events.
    /// </summary>
    internal class UserInputEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserInputEventArgs"/> class.
        /// </summary>
        /// <param name="type">
        /// The class representing the user input needed.
        /// </param>
        /// <param name="data">
        /// Context data for the listener.
        /// </param>
        public UserInputEventArgs(Type type, object? data)
        {
            this.Type = type;
            Data = data;
        }

        /// <summary>
        /// Gets the class representing the user input needed.
        /// </summary>
        public readonly Type Type;

        /// <summary>
        /// Gets context data.
        /// </summary>
        public readonly object? Data;

        /// <summary>
        /// The event listener should set this property to the object
        /// containing user input.
        /// </summary>
        public object? Value;
    }
}
