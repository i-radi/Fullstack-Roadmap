using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tWelcome\n");

            Console.Write("Please Enter Number of Inputs : ");
            int count = int.Parse(Console.ReadLine());

            Console.Write("Please Enter First Input : ");
            int num = int.Parse(Console.ReadLine());
            int max = num;
            int min = num;

            for (int i = 0; i < count-1; i++)
            {
                Console.Write($"Please Enter Input {i+2} : ");
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

            Console.WriteLine("\n\tThanks ...");

            Console.ReadKey();
        }
    }
}
