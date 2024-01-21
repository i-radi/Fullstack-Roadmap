using System.Collections.Generic;
using System.Linq;
using Shopify_RavenDB.Core.ValueObjects;

namespace Shopify_RavenDB.Core.Entities
{
    public class Order : Entity
    {
        private List<OrderLine> _lines = new List<OrderLine>();

        public Order(string customerId, decimal discount)
        {
            CustomerId = customerId;
            Discount = discount;
        }
        public string CustomerId { get; }
        public IReadOnlyCollection<OrderLine> Lines
        {
            get { return _lines.ToArray(); }
            private set { _lines = new List<OrderLine>(value); }
        }
        public decimal Discount { get; private set; } = 0;

        public decimal Total => (_lines.Sum(x => x.Total) - Discount);

        public void Add(OrderLine newLine)
        {
            int index = _lines.LastIndexOf(newLine);
            if (index == -1)
                _lines.Add(newLine);
            else
                _lines[index] = _lines[index].Add(newLine);
        }
        public void ApplyDiscount(decimal discount) => Discount = discount;

    }
}
