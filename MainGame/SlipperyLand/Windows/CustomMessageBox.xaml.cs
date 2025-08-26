using System.Collections.Generic;
using System.Media;
using System.Windows;
using System.Windows.Input;
using SlipperyLand.ControllerInput;

namespace SlipperyLand.Windows
{
    /// <summary>
    /// Interaction logic for CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : ParentWindow
    {
        /// <summary>
        /// ctor
        /// </summary>
        public CustomMessageBox(string message, string title, MessageBoxImage messageBoxImage) : base(100)
        {
            InitializeComponent();
            TopBar.Title = title;
            Message.Content = message;

            KeyDown += Window_KeyDown;

            switch (messageBoxImage)
            {
                case MessageBoxImage.Information:
                    SystemSounds.Exclamation.Play();
                    break;
                case MessageBoxImage.Error:
                    SystemSounds.Hand.Play();
                    break;
                case MessageBoxImage.Warning:
                    SystemSounds.Hand.Play();
                    break;
            }
        }

        /// <inheritdoc/>
        protected override void GameControllerHandler_ControllerButtonDown(object sender, ControllerButton bt)
        {
            if (bt == ControllerButton.A_Cross)
            {
                Dispatcher?.Invoke(() => Close());
            }
        }

        /// <inheritdoc/>
        protected override void GameControllerHandler_ControllerButtonUp(object sender, ControllerButton bt)
        {
        }

        private static readonly HashSet<Key> enterKeys = [Key.Enter, Key.E];

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (enterKeys.Contains(e.Key))
            {
                Dispatcher?.Invoke(() => Close());
            }
        }
    }
}
