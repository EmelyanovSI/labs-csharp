using lab8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace lab8.Views
{
    /// <summary>
    /// Логика взаимодействия для Table3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
        }

        private async void AddClick(object sender, RoutedEventArgs e)
        {
            AddWeather ww = new AddWeather(DialogTypes.Add);
            if (ww.ShowDialog() == true)
            {
                Weather w = new Weather
                {
                    Date = DateTime.Parse(ww.dateBox.Text),
                    Temperature = int.Parse(ww.temperatureBox.Text),
                    Rainfall = ww.rainfallBox.IsChecked == true,
                    RegionId = int.Parse(ww.regionBox.Text)
                };
                await Task.Run(() => AddData(w));
            }
            ShowDataAsync();
        }

        private void ShowClick(object sender, RoutedEventArgs e)
        {
            ShowDataAsync();
        }

        private async void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (grid.SelectedItem == null)
            {
                MessageBox.Show("Select a record!");
                return;
            }
            using (PeopleContext db = new PeopleContext())
            {
                db.Entry(grid.SelectedItem as Weather).State = System.Data.Entity.EntityState.Deleted;
                await db.SaveChangesAsync();
            }
            ShowDataAsync();
        }

        private async void ModifyClick(object sender, RoutedEventArgs e)
        {
            if (grid.SelectedItem == null)
            {
                MessageBox.Show("Select a record!");
                return;
            }
            Weather w = grid.SelectedItem as Weather;
            AddWeather addW = new AddWeather(DialogTypes.Modify);
            addW.dateBox.Text = w.Date.ToString();
            addW.temperatureBox.Text = w.Temperature.ToString();
            addW.rainfallBox.IsChecked = w.Rainfall;
            addW.regionBox.Text = w.RegionId.ToString();
            if (addW.ShowDialog() == true)
            {
                w.Date = addW.dateBox.SelectedDate.Value;
                w.Temperature = int.Parse(addW.temperatureBox.Text);
                w.Rainfall = addW.rainfallBox.IsChecked == true;
                w.RegionId = int.Parse(addW.regionBox.Text);
                using (PeopleContext db = new PeopleContext())
                {
                    db.Entry(w).State = System.Data.Entity.EntityState.Modified;
                    await db.SaveChangesAsync();
                }
            }
            ShowDataAsync();
        }

        private async void ShowDataAsync()
        {
            grid.ItemsSource = await Task.Run(() => GetDatabaseData());
        }

        private IEnumerable<Weather> GetDatabaseData()
        {
            using (PeopleContext db = new PeopleContext())
            {
                return db.Weathers.ToList().AsEnumerable();
            }
        }

        private void AddData(Weather w)
        {
            using (PeopleContext db = new PeopleContext())
            {
                db.Weathers.Add(w);
                db.SaveChanges();
            }
        }
    }
}
