using System;

namespace DesignPattern.BehavioralPatterns.Visitor
{
    class ConcreteVisitor2 : Visitor
    {
        public void visitConcreteComponentA(ConcreteComponentA el)
        {
            Console.Write(el.exclusiveMethodOfConcreteComponentA() + " + ConcreteVisitor2\n");
        }

        public void visitConcreteComponentB(ConcreteComponentB el)
        {
            Console.Write(el.specialMethodOfConcreteComponentB() + " + ConcreteVisitor2\n");
        }
    }
}