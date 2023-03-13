using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Employee.Commands.DeleteEmployee;
using CleanArchitecture.Application.Employee.Commands.CreateEmployee;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Employees.Commands;

using static Testing;

public class DeleteEmployeeTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidEmployeeId()
    {
        var command = new DeleteEmployeeCommand(99);
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteEmployee()
    {
        var employeeID = await SendAsync(new CreateEmployeeCommand
        {
            EmployeeName = "Test EmployeeName",
            Department = "Test Department",
            DOB = DateTime.Now,
            Email = "Test@email.com"
        });

        await SendAsync(new DeleteEmployeeCommand(employeeID));

        var employee = await FindAsync<CleanArchitecture.Domain.Entities.Employee>(employeeID);

        employee.Should().BeNull();
    }
}
