using System.Text.Json.Serialization;

namespace Expenda.Application.Features.Expenses.Models.Response;

public class MonthlyBudgetResponse
{
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    [JsonPropertyName("month")]
    public required int Month { get; set; }
    
    [JsonPropertyName("year")]
    public required int Year { get; set; }
    
    [JsonPropertyName("budget")]
    public required int Budget { get; set; }
}