using Expenda.Application.Architecture.Security.Managers;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Expenda.Infrastructure.Security;

internal class PasswordManager : IPasswordManager
{
    public string HashPassword(string password, byte[]? salt = null)
    {
        if (salt is not { Length: 16 })
        {
            // generate a 128-bit salt using a secure PRNG
            salt = new byte[128 / 8];

            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);
        }

        var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        return $"{hashed}:{Convert.ToBase64String(salt)}";
    }

    public bool VerifyHashedPassword(string password, string hashedPassword)
    {
        // retrieve both salt and password
        var passwordAndHash = hashedPassword.Split(':');

        if (passwordAndHash.Length != 2)
            return false;

        var salt = Convert.FromBase64String(passwordAndHash[1]);

        // compare both hashes
        return hashedPassword.Equals(HashPassword(password, salt));
    }
}
