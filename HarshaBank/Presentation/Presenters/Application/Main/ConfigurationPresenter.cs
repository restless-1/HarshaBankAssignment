using HarshaBank.Configuration;
using HarshaBank.DataAccessLayer;
using HarshaBank.Entities;
using HarshaBank.Presentation.Views.Application.Main;

namespace HarshaBank.Presentation.Presenters.Application.Main
{
    // NOTE: This functionality was added in as an afterthought.  It's functional, but not
    //       very elegant or maintainable.

    /// <summary>
    /// Workflow for application configuration.
    /// </summary>
    internal class ConfigurationPresenter : IApplicationModePresenter
    {
        private readonly IConfigurationView _view;
        private readonly ISettings _settings;
        private readonly IDataStore _dataStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationPresenter"/> class.
        /// </summary>
        /// <param name="settings">
        /// The settings store.
        /// </param>
        /// <param name="dataStore">
        /// The data store.
        /// </param>
        public ConfigurationPresenter(IConfigurationView view,
                                      ISettings settings,
                                      IDataStore dataStore)
        {
            _view = view;
            _settings = settings;
            _dataStore = dataStore;
        }

        /// <inheritdoc />
        public ApplicationMode Mode => ApplicationMode.Configuration;

        /// <inheritdoc />
        public ApplicationMode Enter()
        {
            _view.DisplayTitle();

            ApplicationConfiguration? editedConfiguration = 
                _view.EditSettings(
                    new ApplicationConfiguration()
                    {
                        BaseAccountCode = _settings.BaseAccountCode,
                        BaseCustomerCode= _settings.BaseCustomerCode,
                        DataFilePath = _settings.DataFilePath
                    }
                );

            if (editedConfiguration == null || !_view.Confirm())
            {
                _view.DisplayOperationCancelled();
                return ApplicationMode.MainMenu;
            }

            _dataStore.Save();
            _settings.BaseCustomerCode = editedConfiguration.BaseCustomerCode;
            _settings.BaseAccountCode = editedConfiguration.BaseAccountCode;
            _settings.DataFilePath = editedConfiguration.DataFilePath?.Trim();
            _dataStore.Load();

            _view.DisplayConfigurationUpdated();

            return ApplicationMode.MainMenu;
        }
    }
}
