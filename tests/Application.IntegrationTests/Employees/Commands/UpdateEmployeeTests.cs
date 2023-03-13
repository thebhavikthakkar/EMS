using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Employee.Commands.CreateEmployee;
using CleanArchitecture.Application.Employee.Commands.UpdateEmployee;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Employee.Commands;

using static Testing;

public class UpdateEmployeeTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidEmployeeId()
    {
        var command = new UpdateEmployeeCommand { Id = 99, EmployeeName = "New EmployeeName" };
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldRequireUniqueTitle()
    {
        var employeeID = await SendAsync(new CreateEmployeeCommand
        {
            EmployeeName = "Test EmployeeName",
            DOB = DateTime.Now,
            Department = "Web",
            Email = "bhavik@live.com"
        });

        await SendAsync(new CreateEmployeeCommand
        {
            EmployeeName = "Other Name",
            DOB = DateTime.Now,
            Department = "Web",
            Email = "bhavik@live.com"
        });

        var command = new UpdateEmployeeCommand
        {
            Id = employeeID,
            EmployeeName = "Other Name",
            DOB = DateTime.Now,
            Department = "Web",
            Email = "bhavik@live.com"
        };

        (await FluentActions.Invoking(() =>
            SendAsync(command))
                .Should().ThrowAsync<ValidationException>().Where(ex => ex.Errors.ContainsKey("EmployeeName")))
                .And.Errors["EmployeeName"].Should().Contain("The specified title already exists.");
    }

    [Test]
    public async Task ShouldUpdateEmployee()
    {
        // var userId = await RunAsDefaultUserAsync();

        var employeeID = await SendAsync(new CreateEmployeeCommand
        {
            EmployeeName = "New Name",
            Department = "Test Department",
            DOB = DateTime.Now,
            Email = "Test@email.com"
        });

        var command = new UpdateEmployeeCommand
        {
            Id = employeeID,
            EmployeeName = "Updated EmployeeName",
            Department = "Test Department",
            DOB = DateTime.Now,
            Email = "Test@email.com"
        };

        await SendAsync(command);

        var employee = await FindAsync<CleanArchitecture.Domain.Entities.Employee>(employeeID);

        employee.Should().NotBeNull();
        employee!.EmployeeName.Should().Be(command.EmployeeName);

    }
}
