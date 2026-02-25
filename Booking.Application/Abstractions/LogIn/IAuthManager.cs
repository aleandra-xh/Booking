using Booking.Application.Features.Auth.Login;

namespace Booking.Application.Abstractions.LogIn;

    public interface IAuthManager
    {
        Task<LoginResponse> LoginAsync(string email, string password, CancellationToken ct);
    }

