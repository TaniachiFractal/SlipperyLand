using System.Runtime.CompilerServices;
using System.Windows;
using SlipperyLand.Contracts;

namespace SlipperyLand.Providers
{
    /// <inheritdoc cref="IDialogProvider"/>
    public class DialogProvider : IDialogProvider
    {
        bool IDialogProvider.AskWarning(string message)
            => (this as IDialogProvider).AskWarning(message, Common.Res.Res.Warning);

        bool IDialogProvider.AskWarning(string message, string title)
            => ShowWarning(message, title) == MessageBoxResult.OK;

        void IDialogProvider.ShowErrorMessage(string message)
            => ShowError(message, Common.Res.Res.Error);

        void IDialogProvider.ShowErrorMessage(string message, string title)
            => ShowError(message, title);

        void IDialogProvider.ShowInfoMessage(string message)
            => ShowInfo(message, Common.Res.Res.Information);

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
