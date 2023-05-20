using System;
using System.Collections.Generic;

namespace DesignPattern.BehavioralPatterns.ChainOfResponsibility
{
    class Client
    {
        public static void ClientCode(AbstractHandler handler)
        {
            foreach(var food in new List<string> { "Nut", "Banana", "Cup of coffee" })
            {
                Console.WriteLine("Client: Who wants a " + food + "?");

                var result = handler.Handle(food);

                if (result != null)
                {
                    Console.Write("   " + result);
                }
                else
                {
                    Console.WriteLine("   " + food + " was left untouched.");
                }
            }
        }
    }
}
