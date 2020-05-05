using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace lab8.Views
{
    public enum DialogTypes
    {
        Add,
        Modify
    }

    /// <summary>
    /// Логика взаимодействия для AddPeople.xaml
    /// </summary>
    public partial class AddPeople : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        byte[] img;

        public byte[] Img
        {
            get => img;
            set
            {
                img = value;
                OnPropertyChanged("Img");
            }
        }

        DialogTypes DialogType { get; set; }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public AddPeople(DialogTypes type)
        {
            InitializeComponent();
            DialogType = type;
        }


        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            if (nameBox.Text == string.Empty || languageBox.Text == string.Empty)
            {
                MessageBox.Show("Empty field(s) exists!");
                return;
            }
            if (DialogType == DialogTypes.Add)
            {
                if (!Add()) return;
            }
            else
            {
                if (!Modify()) return;
            }
            DialogResult = true;
        }

        private bool Modify()
        {
            if (nameBox.Text == string.Empty || languageBox.Text == string.Empty)
            {
                MessageBox.Show("Empty field(s) exists!");
                return false;
            }
            return true;
        }

        private bool Add()
        {
            if (Img == null)
            {
                MessageBox.Show("Image!");
                return false;
            }
            return true;
        }

        private byte[] ConvertImage()
        {
            byte[] dataImage = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != true)
            {
                return dataImage;
            }
            BitmapImage image = new BitmapImage(new Uri(openFileDialog.FileName));
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    dataImage = ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dataImage;
        }

        private void Сancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void SelectImage(object sender, RoutedEventArgs e)
        {
            var img = ConvertImage();
            if (img != null)
            {
                Img = img;
            }
        }
    }
}
