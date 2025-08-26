using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using SlipperyLand.ControllerInput;
using SlipperyLand.ViewModel;

namespace SlipperyLand.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ParentWindow
    {
        private readonly MainWindowViewModel viewModel;

        /// <summary>
        /// ctor
        /// </summary>
        public MainWindow(MainWindowViewModel viewModel) : base(300)
        {
            this.viewModel = viewModel;
            DataContext = viewModel;

            InitializeComponent();

            viewModel.GameOver += ViewModel_GameOver;
            viewModel.SwitchingLevels += ViewModel_SwithingLevels;
            viewModel.SwitchedLevels += ViewModel_SwitchedLevels;

            inputTimer.AutoReset = true;
            inputTimer.Elapsed += InputTimer_Elapsed;
            inputTimer.Start();
        }

        private void ViewModel_SwitchedLevels(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() => FadeAnimation(0, 1));
        }

        private void ViewModel_SwithingLevels(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() => FadeAnimation(1, 0));
        }

        private void ViewModel_GameOver(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() => Close());
        }

        #region input

        private readonly Timer inputTimer = new(10);

        private readonly HashSet<Key> pressedKeys = [];

        #region key sets
        private readonly static HashSet<Key> upKeys = [Key.Up, Key.W];
        private readonly static HashSet<Key> downKeys = [Key.Down, Key.S];
        private readonly static HashSet<Key> leftKeys = [Key.Left, Key.A];
        private readonly static HashSet<Key> rightKeys = [Key.Right, Key.D];
        #endregion

        private void InputTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            viewModel.UpKeyDown = pressedKeys.Overlaps(upKeys);
            viewModel.DownKeyDown = pressedKeys.Overlaps(downKeys);
            viewModel.LeftKeyDown = pressedKeys.Overlaps(leftKeys);
            viewModel.RightKeyDown = pressedKeys.Overlaps(rightKeys);
        }

        private void Window_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            pressedKeys.Clear();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            pressedKeys.Add(e.Key);
            Debug.WriteLine(sender.ToString());
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            pressedKeys.Remove(e.Key);
        }

        #region controller

        /// <inheritdoc/>
        protected override void GameControllerHandler_ControllerButtonUp(object sender, ControllerButton bt)
        {
            ControllerToKeyboardDictionary.Dict.TryGetValue(bt, out var key);
            pressedKeys.Remove(key);
        }

        /// <inheritdoc/>
        protected override void GameControllerHandler_ControllerButtonDown(object sender, ControllerButton bt)
        {
            ControllerToKeyboardDictionary.Dict.TryGetValue(bt, out var key);
            pressedKeys.Add(key);
        }

        #endregion

        #endregion

        private void TopBar_Loaded(object sender, RoutedEventArgs e)
        {
            TopBar.Width = GameImage.Source.Width + 5;
        }

    }
}
