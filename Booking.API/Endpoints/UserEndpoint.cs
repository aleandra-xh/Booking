using Booking.Application.Features.Users.RegisterUser;
using MediatR;

namespace Booking.Api;

public static class UserEndpoint
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/v1/users/register", async (RegisterUserCommand command, ISender sender) =>
        {
            var userId = await sender.Send(command);
            return Results.Created($"/v1/users/{userId}", null);
        })
        .WithName("RegisterUser");
    }
}