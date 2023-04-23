using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;

namespace Expenda.Domain.Entities;

public class ApplicationUser : IdentityUser<int>
{
    [Required]
    [MinLength(10)]
    [MaxLength(250)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MinLength(10)]
    [MaxLength(250)]
    public string LastName { get; set; } = null!;
}