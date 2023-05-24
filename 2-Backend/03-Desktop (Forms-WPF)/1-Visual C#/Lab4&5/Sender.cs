namespace Lab5;

public delegate void ValueHandler(string msg);
public class Sender
{
    public int I;

    //The Sender class can send these 2 events
    public event ValueHandler Low;
    public event ValueHandler High;
    public void ReadData()
    {
        Console.Write("Enter Number: ");
        I = int.Parse(Console.ReadLine());
        if (I < 1)
        {
            if (Low != null)
            {
                Low("Out of Range, Number is too small");
            }
        }
        else
        {
            if (I > 100)
            {
                if (High != null)
                {
                    High("Out of Range, Number is too Large");
                }
            }
        }
    }
}