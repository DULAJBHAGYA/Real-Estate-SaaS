using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;

namespace RealEstate.Persistence.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<PropertyView> PropertyViews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure Property entity
            builder.Entity<Property>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Price).HasPrecision(18, 2);
                entity.Property(e => e.SquareFootage).HasPrecision(10, 2);
                entity.Property(e => e.LotSize).HasPrecision(10, 2);
                
                entity.HasOne(e => e.Agent)
                    .WithMany(e => e.Properties)
                    .HasForeignKey(e => e.AgentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => new { e.City, e.State });
                entity.HasIndex(e => e.PropertyType);
                entity.HasIndex(e => e.Status);
                entity.HasIndex(e => e.Price);
            });

            // Configure PropertyImage entity
            builder.Entity<PropertyImage>(entity =>
            {
                entity.HasKey(e => e.Id);
                
                entity.HasOne(e => e.Property)
                    .WithMany(e => e.Images)
                    .HasForeignKey(e => e.PropertyId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure Appointment entity
            builder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.Id);
                
                entity.HasOne(e => e.Property)
                    .WithMany(e => e.Appointments)
                    .HasForeignKey(e => e.PropertyId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Client)
                    .WithMany(e => e.Appointments)
                    .HasForeignKey(e => e.ClientId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Agent)
                    .WithMany()
                    .HasForeignKey(e => e.AgentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => e.ScheduledDate);
                entity.HasIndex(e => e.Status);
            });

            // Configure PropertyView entity
            builder.Entity<PropertyView>(entity =>
            {
                entity.HasKey(e => e.Id);
                
                entity.HasOne(e => e.Property)
                    .WithMany(e => e.Views)
                    .HasForeignKey(e => e.PropertyId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.User)
                    .WithMany(e => e.PropertyViews)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasIndex(e => e.ViewedAt);
                entity.HasIndex(e => e.PropertyId);
            });

            // Configure ApplicationUser
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Bio).HasMaxLength(500);
                entity.Property(e => e.ProfileImageUrl).HasMaxLength(200);
            });
        }
    }
}
