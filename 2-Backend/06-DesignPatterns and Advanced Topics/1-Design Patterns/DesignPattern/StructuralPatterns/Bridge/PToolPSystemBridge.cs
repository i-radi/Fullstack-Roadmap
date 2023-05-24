namespace DesignPattern.StructuralPatterns.Bridge
{
    public class PToolPSystemBridge
    {
        private PaymentTool _order;
        public PToolPSystemBridge(PaymentTool order)
        {
            _order = order;
        }

        public void Pay(IpaymentSystem Bank)
        {
            _order._PaymentSystem = Bank;
            _order.MakePayment();
        }
    }
}