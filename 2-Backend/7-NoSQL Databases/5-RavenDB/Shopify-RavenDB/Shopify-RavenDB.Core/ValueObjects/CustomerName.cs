using System.Collections.Generic;

namespace Shopify_RavenDB.Core.ValueObjects
{
    public class CustomerName : ValueObject
    {
        public CustomerName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new System.ArgumentException($"'{nameof(firstName)}' cannot be null or empty.", nameof(firstName));
            if (string.IsNullOrEmpty(lastName))
                throw new System.ArgumentException($"'{nameof(lastName)}' cannot be null or empty.", nameof(lastName));
            
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get; }
        public string LastName { get; set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
