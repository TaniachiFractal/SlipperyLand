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

        /// <inheritdoc cref="AskWarning(string)"/>
        /// <remarks>With a custom title</remarks>
        bool AskWarning(string message, string title);

        /// <summary>
        /// Show an error message
        /// </summary>
        void ShowErrorMessage(string message);

        /// <inheritdoc cref="ShowErrorMessage(string)"/>
        /// <remarks>With a custom title</remarks>
        void ShowErrorMessage(string message, string title);

        /// <summary>
        /// Show some information
        /// </summary>
        void ShowInfoMessage(string message);

        /// <inheritdoc cref="ShowErrorMessage(string)"/>
        /// <remarks>With a custom title</remarks>
        void ShowInfoMessage(string message, string title);

    }
}
