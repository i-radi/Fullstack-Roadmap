namespace EFCore.Model;

public class Category
{
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public byte Id { get; set; }
    [Required, MaxLength(50)]
    public string Name { get; set; }
    
}