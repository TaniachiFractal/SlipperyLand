using System.ComponentModel;

namespace Common
{
    /// <inheritdoc cref="INotifyPropertyChanged"/>
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        /// <inheritdoc cref="PropertyChangedEventHandler"/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Invoke <see cref="PropertyChanged"/>
        /// </summary>
        protected void PropertyHasChanged() => PropertyChanged?.Invoke(this,
             new PropertyChangedEventArgs(null));

    }
}
