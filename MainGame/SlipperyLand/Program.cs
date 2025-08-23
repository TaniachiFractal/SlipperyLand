using System;
using SlipperyLand.Providers;
using SlipperyLand.ViewModel;
using SlipperyLand.Windows;

namespace SlipperyLand
{
    internal class Program
    {
        /// <summary>
        /// The application entry point
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var app = new App();
            var dialogProvider = new DialogProvider();
            var windowProvider = new WindowProvider();
            var mainWindowViewModel = new MainWindowViewModel(dialogProvider, windowProvider, app);
            var mainWindow = new MainWindow(mainWindowViewModel);
            app.Run(mainWindow);
        }
    }
}
