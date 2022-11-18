using HarshaBank.DataAccessLayer;
using HarshaBank.Presentation.Views.Application;

namespace HarshaBank.Presentation.Presenters.Application
{
    /// <summary>
    /// Workflow for application exit.
    /// </summary>
    internal class ExitPresenter : IApplicationModePresenter
    {
        private readonly IExitView _view;
        private readonly IDataStore _dataLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExitPresenter"/> class.
        /// </summary>
        /// <param name="view">
        /// View used to interact with the user.
        /// </param>
        /// <param name="dataLayer">
        /// Data layer used to save application data.
        /// </param>
        public ExitPresenter(IExitView view, IDataStore dataLayer)
        {
            _view = view;
            _dataLayer = dataLayer;
        }

        /// <inheritdoc />
        public ApplicationMode Mode => ApplicationMode.Exit;

        /// <inheritdoc />
        public ApplicationMode Enter()
        {
            try
            {
                _dataLayer.Save();
            }
            catch (Exception exception)
            {
                _view.DisplaySaveError(exception);
            }
            _view.DisplayExitMessage();
            return ApplicationMode.Terminate;
        }
    }
}
