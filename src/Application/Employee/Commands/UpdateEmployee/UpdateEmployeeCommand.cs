using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Employee.Commands.UpdateEmployee;

public record UpdateEmployeeCommand : IRequest
{
    public int Id { get; init; }

    public string EmployeeName { get; init; }
    public string Email { get; init; }
    public string Department { get; init; }
    public DateTime DOB { get; init; }
}

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Employees
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Employee), request.Id);
        }

        entity.EmployeeName = request.EmployeeName;
        entity.Email = request.Email;
        entity.DOB = request.DOB;
        entity.Department = request.Department;
        await _context.SaveChangesAsync(cancellationToken);
    }
}
