using System;
using System.Globalization;

namespace FunctionalProgramming.FunctionalProgramming3_HigherOrderFunctions_
{
    class HigherOrderFunctions
    {
        public enum ProductType
        {
            Food,
            Beverage,
            RawMaterial

        }

        public static double ClaculateDiscount(Func<int, (double x1, double x2)> ProductParamterCalc, OrderFp3 Order)
        {
            (double x1, double x2) paramters = ProductParamterCalc(Order.ProductIndex);
            return paramters.x1 * Order.Quantity + paramters.x2 * Order.UnitPrice;
        }
        public static (double x1, double x2) ProductParamtersFood(int ProductIndex)
        {
            return (x1: ProductIndex / (double)(ProductIndex + 100), x2: ProductIndex / (double)(ProductIndex + 300));

        }
        public static (double x1, double x2) ProductParamtersBeverage(int ProductIndex)
        {
            return (x1: ProductIndex / (double)(ProductIndex + 300), x2: ProductIndex / (double)(ProductIndex + 400));
        }
        public static (double x1, double x2) ProductParamtersRawMaterial(int ProductIndex)
        {
            return (x1: ProductIndex / (double)(ProductIndex + 400), x2: ProductIndex / (double)(ProductIndex + 700));
        }


        private static Func<int, (double x1, double x2)> DlgProductParamsFood = ProductParamtersFood;
        private static Func<int, (double x1, double x2)> DlgProductParamsBeverage = ProductParamtersBeverage;
        private static Func<int, (double x1, double x2)> DlgProductParamsRawMaterial = ProductParamtersRawMaterial;
        private static OrderFp3 order = new OrderFp3 { OrderId = 10, ProductIndex = 100, Quantity = 20, UnitPrice = 4 };
        public static void LecSecondExample()
        {
            Console.WriteLine("\n \nHigherOrderFunctions (Lec Second Example)");
            var product = ProductType.Food;
            Func<int, (double x1, double x2)> DlgProductParams = product switch
            {
                ProductType.Food => DlgProductParamsFood,
                ProductType.Beverage => DlgProductParamsBeverage,
                _ => DlgProductParamsRawMaterial
            };
            Console.WriteLine(ClaculateDiscount(DlgProductParams, order).ToString(CultureInfo.CurrentCulture));
            Console.ReadLine();
        }

    }
}
