using FluentValidation;

namespace CleanArchitecture.Application.Employee.Queries.GetTodoItemsWithPagination;

public class GetEmployeeQueryValidator : AbstractValidator<GetEmployeeQuery>
{
    public GetEmployeeQueryValidator()
    {
    }
}
