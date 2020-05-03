using System;
using System.Windows.Forms;

namespace lab6
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                label2.Text = radioButton1.Checked ? Convert.ToString(int.Parse(textBox1.Text), 2)
                : (radioButton2.Checked ? Convert.ToString(int.Parse(textBox1.Text), 8)
                : (radioButton3.Checked ? Convert.ToString(int.Parse(textBox1.Text), 16)
                : textBox1.Text));
            }
            catch
            {
                label2.Text = textBox1.Text;
            }
        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            label2.Text = textBox1.Text;
        }

        private void Button3_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Button1_Click(sender, e);
        }
    }
}
