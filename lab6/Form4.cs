using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace lab6
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            String dir = Directory.GetCurrentDirectory();
            for (int i = 0; i < 2; ++i)
            {
                dir = dir.Substring(0, dir.LastIndexOf("\\"));
            }
            int pos = 0;
            this.chart1.Series.Clear();
            using (FileStream fs = new FileStream($"{dir}\\Input.txt", FileMode.Open, FileAccess.Read, FileShare.Read))
            using (StreamReader sr = new StreamReader(fs, Encoding.Default))
            {
                if (fs.Length != 0)
                {
                    pos++;
                    while (!sr.EndOfStream)
                    {
                        try
                        {
                            string text = sr.ReadLine();
                            char[] separator = { ',', ';', '.', ' ' };
                            string[] words = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                            this.chart1.Series.Add(words[0]).Name = words[0];
                            this.chart1.Series[words[0]].Points.AddXY($"{pos}", words[1]);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("The file is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
