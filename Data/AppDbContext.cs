using Microsoft.EntityFrameworkCore;

namespace GDayMateBackend.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(): base() {}

        public AppDbContext(DbContextOptions opt): base(opt) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<PhoneCheckIn> PhoneCheckIns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Organisation>().ToTable("Organisations");
            modelBuilder.Entity<PhoneCheckIn>().ToTable("PhoneCheckIns");
        }
    }
}