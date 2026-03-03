
// Business conflict 
namespace Booking.Application.Common.Exceptions;

public sealed class ConflictException : AppException
{
    public ConflictException(string message) : base(message) { }
}
