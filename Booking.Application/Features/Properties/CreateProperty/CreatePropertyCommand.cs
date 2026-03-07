using MediatR;

namespace Booking.Application.Features.Properties.CreateProperty;

public sealed record CreatePropertyCommand(CreatePropertyRequest Request) : IRequest<Guid>;
