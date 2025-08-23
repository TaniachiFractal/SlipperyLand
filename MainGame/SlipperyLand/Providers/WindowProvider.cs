using SlipperyLand.Contracts;

namespace SlipperyLand.Providers
{
    /// <inheritdoc cref="IWindowProvider"/>
    internal class WindowProvider : IWindowProvider
    {
        private static readonly IDialogProvider dialogProvider = new DialogProvider();

        void IWindowProvider.OpenHelp()
            => dialogProvider.ShowInfoMessage("help");

        void IWindowProvider.OpenSettings()
            => dialogProvider.ShowInfoMessage("settings");
    }
}
