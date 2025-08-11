using System.Diagnostics;
using System.Threading;
using SlipperyLand.Common.Types;
using SlipperyLand.Contracts;
using SlipperyLand.GameTypes.Extensions;
using SlipperyLand.GameTypes.Layers;
using SlipperyLand.GameTypes.TileSpriteSetTypes;
using SlipperyLand.GraphicalResources.Characters;
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
            var tileSize = MapTileSetDict.Get(mapTileSetType).TileSize;

            charaLayer = new CharaLayer(CharaLook.RedCat);
            var spriteSize = CharaSpriteSetDict.Get(charaLayer.MainChara.charaLook).TileSize;

            MapLayer.Setup();
            CharaLayer.Setup(spriteSize, tileSize);
            PlayerMovement.TileSize = tileSize;

            renderer = new GraphicsRenderer(MapLayer, mapTileSetType, CharaLayer);

            timer = new Timer(TimerProc, null, 0, FrameRate);
        }

        private void SetCommandActions()
        {
            ChangeRandomCellCommand = new NoParamCommand(ChangeRandomCell);
        }

        private void TimerProc(object? State)
        {
            StopTimerDebug();
            MainChara.UpdateHero(MapLayer, KeyboardState);
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

    }
}
