
namespace Booking.Application.Features.Properties.CreateProperty;

public sealed record CreatePropertyAddressDto(
    string Country,
    string City,
    string Street,
    string PostalCode
);
