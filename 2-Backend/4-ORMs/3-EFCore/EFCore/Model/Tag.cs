namespace EFCore.Model;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual List<Post> Posts { get; set; }
    public virtual List<TagPost> TagPosts { get; set; }
}