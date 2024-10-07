using LG_Assignment.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace LG_Assignment.Infrastructure.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceCategory> DeviceCategories { get; set; }
        public DbSet<PropertyItem> PropertyItems { get; set; }
        public DbSet<DevicePropertyValue> DevicePropertyValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Device-PropertyValue relationship
            modelBuilder.Entity<Device>()
                .HasMany(d => d.PropertyValues)
                .WithOne(pv => pv.Device) // Each DevicePropertyValue belongs to one Device
                .HasForeignKey(pv => pv.DeviceId); // Foreign key in DevicePropertyValue

            // Configure DeviceCategory-PropertyItem relationship
            modelBuilder.Entity<DeviceCategory>()
                .HasMany(dc => dc.PropertyItems) // A DeviceCategory has many PropertyItems
                .WithOne(); // PropertyItem does not need a navigation property to DeviceCategory

            // Configure the relationship between Device and DeviceCategory
            modelBuilder.Entity<Device>()
                .HasOne(d => d.DeviceCategory) // A Device belongs to one DeviceCategory
                .WithMany(dc => dc.Devices) // A DeviceCategory has many Devices
                .HasForeignKey(d => d.DeviceCategoryId); // Foreign key in Device

            base.OnModelCreating(modelBuilder);
        }
    }
}
