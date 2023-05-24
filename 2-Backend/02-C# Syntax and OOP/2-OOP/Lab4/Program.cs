using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Swap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t Swapping");
            Console.Write("Enter Number 1 :");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Enter Number 2 :");
            int y = int.Parse(Console.ReadLine());
            Swap(ref x,ref y);
            Console.WriteLine("After Swapping");

            Console.WriteLine($"Number 1 : {x}");
            Console.WriteLine($"Number 2 : {y}");
            //////////////////
            Console.WriteLine("\n\t Power Program ");
            Console.Write("Enter Number :");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter Power :");
            int b = int.Parse(Console.ReadLine());
            float pres = Power(a, b);
            Console.WriteLine($" The Result : {pres}");
            //////////////////
            Console.WriteLine("\n\t Factorial Program ");
            Console.Write("Enter Number :");
            int Num = int.Parse(Console.ReadLine());
            long fres = Factorial(Num);
            Console.WriteLine($" The Result : {fres}");
            Console.ReadLine();
        }

        public static void Swap(ref int a, ref int b)
        {
            int temp;

            temp = a;   
            a = b;
            b = temp;
        }

        public static float Power(int num, int power)
        {
            if (power > 0)
            {
                return  num *Power(num,power-1);
            }
            else if (power < 0)
            {
                return 1/(num * Power(num, -power - 1));
            }
            else
            {
                return 1;
            }

        }
        public static long Factorial(int num)
        {
            if (num < 0 )
            {
                return -1;
            }
            long res = 1;
            if (num > 1)
            {
                res = num * Factorial(num - 1);
            }
            return res;
        }

    }
}
