using System;
using System.Data;
using System.Windows.Forms;

namespace Lab8_Disconnected
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlDataAdapter1.Fill(dataSet11);
            sqlConnection1.Close();
            dataGridView1.DataSource = dataSet11.Tables[0];
        }
        //insert
        private void button3_Click(object sender, EventArgs e)
        {
            int InsertedId = int.Parse(textBox1.Text);
            DataRow dRow = dataSet11.Tables[0].Rows.Find(InsertedId);
            if (dRow == null)
            {
                dRow = dataSet11.Tables[0].NewRow();
                dRow["Id"] = int.Parse(textBox1.Text);
                dRow[1] = textBox2.Text;
                dRow[2] = textBox3.Text;
                dataSet11.Tables[0].Rows.Add(dRow);
                textBox1.Text = textBox2.Text = textBox3.Text = "";
            }
            else
            {
                MessageBox.Show("Available ID");
            }
        }
        //update
        private void button4_Click(object sender, EventArgs e)
        {
            int UpdateId = int.Parse(textBox1.Text);
            DataRow dRow = dataSet11.Tables["Emp"].Rows.Find(UpdateId);
            if (dRow != null)
            {
                dRow[1] = textBox2.Text;
                dRow[2] = textBox3.Text;
                textBox1.Text = textBox2.Text = textBox3.Text = "";
            }
            else
            {
                MessageBox.Show("Record Not Found");
            }
        }
        //delete
        private void button5_Click(object sender, EventArgs e)
        {
            int DeleteId = int.Parse(textBox1.Text);
            DataRow dRow = dataSet11.Tables[0].Rows.Find(DeleteId);
            if (dRow != null)
            {
                dataSet11.Tables[0].Rows.Find(DeleteId).Delete();
                textBox1.Text = textBox2.Text = textBox3.Text = "";
            }
            else
            {
                MessageBox.Show("Record Not Found");
            }
        }
        //save changes
        private void button2_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlDataAdapter1.Update(dataSet11);
            sqlConnection1.Close();
            MessageBox.Show("Database Updated");
        }
    }
}
