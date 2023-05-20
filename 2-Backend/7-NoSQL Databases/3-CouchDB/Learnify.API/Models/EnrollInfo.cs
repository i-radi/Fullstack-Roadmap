using Newtonsoft.Json;

namespace Learnify.API.Models;

public class EnrollInfo
{
	[JsonProperty("_id")]
	public string Id { get; set; }
	[JsonProperty("_rev")]
	public string Rev { get; set; }
	public string Name { get; set; }
	public string EmailAddress { get; set; }
	public string CourseName { get; set; }
	public DateTime EnrolledOn { get; set; }
	public DateTime UpdatedOn { get; set; }
}
