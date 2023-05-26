using System;

namespace Lab6
{
    class Employee : Person
    {
        private float Salary;
        public Employee()
        {
        }

        public Employee(int id, string name) : base(id, name)
        {
        }

        public Employee(int id, string name, float salary) : base(id, name)
        {
            Salary = salary;
        }


        public void SetId(int id)
        {
            Id = id;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetSalary(float salary)
        {
            Salary = salary;
        }

        public int GetId()
        {
            return Id;
        }

        public string GetName()
        {
            return Name;
        }

        public float GetSalary()
        {
            return Salary;
        }

        public override void PrintData()
        {
            Console.WriteLine($"\tEmployee Data\n" +
                              $"Id : {Id} , Name : {Name} , Salary : {Salary}");
        }

        ~Employee()
        {
            Console.WriteLine("\n\tBay Bay");
        }

    }
}