using HarshaBank.Properties;

namespace HarshaBank.Presentation.Views.Formatting
{
    /// <summary>
    /// Helper functions for interacting with application resources.
    /// </summary>
    internal static class ResourceManager
    {
        /// <summary>
        /// Fetches strings from application resources.
        /// </summary>
        /// <param name="textId">
        /// The ID of the string or format string to retrieve.
        /// </param>
        /// <param name="args">
        /// Arguments to be inserted into placeholders in the format string.
        /// </param>
        /// <returns>
        /// The requested string.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// No text is defined for the specified ID.
        /// </exception>
        public static string GetText(string textId, params object[] args)
        {
            string? text = Resources.ResourceManager.GetString(textId);
            if (text == null)
            {
                throw new InvalidOperationException($"No text is defined for the ID {textId}");
            }
            return string.Format(text, args);
        }
    }
}
