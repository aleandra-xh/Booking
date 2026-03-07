

namespace Booking.Application.Features.Properties.CreateProperty;

public sealed record CreatePropertyRequest
(
    string Name,
    string Description,
    int PropertyType,
    int MaxGuests,
    string CheckInTime,
    string CheckOutTime,
    CreatePropertyAddressDto Address,
    List<int> Amenities
);

