using lab8.Views;
using System.Windows;

namespace lab8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Show1(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Page1());
        }

        private void Show2(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Page2());
        }

        private void Show3(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Page3());
        }

        private void ShowQ(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Queries());
        }
    }
}
