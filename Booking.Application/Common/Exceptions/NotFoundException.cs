

namespace Booking.Application.Common.Exceptions;

// Requested resource is not found
public sealed class NotFoundException : AppException
{
     public NotFoundException(string message) : base(message) {}
}
