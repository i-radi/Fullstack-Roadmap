namespace DesignPattern.BehavioralPatterns.ChainOfResponsibility
{
    public interface Handler
    {
        Handler setNext(Handler handler);
		
        object Handle(object request);
    }
}