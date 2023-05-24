using System;

namespace FunctionalProgramming.FunctionalProgramming6_AComplexExampleOfComposition_.Classes
{

    public class Order
    {
        public DateTime Date { get; set; }
        public double Cost { get; set; }

    }
    public class Invoice
    {

        public double Cost { get; set; }
        public Invoice()
        {
            Cost = 0;
        }
    }
    public class Shipping
    {

        public double Cost { get; set; }
        public int ShipperId { get; set; }
        public Shipping()
        {
            Cost = 0;
        }
    }
    public class Freight
    {
        public double Cost { get; set; }

        public Freight()
        {
            Cost = 0;
        }
    }
    public class Availability
    {
        public DateTime Date { get; set; }
    }
    public class ShippingDate
    {
        public DateTime Date { get; set; }
    }
}
