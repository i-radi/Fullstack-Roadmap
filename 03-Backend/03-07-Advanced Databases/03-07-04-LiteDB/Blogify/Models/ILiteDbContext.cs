using LiteDB;
using Microsoft.Extensions.Options;

namespace Blogify.Models;

public interface ILiteDbContext
{
	LiteDatabase Database { get; }
}