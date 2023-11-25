using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Expenda.Domain.Entities.Base;

namespace Expenda.Domain.Entities;

public class MonthlyBudget : AuditableBaseEntity
{
    [Required]
    [Range(1, 12)]
    public int Month { get; set; }

    [Required]
    [Range(1970, 2050)]
    public int Year { get; set; }
    
    [Required]
    public double Budget { get; set; }

    [Required]
    [ForeignKey(nameof(ApplicationUser))]
    public int OwnerId { get; set; }
}
