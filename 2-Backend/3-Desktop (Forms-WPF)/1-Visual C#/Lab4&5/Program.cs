namespace Lab5;

public class Program
{
    public static void Main(string[] args)
    {
        #region Delegates

        //int I;
        //do
        //{
        //    Console.Write("Enter Number: ");
        //    I = int.Parse(Console.ReadLine());
        //    if (I < 5)
        //    {
        //        MyDelegate mDelegate = new MyDelegate(TestDelegate.Welcome);
        //        TestDelegate.PrintMessage(mDelegate);
        //    }
        //    else
        //    {
        //        MyDelegate mDelegate = new MyDelegate(TestDelegate.GoodBye);
        //        TestDelegate.PrintMessage(mDelegate);
        //    }
        //} while (I < 5);

        #endregion

        #region Events

        ////Listener
        //Sender s = new Sender();
        ////Hooks into events
        //s.Low += new ValueHandler(OnLow);
        //s.High += new ValueHandler(OnHigh);
        ////Call the Read Data
        //do
        //{
        //    s.ReadData();
        //} while (s.I != 0);

        #endregion

        #region Generics

        int x = 3;
        int y = 4;
        Calculate<int>.Swap(ref x, ref y);
        Console.WriteLine($"X = {x}");
        Console.WriteLine($"Y = {y}");
        Point<float> pt1 = new Point<float>(5.6f, 7.9f);
        Point<float> pt2 = new Point<float>(20.5f, 50.7f);
        Calculate<Point<float>>.Swap(ref pt1, ref pt2);
        Console.WriteLine($"PT1 = {pt1.ToString()}");
        Console.WriteLine($"PT2 = {pt2.ToString()}");

        #endregion

        #region Partial

        //var emp = new Employee();
        //emp.Print1();
        //emp.Print2();

        #endregion

        #region Indexer

        ////Object Initializer
        //IndexedNames names = new IndexedNames(7)
        //{
        //    [0] = "Ali",
        //    [1] = "Amr",
        //    [2] = "Ahmed",
        //    [3] = "Mohamed",
        //    [4] = "Tarek",
        //    [5] = "Ziad",
        //    [6] = "Waleed"
        //};
        //for (int i = 0; i < names.Size; i++)
        //    Console.WriteLine(names[i]);

        #endregion

        #region Extension Method

        //double fahrenheit = 98.7;
        //double Celsius = fahrenheit.ConvertToCelsius();
        //Console.WriteLine($"Fahrenheit: {fahrenheit}\nCelsius: {Celsius}");

        #endregion

    }

    #region Events

    public static void OnLow(string str)
    {
        Console.WriteLine(str);
    }

    public static void OnHigh(string str)
    {
        Console.WriteLine(str);

    }

    #endregion
}