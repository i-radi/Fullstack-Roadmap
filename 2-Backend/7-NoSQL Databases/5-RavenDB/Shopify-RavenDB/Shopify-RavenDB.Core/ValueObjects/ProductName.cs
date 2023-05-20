using System.Collections.Generic;

namespace Shopify_RavenDB.Core.ValueObjects
{
    public class ProductName : ValueObject
    {
        public ProductName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new System.ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            Name = name;
        }
        public string Name { get; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
