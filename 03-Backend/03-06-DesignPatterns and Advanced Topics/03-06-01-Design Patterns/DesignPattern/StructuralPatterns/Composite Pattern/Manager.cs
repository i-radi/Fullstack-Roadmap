using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPattern.StructuralPatterns.Composite_Pattern
{
    public class Manager:IEmployee
    {
        public List<IEmployee> SubOrdinates { get; set; }

        public Manager(string name ,string dept)
        {
            Name = name;
            Department = dept;
            SubOrdinates = new List<IEmployee>();
        }

        public string Name { get; set; }
        public string Department { get; set; }
        public void GetDetails(int indentation)
        {
            Console.WriteLine(string.Format($"\n{new string('-',indentation)} Name:{Name},Dept:{Department} - Manager (Composite)"));
            SubOrdinates.ForEach(x => x.GetDetails(indentation + 1));
        }
    }
}