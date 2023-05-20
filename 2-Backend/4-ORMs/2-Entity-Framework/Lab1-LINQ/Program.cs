using System.Collections;

namespace Lab1_LINQ;

internal static class Program
{
    static void Main(string[] args)
    {
        var employees1 = new []
        {
            new Employee{ID = 1,Name = "Ali",Salary = 13000.00,Department = "HR",JobTitle = "Manager"},
            new Employee{ID = 2,Name = "Ahmed",Salary = 11000.00,Department = "HR",JobTitle = "Senior"},
            new Employee{ID = 3,Name = "Yasser",Salary = 12000.00,Department = "Development",JobTitle = "Manager"},
            new Employee{ID = 4,Name = "Mona",Salary = 10000.00,Department = "Development",JobTitle = "Senior"},
            new Employee{ID = 5,Name = "Mohamed",Salary = 8000.00,Department = "Development",JobTitle = "Junior"}
        };

        var employees2 = new List<Employee>
        {
            new Employee{ID = 1,Name = "Ali",Salary = 13000.00,Department = "HR",JobTitle = "Manager"},
            new Employee{ID = 2,Name = "Ahmed",Salary = 11000.00,Department = "HR",JobTitle = "Senior"},
            new Employee{ID = 3,Name = "Yasser",Salary = 12000.00,Department = "Development",JobTitle = "Manager"},
            new Employee{ID = 4,Name = "Mona",Salary = 10000.00,Department = "Development",JobTitle = "Senior"},
            new Employee{ID = 5,Name = "Mohamed",Salary = 8000.00,Department = "Development",JobTitle = "Junior"}
        };

        var employees3 = new ArrayList
        {
            new Employee{ID = 1,Name = "Ali",Salary = 13000.00,Department = "HR",JobTitle = "Manager"},
            new Employee{ID = 2,Name = "Ahmed",Salary = 11000.00,Department = "HR",JobTitle = "Senior"},
            new Employee{ID = 3,Name = "Yasser",Salary = 12000.00,Department = "Development",JobTitle = "Manager"},
            new Employee{ID = 4,Name = "Mona",Salary = 10000.00,Department = "Development",JobTitle = "Senior"},
            new Employee{ID = 5,Name = "Mohamed",Salary = 8000.00,Department = "Development",JobTitle = "Junior"}
        };


        var empsG1 = employees1.EmpByDepartment("HR");
        var empsG2 = employees1.EmpByJobTitle("Manager");

        var empsG3 = employees2.EmpByDepartment("HR");
        var empsG4 = employees2.EmpByJobTitle("Manager");

        var empsG5 = employees3.Cast<Employee>().EmpByDepartment("HR");
        var empsG6 = employees3.Cast<Employee>().EmpByJobTitle("Manager");

        foreach (var emp in empsG1)
        {
            Console.WriteLine(emp.ToString());
        }
        Console.ReadKey();

    }

    public static IEnumerable<Employee> EmpByDepartment(this IEnumerable<Employee> emps,string department)
    {
        return emps.Where(x => x.Department == department);
    }
    public static IEnumerable<Employee> EmpByJobTitle(this IEnumerable<Employee> emps, string jobTitle)
    {
        return emps.Where(x => x.JobTitle == jobTitle);
    }
}

public class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }
    public string Department { get; set; }
    public string JobTitle { get; set; }

    public override string ToString()
    {
        return $"Id: {ID}\tName: {Name}\tSalary: {Salary:C}";
    }
}
