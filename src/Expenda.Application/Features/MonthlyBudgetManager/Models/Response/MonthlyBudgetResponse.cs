using System.Text.Json.Serialization;

namespace Expenda.Application.Features.MonthlyBudgetManager.Models.Response;

public class MonthlyBudgetResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("month")]
    public int Month { get; set; }
    
    [JsonPropertyName("year")]
    public int Year { get; set; }
    
    [JsonPropertyName("budget")]
    public int Budget { get; set; }
}