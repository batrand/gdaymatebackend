using Microsoft.EntityFrameworkCore;
using GDayMateBackend.Data;

namespace GDayMateBackend.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(): base() {}

        public AppDbContext(DbContextOptions opt): base(opt) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<PhoneCheckIn> PhoneCheckIns { get; set; }
        public DbSet<GDayMateBackend.Data.CheckIn> CheckIns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Organisation>().ToTable("Organisations");
            modelBuilder.Entity<PhoneCheckIn>().ToTable("PhoneCheckIns");
            modelBuilder.Entity<CheckIn>().ToTable("CheckIns");
        }
    }
}