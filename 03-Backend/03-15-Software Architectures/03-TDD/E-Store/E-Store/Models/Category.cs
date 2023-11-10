namespace E_Store.Models;

public class Category
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public string image { get; set; } = string.Empty;
    public DateTime creationAt { get; set; }
    public DateTime updatedAt { get; set; }
}