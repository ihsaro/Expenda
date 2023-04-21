using System.Text.Json.Serialization;

namespace Expenda.Application.Features.Expenses.Models.Response;

public class ExpenseResponse
{
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }
    
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    
    [JsonPropertyName("price")]
    public required double Price { get; set; }
    
    [JsonPropertyName("quantity")]
    public required int Quantity { get; set; }

    [JsonPropertyName("transaction_date")]
    public required DateOnly TransactionDate { get; set; }
}