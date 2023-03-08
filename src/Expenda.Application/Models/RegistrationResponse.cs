namespace Expenda.Application.Models;

public class RegistrationResponse
{
    public int Id { get; set; }
    
    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string EmailAddress { get; set; }

    public required string Username { get; set; }
}