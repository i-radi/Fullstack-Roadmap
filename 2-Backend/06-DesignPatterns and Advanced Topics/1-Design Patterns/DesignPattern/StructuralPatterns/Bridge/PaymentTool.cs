namespace DesignPattern.StructuralPatterns.Bridge
{
    public abstract class PaymentTool
    {
        public IpaymentSystem _PaymentSystem;
        public abstract void MakePayment();
    }
}