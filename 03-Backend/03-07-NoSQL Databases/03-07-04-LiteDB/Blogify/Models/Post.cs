using System.Reflection;

namespace Blogify.Models;

public class Post
{
	public int Id { get; set; }
	public string Title { get; set; }
	//public int Views { get; set; } = 0;
	//public string Content { get; set; }
	//public string Excerpt { get; set; }
	//public string CoverImagePath { get; set; }
	public bool Public { get; set; }

}
