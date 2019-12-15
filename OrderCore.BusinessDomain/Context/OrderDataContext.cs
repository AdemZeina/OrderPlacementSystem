using Microsoft.EntityFrameworkCore;
using Order.Domain.Entities;

namespace Order.Domain.Context
{
    public class OrderDataContext : DbContext
    {
        public OrderDataContext()
        {
            
        }
        public OrderDataContext(DbContextOptions<OrderDataContext> options) : base(options)
        {
        }


        public DbSet<Users> Users { get; set; }

        public DbSet<Individual> IndividualCustomers { get; set; }


        public DbSet<Company> CompanyCustomers { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Entities.Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ServicePricing> ServicePricings { get; set; }

        //public DbSet<OrderServices> OrderServices { get; set; }

        const string Connection = @"Server=.;Database=OrderDb;Trusted_Connection=True;MultipleActiveResultSets=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Connection);
            
            base.OnConfiguring(optionsBuilder);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Order>()
            //    .HasOne(p => p.Customer)
            //    .WithMany(b => b.Orders);

            //modelBuilder.Entity<Order>()
            //    .HasOne(p => p.User)
            //    .WithMany(b => b.Orders);


            //modelBuilder.Entity<Order>()
            //    .HasOne(bc => bc.OrderItems);


            //modelBuilder.Entity<Service>()
            //    .HasMany(bc => bc.ServicePricing);

            //modelBuilder.Entity<Services>()
            //    .HasMany(or => or.OrderServices);


            base.OnModelCreating(modelBuilder);
        }
    }
}
