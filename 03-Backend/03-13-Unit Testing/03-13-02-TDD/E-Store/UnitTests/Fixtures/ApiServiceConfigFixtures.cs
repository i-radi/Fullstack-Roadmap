using E_Store.Configurations;

namespace UnitTests.Fixtures;

public class ApiServiceConfigFixtures
{
    internal static ApiServiceConfig Get()
    {
        return new ApiServiceConfig
        {
            Url = "https://api.escuelajs.co/api/v1/products"
        };
    }
}
