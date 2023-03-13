namespace CleanArchitecture.Domain.Entities;

public class Employee : BaseEntity
{
    public string EmployeeName { get; set; }
    public string Department { get; set; }
    public DateTime DOB { get; set; }
    public string Email { get; set; }
}
