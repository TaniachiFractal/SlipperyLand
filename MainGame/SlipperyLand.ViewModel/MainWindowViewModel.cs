using System;
using System.Diagnostics;
using System.Threading;
using SlipperyLand.Common;
using SlipperyLand.Common.Types;
using SlipperyLand.Contracts;
using SlipperyLand.GraphicalResources.Characters;
using SlipperyLand.GraphicalResources.Map;
using SlipperyLand.MainLogic;

namespace SlipperyLand.ViewModel
{
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
            this.dialogProvider = dialogProvider;
            this.application = application;

            var levels = LevelLoader.GetLevels();

            level = levels[0];

            var tileSize = MapTileSetDict.Get(level.MapTileSetType).TileSize;
            var spriteSize = CharaSpriteSetDict.Get(level.CharaLayer.MainChara.CharaLook).TileSize;

            PlayerMovement.TileSize = tileSize;
            PlayerMovement.OnWinCell += PlayerMovement_OnWinCell;

            renderer = new(level.MapLayer, level.MapTileSetType, level.CharaLayer);

            timer = new Timer(TimerProc, null, 0, FrameRate);

            BP.Released += BP_Released;
            BP.BreakpointSet += BP_BreakpointSet;

        }

        private void PlayerMovement_OnWinCell(object sender, EventArgs e)
        {
            dialogProvider.ShowInfoMessage("you won!");
        }

        private void BP_BreakpointSet(object sender, EventArgs e)
        {
            if (Debugger.IsAttached)
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }

        private void BP_Released(object sender, EventArgs e)
        {
            if (Debugger.IsAttached)
            {
                timer.Change(0, FrameRate);
            }
        }

        private void TimerProc(object State)
        {
            MainChara.UpdateHero(level.MapLayer, KeyboardState);
            PropertyHasChanged();
        }
    }
}
