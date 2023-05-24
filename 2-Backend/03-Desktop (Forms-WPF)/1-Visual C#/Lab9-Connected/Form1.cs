using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FStack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //select
        private void Button1_Click(object sender, EventArgs e)
        {
            SqlDataReader dReader;
            if(listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();
                comboBox1.Items.Clear();
            }
            sqlCommand1.CommandText = "Select Id, Name, Department From Emp";
            sqlConnection1.Open();
            dReader = sqlCommand1.ExecuteReader();
            while(dReader.Read())
            {
                string str = $"{((int)dReader[0]).ToString()}\t{dReader[1].ToString()}\t{dReader[2].ToString()}";
                listBox1.Items.Add(str);
                comboBox1.Items.Add((int)dReader[0]);
            }

            dReader.Close();
            sqlConnection1.Close();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlCommand1.CommandText = $"Select Id, Name, Department From Emp Where ID = {comboBox1.Text}";
            sqlConnection1.Open();
            SqlDataReader dReader = sqlCommand1.ExecuteReader();
            if(dReader.Read())
            {
                textBox1.Text = ((int)dReader["Id"]).ToString();
                textBox2.Text = dReader["Name"].ToString();
                textBox3.Text = dReader["Department"].ToString();
            }
            dReader.Close();
            sqlConnection1.Close();
        }

        //execute
        private void Button5_Click(object sender, EventArgs e)
        {
            if(sender as Button == button2)//insert
            {
                sqlCommand1.CommandText = $"Insert Into Emp Values({textBox1.Text}, '{textBox2.Text}', '{textBox3.Text}')";
            }
            else if(sender as Button == button3)//update
            {
                sqlCommand1.CommandText = $"Update Emp Set Name = '{textBox2.Text} ',Department = '{textBox3.Text}' Where Id = {textBox1.Text}";
            }
            else if(sender as Button == button4)//delete
            {
                sqlCommand1.CommandText = $"Delete From Emp Where Name = '{textBox2.Text}'";
            }
            sqlConnection1.Open();
            int affectedRows = sqlCommand1.ExecuteNonQuery();
            sqlConnection1.Close();
            MessageBox.Show(affectedRows.ToString() + " Rows changed");
            textBox1.Text = textBox2.Text = textBox3.Text = "";
        }

    }
}
