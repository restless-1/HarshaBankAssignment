namespace HarshaBank.Presentation.Views.Application
{
    /// <summary>
    /// View contract for menu presenters.
    /// </summary>
    internal interface IMenuView<TAction> where TAction : Enum
    {
        /// <summary>
        /// Inputs the user's menu option selection.
        /// </summary>
        /// <returns>
        /// The user's menu option choice.
        /// </returns>
        TAction InputSelection();
    }
}
