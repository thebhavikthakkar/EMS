using FluentValidation;

namespace CleanArchitecture.Application.Employee.Commands.UpdateEmployee;

public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(v => v.EmployeeName)
            .MaximumLength(200)
            .NotEmpty();
    }
}
