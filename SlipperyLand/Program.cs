using SlipperyLand.Additions;
using System;
using ViewModel;

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
            var mainWindowModel = new MainWindowViewModel(dialogProvider);
            var mainWindow = new MainWindow(mainWindowModel);
            app.Run(mainWindow);
        }
    }
}
