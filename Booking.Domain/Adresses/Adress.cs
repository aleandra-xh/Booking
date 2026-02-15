using Booking.Domain.Properties;

namespace Booking.Domain.Addresses;

public class Address
{
    public Guid Id { get; set; }

    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }

    public List<Property> Properties { get; set; } = new();


}