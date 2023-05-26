using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopify_RavenDB.Core.DTOs;
using Shopify_RavenDB.Core.Entities;

namespace Shopify_RavenDB.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IDocumentStore _store;
        private readonly IMapper _mapper;
        public ProductsController(IDocumentStore store, IMapper mapper)
        {
            _store = store;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            using var db = _store.OpenAsyncSession();
            return Ok(await db.Query<Product>().ToListAsync());
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<IActionResult> GetProduct(string id)
        {
            using var db = _store.OpenAsyncSession();
            var customer = await db.LoadAsync<Customer>(id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDTO productCreateDTO)
        {
            var product = _mapper.Map<Product>(productCreateDTO);

            using var db = _store.OpenAsyncSession();
            await db.StoreAsync(product);
            await db.SaveChangesAsync();

            var productDTO = _mapper.Map<ProductCreateDTO>(product);
            return CreatedAtRoute(nameof(GetProduct), new { id = product.Id }, productDTO);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            using var db = _store.OpenAsyncSession();
            var foundedProduct = await db.LoadAsync<Product>(id);
            if (foundedProduct is null) return NotFound();
            db.Delete(id);
            await db.SaveChangesAsync();

            return NoContent();
        }
    }
}
