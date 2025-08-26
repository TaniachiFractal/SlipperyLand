using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using SlipperyLand.ControllerInput;

namespace SlipperyLand.Windows
{
    /// <summary>
    /// Window template
    /// </summary>
    public abstract class ParentWindow : Window
    {
        private readonly int fadeTime = 0;

        /// <summary>
        /// ctor
        /// </summary>
        public ParentWindow(int fadeTime)
        {
            this.fadeTime = fadeTime;

            ResizeMode = ResizeMode.NoResize;
            AllowsTransparency = true;
            FontFamily = new FontFamily("Cascadia Mono");
            WindowStyle = WindowStyle.None;

            Closing += Window_Closing;
            Loaded += Window_Loaded;

            Program.GameControllerHandler.ControllerButtonDown += GameControllerHandler_ControllerButtonDown;
            Program.GameControllerHandler.ControllerButtonUp += GameControllerHandler_ControllerButtonUp;
        }

        /// <summary>
        /// When a button on the controller is released
        /// </summary>
        protected abstract void GameControllerHandler_ControllerButtonUp(object sender, ControllerButton bt);

        /// <summary>
        /// When a button on the controller is pressed
        /// </summary>
        protected abstract void GameControllerHandler_ControllerButtonDown(object sender, ControllerButton bt);

        /// <summary>
        /// Animates the window fading in or out
        /// </summary>
        protected void FadeAnimation(double from, double to, EventHandler completed = null)
        {
            DoubleAnimation NewAnim(double from, double to)
                => new(from, to, new Duration(TimeSpan.FromMilliseconds(fadeTime)));

            var opacityFade = NewAnim(from, to);
            if (completed != null)
            { opacityFade.Completed += completed; }
            BeginAnimation(OpacityProperty, opacityFade);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
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
    }
}
