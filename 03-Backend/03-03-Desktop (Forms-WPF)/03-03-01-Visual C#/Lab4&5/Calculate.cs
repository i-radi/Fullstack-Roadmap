namespace Lab5;

class Calculate<T>
{
    public static void Swap(ref T a, ref T b)
    {
        (a, b) = (b, a);
    }
}