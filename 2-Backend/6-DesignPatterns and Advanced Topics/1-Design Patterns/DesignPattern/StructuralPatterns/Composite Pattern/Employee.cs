using System;

namespace DesignPattern.StructuralPatterns.Composite_Pattern
{
    public class Employee : IEmployee
    {
        public Employee( string name ,string dept)
        {
            Name = name;
            Department = dept;
        }

        public string Name { get; set; }
        public string Department { get; set; }
        public void GetDetails(int indentation)
        {
            Console.WriteLine(string.Format($"{new string('-',indentation)} Name:{Name}, Dept:{Department} (Leaf)"));
        }
    }
}