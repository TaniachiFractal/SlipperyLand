using System.Threading;
using Common.Interfaces;
using Common.Types;
using GameTypes;
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
            keyboardState = new KeyboardState();
        }

        #region changeDir

        private void ChangeDir(Direction dir) => MainCharaDir = dir;

        /// <summary>
        /// Change the main character direction
        /// </summary>
        public void ChangeDirUp() => ChangeDir(Direction.Up);
        /// <inheritdoc cref="ChangeDirUp"/>
        public void ChangeDirDown() => ChangeDir(Direction.Down);
        /// <inheritdoc cref="ChangeDirUp"/>
        public void ChangeDirLeft() => ChangeDir(Direction.Left);
        /// <inheritdoc cref="ChangeDirUp"/>
        public void ChangeDirRight() => ChangeDir(Direction.Right);

        #endregion

        private void SetCommandActions()
        {
            ChangeRandomCellCommand = new NoParamCommand(ChangeRandomCell);
            CloseCommand = new NoParamCommand(Close);
        }

        private void TimerProc(object State)
        {
            MainChara.MoveHero(MainCharaDir, KeyboardState);
            PropertyHasChanged();
        }

        private void FillMap()
        {
            mapLayer.FillWithSlippery();
            mapLayer.SetWallBorder();
        }

    }
}
