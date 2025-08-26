using System.Windows;
using System.Windows.Threading;
using SlipperyLand.Contracts;
using SlipperyLand.TextResources;
using SlipperyLand.Windows;

namespace SlipperyLand.Providers
{
    /// <inheritdoc cref="IDialogProvider"/>
    public class DialogProvider : IDialogProvider
    {
        private static readonly Dispatcher dispatcher = Dispatcher.CurrentDispatcher;

        bool IDialogProvider.AskWarning(string message)
            => (this as IDialogProvider).AskWarning(message, DialogRes.Warning);

        bool IDialogProvider.AskWarning(string message, string title)
            => ShowWarning(message, title) == MessageBoxResult.OK;

        void IDialogProvider.ShowErrorMessage(string message)
            => ShowError(message, DialogRes.Error);

        void IDialogProvider.ShowErrorMessage(string message, string title)
            => ShowError(message, title);

        void IDialogProvider.ShowInfoMessage(string message)
            => ShowInfo(message, DialogRes.Information);

        void IDialogProvider.ShowInfoMessage(string message, string title)
            => ShowInfo(message, title);

        private void ShowError(string message, string title)
            => dispatcher.Invoke(() => new CustomMessageBox(message, title, MessageBoxImage.Error).ShowDialog());

        private MessageBoxResult ShowWarning(string message, string title)
            => MessageBox.Show(message, title, MessageBoxButton.OKCancel, MessageBoxImage.Warning);

        private void ShowInfo(string message, string title)
            => dispatcher.Invoke(() => new CustomMessageBox(message, title, MessageBoxImage.Information).ShowDialog());

    }
}
