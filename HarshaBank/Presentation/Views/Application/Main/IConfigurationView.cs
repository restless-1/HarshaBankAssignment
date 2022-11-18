using HarshaBank.Configuration;
using HarshaBank.Entities;

namespace HarshaBank.Presentation.Views.Application.Main
{
    /// <summary>
    /// View contract for <see cref="HarshaBank.Presentation.Presenters.Application.Main.ConfigurationPresenter"/>.
    /// </summary>
    internal interface IConfigurationView
    {
        /// <summary>
        /// Displays the view title.
        /// </summary>
        void DisplayTitle();

        /// <summary>
        /// Inputs configuration data.
        /// </summary>
        /// <param name="configuration">
        /// The current configuration data.
        /// </param>
        /// <returns>
        /// The edited configuration or null if the user cancelled the edit.
        /// </returns>
        ApplicationConfiguration? EditSettings(ApplicationConfiguration configuration);

        /// <summary>
        /// Prompts the user for update confirmation.
        /// </summary>
        /// <returns>
        /// true if the user confirmed the update; false otherwise.
        /// </returns>
        bool Confirm();

        /// <summary>
        /// Displays a message that the operation was cancelled.
        /// </summary>
        void DisplayOperationCancelled();
        void DisplayConfigurationUpdated();
    }
}
