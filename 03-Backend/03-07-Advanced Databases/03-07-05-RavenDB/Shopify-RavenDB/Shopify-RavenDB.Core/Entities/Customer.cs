using Shopify_RavenDB.Core.ValueObjects;

namespace Shopify_RavenDB.Core.Entities
{
    public class Customer : Entity
    {
        public Customer(CustomerName name, Email email)
        {
            Name = name;
            Email = email;
        }
        public Customer()
        {

        }
        public CustomerName Name { get; set; }
        public Email Email { get; set; }

    }
}
