using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal static partial class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                //Task1.MaxMin();

                Console.WriteLine("\n\n");

                Task2.Quadratic();

                Console.ReadLine();
                Console.Clear();
            }

        }

        static class Task1
        {
            public static void MaxMin()
            {
                Console.WriteLine("\tWelcome");
                Console.Write("Please Enter First Number : ");
                int num = int.Parse(Console.ReadLine());
                int max = num;
                int min = num;

                for (int i = 0; i < 4; i++)
                {
                    Console.Write("Please Enter Number : ");
                    int input = int.Parse(Console.ReadLine());
                    if (input > max)
                    {
                        max = input;
                    }

                    if (input < min)
                    {
                        min = input;
                    }

                }

                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.WriteLine($" The Maximum Number is : {max}");

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($" The Minimum Number is : {min}");

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\tThanks ...");
            }
        }

        static class Task2
        {
            public static void Quadratic()
            {
                /*
                 * test cases
                 * 1. a = 1, b = 1, c = 1
                 * 1. a = 1, b = -4, c = 4
                 * 1. a = 1, b = -5, c = 6
                 */
                double real1;
                double real2;

                Console.WriteLine("\tWelcome");
                Console.WriteLine("     Quadratic Equation Calculator ");
                Console.Write("Please Enter First Coefficient  A : ");
                double A = int.Parse(Console.ReadLine());
                Console.Write("Please Enter Second Coefficient B : ");
                double B = int.Parse(Console.ReadLine());
                Console.Write("Please Enter Third Coefficient  C : ");
                double C = int.Parse(Console.ReadLine());


                double b4ac = (B * B) - (4 * A * C);

                if (b4ac > 0)
                {
                    real1 = ((-1 * B) + Math.Sqrt(b4ac) )/(2 *A) ;
                    real2 = ((-1 * B) - Math.Sqrt(b4ac) )/ (2 * A);
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine($"The First Real Result X1 : {real1}");
                    Console.WriteLine($"The First Real Result X2 : {real2}");
                }
                else
                {
                    real1 = (-1 * B) / (2 * A);
                    if (b4ac == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine($"The First Real Result X1 : {real1}");
                        Console.WriteLine($"The First Real Result X2 : {real1}");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(" The Result Contain Imaginary Number");
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine($"The First Real Result X1 : {real1}  + Imaginary Number");
                        Console.WriteLine($"The First Real Result X2 : {real1}  - Imaginary Number");

                    }
                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("\tThanks ...");
            }
        }
    }
}

