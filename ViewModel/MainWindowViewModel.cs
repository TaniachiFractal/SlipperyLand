using System.Threading;
using Common.Interfaces;
using Common.Types;
using GameTypes.Layers;
using GameTypes.TileSpriteSetTypes;
using GraphicsEngine;
using MainLogic;

namespace ViewModel
{
    /// <summary>
    /// The main model of the app
    /// </summary>
    public partial class MainWindowViewModel : NotifyPropertyChanged
    {
        private const int FrameRate = 30;
        private readonly Timer timer;

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
            FillMap();

            CharaLayer = new CharaLayer(CharaLook.RedCat);

            renderer = new GraphicsRenderer(MapLayer, MapTileSetType, CharaLayer);

            timer = new Timer(TimerProc, null, 0, FrameRate);
        }

        private void SetCommandActions()
        {
            ChangeRandomCellCommand = new NoParamCommand(ChangeRandomCell);
        }

        private void TimerProc(object State)
        {
            MainChara.UpdateHero(KeyboardState);
            PropertyHasChanged();
        }

        private void FillMap()
        {
            mapLayer.FillWithSlippery();
            mapLayer.SetWallBorder();
        }

    }
}
