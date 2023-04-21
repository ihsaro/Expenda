using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expenda.Domain.Entities;

public class Expense : BaseEntity
{
    [Required]
    [MinLength(1)]
    [MaxLength(250)]
    public required string Name { get; set; }
    
    [MaxLength(1000)]
    public string? Description { get; set; }
    
    [Required]
    public required double Price { get; set; }
    
    [Required]
    public required int Quantity { get; set; }

    [Required]
    public required DateOnly TransactionDate { get; set; }
    
    [Required]
    [ForeignKey(nameof(ApplicationUser))]
    public required ApplicationUser Owner { get; set; }
}