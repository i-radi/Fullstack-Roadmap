using System;

namespace MagicBox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tWelcome\n");
            int n,r,c;
            do
            {
                Console.Write("Please Enter Size : ");
                n = int.Parse(Console.ReadLine());
            } while ((n % 2) == 0 );

            r = 1;
            c = (n + 1) / 2;
            Print(r,c,1);

            for (int i = 2; i <= n*n; i++)
            {
                if ((i -1)%n == 0)
                {
                    r++;
                    r = r > n ? 1 : r; 
                    Print(r,c,i);
                }
                else
                {
                    r--;
                    r = (r != 0) ? r : n ;
                    c--;
                    c = (c != 0) ? c : n;

                    Print(r,c,i);
                }
            }

            Console.WriteLine("\n\tThanks ...");

            Console.ReadKey();
        }

        static void Print(int r, int c, int num)
        {
            Console.WriteLine($" r = {r} , c = {c}  ==> {num}");
        }
    }
}
