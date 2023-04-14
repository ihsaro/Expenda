using Expenda.Application.Features.MonthlyBudget.Commands;
using Expenda.Application.Features.MonthlyBudget.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Expenda.Web.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MonhtlyBudgetController : ControllerBase
{
    private readonly IMediator _mediator;

    public MonhtlyBudgetController(IMediator mediator)
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

    [HttpGet("{id}")]
    public IActionResult GetMonthlyBudget([FromRoute] int id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}
