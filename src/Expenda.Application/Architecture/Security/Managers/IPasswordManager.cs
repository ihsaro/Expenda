namespace Expenda.Application.Architecture.Security.Managers;

public interface IPasswordManager
{
    string HashPassword(string password, byte[]? salt = null);
    bool VerifyHashedPassword(string password, string hashedPassword);
}
