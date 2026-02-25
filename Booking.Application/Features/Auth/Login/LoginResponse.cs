

namespace Booking.Application.Features.Auth.Login;

public sealed record LoginResponse(
    string Token,
    string Type,
    int Expiration
);