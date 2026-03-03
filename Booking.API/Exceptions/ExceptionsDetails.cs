
namespace Booking.Api.Exceptions;

public sealed record ExceptionDetails(
    int Status,
    string Type,
    string Title,
    string Detail
);
