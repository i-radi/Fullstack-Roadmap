using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalProgramming.FunctionalProgramming5_FunctionComposition_
{
    public static class FunctionComposition
    {
        public static List<double> MyData = new List<double>() { 3, 5, 7, 8 };
        public static double AddOne(double x)
        {
            return x + 1;
        }
        public static double Square(double x)
        {
            return Math.Pow(x, 2);
        }
        public static double SubtactTen(double x)
        {
            return x - 10;
        }

        #region  FirstWay
        public static void FirstWay()
        {
            MyData.Select(AddOne).Select(Square).Select(SubtactTen)
                  .ToList().ForEach((x) => Console.WriteLine(x));
        }
        #endregion  
        #region  SecondWay
        public static void SecondWay()
        {
            MyData.Select((x) => SubtactTen(Square(AddOne(x))))
                  .ToList().ForEach((x) => Console.WriteLine(x));
        }
        #endregion
        #region  ThirdWay ( Composition )
        public static Func<double, double> CompositionFunction(Func<double, double> F1, Func<double, double> F2, Func<double, double> F3)
        {
            return (x) => F3(F2(F1(x)));
        }
        static Func<double, double> MyCompodedFunction = CompositionFunction(AddOne, Square, SubtactTen);

        public static void ThirdWay()
        {
            MyData.Select(MyCompodedFunction)
                   .ToList().ForEach(x => Console.WriteLine(x));
        }
        #endregion
        #region  ForthWay ( Generic Composition )
        public static Func<T1, T3> Compose<T1, T2, T3>(this Func<T1, T2> f, Func<T2, T3> g)
        {
            return (x) => g(f(x));
        }
        public static Func<double, double> AddoneSquareSubtractTen()
        {
            Func<double, double> Q1 = AddOne;

            Func<double, double> Q2 = Square;

            Func<double, double> Q3 = SubtactTen;

            return Q1.Compose(Q2).Compose(Q3);
        }
        public static void ForthWay()
        {
            MyData.Select(AddoneSquareSubtractTen())
                .ToList().ForEach((x) => Console.WriteLine(x));
        }

        #endregion
    }
}
