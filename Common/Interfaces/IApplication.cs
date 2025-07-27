namespace Common.Interfaces
{
    /// <summary>
    /// The app methods that don't rely on the current system
    /// </summary>
    public interface IApplication
    {
        /// <summary>
        /// Close or shutdown the app
        /// </summary>
        void Close();
    }
}
