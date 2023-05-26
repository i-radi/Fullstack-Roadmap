namespace DesignPattern.BehavioralPatterns.Observer
{
    class Client
    {
        public static void ClientCode()
        {
            var subj = new Subject();
            var o1 = new ConcreteObserverA();
            subj.attach(o1);

            var o2 = new ConcreteObserverB();
            subj.attach(o2);

            subj.someBusinessLogic();
            subj.someBusinessLogic();

            subj.detach(o2);

            subj.someBusinessLogic();
        }
    }
}