using System.Threading;
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
        private const int FrameRate = 10;

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


            cols = 14;
            rows = 14;

            MapLayer = new MapLayer(rows, cols);
            MapTileSetType = MapTileSetType.Ice;

            MainChara = Chara.RedCat;
        }
    }
}
