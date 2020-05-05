using lab8.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace lab8.Views
{
    /// <summary>
    /// Логика взаимодействия для Table1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private async void AddClick(object sender, RoutedEventArgs e)
        {
            AddPeople addPeople = new AddPeople(DialogTypes.Add);
            if (addPeople.ShowDialog() == true)
            {
                People people = new People { Name = addPeople.nameBox.Text, Language = addPeople.languageBox.Text, Pic = addPeople.Img };
                await Task.Run(() => AddData(people));
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
                db.Entry(grid.SelectedItem as People).State = System.Data.Entity.EntityState.Deleted;
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
            AddPeople addPeople = new AddPeople(DialogTypes.Modify);
            People people = grid.SelectedItem as People;
            addPeople.nameBox.Text = people.Name;
            addPeople.languageBox.Text = people.Language;
            addPeople.Img = people.Pic;
            if (addPeople.ShowDialog() == true)
            {
                people.Name = addPeople.nameBox.Text;
                people.Language = addPeople.languageBox.Text;
                people.Pic = addPeople.Img;
                using (PeopleContext db = new PeopleContext())
                {
                    db.Entry(people).State = System.Data.Entity.EntityState.Modified;
                    await db.SaveChangesAsync();
                }
            }
        }
        
        private void AddData(People people)
        {
            using (PeopleContext db = new PeopleContext())
            {
                db.Peoples.Add(people);
                db.SaveChanges();
            }
        }

        private async void ShowDataAsync()
        {
            grid.ItemsSource = await Task.Run(() => GetDatabaseData());
        }

        private IEnumerable<People> GetDatabaseData()
        {
            using (PeopleContext db = new PeopleContext())
            {
                return db.Peoples.ToList().AsEnumerable();
            }
        }
    }
}
