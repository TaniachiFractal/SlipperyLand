using System.Diagnostics;
using System.Threading;
using SlipperyLand.Common;
using SlipperyLand.Common.Types;
using SlipperyLand.Contracts;
using SlipperyLand.GameTypes.Layers;
using SlipperyLand.GameTypes.TileSpriteSetTypes;
using SlipperyLand.GraphicalResources.Characters;
using SlipperyLand.GraphicalResources.Map;
using SlipperyLand.MainLogic;
using SlipperyLand.LevelJsonMapper;

namespace SlipperyLand.ViewModel
{
#nullable enable
    /// <summary>
    /// The main model of the app
    /// </summary>
    public partial class MainWindowViewModel : NotifyPropertyChanged
    {
        private const int FrameRate = 25;
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

            level = new()
            {
                MapLayer = new MapLayer(rows, cols),
                MapTileSetType = MapTileSetType.Ice,
                CharaLayer = new CharaLayer(CharaLook.RedCat)
            };
            var tileSize = MapTileSetDict.Get(level.MapTileSetType).TileSize;
            var spriteSize = CharaSpriteSetDict.Get(level.CharaLayer.MainChara.charaLook).TileSize;

            level.MapLayer.Setup();
            level.CharaLayer.Setup(spriteSize, tileSize);
            PlayerMovement.TileSize = tileSize;
            PlayerMovement.OnWinCell += PlayerMovement_OnWinCell;

            renderer = new(level.MapLayer, level.MapTileSetType, level.CharaLayer);

            timer = new Timer(TimerProc, null, 0, FrameRate);

            BP.Released += BP_Released;
            BP.BreakpointSet += BP_BreakpointSet;

            level.ToJson();
        }

        private void PlayerMovement_OnWinCell(object sender, System.EventArgs e)
        {
            dialogProvider.ShowInfoMessage("you won!");
        }

        private void BP_BreakpointSet(object sender, System.EventArgs e)
        {
            if (Debugger.IsAttached)
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }

        private void BP_Released(object sender, System.EventArgs e)
        {
            if (Debugger.IsAttached)
            {
                timer.Change(0, FrameRate);
            }
        }

        private void SetCommandActions()
        {
            ChangeRandomCellCommand = new NoParamCommand(ChangeRandomCell);
        }

        private void TimerProc(object? State)
        {
            MainChara.UpdateHero(level.MapLayer, KeyboardState);
            PropertyHasChanged();
        }
    }
}
