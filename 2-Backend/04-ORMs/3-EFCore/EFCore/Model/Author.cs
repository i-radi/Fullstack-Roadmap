namespace EFCore.Model;

public class Author
{
    public int Id { get; set; }
    [Required,MaxLength(50)]
    public string FirstName { get; set; }
    [Required, MaxLength(50)]
    public string LastName { get; set; }
    [MaxLength(100)]
    public string DisplayName { get; set; }

    public virtual Book Book { get; set; }
}