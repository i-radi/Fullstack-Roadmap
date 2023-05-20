using System;
using System.Collections.Generic;
using System.Globalization;


namespace FunctionalProgramming.FunctionalProgramming3_HigherOrderFunctions_
{
    class IntroToHigherOrderFunctions
    {

        public static void LecFirstExample()
        {
            Func<double, double> DlgtTest1 = Test1;
            Func<double, double> DlgtTest2 = Test2;
            List<Func<Double, Double>> z = new List<Func<Double, Double>>
            {
                DlgtTest1,
                DlgtTest2
            };

            Console.WriteLine("\n \nHigherOrderFunctions(Lec First Example)");
            //Console.WriteLine(Test1(5).ToString());
            //Console.WriteLine(Test2(5).ToString());

            Console.WriteLine(z[0](5).ToString(CultureInfo.CurrentCulture));
            Console.WriteLine(z[1](5).ToString(CultureInfo.CurrentCulture));

            Console.WriteLine(Test3(Test1, 5).ToString(CultureInfo.CurrentCulture));// = Console.WriteLine(Test3(z[0], 5).ToString());
            Console.WriteLine(Test3(Test2, 5).ToString(CultureInfo.CurrentCulture));// = Console.WriteLine(Test3(z[1], 5).ToString());




        }
        public static double Test1(double x)
        {
            return x / 2;
        }
        public static double Test2(double x)
        {
            return x / 4 + 1;
        }
        public static double Test3(Func<double, double> F, Double Value)
        {
            return F(Value) + Value;
        }
    }


}
