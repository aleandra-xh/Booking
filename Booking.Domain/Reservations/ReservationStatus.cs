using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Domain.Reservations
{
    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        Rejected,
        Completed,
        Cancelled
    }
}
