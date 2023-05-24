using System;
using System.Collections.Generic;

namespace FunctionalProgramming.FunctionalProgramming6_AComplexExampleOfComposition_.Classes
{
    public class AvailabilityPath
    {

        public List<(AvailabilityChoice availabilityChoose, Func<Order, Availability> calcAvailability)> AvailabilityFunctions;

        public List<(ShippingDateChoice shippingDateChoose, Func<Availability, ShippingDate> calcShippingDate)> ShippingDateFunctions;

        public AvailabilityPath()
        {
            AvailabilityFunctions = new List<(AvailabilityChoice availabilityChoose, Func<Order, Availability> calcAvailability)>()
                        {
                                 (AvailabilityChoice.Av1,calcAvailability1),
                                 (AvailabilityChoice.Av2,calcAvailability2),
                                 (AvailabilityChoice.Av3,calcAvailability3),
                                 (AvailabilityChoice.Av4,calcAvailability4)
                        };
            ShippingDateFunctions = new List<(ShippingDateChoice shippingDateChoose, Func<Availability, ShippingDate> calcShippingDate)>()
                        {
                                 (ShippingDateChoice.Sd1,calcShippingDate1),
                                 (ShippingDateChoice.Sd2,calcShippingDate2),
                                 (ShippingDateChoice.Sd3,calcShippingDate3),
                                 (ShippingDateChoice.Sd4,calcShippingDate4),
                                 (ShippingDateChoice.Sd5,calcShippingDate5),
                        };
        }

        #region Pure Functions
        public static Availability calcAvailability1(Order o)
        {
            Console.WriteLine("Availability 1");
            Availability a = new Availability();
            a.Date = o.Date.AddDays(3);
            return a;
        }
        public static Availability calcAvailability2(Order o)
        {
            Console.WriteLine("Availability 2");
            Availability a = new Availability();
            a.Date = o.Date.AddDays(2);
            return a;
        }
        public static Availability calcAvailability3(Order o)
        {
            Console.WriteLine("Availability 3");
            Availability a = new Availability();
            a.Date = o.Date.AddDays(1);
            return a;
        }
        public static Availability calcAvailability4(Order o)
        {
            Console.WriteLine("Availability 4");
            Availability a = new Availability();
            a.Date = o.Date.AddDays(4);
            return a;
        }

        public static ShippingDate calcShippingDate1(Availability o)
        {
            Console.WriteLine("ShippingDate 1");
            ShippingDate a = new ShippingDate();
            a.Date = o.Date.AddDays(1);
            return a;
        }
        public static ShippingDate calcShippingDate2(Availability o)
        {
            Console.WriteLine("ShippingDate 2");
            ShippingDate a = new ShippingDate();
            a.Date = o.Date.AddDays(2);
            return a;
        }
        public static ShippingDate calcShippingDate3(Availability o)
        {
            Console.WriteLine("ShippingDate 3");
            ShippingDate a = new ShippingDate();
            a.Date = o.Date.AddHours(14);
            return a;
        }
        public static ShippingDate calcShippingDate4(Availability o)
        {
            Console.WriteLine("ShippingDate 4");
            ShippingDate a = new ShippingDate();
            a.Date = o.Date.AddHours(20);
            return a;
        }
        public static ShippingDate calcShippingDate5(Availability o)
        {
            Console.WriteLine("ShippingDate 5");
            ShippingDate a = new ShippingDate();
            a.Date = o.Date.AddHours(10);
            return a;
        }
        #endregion

    }
}
