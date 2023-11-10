using E_Store.Models;
using E_Store.Services.Implementations;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using UnitTests.Fixtures;
using UnitTests.Helpers;

namespace UnitTests.Systems.Services;

public class TestProductService
{
    [Fact]
    public async Task GetAllProducts_OnInvoked_HttpGet()
    {
        //Arrange
        var Url = ApiServiceConfigFixtures.Get().Url;
        var response = ProductsFixtures.GetProducts();
        var mockHandler = MockHttpHandler<Product>.SetupGetRequest(response);
        var httpClient = new HttpClient(mockHandler.Object);

        var config = Options.Create(ApiServiceConfigFixtures.Get());
        var productService = new ProductService(httpClient, config);

        //Act
        await productService.GetAllProducts();

        //Assert
        mockHandler.Protected().Verify(
            "SendAsync", Times.Once(),
            ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Get && r.RequestUri!.ToString() == Url),
            ItExpr.IsAny<CancellationToken>());
    }

    [Fact]
    public async Task GetAllProducts_OnInvoked_ListOfProducts()
    {
        //Arrange
        var Url = ApiServiceConfigFixtures.Get().Url;
        var response = ProductsFixtures.GetProducts();
        var mockHandler = MockHttpHandler<Product>.SetupGetRequest(response);
        var httpClient = new HttpClient(mockHandler.Object);

        var config = Options.Create(ApiServiceConfigFixtures.Get());
        var productService = new ProductService(httpClient, config);

        //Act
        var result = await productService.GetAllProducts();

        //Assert
        result.Should().BeOfType<List<Product>>();
    }

    [Fact]
    public async Task GetAllProducts_OnInvoked_ReturnEmptyList()
    {
        //Arrange
        var Url = ApiServiceConfigFixtures.Get().Url;
        var mockHandler = MockHttpHandler<Product>.SetupReturnNotFound();
        var httpClient = new HttpClient(mockHandler.Object);

        var config = Options.Create(ApiServiceConfigFixtures.Get());
        var productService = new ProductService(httpClient, config);

        //Act
        var result = await productService.GetAllProducts();

        //Assert
        result!.Count.Should().Be(0);
    }

}
