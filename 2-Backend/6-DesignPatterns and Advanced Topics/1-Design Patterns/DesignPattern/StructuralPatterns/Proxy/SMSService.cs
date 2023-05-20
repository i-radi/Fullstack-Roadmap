namespace DesignPattern.StructuralPatterns.Proxy
{
    public abstract class SMSService
    {
        public abstract string SendSMS(string custId,string mobile, string sms);
        
    }
}