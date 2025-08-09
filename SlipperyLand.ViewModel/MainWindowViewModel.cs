using System.Diagnostics;
using System.Threading;
using SlipperyLand.Common.Types;
using SlipperyLand.Contracts;
using SlipperyLand.GameTypes.Layers;
using SlipperyLand.GameTypes.Extensions;
using SlipperyLand.GameTypes.TileSpriteSetTypes;
using SlipperyLand.GraphicalResources.Map;
using SlipperyLand.GraphicsEngine;
using SlipperyLand.MainLogic;

namespace SlipperyLand.ViewModel
{
#nullable enable
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

            mapLayer = new MapLayer(rows, cols);
            mapTileSetType = MapTileSetType.Ice;
            mapTileSet = MapTileSetDict.Get(mapTileSetType);

            charaLayer = new CharaLayer(CharaLook.RedCat);

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

        private void TimerProc(object? State)
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
