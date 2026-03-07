using Booking.Application.Features.Properties.CreateProperty;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace Booking.Api;

public static class PropertyEndpoint
{
    public static void MapPropertyEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/v1/create/properties", [Authorize(Roles = "Owner")] async (CreatePropertyCommand command, ISender sender) =>
        {
            var propertyId = await sender.Send(command);
            return Results.Created($"/v1/create/properties/{propertyId}", null);
        })
        .WithName("CreateProperty");
    }
}   