using E_Store.Configurations;
using E_Store.Models;
using E_Store.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Net;

namespace E_Store.Services.Implementations;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;
    private readonly ApiServiceConfig _config;

    public ProductService(HttpClient httpClient, IOptions<ApiServiceConfig> config)
    {
        _httpClient = httpClient;
        _config = config.Value;
    }

    public async Task<List<Product>?> GetAllProducts()
    {
        var response = await _httpClient.GetAsync(_config.Url);

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return Enumerable.Empty<Product>().ToList();
        }
        else if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            return null;
        }
        else
        {
            var products = await response.Content.ReadFromJsonAsync<List<Product>>();
            return products;
        }
    }
}
