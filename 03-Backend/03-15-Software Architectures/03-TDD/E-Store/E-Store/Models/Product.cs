namespace E_Store.Models;
public class Product
{
    public int id { get; set; }
    public string title { get; set; } = string.Empty;
    public int price { get; set; }
    public string description { get; set; } = string.Empty;
    public string[]? images { get; set; }
    public DateTime creationAt { get; set; }
    public DateTime updatedAt { get; set; }
    public Category? category { get; set; }
}
