using Booking.Application.Generics.Interfaces;
using Booking.Domain.Users;

namespace Booking.Application.Abstractions.UserRegister;

public interface IUserRepository : IGenericRepository<User>
{
    Task<bool> IsEmailUnique(string email, CancellationToken ct = default);
}