namespace EFCore.Model;

//[Table("Posts",Schema = "Blogging")]
public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    //[MaxLength(500)]
    public string Content { get; set; }

    public int BlogId { get; set; }
    public virtual Blog Blog { get; set; }
    public virtual List<Tag> Tags { get; set; }
    public virtual List<TagPost> TagPosts { get; set; }

}