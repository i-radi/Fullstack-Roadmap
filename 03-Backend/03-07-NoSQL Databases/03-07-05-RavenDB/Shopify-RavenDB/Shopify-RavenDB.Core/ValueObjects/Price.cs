using System;
using System.Collections.Generic;

namespace Shopify_RavenDB.Core.ValueObjects
{
    public class Price : ValueObject
    {
        public decimal Amount { get; }
        public Price(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("Must be bigger than zero.");
            Amount = amount;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
        }
    }
}
