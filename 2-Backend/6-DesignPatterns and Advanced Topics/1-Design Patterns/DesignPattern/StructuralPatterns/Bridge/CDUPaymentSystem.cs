using System;

namespace DesignPattern.StructuralPatterns.Bridge
{
    public class CDUPaymentSystem:IpaymentSystem
    {
        public void ProcessPayment(string paymentSystem)
        {
            Console.WriteLine($"Using CDU Bank Gateway for {paymentSystem} ");
        }
    }
}