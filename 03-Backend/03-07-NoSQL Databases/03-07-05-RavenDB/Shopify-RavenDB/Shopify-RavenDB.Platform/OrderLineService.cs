using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopify_RavenDB.Core.Entities;
using Shopify_RavenDB.Core.ValueObjects;

namespace Shopify_RavenDB.Platform
{
    public class OrderLineService
    {
        private readonly IDocumentStore _store;

        public OrderLineService(IDocumentStore store)
        {
            _store = store;
        }
        public async IAsyncEnumerable<bool> CheckIfAllOrderdedProductsExist(IEnumerable<OrderLine> orderLines)
        {
            using var db = _store.OpenAsyncSession();
            foreach (var line in orderLines)
            {
                if (!await db.Query<Product>().AnyAsync(x => x.Id == line.ProductId)) 
                {
                    yield return false;
                    yield break;
                };
            }
            yield return true;
        }

        public async Task<Order> AddProductsToOrderLine(IEnumerable<OrderLine> orderLines, string customerId, decimal discount)
        {
            var order = new Order(customerId, discount);
            using var db = _store.OpenAsyncSession();
            foreach (var line in orderLines)
            {
                var product = await db.LoadAsync<Product>(line.ProductId);
                OrderLine newLine = new OrderLine(product.Id, line.Quantity, product.Price.Amount);
                order.Add(newLine);
            }
            return order;
        }
    }
}
