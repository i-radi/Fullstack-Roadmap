using System;

namespace Lab6
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Employee employee;
            employee = FillEmployee();
            PrintEmployee(employee);
            Console.ReadLine();

            Employee employee2 = new Employee(300, "Ahmed", 10040.50f);
            Customer costumer = new Customer(10, "Mohamed", 2);
            
            employee2.PrintData();
            costumer.PrintData();
            Console.ReadLine();


        }
        public static Employee FillEmployee()
        {
            Console.WriteLine("\tEnter Data Employee");
            Employee employee = new Employee();
            Console.Write("Enter Id : ");
            employee.SetId(int.Parse(Console.ReadLine()));
            Console.Write("Enter Name : ");
            employee.SetName(Console.ReadLine());
            Console.Write("Enter Salary : ");
            employee.SetSalary(float.Parse(Console.ReadLine()));
            return employee;
        }
        public static void PrintEmployee(Employee e)
        {
            Console.WriteLine("\t Data Employee");
            Console.WriteLine($" Id : {e.GetId()} , Name : {e.GetName()} , Salary : {e.GetSalary()}");

        }

    }
}
