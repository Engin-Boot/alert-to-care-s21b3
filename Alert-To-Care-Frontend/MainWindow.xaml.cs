using Alert_To_Care_Frontend.Views;
using System.Windows;

namespace Alert_To_Care_Frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += HomeWindow_Loaded;
        }

        private void HomeWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Frame.NavigationService.Navigate(new HomePage());
        }
    }
}
