using System;
using System.Windows.Threading;
using SlipperyLand.Providers;
using SlipperyLand.TextResources;
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
        /// The dispatcher
        /// </summary>
        public static readonly Dispatcher Dispatcher = Dispatcher.CurrentDispatcher;

        /// <summary>
        /// The application entry point
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var app = new App(Language.ru);
            var dialogProvider = new DialogProvider();
            var mainWindowViewModel = new MainWindowViewModel(dialogProvider, app);
            var mainWindow = new MainWindow(mainWindowViewModel);
            app.Run(mainWindow);
        }
    }
}
