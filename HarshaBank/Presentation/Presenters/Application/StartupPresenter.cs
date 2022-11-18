using HarshaBank.DataAccessLayer;
using HarshaBank.Presentation.Views.Application;

namespace HarshaBank.Presentation.Presenters.Application
{
    /// <summary>
    /// Workflow for application startup.
    /// </summary>
    internal class StartupPresenter : IApplicationModePresenter
    {
        private readonly IStartupView _view;
        private readonly IDataStore _dataLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="StartupPresenter"/> class.
        /// </summary>
        /// <param name="view">
        /// View used to interact with the user.
        /// </param>
        /// <param name="dataLayer">
        /// Data layer used to load application data.
        /// </param>
        public StartupPresenter(IStartupView view, IDataStore dataLayer)
        {
            _view = view;
            _dataLayer = dataLayer;
        }

        /// <inheritdoc />
        public ApplicationMode Mode => ApplicationMode.Startup;

        /// <inheritdoc />
        public ApplicationMode Enter()
        {
            _view.DisplayApplicationTitle();
            try
            {
                _dataLayer.Load();
            }
            catch (Exception exception)
            {
                _view.DisplayLoadError(exception);
            }
            return ApplicationMode.Login;
        }
    }
}
