using System;

namespace FunctionalProgramming.FunctionalProgramming7_Closures_
{
    static class Closures
    {

        public static Func<double, double> Test(double x)
        {
            Console.WriteLine("I am Here " + x);
            var x1 = x + 10;

            return a => a + x1;
        }

        public static Func<double, double> GrossSalaryCalculator(double BasicSalary)
        {

            var Tax = 0.2 * BasicSalary;

            return Bonus =>
            Bonus + Tax + BasicSalary;

        }
    }

}