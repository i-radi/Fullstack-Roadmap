using System;
using System.Drawing;
using System.Windows.Forms;

namespace FStack_Alex1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.toolStripStatusLabel1.Text = label1.Text;
            this.toolStripStatusLabel2.Text = label1.ForeColor.Name;
        }


        private void RedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(Color.Red);
        }

        private void GreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(Color.Green);
        }

        private void BlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLabelColor(Color.Blue);
        }

        private void ChangeLabelColor(Color clr)
        {
            label1.ForeColor = clr;
            this.toolStripStatusLabel2.Text = label1.ForeColor.Name;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.toolStripStatusLabel3.Text = "X = " + e.X.ToString();
            this.toolStripStatusLabel4.Text = "Y = " + e.Y.ToString();
        }
        private void ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dResult;
            colorDialog1.Color = this.label1.ForeColor;
            dResult = colorDialog1.ShowDialog();
            if(dResult == DialogResult.OK)
            {
                this.label1.ForeColor = colorDialog1.Color;
                this.toolStripStatusLabel2.Text = colorDialog1.Color.Name;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBox dialog = new DBox();
            DialogResult dResult;
            dialog.TBox = this.label1.Text;
            dResult = dialog.ShowDialog();
            if(dResult == DialogResult.OK)
            {
                this.label1.Text = dialog.TBox;
                this.toolStripStatusLabel1.Text = dialog.TBox;
            }
        }

    }
}
