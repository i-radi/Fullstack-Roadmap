using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Oracle;

[Keyless]
public class View_Product
{
    public int ProductRecordId { get; set; }
    public string ProductId { get; set; } = String.Empty;
    public string ProductName { get; set; } = String.Empty;
    public string Manufacturer { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public int Price { get; set; }
}
