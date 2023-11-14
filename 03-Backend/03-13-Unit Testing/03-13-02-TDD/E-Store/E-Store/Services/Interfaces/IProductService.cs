using E_Store.Models;

namespace E_Store.Services.Interfaces;

public interface IProductService
{
    Task<List<Product>?> GetAllProducts();
}
