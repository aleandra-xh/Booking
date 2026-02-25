using Booking.Domain.UserRoles;

namespace Booking.Domain.Roles;

public class Role
{
    public Guid Id { get; set; }

    public RoleType Name { get; set; }
    public string Description { get; set; } = null!;

    public bool IsDefault { get; set; }

    public List<UserRole> UserRoles { get; set; } = new ();
}
