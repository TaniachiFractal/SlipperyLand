using System;
using SlipperyLand.Providers;
using SlipperyLand.ViewModel;
using SlipperyLand.Windows;

namespace SlipperyLand
{
    internal class Program
    {
        /// <summary>
        /// The controller handler for this application
        /// </summary>
        public static readonly GameControllerHandler GameControllerHandler = new();

        /// <summary>
        /// The application entry point
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var app = new App();
            var dialogProvider = new DialogProvider();
            var mainWindowViewModel = new MainWindowViewModel(dialogProvider, app);
            var mainWindow = new MainWindow(mainWindowViewModel);
            app.Run(mainWindow);
        }
    }
}
