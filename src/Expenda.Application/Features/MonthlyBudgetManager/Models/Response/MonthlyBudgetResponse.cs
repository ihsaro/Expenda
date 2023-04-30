using System.Text.Json.Serialization;

namespace Expenda.Application.Features.MonthlyBudgetManager.Models.Response;

public record MonthlyBudgetResponse(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("month")] int Month,
    [property: JsonPropertyName("year")] int Year,
    [property: JsonPropertyName("budget")] int Budget
);