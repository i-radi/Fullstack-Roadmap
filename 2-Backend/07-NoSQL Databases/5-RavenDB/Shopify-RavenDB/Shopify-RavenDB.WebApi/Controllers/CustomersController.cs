using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shopify_RavenDB.Core.DTOs;
using Shopify_RavenDB.Core.Entities;
using Shopify_RavenDB.Core.Extensions;

namespace Shopify_RavenDB.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IDocumentStore _store;
        private readonly IMapper _mapper;
        public CustomersController(IDocumentStore store, IMapper mapper)
        {
            _store = store;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            using var db = _store.OpenAsyncSession();
            return Ok(await db.Query<Customer>().ToListAsync());
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomer(string id)
        {
            using var db = _store.OpenAsyncSession();
            var customer = await db.LoadAsync<Customer>(id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreateDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);

            using var db = _store.OpenAsyncSession();
            await db.StoreAsync(customer);
            await db .SaveChangesAsync();

            var customerDto = _mapper.Map<CustomerCreateDTO>(customer);
            return CreatedAtRoute(nameof(GetCustomer), new { id = customer.Id }, customerDto);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            using var db = _store.OpenAsyncSession();
            var foundedCustomer = await db.LoadAsync<Customer>(id);
            if (foundedCustomer is null) return NotFound();
            db.Delete(id);
            await db.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(string id, [FromBody] CustomerUpdateDTO customerUpdateDTO)
        {
            using var db = _store.OpenAsyncSession();
            var foundedCustomer = await db.LoadAsync<Customer>(id);
            if (foundedCustomer is null) return NotFound();
            var customerToUpdate = _mapper.Map<Customer>(customerUpdateDTO);
            foundedCustomer.Name = customerToUpdate.Name;
            foundedCustomer.Email = customerToUpdate.Email;
            
            await db.SaveChangesAsync();
            
            return NoContent();

        }
    }
}
