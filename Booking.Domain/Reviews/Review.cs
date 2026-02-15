using Booking.Domain.Reservations;
using Booking.Domain.Users;

namespace Booking.Domain.Reviews;

public class Review
{
    public Guid Id { get; set; }

    public Guid ReservationId { get; set; }
    public Reservation Reservation { get; set; } = null!;

    public Guid GuestId { get; set; }
    public User Guest { get; set; } = null!;

    public int Rating { get; set; }
    public string Comment { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}