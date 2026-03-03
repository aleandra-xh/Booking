using Booking.Application.Abstractions.UserRegister;
using Booking.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Persistence;

public sealed class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly BookingDbContext _context;

    public UserRepository(BookingDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> IsEmailUnique(string email, CancellationToken ct)
        => !await _context.Users.AnyAsync(u => u.Email == email, ct);

    public Task<User?> GetByEmailWithRolesAsync(string email, CancellationToken ct)
        => _context.Users
            .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(u => u.Email == email, ct);
}