using System;

namespace Lab5
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\tWelcome\n");

            #region MaxMin

            int[] num = new int[5];
            int max = Int32.MinValue;
            int min = Int32.MaxValue;
            int indexmax = 0;
            int indexmin = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Please Enter Input {i + 1} : ");
                num[i] = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                if (num[i] > max)
                {
                    max = num[i];
                    indexmax = i;
                }

                if (num[i] < min)
                {
                    min = num[i];
                    indexmin = i;
                }

            }

            Console.WriteLine($" The Maximum Number is : {max} , Index : {indexmax}");

            Console.WriteLine($" The Minimum Number is : {min} , Index : {indexmin}");

            #endregion true

            #region 3Students

            int[,] studentsSubjects= new int[3, 4];

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"\tStudent {i + 1} : ");
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"Enter Subject {j + 1} : ");
                    studentsSubjects[i, j] = Int32.Parse(Console.ReadLine() ?? string.Empty);
                }
            }

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"\tStudent {i + 1} : ");
                int sum = 0;
                for (int j = 0; j < 4; j++)
                {
                    sum += studentsSubjects[i, j];
                }
                Console.WriteLine($"The Sum Subjects for Student {i + 1} : {sum}");
            }
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                int sum = 0;
                for (int j = 0; j < 3; j++)
                {
                    sum += studentsSubjects[j, i];
                }

                Console.WriteLine($"The Average Subject {i + 1} : {sum / 3}");
            }

            #endregion

            #region JaggedStudents

            int[][] studentsSubjectd = new int[3][];

            for (int i = 0; i < 3; i++)
            {
                int no;
                Console.WriteLine($"\tStudent {i + 1} : ");
                Console.Write($"Enter Number of Subjects : ");
                no = Int32.Parse(Console.ReadLine() ?? string.Empty);
                studentsSubjectd[i] = new int[no];
                for (int j = 0; j < no; j++)
                {
                    Console.Write($"Enter Subject {j + 1} : ");
                    studentsSubjectd[i][j] = Int32.Parse(Console.ReadLine() ?? string.Empty);
                }
            }

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"\tStudent {i + 1} : ");
                int sum = 0;
                for (int j = 0; j < studentsSubjectd[i].Length; j++)
                {
                    sum += studentsSubjectd[i][j];
                }
                Console.WriteLine($"The Sum Subjects for Student {i + 1} : {sum}");
            }

            #endregion

            Console.ReadLine();

        }
    }
}
