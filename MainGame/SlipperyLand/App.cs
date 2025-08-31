using System.Windows;
using SlipperyLand.Contracts;
using SlipperyLand.TextResources;

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
        internal App(Language language)
        {
            if (LangDict.TryGet(language, out var langStr))
            { System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(langStr); }
        }

        void IApplication.Close() => Shutdown();
    }
}
