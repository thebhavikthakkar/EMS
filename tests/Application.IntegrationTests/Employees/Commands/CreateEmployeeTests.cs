using CleanArchitecture.Application.Employee.Commands.CreateEmployee;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Employees.Commands;

using static Testing;

public class CreateEmployeeTests : BaseTestFixture
{
    //[Test]
    //public async Task ShouldRequireMinimumFields()
    //{
    //    var command = new CreateEmployeeCommand();
    //    await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<System.ComponentModel.DataAnnotations.ValidationException>();
    //}

    [Test]
    public async Task ShouldRequireUniqueName()
    {
        await SendAsync(new CreateEmployeeCommand
        {
            EmployeeName = "Test EmployeeName",
            Department = "Test Department",
            DOB = DateTime.Now,
            Email = "Test@email.com"
        });

        var command = new CreateEmployeeCommand
        {
            EmployeeName = "Test EmployeeName",
            Department = "Test Department",
            DOB = DateTime.Now,
            Email = "Test@email.com"
        };

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<System.ComponentModel.DataAnnotations.ValidationException>();
    }

    [Test]
    public async Task ShouldCreateEmployee()
    {
        //var userId = await RunAsDefaultUserAsync();

        var command = new CreateEmployeeCommand
        {
            EmployeeName = "Test EmployeeName",
            Department = "Test Department",
            DOB = DateTime.Now,
            Email = "Test@email.com"
        };

        var id = await SendAsync(command);

        var employee = await FindAsync<CleanArchitecture.Domain.Entities.Employee>(id);

        employee.Should().NotBeNull();
        employee!.EmployeeName.Should().Be(command.EmployeeName);
    }
}
