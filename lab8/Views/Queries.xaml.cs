using lab8.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace lab8.Views
{
    /// <summary>
    /// Логика взаимодействия для Queries.xaml
    /// </summary>
    public partial class Queries : Page, INotifyPropertyChanged
    {
        IEnumerable<Region> regions;
        IEnumerable<Region> Regions
        {
            get => regions;
            set
            {
                regions = value;
                OnProp("Regions");
            }
        }

        IEnumerable<People> peoples;
        IEnumerable<People> Peoples
        {
            get => peoples;
            set
            {
                peoples = value;
                OnProp("Peoples");
            }
        }

        IEnumerable<Weather> weathers;
        IEnumerable<Weather> Weathers
        {
            get => weathers;
            set
            {
                weathers = value;
                OnProp("Weathers");
            }
        }

        public Queries()
        {
            InitializeComponent();
            using (PeopleContext db = new PeopleContext())
            {
                Peoples = db.Peoples.ToArray();
                Regions = db.Regions.ToList();
                Weathers = db.Weathers.ToList();
                cb1.ItemsSource = Regions;
                cb2.ItemsSource = Regions;
                cb3.ItemsSource = Peoples;
                cb4.ItemsSource = Regions;
            }
        }

        public void OnProp(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Query1(object sender, RoutedEventArgs e)
        {
            try
            {
                grid.ItemsSource = Weathers.Where(w => w.RegionId == Regions.Where(r => r.Name == cb1.Text).Select(x => x.Id).First());
            }
            catch (Exception)
            {
                MessageBox.Show("No results.");
            }
        }

        private void Query2(object sender, RoutedEventArgs e)
        {
            try
            {
                grid.ItemsSource = Weathers
                .Where(w => w.RegionId == Regions
                .Where(r => r.Name == cb2.Text)
                .Select(x => x.Id).First() && w.Rainfall == true && w.Temperature < 0)
                .Select(x => x.Date);
            }
            catch (Exception)
            {
                MessageBox.Show("No results.");
            }
        }

        private void Query3(object sender, RoutedEventArgs e)
        {
            try
            {
                DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(DateTime.Now);
                grid.ItemsSource = Weathers
                    .Where(w => w.RegionId == Regions
                    .Where(r => r.PeopleId == Peoples
                    .Where(p => p.Language == cb3.Text)
                    .Select(x => x.Id).First())
                    .Select(x => x.Id).First() && CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(w.Date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) == CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) - 1);

            }
            catch(Exception)
            {
                MessageBox.Show("No results.");
            }
        }

        private void Query4(object sender, RoutedEventArgs e)
        {
            try
            {
                grid.ItemsSource = Regions.Select(r => new {
                    Region = r.Name,
                    Temperature = Weathers
                    .Where(w => w.RegionId == r.Id && r.Area >= int.Parse(cb4.Text)
                    && CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(w.Date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) == CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) - 1)
                    .Average(x => x.Temperature)
                });
            }
            catch (Exception)
            {
                MessageBox.Show("No results.");
            }
        }
    }
}
