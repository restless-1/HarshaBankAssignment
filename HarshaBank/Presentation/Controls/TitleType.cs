namespace HarshaBank.Presentation.Controls
{
    /// <summary>
    /// Specifies the type of title being displayed by <see cref="Dialog.Title(TitleType, string)"/>.
    /// </summary>
    internal enum TitleType
    {
        /// <summary>
        /// Application-level title.
        /// </summary>
        Application,

        /// <summary>
        /// Login page.
        /// </summary>
        Login,

        /// <summary>
        /// Menu title.
        /// </summary>
        Menu,

        /// <summary>
        /// An operation title (ex: Delete Customer).
        /// </summary>
        Mode
    }
}
