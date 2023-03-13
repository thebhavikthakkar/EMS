using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Employee.Queries.GetTodoItemsWithPagination;

public record GetEmployeeQuery : IRequest<PaginatedList<EmployeeBriefDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, PaginatedList<EmployeeBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEmployeeQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<EmployeeBriefDto>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        return await _context.Employees
            .OrderBy(x => x.EmployeeName)
            .ProjectTo<EmployeeBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
