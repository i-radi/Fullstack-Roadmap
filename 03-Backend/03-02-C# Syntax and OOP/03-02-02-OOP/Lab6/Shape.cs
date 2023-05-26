using System;

namespace Lab6
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Circle c = new Circle(7);
            Rectangle r = new Rectangle(20, 5);
            Triangle t = new Triangle(20, 10);
            Square s = new Square(6);
            GeoShape g = new GeoShape(c, r, t, s);
            Console.WriteLine(g.TotalArea());
        }
    }

    #region Shape


    abstract class Shape
    {
        protected int dim1, dim2;

        public Shape()
        {
            dim1 = dim2 = 0;
        }

        public Shape(int m)
        {
            dim1 = dim2 = m;
        }

        public Shape(int m, int n)
        {
            dim1 = m;
            dim2 = n;
        }

        public void SetD1(int m)
        {
            dim1 = m;
        }

        public void SetD2(int n)
        {
            dim2 = n;
        }

        public int GetD1()
        {
            return dim1;
        }

        public int GetD2()
        {
            return dim2;
        }

        public abstract double Area();
    }

    class Circle : Shape
    {
        public Circle()
        {
        }

        public Circle(int r) : base(r)
        {
        }

        public override double Area()
        {
            return (3.14 * dim1 * dim2);
        }
    }

    class Rectangle : Shape
    {
        public Rectangle()
        {
        }

        public Rectangle(int l, int w) : base(l, w)
        {
        }

        public override double Area()
        {
            return (1.0 * dim1 * dim2);
        }
    }

    class Triangle : Shape
    {
        public Triangle()
        {
        }

        public Triangle(int w, int h) : base(w, h)
        {
        }

        public override double Area()
        {
            return (0.5 * dim1 * dim2);
        }
    }

    class Square : Rectangle
    {
        public Square()
        {
        }

        public Square(int s) : base(s, s)
        {
        }
    }

    class GeoShape
    {
        Shape C;
        Shape R;
        Shape T;
        Shape S;

        public GeoShape(Shape c1, Shape r1,
            Shape t1, Shape s1)
        {
            C = c1;
            R = r1;
            T = t1;
            S = s1;
        }

        public double TotalArea()
        {
            double total;
            total = C.Area() + R.Area() +
                    T.Area() + S.Area();
            return total;
        }
    }

    #endregion

    #region Person

    class Person
    {
        protected int Id;
        protected string Name;

        

    }

    class Employee : Person
    {
        private float salary;
    }

    class Customer : Person
    {
        private float salary;
    }

    #endregion

}
