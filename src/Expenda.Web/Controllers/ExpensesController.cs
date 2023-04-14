using Expenda.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Expenda.Web.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ExpensesController : ControllerBase
{
    [HttpGet]
    public Task<IActionResult> GetExpenses(CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public Task<IActionResult> CreateExpense([FromBody] UpsertExpenseRequest request, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public Task<IActionResult> GetExpense([FromRoute] int id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id}")]
    public Task<IActionResult> UpdateExpense([FromRoute] int id, [FromBody] UpsertExpenseRequest request, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id}")]
    public Task<IActionResult> DeleteExpense([FromRoute] int id, CancellationToken token = default)
    {
        throw new NotImplementedException();
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
