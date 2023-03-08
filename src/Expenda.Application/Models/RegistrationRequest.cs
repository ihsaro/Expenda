using System.ComponentModel.DataAnnotations;

namespace Expenda.Application.Models;

public class RegistrationRequest
{
    [Required]
    [MinLength(10)]
    [MaxLength(250)]
    public required string FirstName { get; set; }

    [Required]
    [MinLength(10)]
    [MaxLength(250)]
    public required string LastName { get; set; }

    [Required]
    [EmailAddress]
    public required string EmailAddress { get; set; }

    [Required]
    [MinLength(10)]
    [MaxLength(100)]
    public required string Username { get; set; }

    [Required]
    [MinLength(10)]
    [MaxLength(100)]
    public required string Password { get; set; }
}