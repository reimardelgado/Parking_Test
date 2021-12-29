using Microsoft.EntityFrameworkCore;
using ParkingLots.Domain.Entities;
using ParkingLots.Infrastructure.EntityConfigurations;
using ParkingLots.Infrastructure.SeederConfigurations;

namespace ParkingLots.Infrastructure
{
    public class AppDbContext : DbContext
    {
        #region Contructor && Properties

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Parking> ParkingLots { get; set; }

        // Permissions
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<ProfilePermission> ProfilePermissions { get; set; }
        public DbSet<UserGlobalPermission> UserGlobalPermissions { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Permissions
            modelBuilder.ApplyConfiguration(new PermissionEfConfig());
            modelBuilder.ApplyConfiguration(new ProfileEfConfig());
            modelBuilder.ApplyConfiguration(new ProfilePermissionEfConfig());
            modelBuilder.ApplyConfiguration(new UserGlobalPermissionEfConfig());
            modelBuilder.ApplyConfiguration(new ApplicationUserEfConfig());

            // Seeders
            modelBuilder.ApplyConfiguration(new ProfileSeederEfConfig());
            modelBuilder.ApplyConfiguration(new PermissionSeederEfConfig());
            modelBuilder.ApplyConfiguration(new ProfilePermissionsSeederEfConfig());
            modelBuilder.ApplyConfiguration(new UserSeederEfConfig());
        }
    }
}