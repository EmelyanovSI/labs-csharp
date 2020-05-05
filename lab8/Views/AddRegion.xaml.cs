using System.Windows;
using System.Windows.Input;

namespace lab8.Views
{
    /// <summary>
    /// Логика взаимодействия для AddRegion.xaml
    /// </summary>
    public partial class AddRegion : Window
    {
        readonly DialogTypes type;

        public AddRegion(DialogTypes dialogTypes)
        {
            InitializeComponent();
            type = dialogTypes;
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
            if (nameBox.Text == string.Empty || areaBox.Text == string.Empty || peopleBox.Text == string.Empty)
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
