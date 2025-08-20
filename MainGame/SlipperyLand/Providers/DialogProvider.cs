using System.Windows;
using SlipperyLand.Contracts;
using SlipperyLand.Common.Res;

namespace SlipperyLand.Providers
{
    /// <inheritdoc cref="IDialogProvider"/>
    public class DialogProvider : IDialogProvider
    {
        bool IDialogProvider.AskWarning(string message)
            => (this as IDialogProvider).AskWarning(message, Res.Warning);

        bool IDialogProvider.AskWarning(string message, string title)
            => ShowWarning(message, title) == MessageBoxResult.OK;

        void IDialogProvider.ShowErrorMessage(string message)
            => ShowError(message, Res.Error);

        void IDialogProvider.ShowErrorMessage(string message, string title)
            => ShowError(message, title);

        void IDialogProvider.ShowInfoMessage(string message)
            => ShowInfo(message, Res.Information);

        void IDialogProvider.ShowInfoMessage(string message, string title)
            => ShowInfo(message, title);

        private void ShowError(string message, string title)
            => MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);

        private MessageBoxResult ShowWarning(string message, string title)
            => MessageBox.Show(message, title, MessageBoxButton.OKCancel, MessageBoxImage.Warning);

        private void ShowInfo(string message, string title)
           => MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
    }
}
