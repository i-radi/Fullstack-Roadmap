using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalProgramming.FunctionalProgramming4_RealExample_
{
    class ExampleDeclarative
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

        public OrderFb4 GetOrderwithDiscount(OrderFb4 order,
                        List<(Func<OrderFb4, bool> QualifyingCondition, Func<OrderFb4, decimal> GetDiscount)> DiscountRules)
        {
            var discount = DiscountRules.Where((a) => a.QualifyingCondition(order)).Select((a) => a.GetDiscount(order))
                                                                       .OrderBy((x) => x)
                                                                       .Take(3)
                                                                       .Average();
            var neworder = new OrderFb4();
            neworder.Discount = discount;
            return neworder;
        }

        public List<(Func<OrderFb4, bool> QualifyingCondition, Func<OrderFb4, decimal> GetDiscount)> GetDiscountRules()
        {
            List<(Func<OrderFb4, bool> QualifyingCondition, Func<OrderFb4, decimal> GetDiscount)> DiscountRules
              = new List<(Func<OrderFb4, bool> QualifyingCondition, Func<OrderFb4, decimal> GetDiscount)>
            { ((isRuleAQualified, RuleA)),
              ((isRuleBQualified, RuleB)),
              ((isRuleCQualified, RuleC)) };

            return DiscountRules;
        }

        public List<OrderFb4> TryExample()
        {
            List<OrderFb4> OrdersforProcessing = new List<OrderFb4>();

            var OrderswithDiscounts = OrdersforProcessing.Select((order) => GetOrderwithDiscount(order, GetDiscountRules()))
                                                         .ToList();
            return OrderswithDiscounts;
        }
    }
}

