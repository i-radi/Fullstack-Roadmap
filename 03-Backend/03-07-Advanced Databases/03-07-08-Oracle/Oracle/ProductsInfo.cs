using System.ComponentModel.DataAnnotations;

namespace Oracle;

public class ProductsInfo
{
    [Key]
    public int ProductRecordId { get; set; }
    [Required]
    [StringLength(100)]
    public string ProductId { get; set; } = String.Empty;
    [StringLength(400)]
    public string ProductName { get; set; } = String.Empty;
    [StringLength(200)]
    public string Manufacturer { get; set; } = String.Empty;
    [StringLength(1000)]
    public string Description { get; set; } = String.Empty;
    public int Price { get; set; }
}
