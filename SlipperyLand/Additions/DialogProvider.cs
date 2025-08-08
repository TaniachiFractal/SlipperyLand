using System.Windows;
using Contracts;

namespace SlipperyLand.Additions
{
    /// <inheritdoc cref="IDialogProvider"/>
    public class DialogProvider : IDialogProvider
    {
        bool IDialogProvider.AskWarning(string message)
            => ShowWarning(message, Common.Properties.Resources.Warning) == MessageBoxResult.OK;

        void IDialogProvider.ShowErrorMessage(string message)
            => ShowError(message, Common.Properties.Resources.Error);

        void IDialogProvider.ShowErrorMessage(string message, string title)
            => ShowError(message, title);

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
