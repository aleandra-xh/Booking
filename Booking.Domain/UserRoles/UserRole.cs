using Booking.Domain.Roles;
using Booking.Domain.Users;
using System;

namespace Booking.Domain.UserRoles
{
    public class UserRole
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public DateTime AssignedAt { get; set; }

        // Navigation properties
        public User User { get; set; } = null!;
        public Role Role { get; set; } = null!;
    }
}