using System;

namespace ConsoleApplication
{
    static class Program
    {
        static void Main()
        {
            Console.Write("Enter Key    : ");
            var key = Console.ReadLine();
            Console.Write("Enter Message: ");
            var message = Console.ReadLine();

            try
            {
                var obj = new Encryption(key);
                Console.WriteLine(obj.GetCipher(message));
            }
            catch
            {
                Console.WriteLine("Error etl3 mn hna");
            }

            Console.ReadKey();
        }
    }
}
