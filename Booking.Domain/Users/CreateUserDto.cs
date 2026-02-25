using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Domain.Users
{
    public record CreateUserDto
    {
        public string FirstName { get; init; } = null!;
        public string LastName { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string Password { get; init; } = null!;
        public string PhoneNumber { get; init; } = null!;
    }
}
