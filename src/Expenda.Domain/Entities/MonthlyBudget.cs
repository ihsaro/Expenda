using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expenda.Domain.Entities;

public class MonthlyBudget : BaseEntity
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
    public required ApplicationUser Owner { get; set; }
}
