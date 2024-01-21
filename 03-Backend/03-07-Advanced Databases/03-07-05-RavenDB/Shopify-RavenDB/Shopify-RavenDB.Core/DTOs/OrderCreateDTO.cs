using System.Collections.Generic;
using Shopify_RavenDB.Core.ValueObjects;

namespace Shopify_RavenDB.Core.DTOs
{
    public class OrderCreateDTO
    {
        public string CustomerId { get; set; }
        public decimal Discount { get; set; }
        public List<OrderLineCreateDTO> OrderLines { get; set; } = new();
       
    }
}
