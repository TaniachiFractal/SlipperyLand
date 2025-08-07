using System.Diagnostics;
using System.Threading;
using Common.Interfaces;
using Common.Types;
using GameTypes.Layers;
using GameTypes.TileSpriteSetTypes;
using GraphicalResources.Map;
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

        private readonly MapTileSet mapTileSet;

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
            mapTileSetType = MapTileSetType.Ice;
            mapTileSet = MapTileSetDict.Get(mapTileSetType);

            CharaLayer = new CharaLayer(CharaLook.RedCat);

            SetupGame();

            renderer = new GraphicsRenderer(MapLayer, mapTileSet, CharaLayer);

            timer = new Timer(TimerProc, null, 0, FrameRate);
        }

        private void SetupGame()
        {
            FillMap();
            MainChara.SetCharaRowColPos(1, 1, mapTileSet.TileSize);
        }

        private void SetCommandActions()
        {
            ChangeRandomCellCommand = new NoParamCommand(ChangeRandomCell);
        }

        private void TimerProc(object State)
        {
            StopTimerDebug();
            MainChara.UpdateHero(MapLayer, mapTileSet.TileSize, KeyboardState);
            PropertyHasChanged();
            StartTimerDebug();
        }

        private void StopTimerDebug()
        {
            if (Debugger.IsAttached)
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }

        private void StartTimerDebug()
        {
            if (Debugger.IsAttached)
            {
                timer.Change(0, FrameRate);
            }
        }

        private void FillMap()
        {
            mapLayer.FillWithSlippery();
            mapLayer.SetWallBorder();
        }

    }
}
