using System.Diagnostics;
using System.IO;
using System;
using System.Threading;
using SlipperyLand.Common;
using SlipperyLand.Common.Types;
using SlipperyLand.Contracts;
using SlipperyLand.GameTypes.Layers;
using SlipperyLand.GameTypes.TileSpriteSetTypes;
using SlipperyLand.GraphicalResources.Characters;
using SlipperyLand.GraphicalResources.Map;
using SlipperyLand.LevelMapper.Serialization;
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




            //cols = 22;
            //rows = 22;

            //level = new()
            //{
            //    MapLayer = new MapLayer(rows, cols),
            //    MapTileSetType = MapTileSetType.Ice,
            //    CharaLayer = new CharaLayer(CharaLook.RedCat)
            //};
            //var tileSize = MapTileSetDict.Get(level.MapTileSetType).TileSize;
            //var spriteSize = CharaSpriteSetDict.Get(level.CharaLayer.MainChara.CharaLook).TileSize;

            //level.MapLayer.Setup();

            //level.CharaLayer.Setup(spriteSize, tileSize);
            //PlayerMovement.TileSize = tileSize;
            //PlayerMovement.OnWinCell += PlayerMovement_OnWinCell;

            ////File.WriteAllText("D:\\test.txt", level.Serialize());
            ////level.MapLayer = MapSerializer.Deserialize(File.ReadAllText("D:\\test.txt"));

            //renderer = new(level.MapLayer, level.MapTileSetType, level.CharaLayer);

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
