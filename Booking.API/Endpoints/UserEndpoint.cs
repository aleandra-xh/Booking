using Booking.Application.Features.Auth.Login;
using Booking.Application.Features.Users.RegisterUser;
using MediatR;

namespace Booking.Api;

public static class UserEndpoint
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        // ---Users---
        app.MapPost("/v1/users/register", async (RegisterUserCommand command, ISender sender) =>
        {
            var userId = await sender.Send(command);
            return Results.Created($"/v1/users/{userId}", null);
        })
        .WithName("RegisterUser");

        // ---Auth---
        app.MapPost("/v1/users/auth/login", async (LoginCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return Results.Ok(result);
        })
        .WithName("LoginUser");
    }
}