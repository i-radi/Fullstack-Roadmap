using System;

namespace DesignPattern.BehavioralPatterns.Command
{
    class ComplexCommand : Command
    {
        Receiver receiver;

        string a;

        string b;

        public ComplexCommand(Receiver r, string a, string b)
        {
            receiver = r;
            this.a = a;
            this.b = b;
        }

        public override void Execute()
        {
            Console.Write("ComplexCommand: Complex stuff should be done by a receiver object.\n");
            receiver.doSomething(a);
            receiver.doSomethingElse(b);
        }
    }
}