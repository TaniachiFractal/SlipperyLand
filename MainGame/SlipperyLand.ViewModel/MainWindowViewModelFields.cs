using System.Drawing;
using SlipperyLand.Common.Types;
using SlipperyLand.Contracts;
using SlipperyLand.GameTypes;
using SlipperyLand.GameTypes.Cells.Chara;
using SlipperyLand.GraphicsEngine;

namespace SlipperyLand.ViewModel
{
    /// <summary>
    /// The fields for <see cref="MainWindowViewModel"/>
    /// </summary>
    public partial class MainWindowViewModel
    {
        /// <summary>
        /// The image of the game field
        /// </summary>
        public Bitmap GameImage => renderer.GetGameImage();

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

        private KeyboardState KeyboardState => new() { LeftKeyDown = LeftKeyDown, DownKeyDown = DownKeyDown, RightKeyDown = RightKeyDown, UpKeyDown = UpKeyDown };

        #endregion

        private readonly IDialogProvider dialogProvider;
        private readonly IApplication application;

        private readonly GraphicsRenderer renderer;

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

        private readonly Level level;

        private CharaCell MainChara => level.CharaLayer.MainChara;

    }
}
