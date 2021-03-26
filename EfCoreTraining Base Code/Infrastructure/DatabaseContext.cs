using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeRequirements> EmployeeRequirements { get; set; }
        public DbSet<JobApplication> JobApplication { get; set; }
        public DbSet<OrderTable> OrderTable { get; set; }
        public DbSet<RestaurantBranch> RestaurantBranch { get; set; }
        public DbSet<Waiter> Waiter { get; set; }
        public DbSet<Manager> Manager { get; set; }

    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderTable>()
                .HasOne<RestaurantBranch>(s => s.RestaurantBranch)
                .WithMany(g => g.OrderTables)
                .HasForeignKey(s => s.RestaurantBranchId);

            modelBuilder.Entity<WaiterOrderTable>().HasKey(sc => new { sc.WaiterId, sc.OrderTableId });

            modelBuilder.Entity<WaiterOrderTable>()
                .HasOne<Waiter>(sc => sc.Waiter)
                .WithMany(s => s.WaiterOrderTables)
                .HasForeignKey(sc => sc.WaiterId);


            modelBuilder.Entity<WaiterOrderTable>()
                .HasOne<OrderTable>(sc => sc.OrderTable)
                .WithMany(s => s.WaiterOrderTables)
                .HasForeignKey(sc => sc.OrderTableId);

            modelBuilder.Entity<RestaurantBranch>()
                .HasOne<Manager>(s => s.Manager)
                .WithOne(ad => ad.RestaurantBranch)
                .HasForeignKey<Manager>(ad => ad.ManagerId);
        }
    }
}
