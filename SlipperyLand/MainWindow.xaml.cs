using System.Windows;
using System.Windows.Input;
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

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void MainGrid_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                case Key.Up:
                    {
                        viewModel.ChangeDirUp();
                        viewModel.KeyboardState.UpKeyDown = true;
                        break;
                    }
                case Key.S:
                case Key.Down:
                    {
                        viewModel.ChangeDirDown();
                        viewModel.KeyboardState.DownKeyDown = true;
                        break;
                    }
                case Key.A:
                case Key.Left:
                    {
                        viewModel.ChangeDirLeft();
                        viewModel.KeyboardState.LeftKeyDown = true;
                        break;
                    }
                case Key.D:
                case Key.Right:
                    {
                        viewModel.ChangeDirRight();
                        viewModel.KeyboardState.RightKeyDown = true;
                        break;
                    }
            }
        }

        private void MainGrid_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                case Key.Up:
                    {
                        viewModel.KeyboardState.UpKeyDown = false;
                        break;
                    }
                case Key.S:
                case Key.Down:
                    {
                        viewModel.KeyboardState.DownKeyDown = false;
                        break;
                    }
                case Key.A:
                case Key.Left:
                    {
                        viewModel.KeyboardState.LeftKeyDown = false;
                        break;
                    }
                case Key.D:
                case Key.Right:
                    {
                        viewModel.KeyboardState.RightKeyDown = false;
                        break;
                    }
            }
        }

        private void ExitButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            viewModel.CloseCommand.Execute();
        }
    }
}
