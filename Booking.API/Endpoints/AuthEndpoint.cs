using Booking.Application.Features.Auth.Login;
using MediatR;

namespace Booking.Api;

public static class AuthEndpoint
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/v1/users/auth/login", async (LoginCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return Results.Ok(result);
        })
        .WithName("LoginUser");
    }
}