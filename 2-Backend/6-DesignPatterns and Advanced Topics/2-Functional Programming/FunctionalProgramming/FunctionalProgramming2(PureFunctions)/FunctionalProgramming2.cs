using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FunctionalProgramming.FunctionalProgramming2_PureFunctions_
{
    public class FunctionalProgramming2
    {
        public static List<double> MyData = new List<double>() { 7, 4, 5, 6, 3, 8, 10 };

        #region imparative

        public static void Imperative()
        {
            Console.WriteLine("Imperative way of doing things");
            foreach (var num in MyData)
            {
                Console.WriteLine(SubtactTen(Square(AddOne(num))).ToString(CultureInfo.InvariantCulture));
            }
        }
        #endregion
        #region Declarative
        public static void Declarative()
        {
            Console.WriteLine("\n \nDeclarative , three successive calls");


            MyData.Select(AddOne).Select(Square).Select(SubtactTen).ToList()
                .ForEach((x) => Console.WriteLine(x.ToString(CultureInfo.InvariantCulture)));

            Console.WriteLine(@"\n Now look to the  magic of filtration in Declarative over Imperative
                              \n in the following example we will apply some fileteraton before
                              \n moving between the steps ");


            MyData.Select(AddOne).Select(Square).Where(x => x < 70).OrderBy(x => x).Take(2).Select(SubtactTen).ToList()
                .ForEach((x) => Console.WriteLine(x.ToString(CultureInfo.InvariantCulture)));
        }

        #endregion

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
    }
}
