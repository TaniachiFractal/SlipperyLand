using Common.Types;

namespace ViewModel
{
    /// <summary>
    /// The commands for <see cref="MainWindowViewModel"/>
    /// </summary>
    public partial class MainWindowViewModel
    {
        #region commands

        public NoParamAction TestCommand { get; private set; } 

        #endregion

        #region methods for commands

        private void TestAction()
        {
            dialogProvider.ShowErrorMessage("lol");
        }

        #endregion

    }
}
