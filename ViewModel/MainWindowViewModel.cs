using Common.Interfaces;
using Common.Types;
using GameTypes.Layers;
using GameTypes.TileSpriteSetTypes;

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
            SetRandomCharacterCommand = new NoParamAction(SetRandomCharacterAction);
            CloseCommand = new NoParamAction(CloseAction);


            cols = 8;
            rows = 8;

            MapLayer = new MapLayer(rows, cols);
            MapTileSetType = MapTileSetType.Ice;
            MapLayer.FillWithSlippery();

            CharaLayer = new CharaLayer(rows, cols);
            MainChara = Chara.RedCat;
        }
    }
}
