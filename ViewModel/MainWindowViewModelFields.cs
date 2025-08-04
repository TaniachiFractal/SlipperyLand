using System.Drawing;
using Common;
using Common.Interfaces;
using Common.Types;
using GameTypes;
using GameTypes.Cells;
using GameTypes.Layers;
using GameTypes.TileSpriteSetTypes;
using GraphicsEngine;
using MainLogic;

namespace ViewModel
{
    /// <summary>
    /// The fields for <see cref="MainWindowViewModel"/>
    /// </summary>
    public partial class MainWindowViewModel
    {
        private readonly IDialogProvider dialogProvider;
        private readonly IApplication application;

        private readonly GraphicsRenderer renderer;

        #region keyboard state


        private bool leftKeyDown;
        private bool rightKeyDown;
        private bool upKeyDown;
        private bool downKeyDown;

        /// <summary>
        /// Left key down
        /// </summary>
        public bool LeftKeyDown
        {
            get => leftKeyDown;
            set
            {
                leftKeyDown = value;
                PropertyHasChanged();
            }
        }
        /// <summary>
        /// Right key down
        /// </summary>
        public bool RightKeyDown
        {
            get => rightKeyDown;
            set
            {
                rightKeyDown = value;
                PropertyHasChanged();
            }
        }
        /// <summary>
        /// Up key down
        /// </summary>
        public bool UpKeyDown
        {
            get => upKeyDown;
            set
            {
                upKeyDown = value;
                PropertyHasChanged();
            }
        }
        /// <summary>
        /// Down key down
        /// </summary>
        public bool DownKeyDown
        {
            get => downKeyDown;
            set
            {
                downKeyDown = value;
                PropertyHasChanged();
            }
        }

        private KeyboardState KeyboardState => new KeyboardState() { LeftKeyDown = LeftKeyDown, DownKeyDown = DownKeyDown, RightKeyDown = RightKeyDown, UpKeyDown = UpKeyDown };

        #endregion

        #region cols rows

        private int cols, rows;

        /// <summary>
        /// Col count of the field
        /// </summary>
        public int Cols
        {
            get => cols;
            set => cols = value;
        }

        /// <summary>
        /// Row count of the field
        /// </summary>
        public int Rows
        {
            get => rows;
            set => rows = value;
        }

        #endregion

        #region mapLayer

        private MapTileSetType mapTileSetType;

        /// <summary>
        /// The tile set type
        /// </summary>
        private MapTileSetType MapTileSetType
        {
            get => mapTileSetType;
            set
            {
                mapTileSetType = value;
                PropertyHasChanged();
            }
        }

        private MapLayer mapLayer;

        /// <summary>
        /// The map layer
        /// </summary>
        private MapLayer MapLayer
        {
            get => mapLayer;
            set
            {
                mapLayer = value;
                PropertyHasChanged();
            }
        }

        /// <summary>
        /// The image for map layer
        /// </summary>
        public Bitmap MapLayerImage => renderer.GetMapImage();

        #endregion

        #region charaLayer

        private CharaCell MainChara => CharaLayer.MainChara;

        private CharaLayer charaLayer;

        /// <summary>
        /// The charaLook layer
        /// </summary>
        private CharaLayer CharaLayer
        {
            get => charaLayer;
            set
            {
                charaLayer = value;
                PropertyHasChanged();
            }
        }

        /// <summary>
        /// The image for the charaLook layer
        /// </summary>
        public Bitmap CharaLayerImage => renderer.GetCharasImage();

        #endregion
    }
}
