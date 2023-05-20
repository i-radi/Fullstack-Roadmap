using System;
using System.Windows.Forms;
using ConsoleApplication;

namespace GUI
{
    public partial class GUI : Form
    {
        public GUI()
        { InitializeComponent();}

        private void ExitBtn_Click(object sender, EventArgs e)
        { Close(); }

        private void min_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
                this.WindowState = FormWindowState.Minimized;
        }

        private void Msg_TextChanged(object sender, EventArgs e)
        {

            try
            {
                var obj = new Encryption(Key.Text);
                EncMsg.Text = obj.GetCipher(Msg.Text);
            }
            catch { EncMsg.Text = "Error"; }
        }
    }
}