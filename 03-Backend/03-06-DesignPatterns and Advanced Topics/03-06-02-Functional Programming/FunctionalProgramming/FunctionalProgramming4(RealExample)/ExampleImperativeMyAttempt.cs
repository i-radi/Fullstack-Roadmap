using System.Collections.Generic;
using System.Linq;

namespace FunctionalProgramming.FunctionalProgramming4_RealExample_
{
    class ExampleImperativeMyAttempt
    {
        public bool isRuleAQualified(OrderFb4 r)
        {
            return true;
        }
        public decimal RuleA(OrderFb4 r)
        {

            return 1M;
        }


        public bool isRuleBQualified(OrderFb4 r)
        {
            return true;
        }
        public decimal RuleB(OrderFb4 r)
        {

            return 1M;
        }


        public bool isRuleCQualified(OrderFb4 r)
        {
            return true;
        }
        public decimal RuleC(OrderFb4 r)
        {

            return 1M;
        }

        public List<OrderFb4> GetOrderswithDiscount(List<OrderFb4> OrdersforProcessing, List<OrderFb4> isRulesQualifiedList)
        {
            List<OrderFb4> orderswithDiscount = new List<OrderFb4>();
            foreach (var order in OrdersforProcessing)
            {
                var discount = isRulesQualifiedList.Where(o => o.OrderId == order.OrderId).Select(o => o.Discount)
                                                 .OrderBy(o => o)
                                                 .Take(3)
                                                 .Average();
                order.Discount = discount;
                orderswithDiscount.Add(order);
            }
            return orderswithDiscount;
        }
        public List<OrderFb4> TryExample()
        {
            List<OrderFb4> OrdersforProcessing = new List<OrderFb4>();

            List<OrderFb4> isRulesQualifiedList = new List<OrderFb4>();


            foreach (var order in OrdersforProcessing)
            {
                if (isRuleAQualified(order))
                {
                    order.Discount = RuleA(order);
                    isRulesQualifiedList.Add(order);
                }
                else if (isRuleBQualified(order))
                {
                    order.Discount = RuleB(order);
                    isRulesQualifiedList.Add(order);
                }
                else if (isRuleCQualified(order))
                {
                    order.Discount = RuleC(order);
                    isRulesQualifiedList.Add(order);
                }
            }
            return GetOrderswithDiscount(OrdersforProcessing,
                                        isRulesQualifiedList);
        }
    }
}
