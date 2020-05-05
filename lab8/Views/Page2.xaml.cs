using lab8.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace lab8.Views
{
    /// <summary>
    /// Логика взаимодействия для Table2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private async void AddClick(object sender, RoutedEventArgs e)
        {
            AddRegion rg = new AddRegion(DialogTypes.Add);
            if (rg.ShowDialog() == true)
            {
                Region r = new Region
                {
                    Name = rg.nameBox.Text,
                    Area = int.Parse(rg.areaBox.Text),
                    PeopleId = int.Parse(rg.peopleBox.Text)
                };
                await Task.Run(() => AddData(r));
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
                db.Entry(grid.SelectedItem as Region).State = System.Data.Entity.EntityState.Deleted;
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
            Region r = grid.SelectedItem as Region;
            AddRegion rg = new AddRegion(DialogTypes.Modify);
            rg.nameBox.Text = r.Name;
            rg.areaBox.Text = r.Area.ToString();
            rg.peopleBox.Text = r.PeopleId.ToString();
            if (rg.ShowDialog() == true)
            {
                r.Name = rg.nameBox.Text;
                r.Area = int.Parse(rg.areaBox.Text);
                r.PeopleId = int.Parse(rg.peopleBox.Text);
                using (PeopleContext db = new PeopleContext())
                {
                    db.Entry(r).State = System.Data.Entity.EntityState.Modified;
                    await db.SaveChangesAsync();
                }
            }
            ShowDataAsync();
        }

        private async void ShowDataAsync()
        {
            grid.ItemsSource = await Task.Run(() => GetDatabaseData());
        }

        private IEnumerable<Region> GetDatabaseData()
        {
            using (PeopleContext db = new PeopleContext())
            {
                return db.Regions.ToList().AsEnumerable();
            }
        }

        private void AddData(Region r)
        {
            using (PeopleContext db = new PeopleContext())
            {
                db.Regions.Add(r);
                db.SaveChanges();
            }
        }
    }
}
