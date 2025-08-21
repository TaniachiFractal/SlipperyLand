using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using SlipperyLand.Common.Types;
using SlipperyLand.Contracts;
using SlipperyLand.GameTypes;
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

        /// <summary>
        /// Invoked upon ending the game
        /// </summary>
        public event EventHandler<EventArgs> GameOver;

        /// <summary>
        /// Invoked upon switching the level
        /// </summary>
        public event EventHandler<EventArgs> SwithingLevels;

        /// <summary>
        /// Invoked upon having switched the level
        /// </summary>
        public event EventHandler<EventArgs> SwitchedLevels;

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

        private const int FrameRate = 25;
        private readonly Timer timer = null;

        private readonly IDialogProvider dialogProvider;

        private GraphicsRenderer renderer;

        private readonly IReadOnlyList<Level> levels;
        private int currLevelId;
        private Level level;
    }
}
