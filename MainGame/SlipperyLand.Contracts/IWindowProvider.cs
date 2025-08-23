namespace SlipperyLand.Contracts
{
    /// <summary>
    /// Provides functionality to open needed windows
    /// </summary>
    public interface IWindowProvider
    {
        /// <summary>
        /// Open the help window
        /// </summary>
        void OpenHelp();

        /// <summary>
        /// Open the settings window
        /// </summary>
        void OpenSettings();
    }
}
