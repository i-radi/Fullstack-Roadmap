using Blogify.Models;
using LiteDB;

namespace Blogify.Services;

public class PostService: IPostService
{
	private LiteDatabase _liteDb;

	public PostService(ILiteDbContext liteDbContext)
	{
		_liteDb = liteDbContext.Database;
	}

	public IEnumerable<Post> FindAll()
	{
		var result = _liteDb.GetCollection<Post>("Post")
			.FindAll();
		return result;
	}

	public Post FindOne(int id)
	{
		return _liteDb.GetCollection<Post>("Post")
			.Find(x => x.Id == id).FirstOrDefault();
	}

	public int Insert(Post post)
	{
		return _liteDb.GetCollection<Post>("Post")
			.Insert(post);
	}

	public bool Update(Post post)
	{
		return _liteDb.GetCollection<Post>("Post")
			.Update(post);
	}

	public bool Delete(int id)
	{
		return _liteDb.GetCollection<Post>("Post")
			.Delete(id);
	}
}
