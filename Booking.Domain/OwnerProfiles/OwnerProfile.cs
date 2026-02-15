using Booking.Domain.Users;
using System.ComponentModel.DataAnnotations; 

namespace Booking.Domain.OwnerProfiles;

public class OwnerProfile
{
    [Key] 
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public string IdentityCardNumber { get; set; } = null!;
    public VerificationStatus VerificationStatus { get; set; }

    public string? BusinessName { get; set; }
    public string CreditCard { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
}