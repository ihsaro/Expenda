using System.ComponentModel.DataAnnotations;

namespace Expenda.Application.Models;

public class UpsertExpenseRequest : IValidatableObject
{
    [Required]
    [MinLength(1)]
    [MaxLength(250)]
    public required string Name { get; set; }

    [MaxLength(1000)]
    public string? Description { get; set; }

    [Required]
    public double Price { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    public DateOnly TransactionDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var result = new List<ValidationResult>();

        if (Quantity == 0)
            result.Add(new ValidationResult("Item quantity cannot be 0"));

        return result;
    }
}
