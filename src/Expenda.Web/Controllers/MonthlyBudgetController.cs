using Expenda.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Expenda.Web.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MonhtlyBudgetController : ControllerBase
{
    [HttpGet]
    public IActionResult ListMonthlyBudgets(CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [HttpPut]
    public IActionResult SetMonthlyBudget(CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public IActionResult GetMonthlyBudget([FromRoute] int id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}
