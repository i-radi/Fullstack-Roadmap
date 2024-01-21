namespace Learnify.API.Models;

public class HttpClientResponse
{
	public bool IsSuccess { get; set; }
	public dynamic SuccessContentObject { get; set; }
	public string FailedReason { get; set; }
}
public class SavedResult
{
	public string Id { get; set; }
	public string Rev { get; set; }
}
