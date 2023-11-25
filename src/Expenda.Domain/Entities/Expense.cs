using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Expenda.Domain.Entities.Base;

namespace Expenda.Domain.Entities;

public class Expense : AuditableBaseEntity
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
    public DateTime TransactionDate { get; set; }
    
    [Required]
    [ForeignKey(nameof(ApplicationUser))]
    public int OwnerId { get; set; }
}