using E_Store.Controllers;
using E_Store.Models;
using E_Store.Services.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTests.Fixtures;

namespace UnitTests.Systems.Controllers;

public class TestProductsController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnStatusCode200()
    {
        //Arrange
        var mockLogger = new Mock<ILogger<ProductsController>>();
        var mockProductService = new Mock<IProductService>();
        mockProductService.Setup(service => service.GetAllProducts())
            .ReturnsAsync(ProductsFixtures.GetProducts());

        var productController = new ProductsController(mockLogger.Object, mockProductService.Object);

        //Act
        var result = (OkObjectResult)await productController.GetAll();

        //Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Get_OnSuccess_ReturnListOfProducts()
    {
        //Arrange
        var mockLogger = new Mock<ILogger<ProductsController>>();
        var mockProductService = new Mock<IProductService>();
        mockProductService.Setup(service => service.GetAllProducts())
            .ReturnsAsync(ProductsFixtures.GetProducts());

        var productController = new ProductsController(mockLogger.Object, mockProductService.Object);

        //Act
        var result = (OkObjectResult)await productController.GetAll();

        //Assert
        result.Should().BeOfType<OkObjectResult>();
        result.Value.Should().BeOfType<List<Product>>();
    }

    [Fact]
    public async Task Get_OnSuccess_ReturnNotFound()
    {
        //Arrange
        var mockLogger = new Mock<ILogger<ProductsController>>();
        var mockProductService = new Mock<IProductService>();
        mockProductService.Setup(service => service.GetAllProducts())
            .ReturnsAsync(Enumerable.Empty<Product>().ToList());

        var productController = new ProductsController(mockLogger.Object, mockProductService.Object);

        //Act
        var result = (NotFoundObjectResult)await productController.GetAll();

        //Assert
        result.StatusCode.Should().Be(404);
    }

}
