using System;

namespace DesignPattern.BehavioralPatterns.Visitor
{
    class ConcreteVisitor1 : Visitor
    {
        public void visitConcreteComponentA(ConcreteComponentA el)
        {
            Console.Write(el.exclusiveMethodOfConcreteComponentA() + " + ConcreteVisitor1\n");
        }

        public void visitConcreteComponentB(ConcreteComponentB el)
        {
            Console.Write(el.specialMethodOfConcreteComponentB() + " + ConcreteVisitor1\n");
        }
    }
}