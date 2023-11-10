using E_Store.Models;

namespace UnitTests.Fixtures;

public class ProductsFixtures
{
    public static List<Product> GetProducts()
    {
        return new List<Product>
        {
            new Product
            {
                id = 1,
                title = "title1",
                description = "description1",
                price = 100,
            },
            new Product
            {
                id = 2,
                title = "title2",
                description = "description2",
                price = 200,
            }
        };
    }
}
