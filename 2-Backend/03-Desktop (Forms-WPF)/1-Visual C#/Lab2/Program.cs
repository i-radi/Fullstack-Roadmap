using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab2
{
    #region Task1

    public struct Employee
    {
        public string _name;
        public double _salary;
        public int _id;
        public EmpPosition _position;
        public JobType _jType;
    }

    public enum EmpPosition
    {
        Manager,
        Leader,
        Senior,
        Junior
    };

    public enum JobType
    {
        FullTime,
        PartTime
    }

    #endregion

    #region Task3

    class C1
    {
        public int a;
    }
    class C2
    {
        public void MyFunction(C1 x)
        {
            x.a = 20;
        }
    }

#endregion

public static class Program
    {
        private static void Main()
        {
            //Employee emp = FillEmp();
            //PrintEmp(emp);
            
            //---------------------

            //Console.Write("Enter Number of Names: ");
            //int num = int.Parse(Console.ReadLine());
            //var names = new string[num];
            //for (var i = 0; i < num; i++)
            //{
            //    Console.Write($"Enter Name {i + 1}: ");
            //    names[i] = Console.ReadLine();
            //}
            //PrintNames(names);

            //---------------------

            //C1 l = new C1();
            //l.a = 5;
            //C2 m = new C2();
            //m.MyFunction(l);
            //Console.WriteLine(l.a);
        }

        #region Task2

        public static void PrintNames(params string[] names) 
            => Console.WriteLine("Welcome "+ string.Join(", ", names));

        //=> Console.WriteLine(names.Aggregate("Welcome: ",(a,b) => $"{a}{b}, "));

        #endregion

        #region Task1

        public static Employee FillEmp()
        {
            Employee emp;
            do
            {
                Console.Write("Enter Name: ");
                emp._name = Console.ReadLine();
                Console.Write("Enter Salary: ");
                emp._salary = double.Parse(Console.ReadLine());
                Console.Write("Enter ID: ");
                emp._id = int.Parse(Console.ReadLine());
                Console.Write("Enter Position: ");
                emp._position = (EmpPosition)int.Parse(Console.ReadLine());
                Console.Write("Enter Job Type: ");
                emp._jType = (JobType)int.Parse(Console.ReadLine());
            } while (emp._name == null);

            return emp;

        }

        public static void PrintEmp(Employee emp)
        {
            Console.WriteLine($" Employee Data:\n" +
                              $"\n Name: {emp._name}\n Salary: {emp._salary}\n" +
                              $" Id: {emp._id}\n Position: {emp._position}\n " +
                              $"Job Type: {emp._jType}\n");
        }

        #endregion

    }
}
