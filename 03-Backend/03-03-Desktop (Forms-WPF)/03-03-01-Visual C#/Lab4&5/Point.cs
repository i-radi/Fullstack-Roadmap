namespace Lab5;

class Point<M>
{
    M x; 
    M y;

    public Point(M a, M b)
    {
        x = a;
        y = b;
    }
    public override string ToString()
    {
        return ("X = " + x.ToString() + " , Y = " + y.ToString());
    }
}