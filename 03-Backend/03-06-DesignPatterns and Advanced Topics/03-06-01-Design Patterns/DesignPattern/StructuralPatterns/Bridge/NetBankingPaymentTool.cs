namespace DesignPattern.StructuralPatterns.Bridge
{
    public class NetBankingPaymentTool:PaymentTool
    {
        public override void MakePayment()
        {
            _PaymentSystem.ProcessPayment("NetBanking Payment");
        }
    }
}
