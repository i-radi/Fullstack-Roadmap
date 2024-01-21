using Blogify.Models;

namespace Blogify.Services;

public interface IPostService
{
	bool Delete(int id);
	IEnumerable<Post> FindAll();
	Post FindOne(int id);
	int Insert(Post post);
	bool Update(Post post);
}
