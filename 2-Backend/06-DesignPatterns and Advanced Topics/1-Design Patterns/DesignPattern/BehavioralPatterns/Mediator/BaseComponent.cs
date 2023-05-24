namespace DesignPattern.BehavioralPatterns.Mediator
{
    class BaseComponent
    {
        protected Mediator mediator;

        public BaseComponent(Mediator mediator = null)
        {
            this.mediator = mediator;
        }

        public void setMediator(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }
}