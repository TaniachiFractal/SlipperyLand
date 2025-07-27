using System.Windows;
using Common.Interfaces;

namespace SlipperyLand
{
    /// <summary>
    /// This application
    /// </summary>
    internal class App : Application, IApplication
    {
        /// <summary>
        /// The constructor for <see cref="App"/>
        /// </summary>
        internal App()
        {
        }

        void IApplication.Close() => Shutdown();
    }
}
