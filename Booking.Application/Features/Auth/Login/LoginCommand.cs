using MediatR;

namespace Booking.Application.Features.Auth.Login;
    public sealed record LoginCommand(LoginRequest Request) 
        : IRequest<LoginResponse>;
