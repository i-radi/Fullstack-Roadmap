using System;
using System.Linq;
using System.Windows.Forms;

namespace Lab3Code_first
{
    public partial class Form1 : Form
    {
        Model1 ent = new Model1();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox1.Text = comboBox2.Text = "";
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            ent.SaveChanges();
            foreach (var dpt in ent.Departments)
            {
                comboBox1.Items.Add(dpt.Id.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = int.Parse(comboBox1.Text);
            var dept = ent.Departments.Where(x => x.Id == id).First();
            textBox1.Text = dept.Id.ToString();
            textBox2.Text = dept.Name;
            comboBox2.Items.Clear();

            var emps = ent.Employees.Where(x => x.DeptId == id);
            foreach (var emp in emps)
            {
                comboBox2.Items.Add(emp.Id.ToString());
            }
            comboBox2.Text = textBox3.Text = textBox4.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = int.Parse(comboBox2.Text);
            var emp = ent.Employees.First(x => x.Id == id);
            textBox4.Text = emp.Id.ToString();
            textBox3.Text = emp.Name;
        }

        private void addDeptBtn_Click(object sender, EventArgs e)
        {
            var dept = new Department();
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                var dpt = ent.Departments.Find(int.Parse(textBox1.Text));
                if (dpt == null)
                {
                    dept.Id = int.Parse(textBox1.Text);
                    dept.Name = textBox2.Text;
                    ent.Departments.Add(dept);
                    Form1_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Department is Available");
                }
            }
            else
            {
                MessageBox.Show("Data Empty");
            }
        }

        private void updateDeptBtn_Click(object sender, EventArgs e)
        {
            Department dept = ent.Departments.Find(int.Parse(textBox1.Text));
            if (dept != null)
            {
                dept.Name = textBox2.Text;
                Form1_Load(null, null);
            }
            else
            {
                MessageBox.Show("Invalid Data");
            }
        }

        private void deleteDeptBtn_Click(object sender, EventArgs e)
        {
            Department dept = ent.Departments.Find(int.Parse(textBox1.Text));

            if (dept != null)
            {
                dept.Employees.Clear();
                ent.SaveChanges();
                ent.Departments.Remove(dept);
                Form1_Load(null,null);
            }
            else
            {
                MessageBox.Show("Invalid Data");
            }
        }

        private void addEmpBtn_Click(object sender, EventArgs e)
        {
            var employee = new Employee();
            if (textBox3.Text != "" && textBox4.Text != "")
            {
                var emp = ent.Employees.Find(int.Parse(textBox4.Text));
                if (emp == null)
                {
                    employee.Id = int.Parse(textBox4.Text);
                    employee.Name = textBox3.Text;
                    employee.DeptId = int.Parse(textBox1.Text);
                    ent.Employees.Add(employee);
                    Form1_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Employee is Available");
                }
            }
            else
            {
                MessageBox.Show("Data Empty");
            }
        }

        private void updateEmpBtn_Click(object sender, EventArgs e)
        {
            Employee employee = ent.Employees.Find(int.Parse(textBox4.Text));
            if (employee != null)
            {
                employee.Name = textBox3.Text;
                Form1_Load(null, null);
            }
            else
            {
                MessageBox.Show("Invalid Data");
            }
        }

        private void deleteEmpBtn_Click(object sender, EventArgs e)
        {
            Employee employee = ent.Employees.Find(int.Parse(textBox4.Text));

            if (employee != null)
            {
                ent.Employees.Remove(employee);
                Form1_Load(null, null);
            }
            else
            {
                MessageBox.Show("Invalid Data");
            }
        }
    }
}