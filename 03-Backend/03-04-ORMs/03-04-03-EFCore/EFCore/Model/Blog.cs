namespace EFCore.Model;

//[Index(nameof(Url),IsUnique = true)]
public class Blog
{
    [Key]
    public int BlogId { get; set; }
    //[Column("BlogUrl",TypeName = "varchar(300)")]
    //[Comment("The Url of the blog")]
    public string Url { get; set; }
    public int Rating { get; set; }
    public DateTime CreatedOn { get; set; }
    [NotMapped]
    public DateTime AddedOn { get; set; }
    public virtual List<Post> Posts { get; set; }
}