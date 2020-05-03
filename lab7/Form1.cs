using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace lab7
{
    public partial class Form1 : Form
    {
        private readonly Stack<string> stack1 = new Stack<string>();
        private readonly Stack<string> stack2 = new Stack<string>();
        readonly GameStudio[] gameStudios = new GameStudio[]
        {
            new GameStudio() { Name = "Ubisoft", Country = "Canada", DateOfFoundation = 1999 },
            new GameStudio() { Name = "Naughty Dog", Country = "USA", DateOfFoundation = 2004 },
        };
        readonly Game[] games = new Game[]
        {
            new Game() { Name = "AC", Price = 2000, GameStudio = "Ubisoft" },
            new Game() { Name = "Far Cry", Price = 1340, GameStudio = "Ubisoft" },
            new Game() { Name = "Rainbow Six", Price = 1575, GameStudio = "Ubisoft" },
            new Game() { Name = "Watch Dogs", Price = 1886, GameStudio = "Ubisoft" },
            new Game() { Name = "The Last Of Us", Price = 4000, GameStudio = "Naughty Dog" },
            new Game() { Name = "Uncharted", Price = 3499, GameStudio = "Naughty Dog" },
            new Game() { Name = "Crash Bandicoot", Price = 3499, GameStudio = "Naughty Dog" },
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string[] array1 = Regex.Split(richTextBox1.Text.Trim(), @"[ :;,.!?/(|)]+");
            string[] array2 = Regex.Split(richTextBox2.Text.Trim(), @"[ :;,.!?/(|)]+");
            foreach (string s in array1) { stack1.Push(s); }
            foreach (string s in array2) { stack2.Push(s); }

            List<string> str = new List<string>();
            foreach (string s in stack1) { str.Add(s); }
            stack1.Clear();
            int count = stack2.Count();
            for (int i = 0; i < count; ++i) { stack1.Push(stack2.Pop()); }
            foreach (string s in str) { stack2.Push(s); }

            richTextBox1.Text = "";
            richTextBox2.Text = "";
            count = stack1.Count();
            for (int i = 0; i < count; ++i) { richTextBox1.Text += $"{stack1.Pop()} "; }
            count = stack2.Count();
            for (int i = 0; i < count; ++i) { richTextBox2.Text += $"{stack2.Pop()} "; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox3.Text += "Name: " + gameStudios[0].Name + "\n";
            richTextBox3.Text += "Country: " + gameStudios[0].Country + "\n";
            richTextBox3.Text += "Established: " + gameStudios[0].DateOfFoundation + "\n";
            richTextBox3.Text += "--------------------------------" + "\n";
            for (int i = 0; i < games.Length - 3; i++)
            {
                richTextBox3.Text += "Name of the game:  " + games[i].Name + "\n";
                richTextBox3.Text += "Price of the game: " + games[i].Price + "\n";
                richTextBox3.Text += "Game Studio: " + games[i].GameStudio + "\n";
            }
            richTextBox3.Text += "\n";
            richTextBox3.Text += "############################" + "\n";
            richTextBox3.Text += "\n";
            richTextBox3.Text += "Name: " + gameStudios[1].Name + "\n";
            richTextBox3.Text += "Country: " + gameStudios[1].Country + "\n";
            richTextBox3.Text += "Established: " + gameStudios[1].DateOfFoundation + "\n";
            richTextBox3.Text += "--------------------------------" + "\n";
            for (int i = 4; i < games.Length; i++)
            {
                richTextBox3.Text += "Name of the game:  " + games[i].Name + "\n";
                richTextBox3.Text += "Price of the game: " + games[i].Price + "\n";
                richTextBox3.Text += "Game Studio: " + games[i].GameStudio + "\n";
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            richTextBox4.Clear();
            if (textBox1.Text.Length != 0)
            {
                if (textBox1.Text == "Ubisoft" || textBox1.Text == "Naughty Dog")
                {
                    richTextBox4.Text += "Request1: " + "\n";
                    // Request1
                    var result1 = games.Where(a => a.Price > 1000);
                    foreach (var item in result1)
                    {
                        richTextBox4.Text += item.Name + "\n";
                    }
                    richTextBox4.Text += "--------------------------------" + "\n";
                    richTextBox4.Text += "Request2: " + "\n";
                    // Request2
                    var result2 = games.Where(a => textBox1.Text == a.GameStudio && a.Price < 3000);
                    foreach (var item in result2)
                    {
                        richTextBox4.Text += item.Name + "\n";
                    }
                    richTextBox4.Text += "--------------------------------" + "\n";
                    richTextBox4.Text += "Request3: " + "\n";
                    // Request3
                    var result3 = from p in games
                                  where p.GameStudio == "Ubisoft"
                                  orderby p.Name
                                  select p;
                    foreach (var item in result3)
                    {
                        richTextBox4.Text += item.Name + "\n";
                    }
                    richTextBox4.Text += "--------------------------------" + "\n";
                    richTextBox4.Text += "Request4: " + "\n";
                    // Request4
                    var result4 = from p in games
                                  where p.GameStudio == "Naughty Dog"
                                  select new { Count = p.Name.Count() };
                    foreach (var item in result4)
                    {
                        richTextBox4.Text += item.Count + "\n";
                    }
                    richTextBox4.Text += "--------------------------------" + "\n";
                    richTextBox4.Text += "Request5: " + "\n";
                    // Request5
                    var result5_1 = games.Max(a => a.Price);
                    var result5_2 = games.Average(a => a.Price);
                    richTextBox4.Text += "Max: " + result5_1 + "\n";
                    richTextBox4.Text += "Average: " + $"{result5_2}" + "\n";
                    richTextBox4.Text += "--------------------------------" + "\n";
                    richTextBox4.Text += "Request6: " + "\n";
                    // Request6
                    var result6 = from p in gameStudios
                                  let dates = DateTime.Now.Year - p.DateOfFoundation
                                  select new { p.Name, Data = dates };
                    foreach (var item in result6)
                    {
                        richTextBox4.Text += item.Name + ": " + item.Data + "\n";
                    }
                    richTextBox4.Text += "--------------------------------" + "\n";
                    richTextBox4.Text += "Request7: " + "\n";
                    // Request7
                    var result7 = from p in games
                                  group p by p.GameStudio;
                    foreach (var item in result7)
                    {
                        foreach (var a in item)
                        {
                            richTextBox4.Text += a.GameStudio + ": " + a.Name + "\n";
                        }
                    }
                    richTextBox4.Text += "--------------------------------" + "\n";
                    richTextBox4.Text += "Request8: " + "\n";
                    // Request8
                    var result8 = from p in games
                                  join a in gameStudios on p.GameStudio equals a.Name
                                  select new { p.Name, a.Country };
                    foreach (var item in result8)
                    {
                        richTextBox4.Text += item.Name + ": " + item.Country + "\n";
                    }
                    richTextBox4.Text += "--------------------------------" + "\n";
                    richTextBox4.Text += "Request9: " + "\n";
                    // Request9
                    var result9 = gameStudios.GroupJoin(
                            games, item1 => item1.Name, item2 => item2.GameStudio,
                            (coun, nam) => new { coun.Country, Name = nam.Select(a => a.Name).ToArray() }
                        );
                    foreach (var t in result9)
                    {
                        richTextBox4.Text += t.Country + ": " + "\n";
                        foreach (var g in t.Name)
                        {
                            richTextBox4.Text += g + "\n";
                        }
                    }
                    richTextBox4.Text += "--------------------------------" + "\n";
                    // Request10
                    var result10 = games.All(a => a.Price > 2000);
                    richTextBox4.Text += "Request10: " + result10 + "\n";
                    richTextBox4.Text += "--------------------------------" + "\n";
                    // Request11
                    var result11 = games.Any(a => a.Name == "The Last Of Us");
                    richTextBox4.Text += "Request11: " + result11 + "\n";
                }
                else
                {
                    MessageBox.Show("Enter Ubisoft or Naughty Dog", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                };
            }
            else
            {
                MessageBox.Show("Enter the name of company", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            };
        }
    }
}
