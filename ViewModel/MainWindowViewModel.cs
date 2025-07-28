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
        public MainWindowViewModel(IDialogProvider dialogProvider, IApplication application)
        {
            this.dialogProvider = dialogProvider;
            this.application = application;

            ChangeRandomCellCommand = new NoParamAction(ChangeRandomCellAction);
            CloseCommand = new NoParamAction(CloseAction);

            cols = 8;
            rows = 8;

            MapLayer = new MapLayer(rows, cols);
            MapTileSetType = GameTypes.TileSpriteSetTypes.MapTileSetType.Ice;
            MapLayer.FillWithSlippery();
        }
    }
}
