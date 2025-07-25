using Common.Interfaces;
using Common.Types;

namespace ViewModel
{
    /// <summary>
    /// The main model of the app
    /// </summary>
    public partial class MainWindowViewModel
    {
        /// <summary>
        /// ctor
        /// </summary>
        public MainWindowViewModel(IDialogProvider dialogProvider) 
        {
            TestCommand = new NoParamAction(TestAction);

            this.dialogProvider = dialogProvider;
        }
    }
}
