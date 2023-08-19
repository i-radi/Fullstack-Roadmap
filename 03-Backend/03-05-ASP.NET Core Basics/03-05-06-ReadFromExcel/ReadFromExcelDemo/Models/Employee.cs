namespace ReadFromExcelDemo.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public string Email { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public string Manager { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;

}
