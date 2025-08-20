using System;
using SlipperyLand.Providers;
using SlipperyLand.ViewModel;

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
            var mainWindowModel = new MainWindowViewModel(dialogProvider, app);
            var mainWindow = new MainWindow(mainWindowModel);
            app.Run(mainWindow);
        }
    }
}
