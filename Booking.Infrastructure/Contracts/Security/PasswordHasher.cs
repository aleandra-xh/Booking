using Booking.Application.Abstractions.Security;

namespace Booking.Infrastructure.Contracts.Security;

public sealed class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
        => BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);

    public bool Verify(string password, string passwordHash)
        => BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
}