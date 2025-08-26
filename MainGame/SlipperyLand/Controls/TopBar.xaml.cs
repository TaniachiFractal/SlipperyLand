using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SlipperyLand.Controls
{
    /// <summary>
    /// Interaction logic for TopBar.xaml
    /// </summary>
    public partial class TopBar : UserControl
    {
        /// <summary>
        /// The title property
        /// </summary>
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(TopBar),
                new FrameworkPropertyMetadata(TextResources.MainRes.AppName));

        /// <inheritdoc cref="TitleProperty"/>
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        private Window parent;

        /// <summary>
        /// ctor
        /// </summary>
        public TopBar()
        {
            InitializeComponent();
            DataContext = this;
        }

        private bool canTopGridMouseDown = true;

        private void TopBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (canTopGridMouseDown && e.ChangedButton == MouseButton.Left)
            {
                parent.DragMove();
            }
        }

        private void ExitButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            canTopGridMouseDown = false;
            parent.Close();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            parent = Window.GetWindow(this);
        }
    }
}
