using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expenda.Domain.Entities;

public class Expense : BaseEntity
{
    [Required]
    [MinLength(1)]
    [MaxLength(250)]
    public string Name { get; set; } = null!;
    
    [MaxLength(1000)]
    public string? Description { get; set; }
    
    [Required]
    public double Price { get; set; }
    
    [Required]
    public int Quantity { get; set; }

    [Required]
    public DateOnly TransactionDate { get; set; }
    
    [Required]
    [ForeignKey(nameof(ApplicationUser))]
    public ApplicationUser Owner { get; set; } = null!;
}