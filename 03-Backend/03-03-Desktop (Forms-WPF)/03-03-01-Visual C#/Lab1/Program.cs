using System;

namespace Lab1_EnumColor
{
    public static class Program
    {
        private static void Main()
        {
            int value;
            string colorName;
            do
            {
                Console.Write("Choose Number of Color: ");
                value = int.Parse(Console.ReadLine() ?? string.Empty);
            } while (value < 0 || value > 4);
            
            switch (value)
            {
                case 1: 
                    Console.WriteLine($"Color name : {Color.Red}");
                    break;
                case 2:
                    Console.WriteLine($"Color name : {Color.Green}");
                    break;
                case 3:
                    Console.WriteLine($"Color name : {Color.Blue}");
                    break;
            }

            do
            {
                Console.Write("Choose Color: ");
                colorName = Console.ReadLine();
            } while (colorName!="red" && colorName!="green"&& colorName!="blue");
            
            switch (colorName)
            {
                case "red":
                    Console.WriteLine($"Color value : {(int)Color.Red}");
                    break;
                case "green":
                    Console.WriteLine($"Color value : {(int)Color.Green}");
                    break;
                case "blue":
                    Console.WriteLine($"Color value : {(int)Color.Blue}");
                    break;
            }

            Console.Write("\n\tThanks");
            Console.ReadKey();
        }
    }
    enum Color //1,2,3
    {
        Red = 1,
        Green,
        Blue
    }
    //enum Color { Red = 10, Green = 20, Blue = 30 } //10,20,30
    //enum Color { Red, Green, Blue } //0,1,2
}
