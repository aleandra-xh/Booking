using Booking.Domain.Users;
using Booking.Domain.Roles;
using Booking.Domain.UserRoles;
using Booking.Domain.OwnerProfiles;
using Booking.Domain.Properties;
using Booking.Domain.Addresses;
using Booking.Domain.Reservations;
using Booking.Domain.Reviews;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<UserRole> UserRoles { get; set; } = null!;
        public DbSet<OwnerProfile> OwnerProfiles { get; set; } = null!;
        public DbSet<Property> Properties { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Reservation> Reservations { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // USER ROLE 
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            // OWNER PROFILE 
            modelBuilder.Entity<OwnerProfile>()
                .HasKey(op => op.UserId);

            modelBuilder.Entity<OwnerProfile>()
                .HasOne(op => op.User)
                .WithOne(u => u.OwnerProfile)
                .HasForeignKey<OwnerProfile>(op => op.UserId);

            // PROPERTY → OWNER 
            modelBuilder.Entity<Property>()
                .HasOne(p => p.Owner)
                .WithMany(u => u.Properties)
                .HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.NoAction);

            // PROPERTY → ADDRESS 
            modelBuilder.Entity<Property>()
           .HasOne(p => p.Address)
           .WithMany(a => a.Properties)
           .HasForeignKey(p => p.AddressId)
           .OnDelete(DeleteBehavior.Restrict);


            // RESERVATION → GUEST 
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Guest)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.GuestId)
                .OnDelete(DeleteBehavior.NoAction);

            // RESERVATION → PROPERTY
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Property)
                .WithMany(p => p.Reservations)
                .HasForeignKey(r => r.PropertyId)
                .OnDelete(DeleteBehavior.NoAction);

            // REVIEW → BOOKING 
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Reservation)
                .WithOne(b => b.Review)
                .HasForeignKey<Review>(r => r.ReservationId)
                .OnDelete(DeleteBehavior.Restrict);

            // REVIEW → GUEST
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Guest)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.GuestId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}

