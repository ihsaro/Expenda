using Expenda.Application.Features.Expenses.Commands;
using Expenda.Application.Features.Expenses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Expenda.Web.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExpensesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetExpenses(CancellationToken token = default)
    {
        return Ok(await _mediator.Send(new GetExpensesQuery()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateExpense([FromBody] CreateExpenseCommand command, CancellationToken token = default)
    {
        var result = await _mediator.Send(command, token);
        return result.Success && result.ResultObject is not null ? Created($"api/v1/expenses/{result.ResultObject.Id}", result.ResultObject) : BadRequest(result.ErrorMessages);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetExpense([FromRoute] int id, CancellationToken token = default)
    {
        var result = await _mediator.Send(new GetExpenseQuery { Id = id }, token);
        return result.Success && result.ResultObject is not null ? Ok(result.ResultObject) : NotFound(result.ErrorMessages);
    }

    [HttpPut("{id}")]
    public Task<IActionResult> UpdateExpense([FromRoute] int id, [FromBody] UpdateExpenseCommand command, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExpense([FromRoute] int id, CancellationToken token = default)
    {
        var result = await _mediator.Send(new DeleteExpenseCommand { Id = id }, token);
        return result.Success && result.ResultObject ? NoContent() : NotFound(result.ErrorMessages);
    }

    [HttpDelete("")]
    public Task<IActionResult> DeleteExpenses([FromBody] IEnumerable<int> ids, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    [HttpGet("list-monthly-expenses-total")]
    public Task<IActionResult> ListMonthlyExpensesTotal(CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}
