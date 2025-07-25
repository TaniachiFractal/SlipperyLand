using System.Windows;
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
    }
}
