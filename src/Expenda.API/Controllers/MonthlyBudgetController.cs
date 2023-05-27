using Expenda.Application.Features.MonthlyBudgetManager.Commands;
using Expenda.Application.Features.MonthlyBudgetManager.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Expenda.API.Controllers;

[ApiController]
[Route("api/v1")]
public class MonthlyBudgetController : ControllerBase
{
    private readonly IMediator _mediator;

    public MonthlyBudgetController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("monthly-budgets")]
    public IActionResult ListMonthlyBudgets(ListMonthlyBudgetsQuery query, CancellationToken token = default)
    {
        return Ok(_mediator.Send(query, token));
    }

    [HttpPost]
    [HttpPut]
    [Route("monthly-budget")]
    public IActionResult SetMonthlyBudget(SetMonthlyBudgetCommand command, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    [HttpGet("monthly-budget/{year}")]
    public IActionResult GetMonthlyBudget([FromRoute] int year, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}
