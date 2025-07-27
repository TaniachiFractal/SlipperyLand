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

        private void ExitButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            viewModel.CloseCommand.Execute();
        }
    }
}
