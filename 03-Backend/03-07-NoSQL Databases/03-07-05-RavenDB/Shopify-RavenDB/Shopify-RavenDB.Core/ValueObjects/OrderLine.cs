using System;
using System.Collections.Generic;

namespace Shopify_RavenDB.Core.ValueObjects
{
    public class OrderLine : ValueObject
    {
        public string ProductId { get; }
        public int Quantity { get; }
        public decimal Price { get;  }
        public decimal Total => Price * Quantity;

        public OrderLine(string productId, int quantity, decimal price)
        {
            if (string.IsNullOrWhiteSpace(productId)) throw new Exception("invalid productId");
            if (quantity < 1) throw new Exception("invalid quantity");
            if (price <= 0) throw new Exception("invalid price");

            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        public OrderLine(string productId, int quantity)
        {
            if (string.IsNullOrWhiteSpace(productId)) throw new Exception("invalid productId");
            if (quantity < 1) throw new Exception("invalid quantity");
            
            ProductId = productId;
            Quantity = quantity;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ProductId;
            yield return Price;
        }

        public OrderLine Add(OrderLine other)
        {
            if (this != other) throw new Exception("Cannot add order lines with different products");

            return new OrderLine(this.ProductId, this.Quantity + other.Quantity, this.Price);
        }
    }
}
