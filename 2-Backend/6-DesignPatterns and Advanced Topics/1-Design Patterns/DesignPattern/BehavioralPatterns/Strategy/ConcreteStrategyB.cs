using System.Collections.Generic;

namespace DesignPattern.BehavioralPatterns.Strategy
{
    class ConcreteStrategyB : Strategy
    {
        public object doAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();
            list.Reverse();

            return list;
        }
    }
}