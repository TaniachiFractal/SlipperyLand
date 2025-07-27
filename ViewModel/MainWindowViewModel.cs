using CellTypes.Layers;
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
            ChangeRandomCellCommand = new NoParamAction(ChangeRandomCellAction);

            cols = 12;
            rows = 6;

            MapLayer = new MapLayer(rows, cols);

            this.dialogProvider = dialogProvider;
        }
    }
}
