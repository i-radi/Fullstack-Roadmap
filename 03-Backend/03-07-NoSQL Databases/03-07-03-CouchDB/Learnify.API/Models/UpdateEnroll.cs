using Newtonsoft.Json;

namespace Learnify.API.Models;

public class UpdateEnroll
{
	public string Id { get; set; }
	[JsonIgnore]
	public string Rev { get; set; }
	public string Name { get; set; }
	public string EmailAddress { get; set; }
	public string CourseName { get; set; }
	public DateTime EnrolledOn { get; set; }
	public DateTime UpdatedOn { get; set; }
}
