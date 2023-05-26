using FunctionalProgramming.FunctionalProgramming2_PureFunctions_;
using FunctionalProgramming.FunctionalProgramming3_HigherOrderFunctions_;
using FunctionalProgramming.FunctionalProgramming4_RealExample_;
using FunctionalProgramming.FunctionalProgramming5_FunctionComposition_;
using FunctionalProgramming.FunctionalProgramming6_AComplexExampleOfComposition_;
using FunctionalProgramming.FunctionalProgramming6_AComplexExampleOfComposition_.Classes;
using FunctionalProgramming.FunctionalProgramming7_Closures_;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalProgramming;

static class Program
{
    static void Main()
    {
        #region Functional Programming 2
        FunctionalProgramming2.Imperative();
        FunctionalProgramming2.Declarative();
        #endregion

        #region  FunctionalProgramming 3 (HigherOrderFunctions)
        IntroToHigherOrderFunctions.LecFirstExample();
        HigherOrderFunctions.LecSecondExample();
        #endregion

        #region Functional Programming 4, An Example
        ExampleDeclarative exampleDeclarative = new ExampleDeclarative();
        exampleDeclarative.TryExample();

        ExampleImperativeMyAttempt exampleImperative = new ExampleImperativeMyAttempt();
        exampleImperative.TryExample();
        #endregion

        #region Functional Programming 5 (Function Composition)
        FunctionComposition.FirstWay();
        FunctionComposition.SecondWay();
        FunctionComposition.ThirdWay();
        FunctionComposition.ForthWay();
        #endregion

        #region Functional Programming 6 (A Complex Example Of Composition)
        InvoicingPath InvoicePath = new InvoicingPath();
        AvailabilityPath AvailabilityPath = new AvailabilityPath();
        (Order order, ProcessConfiguration procConfig) = ComplexComposition.setConfiguration();

        Func<Order, Double> CostOfOrder = ComplexComposition.CalcAdjustedCostofOrder(procConfig, InvoicePath, AvailabilityPath);

        Console.WriteLine(CostOfOrder(order));
        Console.ReadLine();
        #endregion

        #region Functional Programming 7 (Closures)
        var Q10 = Closures.Test(10);
        Console.WriteLine(Q10(4));
        Console.ReadLine();

        var Q20 = Closures.Test(20);
        Console.WriteLine(Q20(4));
        Console.ReadLine();


        var f5 = Closures.GrossSalaryCalculator(200);
        Console.WriteLine(f5(40));

        var f6 = Closures.GrossSalaryCalculator(300);
        Console.WriteLine(f6(40));

        List<(string Segment, double BasicSalary)> z = new List<(string EmployyID, double BasicSalary)>
        {
            ("a", 1000),
            ("b", 2000),
            ("c", 3000)
        };

        var GrossSalaryCalculators = z
            .Select((a)
                => (ID: a.Segment, MyGrossSalaryCalculator: Closures.GrossSalaryCalculator(a.BasicSalary)))
            .ToList();

        Console.WriteLine(GrossSalaryCalculators[0].MyGrossSalaryCalculator(80));
        Console.WriteLine(GrossSalaryCalculators[1].MyGrossSalaryCalculator(90));
        Console.WriteLine(GrossSalaryCalculators.FirstOrDefault((m) => m.ID == "c").MyGrossSalaryCalculator(100));

        Console.ReadLine();
        #endregion
    }
}