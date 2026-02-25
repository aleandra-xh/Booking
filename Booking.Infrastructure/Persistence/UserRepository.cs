using Booking.Application.Abstractions.UserRegister;
using Booking.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Persistence;

public sealed class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(BookingDbContext dbContext) : base(dbContext) { }

    public async Task<bool> IsEmailUnique(string email, CancellationToken ct = default)
    {
        var normalized = email.Trim().ToLowerInvariant();
        var exists = await _dbContext.Users.AnyAsync(u => u.Email == normalized, ct);
        return !exists;
    }
}