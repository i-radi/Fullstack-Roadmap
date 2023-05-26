using System;
using System.Collections.Generic;

namespace DesignPattern.BehavioralPatterns.Strategy
{
    class Context
    {
        private Strategy _strategy;

        public Context()
        { }

        public Context(Strategy strategy)
        {
            this._strategy = strategy;
        }

        public void setStrategy(Strategy strategy)
        {
            this._strategy = strategy;
        }

        public void doSomeBusinessLogic()
        {
            Console.Write("Context: Sorting data using the strategy (not sure how it'll do it)\n");
            var result = this._strategy.doAlgorithm(new List<string> { "a", "b", "c", "d", "e" });

            string result_str = string.Empty;
            foreach(var element in result as List<string>)
            {
                result_str += element + ",";
            }

            Console.Write(result_str);
        }
    }
}