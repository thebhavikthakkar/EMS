using FluentValidation;

namespace CleanArchitecture.Application.Employee.Commands.CreateEmployee;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(v => v.EmployeeName)
            .MaximumLength(200)
            .NotEmpty();
    }
}
