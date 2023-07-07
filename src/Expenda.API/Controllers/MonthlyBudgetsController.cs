using Expenda.Application.Features.MonthlyBudgetManager.Commands;
using Expenda.Application.Features.MonthlyBudgetManager.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Expenda.API.Controllers;

[ApiController]
[Route("api/v1/monthly-budgets")]
public class MonthlyBudgetsController : ControllerBase
{
    private readonly IMediator _mediator;

    public MonthlyBudgetsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("")]
    public async Task<IActionResult> ListMonthlyBudgets(ListMonthlyBudgetsQuery query, CancellationToken token = default)
    {
        return Ok(await _mediator.Send(query, token));
    }

    [HttpPost]
    [HttpPut]
    [Route("")]
    public async Task<IActionResult> SetMonthlyBudget(SetMonthlyBudgetCommand command, CancellationToken token = default)
    {
        var result = await _mediator.Send(command, token);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpGet("{year}/{month}")]
    public async Task<IActionResult> GetMonthlyBudget([FromRoute] int year, [FromRoute] int month, CancellationToken token = default)
    {
        var result = await _mediator.Send(new RetrieveMonthlyBudgetQuery { Year = year, Month = month }, token);
        return result is { Success: true, ResultObject: not null } ? Ok(result.ResultObject) : NotFound(result.ErrorMessages);
    }
}
