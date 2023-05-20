using System;

namespace DesignPattern.StructuralPatterns.Bridge
{
    public class MCAPaymentSystem:IpaymentSystem
    {
        public void ProcessPayment(string paymentSystem)
        {
            Console.WriteLine($"Using MCA Bank Gateway for {paymentSystem} ");
        }
    }
}