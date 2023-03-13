using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<CleanArchitecture.Domain.Entities.Employee> Employees { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}