using HarshaBank.Events;
using HarshaBank.Presentation.Presenters;
using HarshaBank.Presentation.Presenters.Application;
using HarshaBank.Presentation.Presenters.Input;

namespace HarshaBank
{
    /// <summary>
    /// Main application logic.
    /// </summary>
    internal class Application
    {
        private readonly IDictionary<ApplicationMode, IApplicationModePresenter> _applicationModePresenters;
        private readonly IDictionary<Type, IUserInputPresenter> _userInputPresenters;

        /// <summary>
        /// Initializes a new instance of the <see cref="Application"/> class.
        /// </summary>
        /// <param name="eventBus">
        /// The event bus used to subscribe to system events.
        /// </param>
        /// <param name="presenters">
        /// The presenters used to drive the presentation layer.
        /// </param>
        /// <exception cref="ArgumentException">
        /// More than one presenter is assigned to one <see cref="ApplicationMode"/>.
        /// </exception>
        public Application(IEventBus eventBus, params IPresenter[] presenters)
        {
            eventBus.UserInputRequired += OnUserInputRequired;
            _applicationModePresenters = new Dictionary<ApplicationMode, IApplicationModePresenter>();
            _userInputPresenters = new Dictionary<Type, IUserInputPresenter>();
            if (presenters == null)
            {
                return;
            }

            foreach (IPresenter presenter in presenters)
            {
                if (presenter is IApplicationModePresenter applicationModePresenter)
                {
                    if (_applicationModePresenters.ContainsKey(applicationModePresenter.Mode))
                    {
                        throw new ArgumentException(
                            $"More than one presenter is assigned for the {Enum.GetName(applicationModePresenter.Mode)} mode",
                            nameof(presenters)
                        );
                    }
                    _applicationModePresenters[applicationModePresenter.Mode] = applicationModePresenter;
                }
                else if (presenter is IUserInputPresenter userInputPresenter)
                {
                    if (_userInputPresenters.ContainsKey(userInputPresenter.Type))
                    {
                        throw new ArgumentException(
                            $"More than one presenter is assigned for the {userInputPresenter.Type} type",
                            nameof(presenters)
                        );
                    }
                    _userInputPresenters[userInputPresenter.Type] = userInputPresenter;
                }
                else
                {
                    throw new ArgumentException(
                        $"Unsupported presenter type: {presenter.GetType()}",
                        nameof(presenters)
                    );
                }
            }
        }

        /// <summary>
        /// Executes the application.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// No presenter is available for the requested operation.
        /// This indicates a bug in the application code.
        /// </exception>
        public void Execute()
        {
            try
            {
                ApplicationMode nextMode = ApplicationMode.Startup;
                do
                {
                    if (!_applicationModePresenters.TryGetValue(nextMode, out IApplicationModePresenter? presenter))
                    {
                        throw new InvalidOperationException($"No presenter is registered for {Enum.GetName(nextMode)}");
                    }

                    nextMode = presenter.Enter();
                } while (nextMode != ApplicationMode.Terminate);
                Environment.ExitCode = 0;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"\n\nFatal Error: {exception}");
                Environment.ExitCode = 1;
            }
        }

        /// <summary>
        /// Event handler for <see cref="IEventBus.UserInputRequired"/>.
        /// </summary>
        /// <param name="sender">
        /// Object where the event originated.
        /// </param>
        /// <param name="e">
        /// Event details.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// No presenter is registered for the requested input type.
        /// This indicates a bug in the application code.
        /// </exception>
        private void OnUserInputRequired(object? sender, UserInputEventArgs e)
        {
            if (_userInputPresenters.TryGetValue(e.Type, out IUserInputPresenter? presenter))
            {
                e.Value = presenter.Execute(e.Data);
            }
            else
            {
                throw new InvalidOperationException($"No presenter is registered for {e.Type}");
            }
        }
    }
}
