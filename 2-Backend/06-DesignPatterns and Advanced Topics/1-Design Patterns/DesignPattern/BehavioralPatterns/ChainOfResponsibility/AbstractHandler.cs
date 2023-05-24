namespace DesignPattern.BehavioralPatterns.ChainOfResponsibility
{
    abstract class AbstractHandler : Handler
    {
        private Handler nextHandler;

        public Handler setNext(Handler handler)
        {
            this.nextHandler = handler;
            return handler;
        }
		
        public virtual object Handle(object request)
        {
            if (this.nextHandler != null)
            {
                return this.nextHandler.Handle(request);
            }
            else
            {
                return null;
            }
        }
    }
}