using System.ComponentModel.DataAnnotations;

namespace Expenda.Application.Models;

public class VerifyUserCredentialRequest
{
    [Required]
    public required string Username { get; set; }

    [Required]
    public required string Password { get; set; }
}