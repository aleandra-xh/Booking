
using Booking.Domain.Addresses;
using Booking.Domain.Reservations;
namespace Booking.Domain.Properties;
using Booking.Domain.Users;

public class Property
{

    public Guid Id { get; set; }

    public Guid OwnerId { get; set; }
    public User Owner { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public string PropertyType { get; set; }

    public Guid AddressId { get; set; }
    public Address Address { get; set; }

    public int MaxGuests { get; set; }

    public TimeSpan CheckInTime { get; set; }
    public TimeSpan CheckOutTime { get; set; }

    public bool IsActive { get; set; }
    public bool IsApproved { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }

    public DateTime? LastBookedOnUtc { get; set; }

    public List<Reservation> Reservations { get; set; } = new ();


}
