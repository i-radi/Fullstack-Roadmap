using Shopify_RavenDB.Core.ValueObjects;

namespace Shopify_RavenDB.Core.Entities
{
    public class Product : Entity
    {
        public ProductName Name { get; set; }
        public Price Price { get; set; }
    }
}
