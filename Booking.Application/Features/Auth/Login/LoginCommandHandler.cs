using MediatR;
using Booking.Application.Abstractions.LogIn;

namespace Booking.Application.Features.Auth.Login;

public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IAuthManager _authManager;

    public LoginCommandHandler(IAuthManager authManager)
    {
        _authManager = authManager;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken ct)
    {
        return await _authManager.LoginAsync(request.Request.Email, request.Request.Password, ct);
    }

}