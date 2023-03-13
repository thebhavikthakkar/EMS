using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;
using MediatR;

namespace CleanArchitecture.Application.Employee.Commands.CreateEmployee;

public record CreateEmployeeCommand : IRequest<int>
{
    public string EmployeeName { get; init; }
    public string Department { get; init; }
    public string Email { get; init; }
    public DateTime DOB { get; init; }
}

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = new CleanArchitecture.Domain.Entities.Employee
        {
            EmployeeName = request.EmployeeName, Department = request.Department,
            Email = request.Email, DOB = request.DOB
        };

        entity.AddDomainEvent(new EmployeeCreatedEvent(entity));

        _context.Employees.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
