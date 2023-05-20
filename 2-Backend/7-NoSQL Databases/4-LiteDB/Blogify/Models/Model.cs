namespace Blogify.Models;

public class Model
{
	// Everything needs and ID, not explanation required
	public int Id { get; set; }

	// Will hold the original creation date of the field, 
	// the default value is set to DateTime.Now
	public DateTime Created { get; set; } = DateTime.Now;

	// will hold the last updated date of the field
	///will initially be set to DateTime.Now, but should be updated on every...update
	public DateTime Updated { get; set; } = DateTime.Now;
	public bool Deleted { get; set; } = false;
}
