using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopify_RavenDB.Core.DTOs;
using Shopify_RavenDB.Core.Entities;
using Shopify_RavenDB.Core.Extensions;
using Shopify_RavenDB.Core.ValueObjects;
using Shopify_RavenDB.Platform;

namespace Shopify_RavenDB.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IDocumentStore _store;
        private readonly IMapper _mapper;
        private readonly OrderLineService _orderLineService;

        public OrdersController(IDocumentStore store, IMapper mapper, OrderLineService orderLineService )
        {
            _store = store;
            _mapper = mapper;
            _orderLineService = orderLineService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            using var db = _store.OpenAsyncSession();
            return Ok(await db.Query<Order>().ToListAsync());
        }

        [HttpGet("{id}", Name = "GetOrder")]
        public async Task<IActionResult> GetOrder(string id)
        {
            using var db = _store.OpenAsyncSession();
            var customer = await db.LoadAsync<Customer>(id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDTO orderCreateDTO)
        {
            var order = _mapper.Map<Order>(orderCreateDTO);
            var orderLines = _mapper.Map<IEnumerable<OrderLine>>(orderCreateDTO.OrderLines);

            using var db = _store.OpenAsyncSession();
            var areProductsValid = await _orderLineService.CheckIfAllOrderdedProductsExist(orderLines).ToListAsync();
            if (areProductsValid.Any(foundedProduct => !foundedProduct))
                return BadRequest("Product does not exist!");

            var orderPopulated = await _orderLineService.AddProductsToOrderLine(orderLines, order.CustomerId, orderCreateDTO.Discount);
            await db.StoreAsync(orderPopulated);
            await db.SaveChangesAsync();
            
            return CreatedAtRoute(nameof(GetOrder), new { id = orderPopulated.Id }, orderPopulated);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(string id)
        {
            using var db = _store.OpenAsyncSession();
            var foundedOrder = await db.LoadAsync<Order>(id);
            if (foundedOrder is null) return NotFound();
            db.Delete(id);
            await db.SaveChangesAsync();

            return NoContent();
        }
       
    }
}
