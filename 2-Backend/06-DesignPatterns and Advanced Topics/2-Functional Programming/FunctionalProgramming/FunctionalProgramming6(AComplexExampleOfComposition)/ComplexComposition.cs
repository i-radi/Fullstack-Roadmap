using FunctionalProgramming.FunctionalProgramming6_AComplexExampleOfComposition_.Classes;
using System;
using System.Linq;
namespace FunctionalProgramming.FunctionalProgramming6_AComplexExampleOfComposition_
{
    static class ComplexComposition
    {


        #region Abstractions

        #region Last Abstraction
        public static Func<Order, double> CalcAdjustedCostofOrder(ProcessConfiguration procConfig, InvoicingPath InvoicePath, AvailabilityPath AvailabilityPath)
        {
            return (x) =>
               AdjustCost(x, InvoicePathFunc(procConfig, InvoicePath), AvailabilityPathFunc(procConfig, AvailabilityPath));
        }
        public static double AdjustCost(Order order, Func<Order, Freight> invoicePathFunc, Func<Order, ShippingDate> availabilityPathFunc)
        {

            Freight fright = invoicePathFunc(order);
            ShippingDate shippingDate = availabilityPathFunc(order);
            Console.WriteLine("\n\nDay of Shipping : " + shippingDate.Date.DayOfWeek.ToString() + "\n");

            double cost = (shippingDate.Date.DayOfWeek.ToString() == "Monday") ? fright.Cost + 1000 : fright.Cost + 500;

            //Finall Cost 
            return cost;
        }
        #endregion

        #region First Abstraction
        public static Func<Order, Freight> InvoicePathFunc(ProcessConfiguration procConfig, InvoicingPath invPath)
        {

            Func<Order, Freight> invComposition = invPath.InvoiceFunctions

                                                        .Where((x) => x.InvoiceChoose == procConfig.InvoiceChoice)
                                                        .Select((x) => x.CalcInvoice).FirstOrDefault()
                                                        .Compose(invPath.ShippingFunctions

                                                        .Where((x) => x.ShippingChoose == procConfig.ShippingChoice)
                                                        .Select((x) => x.calcShipping).FirstOrDefault())
                                                        .Compose(invPath.FrieghtFunctions

                                                        .Where((x) => x.freightChoose == procConfig.FreightChoice)
                                                        .Select((x) => x.calcFrieght).FirstOrDefault());
            return invComposition;
        }
        #endregion

        #region Second Abstraction
        public static Func<Order, ShippingDate> AvailabilityPathFunc(ProcessConfiguration procConfig, AvailabilityPath availabilityPath)
        {

            Func<Order, ShippingDate> availabilityComposition = availabilityPath.AvailabilityFunctions

                                                     .Where((x) => x.availabilityChoose == procConfig.AvailabilityChoice)
                                                     .Select((x) => x.calcAvailability).FirstOrDefault()
                                                     .Compose(availabilityPath.ShippingDateFunctions

                                                     .Where((x) => x.shippingDateChoose == procConfig.ShippingDateChoice)
                                                     .Select((x) => x.calcShippingDate).FirstOrDefault());

            return availabilityComposition;
        }
        #endregion


        #endregion

        #region Process Configration
        public static (Order order, ProcessConfiguration procConfig) setConfiguration()
        {
            ProcessConfiguration processConfig = new ProcessConfiguration();
            Order order = new Order();
            processConfig.InvoiceChoice = InvoiceChoice.Inv3;
            processConfig.ShippingChoice = ShippingChoice.Sh2;
            processConfig.FreightChoice = FreightChoice.Fr3;
            processConfig.AvailabilityChoice = AvailabilityChoice.Av2;
            processConfig.ShippingDateChoice = ShippingDateChoice.Sd2;
            order.Date = new DateTime(2021, 3, 16);
            order.Cost = 2000;
            return (order, processConfig);
        }
        #endregion

        #region Generic Extension Method ( Compose )
        public static Func<T1, T3> Compose<T1, T2, T3>(this Func<T1, T2> f, Func<T2, T3> g)
        {
            return (x) => g(f(x));
        }
        #endregion
    }
}
