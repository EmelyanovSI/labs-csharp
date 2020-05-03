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
    }
}
