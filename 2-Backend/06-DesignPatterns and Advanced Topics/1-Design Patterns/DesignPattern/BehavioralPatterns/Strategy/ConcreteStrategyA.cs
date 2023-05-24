using System.Collections.Generic;

namespace DesignPattern.BehavioralPatterns.Strategy
{
    class ConcreteStrategyA : Strategy
    {
        public object doAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();

            return list;
        }
    }
}