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
        private readonly Timer timer = null;

        /// <summary>
        /// ctor
        /// </summary>
        public MainWindowViewModel(IDialogProvider dialogProvider, IApplication application)
        {
            this.dialogProvider = dialogProvider;

            levels = LevelLoader.GetLevels(dialogProvider, application);
            currLevelId = 0;
            LoadNewLevel();

            PlayerMovement.OnWinCell += PlayerMovement_OnWinCell;

            #region old
            /////////////////////////////////////////////////

            //cols = 22;
            //rows = 22;

            //level = new()
            //{
            //    MapLayer = new MapLayer(rows, cols),
            //    MapTileSetType = MapTileSetType.Ice,
            //    CharaLayer = new CharaLayer(CharaLook.RedCat),
            //};

            //var tileSize = MapTileSetDict.Get(level.MapTileSetType).TileSize;
            //var spriteSize = CharaSpriteSetDict.Get(level.CharaLayer.MainChara.CharaLook).TileSize;

            //level.MapLayer.Setup();

            //level.CharaLayer.Setup(spriteSize, tileSize);
            //PlayerMovement.TileSize = tileSize;
            //PlayerMovement.OnWinCell += PlayerMovement_OnWinCell;

            //File.WriteAllText("D:\\test.txt", level.Serialize(), Encoding.UTF8);

            //renderer = new(level.MapLayer, level.MapTileSetType, level.CharaLayer);
            #endregion

            timer = new Timer(TimerProc, null, 0, FrameRate);

            BP.Released += BP_Released;
            BP.BreakpointSet += BP_BreakpointSet;

        }

        private void LoadNewLevel()
        {
            level = levels[currLevelId];
            var tileSize = MapTileSetDict.Get(level.MapTileSetType).TileSize;
            var spriteSize = CharaSpriteSetDict.Get(level.CharaLayer.MainChara.CharaLook).TileSize;
            level.CharaLayer.Setup(level.StartRow, level.StartCol, spriteSize, tileSize);
            PlayerMovement.TileSize = tileSize;
            renderer = new(level);
        }

        private void PlayerMovement_OnWinCell(object sender, EventArgs e)
        {
            currLevelId++;
            if (currLevelId >= levels.Count)
            {
                timer.Dispose();
                PlayerMovement.GameOver();
                dialogProvider.ShowInfoMessage(Common.Res.Res.Victory);
                GameOver?.Invoke(null, null);
            }
            else
            {
                level = levels[currLevelId];
                LoadNewLevel();
            }
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
            level.CharaLayer.MainChara.UpdateHero(level.MapLayer, KeyboardState);
            PropertyHasChanged();
        }
    }
}
