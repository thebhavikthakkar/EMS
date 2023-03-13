using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Employee.Queries.GetTodoItemsWithPagination;

public class EmployeeBriefDto : IMapFrom<CleanArchitecture.Domain.Entities.Employee>
{
    public int Id { get; set; }
    public string EmployeeName { get; init; }

    public string Department { get; init; }

    public DateTime DOB { get; set; }
    public string Email { get; set; }
}
