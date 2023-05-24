using System;

namespace DesignPattern.BehavioralPatterns.Memento
{
    class Client
    {
        public static void ClientCode()
        {
            Originator originator = new Originator("Super-duper-super-puper-super.");
            Caretaker caretaker = new Caretaker(originator);

            caretaker.backup();
            originator.doSomething();

            caretaker.backup();
            originator.doSomething();

            caretaker.backup();
            originator.doSomething();

            Console.WriteLine();
            caretaker.showHistory();

            Console.Write("\nClient: Now, let's rollback!\n\n");
            caretaker.undo();

            Console.Write("\n\nClient: Once more!\n\n");
            caretaker.undo();

            Console.WriteLine();
        }
    }
}