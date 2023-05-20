namespace DesignPattern.StructuralPatterns.Bridge
{
    public class CardPaymentTool:PaymentTool
    {
        public override void MakePayment()
        {
            _PaymentSystem.ProcessPayment("Card Payment");
        }
    }
}