using Booking.Domain.Users;
using MediatR;

namespace Booking.Application.Features.Users.RegisterUser
{
    public record RegisterUserCommand(CreateUserDto UserDto) :  IRequest<Guid>;
    
}
