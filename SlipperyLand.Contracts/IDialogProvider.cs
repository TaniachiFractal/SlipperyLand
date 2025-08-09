namespace SlipperyLand.Contracts
{
    /// <summary>
    /// Provides messages and file dialogs
    /// </summary>
    public interface IDialogProvider
    {
        /// <summary>
        /// Ask user something
        /// </summary>
        /// <returns>Whether or not user has agreed</returns>
        bool AskWarning(string message);

        /// <summary>
        /// Show an error message
        /// </summary>
        void ShowErrorMessage(string message);

        /// <summary>
        /// Show an error message with a custom title
        /// </summary>
        void ShowErrorMessage(string message, string title);

        /// <summary>
        /// Show some information
        /// </summary>
        void ShowInfoMessage(string message, string title);

    }
}
