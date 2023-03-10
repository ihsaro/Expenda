using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;

namespace Expenda.Domain.Entities;

public class ApplicationUser : IdentityUser<int>
{
    [Required]
    [MinLength(10)]
    [MaxLength(250)]
    public required string FirstName { get; set; }

    [Required]
    [MinLength(10)]
    [MaxLength(250)]
    public required string LastName { get; set; }
}