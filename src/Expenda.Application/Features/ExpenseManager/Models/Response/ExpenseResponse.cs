using System.Text.Json.Serialization;

namespace Expenda.Application.Features.ExpenseManager.Models.Response;

public record ExpenseResponse(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("description")] string? Description,
    [property: JsonPropertyName("price")] double Price,
    [property: JsonPropertyName("quantity")] int Quantity,
    [property: JsonPropertyName("transaction_date")] DateTime TransactionDate
);