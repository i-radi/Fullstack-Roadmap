namespace MongoDB_CRUD_Project.Models;

public class SchoolDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string StudentsCollectionName { get; set; } = null!;
}
