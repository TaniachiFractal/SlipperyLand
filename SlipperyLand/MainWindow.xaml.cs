using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using ViewModel;

namespace SlipperyLand
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel viewModel;

        /// <summary>
        /// ctor
        /// </summary>
        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();

            this.viewModel = viewModel;
            DataContext = viewModel;

            keyboardTimer.AutoReset = true;
            keyboardTimer.Elapsed += KeyboardTimer_Elapsed;
            keyboardTimer.Start();
            //Icon = BitmapSource.Create(2, 2, 1, 1, PixelFormats.Gray2, null, new byte[16], 8);
        }

        #region keyboard

        private readonly Timer keyboardTimer = new(10);

        private readonly HashSet<Key> pressedKeys = new();

        #region key sets
        private readonly static HashSet<Key> upKeys = new() { Key.Up, Key.W };
        private readonly static HashSet<Key> downKeys = new() { Key.Down, Key.S };
        private readonly static HashSet<Key> leftKeys = new() { Key.Left, Key.A };
        private readonly static HashSet<Key> rightKeys = new() { Key.Right, Key.D };
        #endregion

        private void KeyboardTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            viewModel.UpKeyDown = pressedKeys.Overlaps(upKeys);
            viewModel.DownKeyDown = pressedKeys.Overlaps(downKeys);
            viewModel.LeftKeyDown = pressedKeys.Overlaps(leftKeys);
            viewModel.RightKeyDown = pressedKeys.Overlaps(rightKeys);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            pressedKeys.Add(e.Key);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            pressedKeys.Remove(e.Key);
        }

        #endregion

        private void TopGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void ExitButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void TopGrid_Loaded(object sender, RoutedEventArgs e)
        {
            TopGrid.Width = GameImage.Source.Width + 10;
        }

        #region fade

        private void FadeAnimation(double from, double to, EventHandler completed = null)
        {
            var fade = new DoubleAnimation(from, to, new Duration(TimeSpan.FromMilliseconds(300)));
            if (completed != null)
            { fade.Completed += completed; }
            BeginAnimation(Window.OpacityProperty, fade);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            TopGrid.MouseDown -= TopGrid_MouseDown;
            ExitButton.MouseDown -= ExitButton_MouseDown;
            void completed(object s, EventArgs _)
            {
                Closing -= Window_Closing;
                Close();
            }
            FadeAnimation(1, 0, completed);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FadeAnimation(0, 1);
        }

        #endregion
    }
}
