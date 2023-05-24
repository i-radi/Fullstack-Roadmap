using System;
using System.Windows.Forms;

namespace Lab2_DatabaseFirst
{
    public partial class Form1 : Form
    {
        
        private DepartmentRepository deptRepo = new DepartmentRepository();
        private EmployeeRepository empRepo = new EmployeeRepository();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillDeptBox();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Id = int.Parse(comboBox1.Text);
            Department dept = deptRepo.GetById(Id);
            if (dept != null)
            {
                textBox1.Text = dept.Id.ToString();
                textBox2.Text = dept.Name;
                ClearEmp();
                FillEmpBox(dept);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Id = int.Parse(comboBox2.Text);
            Employee emp = empRepo.GetById(Id);
            if (emp != null)
            {
                textBox4.Text = emp.Id.ToString();
                textBox3.Text = emp.Name;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Department dept = new Department
            {
                Id = int.Parse(textBox1.Text),
                Name = textBox2.Text
            };
            if (deptRepo.GetById(dept.Id) == null)
            {
                deptRepo.Post(dept);
                deptRepo.Save();
                ClearDept();
                ClearEmp();
                FillDeptBox();

            }
            else
            {
                MessageBox.Show("Invalid Data");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Department dept = new Department
            {
                Id = int.Parse(textBox1.Text),
                Name = textBox2.Text
            };
            if (deptRepo.GetById(dept.Id) != null)
            {
                deptRepo.Put(dept);
                deptRepo.Save();
            }
            else
            {
                MessageBox.Show("Invalid Data");
            }
            ClearDept();
            ClearEmp();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var id = int.Parse(textBox1.Text);

            if (deptRepo.GetById(id) != null)
            {
                foreach (var emp in deptRepo.GetById(id).Employees)
                {
                    emp.DeptId = 1;
                    empRepo.Save();
                }
                deptRepo.Delete(id);
                deptRepo.Save();
                FillDeptBox();
            }
            else
            {
                MessageBox.Show("Invalid Data");
            }
            ClearDept();
            ClearEmp();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee
            {
                Id = int.Parse(textBox4.Text),
                Name = textBox3.Text,
                DeptId = int.Parse(textBox1.Text)
            };
            if (empRepo.GetById(emp.Id) == null)
            {
                empRepo.Post(emp);
                empRepo.Save();
                ClearEmp();
                var dId = emp.DeptId??1;
                FillEmpBox(deptRepo.GetById(dId));
            }
            else
            {
                MessageBox.Show("Invalid Data");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee
            {
                Id = int.Parse(textBox4.Text),
                Name = textBox3.Text,
                DeptId = int.Parse(textBox1.Text)
            };
            if (empRepo.GetById(emp.Id) != null)
            {
                empRepo.Put(emp);
                empRepo.Save();
            }
            else
            {
                MessageBox.Show("Invalid Data");
            }
            ClearEmp();
            FillEmpBox(deptRepo.GetById(emp.DeptId??1));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var id = int.Parse(textBox4.Text);

            if (empRepo.GetById(id) != null)
            {
                empRepo.Delete(id);
                empRepo.Save();
                FillEmpBox(deptRepo.GetById(int.Parse(textBox1.Text)));
            }
            else
            {
                MessageBox.Show("Invalid Data");
            }
            ClearEmp();
        }

        private void ClearEmp()
        {
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
        }
        private void ClearDept()
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
        }
        private void FillDeptBox()
        {
            comboBox1.Items.Clear();
            foreach (var dept in deptRepo.GetAll())
            {
                comboBox1.Items.Add(dept.Id.ToString());
            }
        }
        private void FillEmpBox(Department dept)
        {
            comboBox2.Items.Clear();
            foreach (Employee emp in dept.Employees)
            {
                comboBox2.Items.Add(emp.Id.ToString());
            }
        }
    }
}
