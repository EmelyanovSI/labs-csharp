using System;
using System.Windows.Forms;

namespace lab6
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            int x1 = -8;
            int x2 = 10;
            double h = (x2 - x1) / 300.0;
            for (double x = x1; x <= x2; x += h)
            {
                double y = F1(x);
                chart1.Series[0].Points.AddXY(x, y);
            }
        }

        private Double F1(double x)
        {
            double f = Double.NaN;
            if (x >= -8 && x <= -5)
            {
                f = -2;
            }
            else if (x > -5 && x < -3)
            {
                f = x + 3;
            }
            else if (x >= -3 && x <= 3)
            {
                f = Math.Sqrt(Math.Abs(Math.Pow(x, 2) - 9));
            }
            else if (x > 3 && x < 8)
            {
                f = 0.6 * (x - 3);
            }
            else if (x >= 8 && x <= 10)
            {
                f = 3;
            }
            return f;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(textBox1.Text);
                double y = Convert.ToDouble(textBox2.Text);
                double f = F1(x);
                chart1.Series[1].Points.Clear();
                chart1.Series[1].Points.AddXY(x, y);
                if (f == y)
                {
                    MessageBox.Show("Point belongs to the chart");
                }
                else
                {
                    MessageBox.Show("The point does not belong to the chart");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid point parameters");
            }
        }
    }
}
