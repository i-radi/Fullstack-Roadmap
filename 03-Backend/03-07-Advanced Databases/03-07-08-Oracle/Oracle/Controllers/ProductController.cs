using Core_APIOracle.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Oracle.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductInfoController : ControllerBase
{
    private readonly OraDbContext _context;

    public ProductInfoController(OraDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _context.Products.ToListAsync();
        return Ok(result);
    }

    [HttpGet("View")]
    public async Task<IActionResult> View_GetAll()
    {
        var products = await _context.PRODUCTVIEW.ToListAsync();

        return Ok(products);
    }

    [HttpGet("SP_Out/{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var productIdParam = new OracleParameter("p_ProductId", OracleDbType.NVarchar2, 100, id, ParameterDirection.Input);
        var productRecordIdParam = new OracleParameter("p_ProductRecordId", OracleDbType.Int32, ParameterDirection.Output);
        var productNameParam = new OracleParameter("p_ProductName", OracleDbType.NVarchar2, 400, null, ParameterDirection.Output);
        var manufacturerParam = new OracleParameter("p_Manufacturer", OracleDbType.NVarchar2, 200, null, ParameterDirection.Output);
        var descriptionParam = new OracleParameter("p_Description", OracleDbType.NVarchar2, 1000, null, ParameterDirection.Output);
        var priceParam = new OracleParameter("p_Price", OracleDbType.Int32, ParameterDirection.Output);

        await _context.Database.ExecuteSqlInterpolatedAsync($@"
                    BEGIN
                        GetProductById(
                            {productIdParam},
                            {productRecordIdParam}, 
                            {productNameParam},
                            {manufacturerParam},
                            {descriptionParam},
                            {priceParam});
                    END;");

        var product = new ProductsInfo
        {
            ProductRecordId = int.TryParse(productRecordIdParam?.Value?.ToString(), out int productRecordId) ? productRecordId : 0,
            ProductId = productIdParam?.Value?.ToString() ?? string.Empty,
            ProductName = productNameParam?.Value?.ToString() ?? string.Empty,
            Manufacturer = manufacturerParam?.Value?.ToString() ?? string.Empty,
            Description = descriptionParam?.Value?.ToString() ?? string.Empty,
            Price = int.TryParse(priceParam?.Value?.ToString(), out int price) ? price : 0
        };

        return Ok(product);
    }

    [HttpGet("SP_Cursor/{id}")]
    public async Task<IActionResult> CURSOR_GetProductById(string id)
    {
        var productIdParam = new OracleParameter("p_ProductId", OracleDbType.NVarchar2, 100, id, ParameterDirection.Input);
        var outputParams = new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

        var product = await _context.SP_GetProductByIdResponse.FromSqlInterpolated($@"
                    BEGIN
                        CURSOR_GetProductById(
                            {productIdParam},
                            {outputParams});
                    END;")
                .ToListAsync();

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Post(ProductsInfo productsInfo)
    {
        var result = await _context.Products.AddAsync(productsInfo);
        await _context.SaveChangesAsync();
        return Ok(result.Entity);
    }
}
