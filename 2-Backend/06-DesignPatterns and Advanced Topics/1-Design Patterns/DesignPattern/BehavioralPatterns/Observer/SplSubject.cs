namespace DesignPattern.BehavioralPatterns.Observer
{
    public interface SplSubject
    {
        void attach(SplObserver observer);

        void detach(SplObserver observer);

        void notify();
    }
}