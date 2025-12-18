using ClubHouse.Backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClubHouse.Backend.Services
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<ProfileSnapshot> ProfileSnapshots { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ProfileSnapshot>()
                .HasOne(ps => ps.AppUser)
                .WithMany(u => u.ProfileSnapshots)
                .HasForeignKey(ps => ps.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
