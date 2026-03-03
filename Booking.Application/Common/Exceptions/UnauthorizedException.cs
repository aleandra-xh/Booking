namespace Booking.Application.Common.Exceptions;


public sealed class UnauthorizedException : AppException
{
    public UnauthorizedException(string message= "Invalid Credentials!") : base(message) { }
}
