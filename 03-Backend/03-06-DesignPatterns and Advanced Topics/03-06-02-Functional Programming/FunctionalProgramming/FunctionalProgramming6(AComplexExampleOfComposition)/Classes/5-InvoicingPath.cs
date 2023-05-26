using System;
using System.Collections.Generic;

namespace FunctionalProgramming.FunctionalProgramming6_AComplexExampleOfComposition_.Classes
{
    public class InvoicingPath
    {
        public List<(InvoiceChoice InvoiceChoose, Func<Order, Invoice> CalcInvoice)> InvoiceFunctions;
        public List<(ShippingChoice ShippingChoose, Func<Invoice, Shipping> calcShipping)> ShippingFunctions;
        public List<(FreightChoice freightChoose, Func<Shipping, Freight> calcFrieght)> FrieghtFunctions;

        public InvoicingPath()
        {
            InvoiceFunctions = new List<(InvoiceChoice InvoiceChoose, Func<Order, Invoice> CalcInvoice)>()
                    {
                         (InvoiceChoice.Inv1,calcInvoice1),
                         (InvoiceChoice.Inv2,calcInvoice2),
                         (InvoiceChoice.Inv3,calcInvoice3),
                         (InvoiceChoice.Inv4,calcInvoice4),
                         (InvoiceChoice.Inv5,calcInvoice5)
                    };
            ShippingFunctions = new List<(ShippingChoice ShippingChoose, Func<Invoice, Shipping> calcShipping)>()
                    {
                         (ShippingChoice.Sh1,calcShipping1),
                         (ShippingChoice.Sh2,calcShipping2),
                         (ShippingChoice.Sh3,calcShipping3)
                    };
            FrieghtFunctions = new List<(FreightChoice freightChoose, Func<Shipping, Freight> calcFrieght)>()
                        {
                             (FreightChoice.Fr1,calcFreightCost1),
                             (FreightChoice.Fr2,calcFreightCost2),
                             (FreightChoice.Fr3,calcFreightCost3),
                             (FreightChoice.Fr4,calcFreightCost4),
                             (FreightChoice.Fr5,calcFreightCost5),
                             (FreightChoice.Fr6,calcFreightCost6)
                        };
        }

        #region Pure Functions
        public static Invoice calcInvoice1(Order o)
        {
            Console.WriteLine("Invoice 1");
            Invoice invoice = new Invoice();
            invoice.Cost = o.Cost * 1.1;
            return invoice;
        }
        public static Invoice calcInvoice2(Order o)
        {
            Console.WriteLine("Invoice 2");
            Invoice invoice = new Invoice();
            invoice.Cost = o.Cost * 1.2;
            return invoice;
        }
        public static Invoice calcInvoice3(Order o)
        {
            Console.WriteLine("Invoice 3");
            Invoice invoice = new Invoice();
            invoice.Cost = o.Cost * 1.3;
            return invoice;
        }
        public static Invoice calcInvoice4(Order o)
        {
            Console.WriteLine("Invoice 4");
            Invoice invoice = new Invoice();
            invoice.Cost = o.Cost * 1.4;
            return invoice;

        }
        public static Invoice calcInvoice5(Order o)
        {
            Console.WriteLine("Invoice 5");
            Invoice invoice = new Invoice();
            invoice.Cost = o.Cost * 1.5;
            return invoice;
        }

        public static Shipping calcShipping1(Invoice o)
        {
            Console.WriteLine("Shipping 1");
            Shipping s = new Shipping();
            s.ShipperId = (o.Cost > 1000) ? 1 : 2;
            s.Cost = o.Cost;

            return s;
        }
        public static Shipping calcShipping2(Invoice i)
        {
            Console.WriteLine("Shipping 2");
            Shipping s = new Shipping();

            s.ShipperId = (i.Cost > 1100) ? 1 : 2;
            s.Cost = i.Cost;

            return s;
        }
        public static Shipping calcShipping3(Invoice i)
        {
            Console.WriteLine("Shipping 3");
            Shipping s = new Shipping();
            s.ShipperId = (i.Cost > 1200) ? 1 : 2;
            s.Cost = i.Cost;

            return s;
        }

        public static Freight calcFreightCost1(Shipping s)
        {
            Console.WriteLine("Freight 1");
            Freight f = new Freight();
            f.Cost = (s.ShipperId == 1) ? s.Cost * 0.25 : s.Cost * 0.5;
            return f;
        }
        public static Freight calcFreightCost2(Shipping s)
        {
            Console.WriteLine("Freight 2");
            Freight f = new Freight();
            f.Cost = (s.ShipperId == 1) ? s.Cost * 0.28 : s.Cost * 0.52;
            return f;
        }
        public static Freight calcFreightCost3(Shipping s)
        {
            Console.WriteLine("Freight 3");
            Freight f = new Freight();
            f.Cost = (s.ShipperId == 1) ? s.Cost * 0.3 : s.Cost * 0.6;
            return f;
        }
        public static Freight calcFreightCost4(Shipping s)
        {
            Console.WriteLine("Freight 4");
            Freight f = new Freight();
            f.Cost = (s.ShipperId == 1) ? s.Cost * 0.35 : s.Cost * 0.65;
            return f;
        }
        public static Freight calcFreightCost5(Shipping s)
        {
            Console.WriteLine("Freight 5");
            Freight f = new Freight();
            f.Cost = (s.ShipperId == 1) ? s.Cost * 0.15 : s.Cost * 0.2;
            return f;
        }
        public static Freight calcFreightCost6(Shipping s)
        {
            Console.WriteLine("Freight 6");
            Freight f = new Freight();
            f.Cost = (s.ShipperId == 1) ? s.Cost * 0.1 : s.Cost * 0.15;
            return f;
        }
        #endregion

    }
}
