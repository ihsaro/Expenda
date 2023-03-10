using System.ComponentModel.DataAnnotations;

namespace Expenda.Application.Models;

public class VerifyUserCredentialRequest
{
    [Required]
    [MinLength(10)]
    [MaxLength(100)]
    public required string Username { get; set; }

    [Required]
    [MinLength(10)]
    [MaxLength(100)]
    public required string Password { get; set; }
}