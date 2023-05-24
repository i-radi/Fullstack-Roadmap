namespace Lab1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const float num1 = 9_999_999.99f;
            const double num2 = 99.99;
            const long num3 = 1_000_000_000;
            Console.Write("\tProgram to add two numbers" +
                          "\nEnter Number one : ");
            var x = int.Parse(Console.ReadLine()!);
            Console.Write("Enter Number Two : ");
            var y = int.Parse(Console.ReadLine()!);
            Console.WriteLine($"The Result of {x} + {y} = {x + y}\n\n");
            Console.WriteLine($"Printing Data Types");
            Console.WriteLine($"Float Point Type : {num1:f}");
            Console.WriteLine($"Double Type : {num2:n}");
            Console.WriteLine($"Long Type : {num3:e}");
            Console.ReadKey();
        }
    }
}