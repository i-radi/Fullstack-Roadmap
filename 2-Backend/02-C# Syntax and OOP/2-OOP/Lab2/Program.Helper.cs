using System;

namespace Lab2
{
    internal static partial class Program
    {
        private static class Helper
        {
            public static void ResetColor()
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Title = $"{typeof(Program).Assembly.GetName().Name}";
                Console.Clear();
            }

            public static string Spaces(int num) => new string(' ', num);
        }
    }
}