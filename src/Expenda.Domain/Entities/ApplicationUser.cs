using Expenda.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Expenda.Domain.Entities;

public class ApplicationUser : AuditableBaseEntity
{
    [Required]
    [MinLength(10)]
    [MaxLength(250)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MinLength(10)]
    [MaxLength(250)]
    public string LastName { get; set; } = null!;

    [Required]
    [MinLength(10)]
    [MaxLength(250)]
    public string EmailAddress { get; set; } = null!;

    [Required]
    [MinLength(10)]
    [MaxLength(250)]
    public string Username { get; set; } = null!;
}