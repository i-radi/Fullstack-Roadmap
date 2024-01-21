using System;
using System.Collections.Generic;

namespace Shopify_RavenDB.Core.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            if (string.IsNullOrEmpty(address))
               throw new ArgumentException($"'{nameof(address)}' cannot be null or empty.", nameof(address));
            if (!address.Contains("@"))
                throw new ArgumentException($"'{nameof(address)}' must have '@' character.", nameof(address));
            if (!address.Contains("."))
                throw new ArgumentException($"'{nameof(address)}' must have '.' character.", nameof(address));

            Address = address;
        }
        public string Address { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Address;
        }
    }

}
