
using Booking.Domain.Properties;

namespace Booking.Domain.PropertyAmenities;

public class PropertyAmenity
{
    public Guid PropertyId { get; set; }
    public Property Property { get; set; } = null!;
    public Amenity Amenity { get; set; }
}
