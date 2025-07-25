namespace Common.Interfaces
{
    /// <summary>
    /// Provides messages and file dialogs
    /// </summary>
    public interface IDialogProvider
    {
        /// <summary>
        /// Ask user something
        /// </summary>
        bool AskWarning(string message);

        /// <summary>
        /// Show an error message
        /// </summary>
        void ShowErrorMessage(string message);

        /// <summary>
        /// Show an error message with a custom title
        /// </summary>
        void ShowErrorMessage(string message, string title);

    }
}
