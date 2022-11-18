using HarshaBank.Entities;
using HarshaBank.Presentation.Controls;
using HarshaBank.Presentation.Views.Formatting;
using System.Security.Principal;

namespace HarshaBank.Presentation.Views.Application.Main
{
    /// <summary>
    /// View implementation for <see cref="HarshaBank.Presentation.Presenters.Application.Main.ConfigurationPresenter"/>.
    /// </summary>
    internal class ConfigurationView : IConfigurationView
    {
        private readonly FormControl<ApplicationConfiguration> _editControl;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationView"/> class.
        /// </summary>
        public ConfigurationView()
        {
            _editControl = new FormControl<ApplicationConfiguration>();
        }

        /// <inheritdoc />
        public void DisplayTitle()
        {
            Dialog.Title(TitleType.Mode, ResourceManager.GetText("Configuration_Title"));
        }

        /// <inheritdoc />
        public ApplicationConfiguration? EditSettings(ApplicationConfiguration configuration)
        {
            return _editControl.InputData(configuration);
        }

        /// <inheritdoc />
        public bool Confirm()
        {
            string? input = Dialog.Prompt(ResourceManager.GetText("Configuration_Prompts_Confirm"));
            return "yes".Equals(input, StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc />
        public void DisplayOperationCancelled()
        {
            Dialog.Notify(ResourceManager.GetText("Configuration_Notifications_Cancelled"));
        }

        /// <inheritdoc />
        public void DisplayConfigurationUpdated()
        {
            Dialog.Notify(ResourceManager.GetText("Configuration_Notifications_Updated"));
        }
    }
}
