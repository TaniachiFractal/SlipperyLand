using System.Windows;
using SlipperyLand.Contracts;

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
