using System.Text;

namespace Lab3
{
    #region Task1

    public class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public int Id { get; set; }
        public EmpPosition Position { get; set; }
        public JobType JType { get; set; }
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

    #region Task4

    sealed class Student
    {
        public string Name { get; set; }
        public List<Subject> Subjects { get; set; }

    }

    sealed class Subject
    {
        public string Name { get; set; }
        public int Grade { get; set; }
    }

    #endregion

    internal class Program
    {
        static void Main()
        {
            //Task 1
            //Employee emp = FillEmp();
            //PrintEmp(emp);

            //Task 2
            //string str = "";
            //Console.Write(" Enter String to be Reversed: ");
            //str = Console.ReadLine();
            ////str = string.Join(String.Empty,str.Reverse());
            ////Console.WriteLine($" Reversed String : {str}");
            //string temp = "";
            //for (int i = str!.Length - 1; i >= 0; i--)
            //{
            //    temp +=str[i];
            //}
            //Console.WriteLine($" Reversed String : {temp}");

            //Task 3
            //string Name = "Ibrahim";
            //string Password = "123";
            //string n, p, result;
            //Console.Write("Enter Name: ");
            //n = Console.ReadLine();
            //Console.Write("Enter Password: ");
            //p = Console.ReadLine();
            //result = Name == n && Password == p ? "Successful" : "Failed";
            //Console.WriteLine($"Login {result}");

            //Task 4
            //List<Student> students = new List<Student>
            //{
            //    new Student
            //    {
            //        Name = "Mohamed", Subjects = new List<Subject>
            //        {
            //            new Subject { Name = "Math", Grade = 10 },
            //        }
            //    },
            //    new Student
            //    {
            //        Name = "Ahmed", Subjects = new List<Subject>
            //        {
            //            new Subject { Name = "Math", Grade = 10 },
            //            new Subject { Name = "English", Grade = 9 }
            //        }
            //    },
            //    new Student
            //    {
            //        Name = "Ali", Subjects = new List<Subject>
            //        {
            //            new Subject { Name = "Math", Grade = 10 },
            //            new Subject { Name = "English", Grade = 9 },
            //            new Subject { Name = "Arabic", Grade = 8 }
            //        }
            //    },
            //    new Student
            //    {
            //        Name = "Mona", Subjects = new List<Subject>
            //        {
            //            new Subject { Name = "Math", Grade = 10 },
            //            new Subject { Name = "English", Grade = 9 },
            //            new Subject { Name = "Arabic", Grade = 8 },
            //            new Subject { Name = "French", Grade = 10 }
            //        }
            //    },

            //};

            //int sumGrades = 0;
            ////sumGrades= students.Select(x => x.Subjects)
            ////    .Select(x => x.Sum(subject => subject.Grade)).Sum();

            //foreach (var student in students)
            //{
            //    foreach (var subject in student.Subjects)
            //    {
            //        sumGrades += subject.Grade;
            //    }
            //}
            //Console.WriteLine($"The sum of grades of 4 students: {sumGrades}");
        }

        #region Task1

        public static Employee FillEmp()
        {
            Employee emp = new Employee();
            do
            {
                Console.Write("Enter Name: ");
                emp.Name = Console.ReadLine();
                Console.Write("Enter Salary: ");
                emp.Salary = double.Parse(Console.ReadLine());
                Console.Write("Enter ID: ");
                emp.Id = int.Parse(Console.ReadLine());
                Console.Write("Enter Position: ");
                emp.Position = (EmpPosition)int.Parse(Console.ReadLine());
                Console.Write("Enter Job Type: ");
                emp.JType = (JobType)int.Parse(Console.ReadLine());
            } while (emp.Name == null);

            return emp;

        }

        public static void PrintEmp(Employee emp)
        {
            Console.WriteLine($" Employee Data:\n" +
                              $"\n Name: {emp.Name}\n Salary: {emp.Salary}\n" +
                              $" Id: {emp.Id}\n Position: {emp.Position}\n " +
                              $"Job Type: {emp.JType}\n");
        }

        #endregion
    }
}