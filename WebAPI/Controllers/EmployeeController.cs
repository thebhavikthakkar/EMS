using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Employee.Commands.CreateEmployee;
using CleanArchitecture.Application.Employee.Commands.UpdateEmployee;
using CleanArchitecture.Application.Employee.Commands.DeleteEmployee;
using CleanArchitecture.Application.Employee.Queries.GetTodoItemsWithPagination;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
public class EmployeeController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<EmployeeBriefDto>>> GetEmployeeList([FromQuery] GetEmployeeQuery query)
    {
        return await Mediator.Send(query);
    }
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateEmployeeCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(int id, UpdateEmployeeCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteEmployeeCommand(id));

        return NoContent();
    }
}
