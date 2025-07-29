using System.Threading;
using Common.Interfaces;
using Common.Types;
using GameTypes.Layers;
using GameTypes.TileSpriteSetTypes;
using GraphicsEngine;

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
            SetCommandActions();

            this.dialogProvider = dialogProvider;
            this.application = application;

            cols = 14;
            rows = 14;

            MapLayer = new MapLayer(rows, cols);
            MapTileSetType = MapTileSetType.Ice;

            CharaLayer = new CharaLayer();

            renderer = new GraphicsRenderer(MapLayer, MapTileSetType, CharaLayer);

            timer = new Timer(TimerProc, null, 0, FrameRate);
        }

        private void SetCommandActions()
        {
            ChangeRandomCellCommand = new NoParamAction(ChangeRandomCellAction);
            SetRandomCharacterCommand = new NoParamAction(SetRandomCharacterAction);
            CloseCommand = new NoParamAction(CloseAction);

        }


        private void TimerProc(object State)
        {
            PropertyHasChanged();
        }

    }
}
