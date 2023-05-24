using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int x;
        private int y;
        private void button1_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out x);
            int.TryParse(textBox2.Text, out y);
            textBox3.Text = (x + y).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = (Int32.Parse(textBox1.Text) - Int32.Parse(textBox2.Text)).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = (Int32.Parse(textBox1.Text) * Int32.Parse(textBox2.Text)).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var num1 = Int32.Parse(textBox1.Text); 
            var num2  = float.Parse(textBox2.Text);
            textBox3.Text = (num1 /num2 ).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
