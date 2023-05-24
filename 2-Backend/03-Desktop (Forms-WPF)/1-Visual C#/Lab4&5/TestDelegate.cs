namespace Lab5;

public delegate void MyDelegate();
public class TestDelegate
{
    static int I;

    public static void Welcome()
    {
        Console.WriteLine("Welcome to Our Test Class");
    }

    public static void GoodBye()
    {
        Console.WriteLine("This is the end of our Class");
    }

    public static void PrintMessage(MyDelegate m)
    {
        Console.WriteLine("This Message from Test Class");
        m();
    }
}