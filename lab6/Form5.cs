using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace lab6
{
    public partial class Form5 : Form
    {
        int[] array;
        int c = -1;
        public Form5()
        {
            InitializeComponent();
            chart1.Enabled = false;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developer: EmelyanovSI", "Author");
        }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            animateToolStripMenuItem.Enabled = false;
            OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Text files(*.txt)|*.txt" };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                char[] separator = { ',', ';', ' ', '.' };
                string text = String.Empty;
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read))
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    if (fs.Length != 0)
                    {
                        try
                        {
                            while (!sr.EndOfStream)
                            {
                                text += sr.ReadLine();
                            }
                            string[] word = text.Split(separator);
                            array = new int[word.Length];
                            for (int i = 0; i < word.Length; ++i)
                            {
                                array[i] = Convert.ToInt32(word[i]);
                            }
                            animateToolStripMenuItem.Enabled = true;
                            chart1.Series.Clear();
                            chart1.Enabled = true;
                            for (int i = 0; i < array.Length; ++i)
                            {
                                this.chart1.Series.Add(array[i].ToString()).Name = $"{array[i]}";
                                this.chart1.Series[array[i].ToString()].Points.AddXY(1, array[i]);
                            }
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Invalid format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The file is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void AnimateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            c = -1;
            Timer timer = new Timer { Interval = 1000 };
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
            if (c == array.Length - 1)
            {
                timer.Stop();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ++c;
            if (c < array.Length)
            {
                int min = c;
                for (int j = c + 1; j < array.Length; ++j)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                this.chart1.Series[c].Points[0].SetValueY(array[min]);
                this.chart1.Series[min].Points[0].SetValueY(array[c]);
                string a = " ";
                this.chart1.Series[min].Name = a.PadLeft(c) + array[c].ToString();
                this.chart1.Series[c].Name = $"Sort: " + array[min].ToString();
                int temp = array[min];
                array[min] = array[c];
                array[c] = temp;
            }
        }
    }
}
