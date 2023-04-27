using System.Text.Json.Serialization;

namespace Expenda.Application.Features.ExpenseManager.Models.Response;

public class ExpenseResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;
    
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    
    [JsonPropertyName("price")]
    public double Price { get; set; }
    
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("transaction_date")]
    public DateOnly TransactionDate { get; set; }
}