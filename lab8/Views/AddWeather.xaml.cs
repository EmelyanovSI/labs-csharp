using System.Windows;
using System.Windows.Input;

namespace lab8.Views
{
    /// <summary>
    /// Логика взаимодействия для AddWeather.xaml
    /// </summary>
    public partial class AddWeather : Window
    {
        readonly DialogTypes type;

        public AddWeather(DialogTypes type)
        {
            InitializeComponent();
            this.type = type;
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            if (type == DialogTypes.Add)
            {
                if (!Add()) return;
            }
            else if (type == DialogTypes.Modify)
            {
                if (!Modify()) return;
            }
            DialogResult = true;
        }

        private bool Modify()
        {
            return true;
        }

        private bool Add()
        {
            if (dateBox.Text == string.Empty || temperatureBox.Text == string.Empty || regionBox.Text == string.Empty)
            {
                MessageBox.Show("Empty field(s) exists!");
                return false;
            }
            return true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBoxPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.OemPeriod)
            {
                e.Handled = true;
            }
        }
    }
}
