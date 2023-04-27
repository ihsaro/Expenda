using Expenda.Application.Features.MonthlyBudgetManager.Commands;
using Expenda.Application.Features.MonthlyBudgetManager.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Expenda.Web.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MonthlyBudgetController : ControllerBase
{
    private readonly IMediator _mediator;

    public MonthlyBudgetController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public IActionResult ListMonthlyBudgets(ListMonthlyBudgetsQuery query, CancellationToken token = default)
    {
        return Ok(_mediator.Send(query, token));
    }

    [HttpPost]
    [HttpPut]
    public IActionResult SetMonthlyBudget(SetMonthlyBudgetCommand command, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id:int}")]
    public IActionResult GetMonthlyBudget([FromRoute] int id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}
